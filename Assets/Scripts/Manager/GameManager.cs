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

    //데미지
    private double collisionDamage=5.0;
    private double MagicDamage=3.0;
    private double ArrowDamage=10.0;
    private double BulletDamage=5.0;

    //마법 크기
    private Vector3 MagicSize= new Vector3(1f,1f,3f);

    //속도관련
    private double MagicIgnoreTime = 1.0;
    private double ArrowAS = 2.0;
    private double BulletAS = 2.0;


    //목적지
    public GameObject Line2Arrival;
    
    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ업그레이드ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //리턴
    //데미지 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    public double ChkColDMG(){
        return collisionDamage;
    }

    public double ChkMagicDMG(){
        return MagicDamage;
    }

    public double ChkArrowDMG(){
        return ArrowDamage;
    }

    public double ChkBulletDMG(){
        return BulletDamage;
    }    
    

    //속도 관련 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
    public double ChkIgnoreTime(){
        return MagicIgnoreTime;
    }
    
    public double ChkArrowAS(){
        return ArrowAS;
    }

    public double ChkBulletAS(){
        return BulletAS;
    }


   
    // 크기
    public Vector3 ChkMagicSize(){
        return MagicSize;
    }
    

    //목적지
    public GameObject ChkArrival(){
        return Line2Arrival;
    }
    


    //타워, 공격자 업그레이드    
    public void Up_MagicSize(){
        MagicSize.x+=0.1f;
    }

    public void Up_MagicDMG(){
        MagicDamage+=0.5;
    }

    public void Up_ArrowDMG(){
        ArrowDamage+=1.0;
    }

    public void Up_BulletDMG(){
        BulletDamage+=1.0;
    }

    
    //공격 속도 관련 
    public void Up_IgNoreTime(){
        MagicIgnoreTime-=0.1;
    }
  
    public void Up_ArrowAS(){
        ArrowAS-=0.1;
    }
    
    public void Up_BulletAS(){
        BulletAS-=0.1;
    }
}
