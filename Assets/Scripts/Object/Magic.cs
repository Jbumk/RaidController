using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private Vector3 Arrival;
    private GameObject Target;
    private MonWalker TargetHit;
    private double Damage;
    
    void Update()
    {
        transform.Translate(Vector3.forward*5f*Time.deltaTime);
    }

    public void SetArrival(GameObject Target,double DMG,Vector3 Size){
        this.Target = Target;
        Arrival = Target.transform.position;
        Damage = DMG;
        TargetHit=Target.GetComponent<MonWalker>();
        transform.LookAt(Arrival);
        this.transform.localScale = Size;   
    }
  

    public double ReturnDamage(){
        return Damage;
    }
}
