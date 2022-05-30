using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 Arrival;
    private GameObject Target;
    private MonWalker TargetHit;
    private double Damage;
    
    void Update()
    {
        transform.Translate(Vector3.forward*5f*Time.deltaTime);
    }

    public void SetArrival(Vector3 point, GameObject Target,double DMG){
        this.Target = Target;
        Arrival = point;
        Damage = DMG;
        TargetHit=Target.GetComponent<MonWalker>();
        transform.LookAt(Arrival);
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject==Target){
            TargetHit.HitDamage(Damage,true);
            ArcherAttackPool.instance.ReturnArrow(this);            
        }
    }
}
