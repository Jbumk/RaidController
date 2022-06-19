using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject Arrival;
    public static TestSpawn instance {
        get
        {
            if(m_inst==null){
                m_inst = FindObjectOfType<TestSpawn>();
            }
            return m_inst;

        }
    }

    private static TestSpawn m_inst;

    private int count = 3;
    private Vector3 SummonPoint;
    
    private void Update() {
        if(count>0){
           var mon = WalkerPool.instance.SummonWalker();           
           SummonPoint = new Vector3(0,1,Random.Range(-5,5));
           mon.transform.position=SummonPoint;
           mon.SetSpec(100,1,5);
           mon.SetArrival(Arrival.transform.position);
          
           count--;
        }
    }
}
