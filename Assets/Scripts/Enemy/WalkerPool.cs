using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPool : MonoBehaviour
{
    public static WalkerPool instance;
    public GameObject WalkerPrefabs;
    private int count = 30;

    Queue<MonWalker> MonWalkerPool = new Queue<MonWalker>();

    private void Awake() {
        instance=this;
        initialize(count);
    }
    private void initialize(int count){
        for(int i=0; i<count;i++){
            MonWalkerPool.Enqueue(CreateNewMon());
        }

    }

    private MonWalker CreateNewMon(){
        var newMon = Instantiate(WalkerPrefabs).GetComponent<MonWalker>();
        newMon.transform.SetParent(transform);
        newMon.gameObject.SetActive(false);       

        return newMon;
    }

    public MonWalker SummonWalker(){
        if(MonWalkerPool.Count>0){           
            var mon = MonWalkerPool.Dequeue();
            mon.transform.SetParent(null);
            mon.gameObject.SetActive(true);            

            return mon;
        }else{            
            var newMon = CreateNewMon();
            newMon.transform.SetParent(null);
            newMon.gameObject.SetActive(true);            

            return newMon;
        }

    }

    public void ReturnMon(MonWalker Mon){       
        Mon.transform.position =Vector3.zero;
        Mon.transform.SetParent(instance.transform);
        Mon.gameObject.SetActive(false);
        
        instance.MonWalkerPool.Enqueue(Mon);

    }

}
