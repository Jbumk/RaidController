using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerSenser : MonoBehaviour
{
    public GameObject MonPrefab;
    private MonWalker Walker;
    private Vector3 Point;
    private bool isFind;

    private void Start() {
       Walker = MonPrefab.GetComponent<MonWalker>();       
    }
  
 
    //첫 감지는 가능한데 만약 대상이 죽었을경우 새로운 대상의 판별은 없으니 추가 해야한다
    /*
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Ally")){
            Walker.DetectEnemy(col.transform.position);
        }
    }*/

    private void OnTriggerStay(Collider col) {
        if(col.gameObject.CompareTag("Ally")){         
            Walker.DetectEnemy(col.transform.position);                     
        }  
    }

    
}
