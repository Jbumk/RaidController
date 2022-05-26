using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject Target;
    private MonWalker TargetHit;
    private Rigidbody rigid;
    private Vector3 Direction;
    private double Damage;
    


    private void Awake(){
        rigid = this.GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direc, GameObject obj,double DMG){
        Direction = direc;
        Target = obj;
        Damage= DMG;
        TargetHit = Target.GetComponent<MonWalker>();        
    }

    //스폰시 직진
    private void Update(){
        transform.Translate(Direction*Time.deltaTime*3f);
    }

    //이후 타겟에 적중하면 리턴
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject==Target){
            TargetHit.HitDamage(Damage,true);         
            TowerAttackPool.instance.ReturnObj(this);
        }
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject==Target){        
            //TowerAttackPool.instance.ReturnObj(this);
        }
        
    }

    //버튼 업그레이트
    public void UpGradeDMG(){
        Damage+=1.0;
    }
}
