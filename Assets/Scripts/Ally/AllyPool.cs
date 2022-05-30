using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyPool : MonoBehaviour
{
    public static AllyPool instance;

    public GameObject AllyPrefab;
    
    Queue<TestAlly> AlliesQueue = new Queue<TestAlly>();
    private int count = 30;


    private void Awake() {
        instance = this;
        initialize(count);
    }

    private void initialize(int count){
        for(int i=0;i<count;i++){
            AlliesQueue.Enqueue(CreateNewAlly());
        }
    }

    private TestAlly CreateNewAlly(){
        var newAlly = Instantiate(AllyPrefab).GetComponent<TestAlly>();
        newAlly.transform.SetParent(transform);
        newAlly.gameObject.SetActive(false);
        return newAlly;
    }

    public TestAlly SummonAlly(){
        if(AlliesQueue.Count>0){
            var Ally = AlliesQueue.Dequeue();
            Ally.transform.SetParent(null);
            Ally.gameObject.SetActive(true);

            return Ally;
        }else{
            var newAlly = CreateNewAlly();
            newAlly.transform.SetParent(null);
            newAlly.gameObject.SetActive(true);
            return newAlly;
        }
    }

    public void ReturnAlly(TestAlly Ally){
        Ally.transform.SetParent(instance.transform);
        Ally.gameObject.SetActive(false);
        AlliesQueue.Enqueue(Ally);
    }
}
