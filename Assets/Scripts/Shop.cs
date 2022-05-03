using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{    
    public static Shop instance{
        get{
            if(m_inst==null){
                m_inst=FindObjectOfType<Shop>();
            }
            return m_inst;
        }
    }

    private static Shop m_inst;

    [Header("Money")]
    private int Money=0;
    private int MoneyIncrease=10;
    private double MoneyInterval=10;
    private float MoneyTimer=0;
    

    
    [Header("Item")]
    public GameObject SummonZone1;
    private Vector3 SummonPos;
    
    //수비지역 아군1 생성 가격
    private int SummonAlly1Price = 10;

    //수급량 증가 가격
    private int IncreasePrice=10;

    //수급 시간 단축 가격
    private int IntervalPrice=10;



    private void Update() {
        //if문 게임 시작됐을때
        MoneyTimer+=Time.deltaTime;
        if(MoneyTimer>=MoneyInterval){
            Money+=MoneyIncrease;
            MoneyTimer=0;
        }
    }

    //수비지역 아군 생성 1
    public void SummonAlly1(){
        //재화 체크, 소모

        //Ally pool에서 생성
        var Ally = AllyPool.instance.SummonAlly();
        SummonPos = SummonZone1.transform.position;
        SummonPos.x += Random.Range(0,5);
        SummonPos.z += Random.Range(0,5);
        Ally.transform.position = SummonPos;
    }

    // 공격지역 아군 생성 1

    // 골드 수급량 증가
    public void UpgradeMoneyIncrease(){
        if(Money>=IncreasePrice){
            MoneyIncrease+=3;
            IncreasePrice+=15;
            // 상승량은 추후 조절
        }else{
            //재화 부족 경고
        }
        
    }

    // 골드 수급시간 단축
    public void UpGradeMoneyInterval(){
        if(Money>=IntervalPrice){
            MoneyInterval-=0.25;
            IntervalPrice+=15;
            // 상승량은 추후 조절
        }else{
            //재화부족경고
        }
    }


}
