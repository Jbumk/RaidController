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
 
    private Vector3 HitDirec;
    private Vector3 PlayerPoint;

    private GameObject CollideTarget;

    private GameObject Target;

    private float SlowTimer=0;
    private double SlowEndTime=1.5;
    private bool isSlow=false;  

    private float HitTimer=0.5f;
   
    
    [Header("Spec")]
    private double Health;
    private float MoveSpeed;   

    
    private void Awake() {
        rigid = MonPrefab.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {  
        if(Health>0){
            // 적 감지했을 때
            if(Target!=null){
                MonPrefab.transform.LookAt(Target.transform.position);

                 if(Vector3.Distance(this.transform.position,Target.transform.position)>=16){
                Target=null;
            }
            }                
           
           

            // 맞아서 슬로우 상태일때
            if(isSlow){             
                MonPrefab.transform.Translate(Vector3.forward* MoveSpeed*0.3f * Time.deltaTime);
                SlowTimer+=Time.deltaTime;
                if(SlowTimer>=SlowEndTime){
                    isSlow=false;                          
                }
            }
            else{
             MonPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
            }
        }      

          if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화
            WalkerPool.instance.ReturnMon(this);
            Health=0;
            MoveSpeed=0;
            ArrivalPoint = Vector3.zero;            
        } 
       
    }
    
    //설정 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public void SetSpec(double HP, float Speed){
        Health = HP;
        MoveSpeed = Speed;
    }
    public void SetArrival(Vector3 Point){
        ArrivalPoint = Point;
        MonPrefab.transform.LookAt(Point);
    }

    public void LookForward(){        
        MonPrefab.transform.LookAt(ArrivalPoint);  
    }


    //충돌 관련 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ


    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Arrival")){
            WalkerPool.instance.ReturnMon(this);
        }

        if(col.gameObject.CompareTag("Ally")){
            Target = col.gameObject;
        }      
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject==Target){
            Target=null;
        }
    }

    private void OnTriggerStay(Collider col) {
        if(col.gameObject.CompareTag("Magic")){
            HitTimer+=Time.deltaTime;
            if(HitTimer>= GameManager.instance.ChkIgnoreTime()){
                HitDamage(GameManager.instance.ChkMagicDMG(),true);
                Debug.Log("데미지s 들어감");                 
                HitTimer=0;
            }
        }
    }  

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
   
    
    

    public void HitDamage(double dmg,bool isBullet){
        Health -= dmg;
        SlowTimer=0;
        isSlow=true;          
        if(!isBullet){
            rigid.AddForce((this.transform.position-CollideTarget.transform.position).normalized*4f,ForceMode.Impulse);                     
        }
        //약간 빨개지는 이펙트 추가      
       
    }
    

    

    

}
