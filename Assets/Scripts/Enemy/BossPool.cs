using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPool : MonoBehaviour
{
   public static BossPool instance;
   public GameObject BossPrefabs;
   private int Count = 5;

   Queue<Boss> BossQueue = new Queue<Boss>();

   private void Awake() {
        instance=this;
        initialize(Count);
   }

   private void initialize(int Count){
        for(int i=0;i<Count;i++){
            BossQueue.Enqueue(CreateNewBoss());
        }
   }

   private Boss CreateNewBoss(){
        var obj = Instantiate(BossPrefabs).GetComponent<Boss>();
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);

        return obj;
   }

   public Boss SummonBoss(){
        if(BossQueue.Count>0){
            var obj = BossQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }else{
            var obj = CreateNewBoss();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }
   }

   public void ReturnBoss(Boss obj){
        obj.transform.position= Vector3.zero;
        obj.transform.SetParent(instance.transform);
        obj.gameObject.SetActive(false);
        BossQueue.Enqueue(obj);
   }

}
