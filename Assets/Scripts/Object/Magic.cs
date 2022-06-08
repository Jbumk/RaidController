using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
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
        this.transform.localScale = GameManager.instance.ChkMagicSize();   
    }
}
