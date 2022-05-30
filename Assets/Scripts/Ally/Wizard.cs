using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [Header("Set")]
    public GameObject WizardPrefab;
    public GameObject DietectArea;
    private Rigidbody rigid;
 
    private Vector3 ArrivalPoint;
    public bool isFind=false;
    private Vector3 Direc;
    private Vector3 PlayerPoint;

    private GameObject Target; 

    private float AttackTimer=0;
    private double AttackCoolTime=2.0;   
    
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
            WizardPool.instance.ReturnWizard(this);
            MaxHealth=0;
            Health=0;
            MoveSpeed=0;
            ArrivalPoint = Vector3.zero;            
        }    
    }
    
    void FixedUpdate()
    {    
        if(Health>0){
            if(isFind){
                AttackTimer+=Time.deltaTime;
                WizardPrefab.transform.LookAt(Target.transform.position);
                                
                //멈춰서서 공격
                if(AttackTimer>=AttackCoolTime){
                    var Attack = WizardMagicPool.instance.GetMagic();
                    Attack.transform.position=transform.position;
                    Attack.SetArrival(Target.transform.position,Target,2.0);
                    AttackTimer=0;   
                }             
                
            }
            else{                
                WizardPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
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

    public void SetSpec(double HP, float Speed){
        MaxHealth = HP;
        Health = HP;
        MoveSpeed = Speed;
    }
    public void SetArrival(Vector3 Point){
        ArrivalPoint = Point;
        WizardPrefab.transform.LookAt(Point);
    }

    public void DetectEnemy(Vector3 point){
        //거리 안에 적이 발견됐을때
        //해당 적의 위치를 받아와     
        //해당 적을 바라본채로 사거리 까지 다가가고
        isFind=true; 
        PlayerPoint = point;             
       
    }

    public void LookForward(){        
        WizardPrefab.transform.LookAt(ArrivalPoint);
        isFind=false;        
    }
   
    public bool FindChk(){
        return isFind;
    }


    //충돌 관련ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Enemy")){
            Target = col.gameObject;
            //DetectEnemy(col.transform.position);
            isFind=true;
            PlayerPoint=Target.transform.position;            
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject==Target){
            isFind=false;
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
