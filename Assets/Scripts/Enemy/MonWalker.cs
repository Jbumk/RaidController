using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonWalker : MonoBehaviour
{
    [Header("Set")]
    public GameObject MonPrefab;
    public GameObject DietectArea;
    private Rigidbody rigid;
    private Vector3 ArrivalPoint;
    
    public bool isFind=false;
    private Vector3 HitDirec;
    private Vector3 PlayerPoint;

    private GameObject CollideTarget;
    
    [Header("Spec")]
    private double Health;
    private float MoveSpeed;

    
    private void Awake() {
        rigid = MonPrefab.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {  
        if(Health>0){
            if(isFind){
                MonPrefab.transform.LookAt(PlayerPoint);
            }                
            MonPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
        }      

          if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화
            WalkerPool.instance.ReturnMon(this);
            Health=0;
            MoveSpeed=0;
            ArrivalPoint = Vector3.zero;            
        } 
       
    }

    public void SetSpec(double HP, float Speed){
        Health = HP;
        MoveSpeed = Speed;
    }
    public void SetArrival(Vector3 Point){
        ArrivalPoint = Point;
        MonPrefab.transform.LookAt(Point);
    }

    public void DetectEnemy(Vector3 point){
        //거리 안에 적이 발견됐을때
        //해당 적의 위치를 받아와           
        //해당 적을 바라본채로 사거리 까지 다가가고
        isFind=true; 
        PlayerPoint = point;       
               
        // 그후 정지하고 공격한다
    }

    public void LookForward(){        
        MonPrefab.transform.LookAt(ArrivalPoint);
        isFind=false;
        //isFight=false;
    }

    public bool FindChk(){
        return isFind;
    }


    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Arrival")){
            WalkerPool.instance.ReturnMon(this);
        }          
    }

    /*
    private void OnTriggerStay(Collider col) {
        if(!col.gameObject.CompareTag("Ally") && Vector3.Distance(this.transform.position,PlayerPoint)<=0.1
            ||!col.gameObject.CompareTag("Ally") && isFight){
            LookForward();            
        }
        
    }*/

    private void OnCollisionEnter(Collision col) {
         if(col.gameObject.CompareTag("Ally")){
            Debug.Log("적과 충돌");
            CollideTarget=col.gameObject;
            HitDamage(5,false);          
        }

        if(col.gameObject.CompareTag("Door")){  
            CollideTarget =col.gameObject;         
            HitDamage(0,false);            
        }         
    }
    
    
    
   
    
    private void OnCollisionStay(Collision col) {
        if(!col.gameObject.CompareTag("Ally") && Vector3.Distance(this.transform.position,PlayerPoint)<=0.1){
            LookForward();            
        }
    }
    

    public void HitDamage(double dmg,bool isBullet){
        Health -= dmg;
        if(!isBullet){
            rigid.AddForce((this.transform.position-CollideTarget.transform.position).normalized*6f,ForceMode.Impulse);                     
        }
        //약간 빨개지는 이펙트 추가
        
        Debug.Log("맞았음");
    }
    

    

    

}
