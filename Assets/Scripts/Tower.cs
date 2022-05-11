using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
   public GameObject TargetObj=null;//포착 오브젝트
   public GameObject TowerPrefab; //타워 본체
   private Vector3 Direction;
   private Quaternion Direc;
   
   private double AttackCoolTime = 1.0;
   private float AttackTimer = 0;
   

   private void Update() {
       if(TargetObj!=null){
           //Direction = (TowerPrefab.transform.position - TargetObj.transform.position).normalized;
           //TowerPrefab.transform.rotation = Quaternion.Slerp(TowerPrefab.transform.rotation, Quaternion.Euler(Direction),10f*Time.deltaTime);

           AttackTimer += Time.deltaTime;
           
           //타워 방향설정
           TowerPrefab.transform.LookAt(TargetObj.transform);
           Direc = TowerPrefab.transform.rotation;
           Direc.x=0;
           Direc.z=0;
           TowerPrefab.transform.rotation=Direc;

            if(AttackTimer>=AttackCoolTime){
            //해당 방향으로 발사
                Direction = (TargetObj.transform.position - TowerPrefab.transform.position);
                var Bullet = TowerAttackPool.instance.GetObj();
                Bullet.transform.position = transform.position;
                Bullet.Shoot(Direction,TargetObj);
                AttackTimer=0;
            }

            
            if(Vector3.Distance(TargetObj.transform.position,transform.position)>=16){
                TargetObj=null;
            }

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
