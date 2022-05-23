using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private int MaxHealth = 10000;
    private int NowHealth = 10000;





    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Enemy")){
            HitDmage(5);
        }     
    }

    //기능
    public void HitDmage(int Dmg){
        NowHealth -= Dmg;
    }

    public void Repair(){
        NowHealth = MaxHealth;
    }

    //상점 스크립트에서 호출함
    public void UpGradeHealth(){
        MaxHealth+=1000;
        NowHealth+=1000;
    }

    //리턴
    public int ChkMaxHealth(){
        return MaxHealth;
    }

    public int CHkNowHealth(){
        return NowHealth;
    }


}
