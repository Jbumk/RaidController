using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
     [Header("Set")]
    public GameObject AttackerPrefab;
    public GameObject DietectArea;
    private Vector3 ArrivalPoint;
    public bool isFight=false;
    public bool isFind=false;
    private Vector3 Direc;
    private Vector3 PlayerPoint;

    private float HitTimer=0;
    private double HitDelay =0.5;
    
    [Header("Spec")]
    public double Health=100;
    private float MoveSpeed;

    private void Update() {
        if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화
            AttackerPool.instance.ReturnAttacker(this);
            Health=0;
            MoveSpeed=0;
            ArrivalPoint = Vector3.zero;            
        }    
    }
    
    void FixedUpdate()
    {                
        if(isFight){
            //전투
            
        }else{
            if(Health>0){
                if(isFind){
                    AttackerPrefab.transform.LookAt(PlayerPoint);
                }                
                AttackerPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
            }
            
        }
       

       
    }

    public void SetSpec(double HP, float Speed){
        Health = HP;
        MoveSpeed = Speed;
    }
    public void SetArrival(Vector3 Point){
        ArrivalPoint = Point;
        AttackerPrefab.transform.LookAt(Point);
    }

    public void DetectEnemy(Vector3 point){
        //거리 안에 적이 발견됐을때
        //해당 적의 위치를 받아와
        //Direc =(MonPrefab.transform.position-point).normalized;        
        //해당 적을 바라본채로 사거리 까지 다가가고
        isFind=true; 
        PlayerPoint = point;       
               
        // 그후 정지하고 공격한다
    }

    public void LookForward(){        
        AttackerPrefab.transform.LookAt(ArrivalPoint);
        isFind=false;
        isFight=false;
    }

    public bool FindChk(){
        return isFind;
    }




    /*
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Enemy")){                       
            isFight=true;       
        }          
    }


    private void OnTriggerStay(Collider col) {
        if(col.gameObject.CompareTag("Enemy")){            
          
        }
        else{
            if(Vector3.Distance(this.transform.position,PlayerPoint)<=0.1|| isFight){
                LookForward();            
            }            
        }       
    }
    */
    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Enemy")){                       
            isFight=true;
            Debug.Log("첫 피해");
           HitDamage(5);
        }  
    }

    private void OnCollisionStay(Collision col) {
        if(col.gameObject.CompareTag("Enemy")){            
            HitTimer+=Time.deltaTime;
            Debug.Log("충돌중");
            if(HitTimer>=HitDelay){
                Debug.Log("추가 피해");
                HitDamage(5);
                HitTimer=0;
            }
        }
    }

    public void HitDamage(double dmg){
        Health -= dmg;
            
    }

}
