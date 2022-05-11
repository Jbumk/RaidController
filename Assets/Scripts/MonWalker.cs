using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonWalker : MonoBehaviour
{
    [Header("Set")]
    public GameObject MonPrefab;
    public GameObject DietectArea;
    private Vector3 ArrivalPoint;
    public bool isFight=false;
    public bool isFind=false;
    private Vector3 Direc;
    private Vector3 PlayerPoint;
    
    [Header("Spec")]
    private double Health;
    private float MoveSpeed;

    private void Update() {
        if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화
            WalkerPool.instance.ReturnMon(this);
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
                    MonPrefab.transform.LookAt(PlayerPoint);
                }                
                MonPrefab.transform.Translate(Vector3.forward* MoveSpeed * Time.deltaTime);
            }
            
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
        //Direc =(MonPrefab.transform.position-point).normalized;        
        //해당 적을 바라본채로 사거리 까지 다가가고
        isFind=true; 
        PlayerPoint = point;       
               
        // 그후 정지하고 공격한다
    }

    public void LookForward(){        
        MonPrefab.transform.LookAt(ArrivalPoint);
        isFind=false;
        isFight=false;
    }

    public bool FindChk(){
        return isFind;
    }


    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Arrival")){
            WalkerPool.instance.ReturnMon(this);
        }

        if(col.gameObject.CompareTag("Ally")){
            Debug.Log("적과 충돌");           
            isFight=true;
        }          
    }


    private void OnTriggerStay(Collider col) {
        if(!col.gameObject.CompareTag("Ally") && Vector3.Distance(this.transform.position,PlayerPoint)<=0.1
            ||!col.gameObject.CompareTag("Ally") && isFight){
            LookForward();            
        }
        
    }

    public void HitDamage(double dmg){
        Health -= dmg;
        Debug.Log("맞았음");
    }
    

    

    

}
