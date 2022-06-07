using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [Header("Set")]
    public GameObject ArcherPrefab;
    public GameObject DietectArea;
    private Rigidbody rigid;
 
    private GameObject ArrivalPoint;
    private Vector3 Direc;
    private Vector3 PlayerPoint;

    //목표
    private GameObject Target; 
    
    //공격 딜레이
    private float AttackTimer=0;
    private double AttackCoolTime=2.0;
    
    private GameManager GameManager;    

    [Header("Spec")]
    public double MaxHealth=100;
    public double Health=100;
    private float MoveSpeed=1f;

    //버프
    private bool HealBuff=false;
    private double HealBuffTime=30.0;
    private float HealBuffCount=0;    
    
    private void Awake() {
        rigid = this.GetComponent<Rigidbody>();       
    }

    private void Update() {
        if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화
            ArcherPool.instance.ReturnArcher(this);
            MaxHealth=0;
            Health=0;
            MoveSpeed=0;
            ArrivalPoint = null;            
        }    
    }
    
    void FixedUpdate()
    {    
        if(Health>0){
            if(Target!=null){
                AttackTimer+=Time.deltaTime;
                ArcherPrefab.transform.LookAt(Target.transform.position);
                                
                //멈춰서서 공격
                if(AttackTimer>=AttackCoolTime){
                    var Attack = ArcherAttackPool.instance.GetArrow();
                    Attack.transform.position=transform.position;
                    Attack.SetArrival(Target,GameManager.ChkArrowDMG());
                    AttackTimer=0;   
                } 
                 if(Vector3.Distance(this.transform.position,Target.transform.position)>=16){
                    Target=null;
                }            
                
            }
            else{
                ArcherPrefab.transform.LookAt(ArrivalPoint.transform.position);              
                ArcherPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
            }

           
            //테스트 해봐야함
            if(HealBuff){
                HealBuffCount+=Time.deltaTime;
                if(HealBuffCount%1==0){
                    Health += MaxHealth*0.02;
                }
            }
        }  
    }

    //설정 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public void SetSpec(double HP, float Speed){
        MaxHealth = HP;
        Health = HP;
        MoveSpeed = Speed;
    }
    public void SetArrival(){        
        ArrivalPoint = GameManager.ChkArrival();
        ArcherPrefab.transform.LookAt(ArrivalPoint.transform.position);
    }

    /*
    public void DetectEnemy(Vector3 point){       
        PlayerPoint = point;             
       
    }
    */

    public void LookForward(){        
        ArcherPrefab.transform.LookAt(ArrivalPoint.transform.position);
       
    }   
 

    public void SetManager(GameObject obj){
        GameManager= obj.GetComponent<GameManager>();
        
    }


    //충돌 관련ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Enemy")){
            Target = col.gameObject;          
         
            PlayerPoint=Target.transform.position;            
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject==Target){
         
            Target=null;
            PlayerPoint=Vector3.zero;
        }
    }
  
    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Enemy")){
           HitDamage(5,col.gameObject);
        }  
    }

    private void OnCollisionStay(Collision col) {
        if(!col.gameObject.CompareTag("Enemy") && Vector3.Distance(this.transform.position,PlayerPoint)<=0.1){
            LookForward();            
        }
    }


    public void HitDamage(double dmg,GameObject obj){
        Health -= dmg;
        rigid.AddForce((this.transform.position-obj.transform.position).normalized *3f,ForceMode.Impulse);       
            
    }

    //버프 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public void BuffHeal(){
        HealBuffCount=0;
        HealBuff=true;        
    }

}
