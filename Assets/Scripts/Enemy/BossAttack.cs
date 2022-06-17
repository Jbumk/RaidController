using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
   private GameObject Target;

   private void FixedUpdate() {
        transform.Translate(Vector3.forward * 5.5f * Time.deltaTime);
   }


   public void SetArrival(GameObject obj){
        Target = obj;
        transform.LookAt(Target.transform.position);
   }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Ally")){
            BossAttackPool.instance.ReturnBossAttack(this);
        }
    }
}
