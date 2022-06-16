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
    private double MonCrashDMG=10.0;
    private double BossCrashDMG=30.0;
    private double TankCrashDMG=10.0;

    //AD 스펙 + 버프
    private double ArrowDamage=10.0;    
    private double ArrowAS = 2.0;    
    private double ADHealth = 100;
   

    //AP 스펙 + 버프
    private double MagicDamage=3.0;    
    private Vector3 MagicSize= new Vector3(1f,1f,3f);
    private int MagicSizeCount=0;
    private double MagicIgnoreTime = 1.0;    
    private double APHealth = 100;
    private int APHealthCount=0;
    private double MagicAS = 2.0;

    //딜러 통합 버프
    //데미지
    private bool B_DealerDMG=false;
    private bool B_isDealerDMGUse=false;
    private double B_DealerDMGDur = 20.0;
    private double B_DealerDMGCoolTime = 50.0;
    private float B_DealerDMGTimer = 0;
    //공격 속도
    private bool B_DealerAS=false;
    private bool B_isDealerASUse=false;
    private double B_DealerASDur = 20.0;
    private double B_DealerASCoolTime = 50.0;
    private float B_DealerASTimer = 0;
    //무적
    private bool B_Invincibility=false;
    private bool B_isInvincibilityUse=false;
    private double B_InvincibilityDur = 10.0;
    private double B_InvincibilityCoolTime = 120.0;
    private float B_InvincibilityTimer = 0;




    //탱커 스펙 + 버프
    private double TankHealth = 200;
    private int TankHealthCount=0;
    private double TankDEF = 1;
    private int TankDEFCount=0;

    //Tower 스펙 + 버프
    private double BulletDamage=5.0;   
    private double BulletAS = 2.0;
    
    //데미지 버프
    private bool B_BulletDMG= false;
    private bool B_isBulletDMGUse=false;
    private double B_BulletDMGDur = 20.0;
    private double B_BulletDMGCoolTime = 50.0;
    private float B_BulletDMGTimer = 0;
    //공격 속도 버프
    private bool B_BulletAS=false;
    private bool B_isBulletASUse=false;
    private double B_BulletASDur = 20.0;
    private double B_BulletASCoolTime = 50.0;
    private float B_BulletASTimer = 0;
    

    
    


    //목적지
    public GameObject Line2Arrival;

    private void Update() {
        //버프 시간관리
        
        //딜러 버프
        //데미지
        if(B_isDealerDMGUse){
            B_DealerDMGTimer+=Time.deltaTime;
            if(B_DealerDMGTimer>=B_DealerDMGDur){
                B_DealerDMG=false;
            }
            if(B_DealerDMGTimer>=B_DealerDMGCoolTime){
                B_isDealerDMGUse=false;
                B_DealerDMGTimer=0;
            }
        }
        //공격속도
        if(B_isDealerASUse){
            B_DealerASTimer+=Time.deltaTime;
            if(B_DealerASTimer>=B_DealerASDur){
                B_DealerAS=false;
            }
            if(B_DealerASTimer>=B_BulletASCoolTime){
                B_isDealerASUse=false;
                B_DealerASTimer=0;
            }
        }

        //타워 버프
        //데미지
        if(B_isBulletDMGUse){
            B_BulletDMGTimer+=Time.deltaTime;
            if(B_BulletDMGTimer>=B_BulletDMGDur){
                B_BulletDMG=false;
            }
            if(B_BulletDMGTimer>=B_BulletDMGCoolTime){
                B_isBulletDMGUse=false;
                B_BulletDMGTimer=0;
            }            
        }
        //공격속도
        if(B_isBulletASUse){
            B_BulletASTimer+=Time.deltaTime;
            if(B_BulletASTimer>=B_BulletASDur){
                B_BulletAS=false;
            }
            if(B_BulletASTimer>=B_BulletASCoolTime){
                B_isBulletASUse=false;
                B_BulletASTimer=0;
            }
        }
        
    }
    
    

    //리턴 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    //충돌데미지
    public double ChkMonCrashDMG(){
        if(B_Invincibility){
            return 0;
        }else{
            return MonCrashDMG;
        }
        
    }
    public double ChkBossCrashDMG(){
        if(B_Invincibility){
            return 0;
        }else{
            return BossCrashDMG;
        }
        
    }
    public double ChkTankCrashDMG(){
        return TankCrashDMG;
    }



    //AD 관련
    public double ChkArrowDMG(){
        if(B_DealerDMG){
            return ArrowDamage*1.3;
        }else{
            return ArrowDamage;
        }       
    }
    public double ChkArrowAS(){
        if(B_DealerAS){
            return ArrowAS*0.8;
        }else{
            return ArrowAS;
        }
        
    }
    public double ChkADHealth(){
        return ADHealth;
    }

    //AP 관련
    public double ChkMagicDMG(){
        if(B_DealerDMG){
            return MagicDamage*1.1;
        }else{
            return MagicDamage;
        }        
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
    public double ChkMagicAS(){
        if(B_DealerAS){
            return MagicAS*0.9;
        }else{
            return MagicAS;
        }        
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
        if(B_BulletDMG){
            return BulletDamage*1.3;
        }else{
            return BulletDamage;
        }        
    } 
    public double ChkBulletAS(){
        if(B_BulletAS){
            return BulletAS*0.8;
        }else{
            return BulletAS;
        }        
    }    
  
    

    //목적지
    public GameObject ChkArrival(){
        return Line2Arrival;
    }
    

    //타워, 공격자 업그레이드, 버프 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
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
    public void Up_TankHealth(){
        TankHealth+=15;
    }
    public void Up_TankDEF(){
        TankDEF+=1;
    }

    //타워 관련
    public void Up_BulletDMG(){
        BulletDamage+=1.0;
    }
    public void Up_BulletAS(){
        BulletAS-=0.1;
    }

    //버프 항목들 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    //딜러 관련
    public void Buff_DealerDMG(){
        if(!B_isDealerDMGUse){
            B_DealerDMG=true;
            B_isDealerDMGUse=true;
            B_DealerDMGTimer=0;
        }
    }
    public void Buff_DealerAS(){
        if(!B_isDealerASUse){
            B_DealerAS=true;
            B_isDealerDMGUse=true;
            B_DealerASTimer=0;
        }
    }
    public void Buff_Invincibility(){
        if(!B_isInvincibilityUse){
            B_Invincibility=true;
            B_isInvincibilityUse=true;
            B_InvincibilityTimer=0;
        }
    }
    public void Buff_TowerDMG(){
        if(!B_isBulletDMGUse){
            B_BulletDMG=true;
            B_isBulletDMGUse=true;
            B_BulletDMGTimer=0;
        }
    }
    public void Buff_TowerAS(){
        if(!B_isBulletASUse){
            B_BulletAS=true;
            B_isBulletASUse=true;
            B_BulletASTimer=0;
        }
    }
    
    
}
