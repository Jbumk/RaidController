using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
     [Header("Set")]
    public GameObject AttackerPrefab;
    public GameObject DietectArea;
    private Rigidbody rigid;
 
    private GameObject ArrivalPoint;
    private Vector3 Direc;
    private Vector3 EnemyPoint;

    private GameObject Target;

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
            AttackerPool.instance.ReturnAttacker(this);
            MaxHealth=0;
            Health=0;          
            ArrivalPoint = null;            
        }    
    }
    
    void FixedUpdate()
    {    
        if(Health>0){
            if(Target!=null){
                AttackerPrefab.transform.LookAt(Target.transform.position);                 

                if(Vector3.Distance(this.transform.position,Target.transform.position)>=16){
                    Target=null;                
                }            
            }
            else{
                AttackerPrefab.transform.LookAt(ArrivalPoint.transform.position);
            }    

            AttackerPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);           
           

            //테스트 해봐야함
            if(HealBuff){
                HealBuffCount+=Time.deltaTime;
                if(HealBuffCount%1==0){
                    Health += MaxHealth*0.02;
                }
            }

            
        }  
    }

    //설정 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public void SetSpec(double HP){
        MaxHealth = HP;
        Health = HP;      
    }
    public void SetArrival(){
        ArrivalPoint = GameManager.instance.ChkArrival();
        AttackerPrefab.transform.LookAt(ArrivalPoint.transform.position);
    } 

    public void LookForward(){        
        AttackerPrefab.transform.LookAt(ArrivalPoint.transform.position);
      
    }


    //충돌 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Enemy")){
            Target = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.gameObject==Target){
            Target = null;
        }
    }
  
    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Enemy")){
           HitDamage(5,col.gameObject);
        }  
    }

    private void OnCollisionStay(Collision col) {
        if(!col.gameObject.CompareTag("Enemy") && Vector3.Distance(this.transform.position,EnemyPoint)<=0.1){
            LookForward();            
        }
    }


    public void HitDamage(double dmg,GameObject obj){
        Health -= (dmg-GameManager.instance.ChkTankDEF());
        rigid.AddForce((this.transform.position-obj.transform.position).normalized *3f,ForceMode.Impulse);        
    }

    //버프

    public void BuffHeal(){
        HealBuffCount=0;
        HealBuff=true;        
    }

}
