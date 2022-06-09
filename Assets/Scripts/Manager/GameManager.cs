using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{
        get{
            if(m_inst==null){
                m_inst =FindObjectOfType<GameManager>();
            }
            return m_inst;            
        }
    }

    private static GameManager m_inst;

    //충돌 데미지
    private double collisionDamage=10.0;

    //AD 스펙
    private double ArrowDamage=10.0;
    private double ArrowAS = 2.0;
    private double ADHealth = 100;
    //AP 스펙
    private double MagicDamage=3.0;
    private Vector3 MagicSize= new Vector3(1f,1f,3f);
    private double MagicIgnoreTime = 1.0;
    private double APHealth = 100;
    //탱커 스펙
    private double TankHealth = 200;
    private double TankDEF = 1;
    //Tower 스펙
    private double BulletDamage=5.0;
    private double BulletAS = 2.0;   
    

    
    


    //목적지
    public GameObject Line2Arrival;
    
    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ업그레이드ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //리턴
     public double ChkColDMG(){
        return collisionDamage;
    }


    //AD 관련
    public double ChkArrowDMG(){
        return ArrowDamage;
    }
    public double ChkArrowAS(){
        return ArrowAS;
    }
    public double ChkADHealth(){
        return ADHealth;
    }

    //AP 관련
    public double ChkMagicDMG(){
        return MagicDamage;
    }
     public double ChkIgnoreTime(){
        return MagicIgnoreTime;
    }
    public Vector3 ChkMagicSize(){
        return MagicSize;
    }
    public double ChkAPHealth(){
        return APHealth;
    }


    //Tank 관련
    public double ChkTankHealth(){
        return TankHealth;
    }
    public double ChkTankDEF(){
        return TankDEF;
    }


    //Tower 관련
    public double ChkBulletDMG(){
        return BulletDamage;
    } 
    public double ChkBulletAS(){
        return BulletAS;
    }    
  
    

    //목적지
    public GameObject ChkArrival(){
        return Line2Arrival;
    }
    

    //타워, 공격자 업그레이드
    //AD 딜러 관련
    public void Up_ArrowDMG(){
        ArrowDamage+=1.0;
    }
    public void Up_ArrowAS(){
        ArrowAS-=0.1;
    }
    public void Up_ADHealth(){
        ADHealth +=10;
    }


    //AP 딜러 관련
    public void Up_MagicSize(){
        MagicSize.x+=0.1f;
    }

    public void Up_MagicDMG(){
        MagicDamage+=0.5;
    }
    public void Up_IgNoreTime(){
        MagicIgnoreTime-=0.1;
    }
    public void Up_APHealth(){
        APHealth+=5;
    }
    

    //탱커 관련
    private void Up_TankHealth(){
        TankHealth+=15;
    }
    private void Up_TankDEF(){
        TankDEF+=1;
    }
    //타워 관련
    public void Up_BulletDMG(){
        BulletDamage+=1.0;
    }
    public void Up_BulletAS(){
        BulletAS-=0.1;
    }  
    
    
    
}
