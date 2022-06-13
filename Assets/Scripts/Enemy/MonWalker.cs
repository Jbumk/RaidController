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
    private double SlowEndTime=0.8;
    private bool isSlow=false;  

    private float HitTimer=0.5f;
   
    
    //스펙
    private double Health;
    private float MoveSpeed;

    //이미지
    public GameObject Sprite;
    private Renderer MonColor;
    private Material[] mats;
    private Material M1_G,M1_B,M1_R,M1_BK,M1_GBoss,M1_BBoss,M1_RBoss,M1_BKBoss;
    private double HitColorTerm =0.8;
    private float HitColorTimer = 0;
    private bool isHit=false;

       

    
    private void Awake() {
        rigid = MonPrefab.GetComponent<Rigidbody>();
        MonColor = Sprite.GetComponent<Renderer>();
        mats = MonColor.sharedMaterials;
        M1_G=mats[0];
        M1_B=mats[1];
        M1_R=mats[2];
        M1_BK=mats[3];
        /*
        M1_GBoss=mats[4];
        M1_BBoss=mats[5];
        M1_RBoss=mats[6];
        M1_BKBoss=mats[7];
        */
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

            if(isHit){
                HitColorTimer+=Time.deltaTime;
                if(HitColorTimer>=HitColorTerm){
                    isHit=false;
                    mats[mats.Length-1].color = Color.white;
                    Debug.Log("색 원상복구");
                }
            }
        }      

          if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화            
            Health=0;
            MoveSpeed=0;
            isHit=false;
            HitColorTimer=0;
            mats[mats.Length-1].color = Color.white;
            ArrivalPoint = Vector3.zero;
            WalkerPool.instance.ReturnMon(this);            
        } 
       
    }
    
    //설정 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public void SetSpec(double HP, float Speed,int type){
        Health = HP;
        MoveSpeed = Speed;
        
        switch (type)
        {
            case 0:
                mats[mats.Length-1]=M1_G;
                
                MonColor.sharedMaterials =mats;
                break;
            case 1:
                mats[mats.Length-1]=M1_B;
                MonColor.sharedMaterials =mats;
                break;
            case 2:
                mats[mats.Length-1]=M1_R;
                MonColor.sharedMaterials =mats;
                break;
            case 3:
                mats[mats.Length-1]=M1_BK;
                MonColor.sharedMaterials =mats;
                break;            
            default:
                mats[mats.Length-1]=M1_G;
                MonColor.sharedMaterials =mats;
                break;
        }
        
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
        
        Debug.Log("색변경 시도1");
        mats[3].color = Color.red;
        isHit=true;
        HitColorTimer=0;
        Debug.Log("색변경 시도2");   
            
       
    }

    private void OnApplicationQuit() {
        for(int i=0;i<mats.Length;i++){
            mats[i].color= Color.white;
        }
    }
    

    

    

}
