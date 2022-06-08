using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 Arrival;
    private GameObject Target;
    private MonWalker TargetHit;
   
    
    void Update()
    {
        transform.Translate(Vector3.forward*5f*Time.deltaTime);
    }

    public void SetArrival(GameObject Target){
        this.Target = Target;
        Arrival = Target.transform.position;       
        TargetHit=Target.GetComponent<MonWalker>();
        transform.LookAt(Arrival);
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject==Target){
            TargetHit.HitDamage(GameManager.instance.ChkArrowDMG(),true);
            ArcherAttackPool.instance.ReturnArrow(this);            
        }
    }
}
