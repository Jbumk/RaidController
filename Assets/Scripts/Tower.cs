using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
   public GameObject TargetObj=null;//포착 오브젝트
   public GameObject TowerPrefab; //타워 본체
   private Vector3 Direction;
   private Quaternion Direc;
   
   

   private void Update() {
       if(TargetObj!=null){
           //Direction = (TowerPrefab.transform.position - TargetObj.transform.position).normalized;
           //TowerPrefab.transform.rotation = Quaternion.Slerp(TowerPrefab.transform.rotation, Quaternion.Euler(Direction),10f*Time.deltaTime);
           TowerPrefab.transform.LookAt(TargetObj.transform);
           Direc = TowerPrefab.transform.rotation;
           Direc.x=0;
           Direc.z=0;
           TowerPrefab.transform.rotation=Direc;

           if(Input.GetKey(KeyCode.F5)){
               TargetObj=null;
           }
       }
   }
 
   
   private void OnTriggerStay(Collider col) {
       if(TargetObj==null && col.gameObject.CompareTag("Enemy")){
           TargetObj=col.gameObject;
       }
   }
}
