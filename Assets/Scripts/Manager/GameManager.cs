using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //데미지
    private double collisionDamage=5.0;
    private double MagicDamage=3.0;
    private double ArrowDamage=10.0;
    private double BulletDamage=5.0;


    //업그레이드



    //목적지
    public GameObject Line2Arrival;
    


    //리턴
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
    

    public GameObject ChkArrival(){
        return Line2Arrival;
    }
    
}
