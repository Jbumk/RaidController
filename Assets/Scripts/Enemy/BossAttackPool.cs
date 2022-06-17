using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPool : MonoBehaviour
{
   public static BossAttackPool instance;
   public GameObject BossAttackPrefab;
   private int count = 30;

   Queue<BossAttack> BossAttackQueue = new Queue<BossAttack>();

   private void Awake() {
        instance=this;
        initialize(count);
   }

   private void initialize(int count){
        for(int i=0;i<count;i++){
            BossAttackQueue.Enqueue(CreateNewBossAttack());
        }
   }

   private BossAttack CreateNewBossAttack(){
        var obj = Instantiate(BossAttackPrefab).GetComponent<BossAttack>();
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);

        return obj;
   }

   public BossAttack getBossAttack(){
        if(BossAttackQueue.Count>0){
            var obj = BossAttackQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }else{
            var obj = CreateNewBossAttack();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }
   }

   public void ReturnBossAttack(BossAttack obj){
        obj.transform.position = Vector3.zero;
        obj.transform.SetParent(instance.transform);
        obj.gameObject.SetActive(false);

        BossAttackQueue.Enqueue(obj);        
   }
}
