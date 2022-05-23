using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlly : MonoBehaviour
{
   private void OnTriggerEnter(Collider col) {
       if(col.gameObject.CompareTag("Enemy")){
           this.gameObject.SetActive(false);
       }
   }
}
