using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
   public GameObject TargetObj=null;//포착 오브젝트
   public GameObject TowerPrefab; //타워 본체
   private Vector3 Direction;
   private Quaternion Direc;
   
   private double AttackCoolTime = 2.0;
   private float AttackTimer = 0;
   private double Damage = 5.0;

   //buff
   private bool DMGBuff =false;
   private double DMGBuffTime = 30.0;
   private float DMGBuffCount=0;

   private bool SpeedBuff =false;
   private double OriginAttackCoolTime=0;
   private double SpeedBuffTime = 30.0;
   private float SPeedBuffCount = 0;
   

   private void Update() {

       //대상 포착시 발사
       if(TargetObj!=null){
           

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
                if(DMGBuff){
                    Bullet.Shoot(Direction,TargetObj,Damage*1.3);
                }else{
                    Bullet.Shoot(Direction,TargetObj,Damage);   
                }
                
                AttackTimer=0;
            }

            //거리 멀어지면 대상 포착해제
            if(Vector3.Distance(TargetObj.transform.position,transform.position)>=16){
                TargetObj=null;
            }

           if(Input.GetKey(KeyCode.F5)){
               TargetObj=null;
           }
       }

       if(DMGBuff){
           DMGBuffCount+=Time.deltaTime;
           if(DMGBuffTime<=DMGBuffCount){
               DMGBuffCount=0;
               DMGBuff=false;               
           }
       }
       if(SpeedBuff){
           SPeedBuffCount+=Time.deltaTime;
           if(SpeedBuffTime<=SPeedBuffCount){
               AttackCoolTime = OriginAttackCoolTime;
               SPeedBuffCount=0;
               SpeedBuff=false;
           }
       }
   }
 
   
   private void OnTriggerStay(Collider col) {
       if(TargetObj==null && col.gameObject.CompareTag("Enemy")){
           TargetObj=col.gameObject;
       }
   }

   //버튼으로 업그레이드
   public void UpGradeSpeed(){
       AttackCoolTime-=0.1;
   }

   public void Buff_DMG(){
       DMGBuff=true;
   }

   public void Buff_Speed(){
       OriginAttackCoolTime = AttackCoolTime;
       AttackCoolTime *= 0.7;
       SpeedBuff=true;
   }
}
