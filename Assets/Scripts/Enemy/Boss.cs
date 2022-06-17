using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameObject Target;
    private GameObject ArrivalPoint=null;

    private float AttackTimer=0;
    private double AttackSec=5.0;


    //스펙
    private double Health = 2000;
    private float MoveSpeed = 1f;
    private int Defense = 10;

    private void FixedUpdate() {
        if(Health>0){
            if(ArrivalPoint!=null){
                //수비지역의 보스
                if(Target!=null){ 
                    //목표물 존재시 멈춰서 공격
                    this.transform.LookAt(Target.transform.position);
                    AttackTimer+=Time.deltaTime;
                    
                    if(AttackTimer>=AttackSec){
                        //공격수행
                        var obj = BossAttackPool.instance.getBossAttack();
                        obj.transform.position = this.transform.position;
                        obj.SetArrival(Target);
                        AttackTimer=0;
                    }
                    //멀어지면 타겟 재설정
                    if(Vector3.Distance(this.transform.position,Target.transform.position)>=16){
                        Target=null;
                    }
                }else{
                    this.transform.LookAt(ArrivalPoint.transform.position);
                    this.transform.Translate(Vector3.forward*MoveSpeed*Time.deltaTime);

                }
            }else{
                //공격지역의 보스
                if(Target!=null){ 
                    //목표물 존재시 멈춰서 공격
                    this.transform.LookAt(Target.transform.position);
                    AttackTimer+=Time.deltaTime;
                    
                    if(AttackTimer>=AttackSec){
                        //공격수행
                        var obj = BossAttackPool.instance.getBossAttack();
                        obj.transform.position = this.transform.position;
                        obj.SetArrival(Target);
                        AttackTimer=0;
                    }
                    //멀어지면 타겟 재설정
                    if(Vector3.Distance(this.transform.position,Target.transform.position)>=16){
                        Target=null;
                    }
                }

            }
           

        }else{
            ArrivalPoint=null;
            BossPool.instance.ReturnBoss(this);
        }
    }


    //설정

    public void SetSpec(double Health, float MoveSpeed, int Defende){
        this.Health= Health;
        this.MoveSpeed = MoveSpeed;
        this.Defense = Defense;
    }

    public void SetArrival(GameObject Arrival){
        ArrivalPoint = Arrival;
    }

    //충돌
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Ally")&&Target==null){
            Target=col.gameObject;
        }
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Ally")){
            HitDamage(GameManager.instance.ChkTankCrashDMG());
        }
    }

    public void HitDamage(double Damage){
        Health-=Damage;
    }
}
