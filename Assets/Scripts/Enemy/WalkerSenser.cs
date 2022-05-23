using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerSenser : MonoBehaviour
{
    public GameObject MonPrefab;
    private MonWalker Walker;
    private Vector3 Point;

    private void Start() {
       Walker = MonPrefab.GetComponent<MonWalker>();       
    }    

    private void Update() {
        this.transform.localPosition = new Vector3(0,0,0);
    }

    private void OnTriggerStay(Collider col) {
        if(col.gameObject.CompareTag("Ally") && !Walker.FindChk()){           
            Walker.DetectEnemy(col.transform.position);                                
        }   
    }

    
}
