using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonWalker : MonoBehaviour
{
    [Header("Set")]
    public GameObject MonPrefab;
    public GameObject DietectArea;
    private Vector3 ArrivalPoint;
    private bool isFight=false;
    
    
    [Header("Spec")]
    private double Health;
    private float MoveSpeed;

    private void Update() {
        if(Health<=0){
            //풀링 반환 + Health 초기화 + Speed 초기화
            WalkerPool.instance.ReturnMon(this);
            Health=0;
            MoveSpeed=0;            
        }    
    }
    
    void FixedUpdate()
    {
        if(!isFight && Health>0){
            MonPrefab.transform.position 
                = Vector3.MoveTowards(MonPrefab.transform.position,ArrivalPoint,MoveSpeed*Time.deltaTime);
        }
    }

    public void SetSpec(double HP, float Speed){
        Health = HP;
        MoveSpeed = Speed;
    }
    public void SetArrival(Vector3 Point){
        ArrivalPoint = Point;
    }


    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Arrival")){
            WalkerPool.instance.ReturnMon(this);
        }
    }
}
