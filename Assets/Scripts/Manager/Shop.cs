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
    private double MoneyInterval=5.0;
    private float MoneyTimer=0;
    

    
    [Header("Item")]
    public GameObject SummonZone1;
    private Vector3 SummonPos;
    
    //재화 관리 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //수비지역 아군1 생성 가격
    private int SummonAlly1Price = 10;
    //수급량 증가 가격
    private int IncreasePrice=10;
    //수급 시간 단축 가격
    private int IntervalPrice=10;
    //AD 공격속도 가격
    private int ArrowASPrice=10;
    //AD 공격력 가격
    private int ArrowDMGPrice=10;
    //AP 공격력 가격
    private int MagicDMGPrice=10;
    //AP 히트간격 가격
    private int MagicIgnorePrice=20;
    //타워 공격력 가격
    private int BulletDMGPrice=10;
    //타워 공격속도 가격
    private int BulletASPrice=10;

    

    //재화 관리 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //타워
    public GameObject[] LTower;
    public GameObject[] RTower;

    //타워수
    private int LTowerCount=0;
    private int RTowerCount=0;

    private int LTowerPrice=10;
    private int RTowerPrice=10;




    private void Update() {
        //if문 게임 시작됐을때
        MoneyTimer+=Time.deltaTime;        
        if(MoneyTimer>=MoneyInterval){           
            Money+=MoneyIncrease;
            MoneyTimer=0;
            UIManager.instance.Show_Gold(Money);
        }
    }

    //수비지역 아군 생성 1
    //=> 타워 설치로 변경
    public void CreateLTower(){
        if(LTowerPrice>=Money){
            LTower[LTowerCount].SetActive(true);
            LTowerCount++;
            Money -=LTowerPrice;
            //LTower 건설값 증가 추가해야함
        }
    }
    
    public void CreateRTower(){
        if(RTowerPrice>=Money){
            RTower[RTowerCount].SetActive(true);
            RTowerCount++;
            Money -=RTowerPrice;
            //RTower 건설값 증가 추가해야함
        }
    }

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
    public void SummonAD(){
        if(Money>=10){
            Money-=10;
            UIManager.instance.Show_Gold(Money);
            var obj = ArcherPool.instance.SummonArcher();
            SummonPos = SummonZone1.transform.position;
            SummonPos.x += Random.Range(0,5);
            SummonPos.z += Random.Range(0,5);
            obj.transform.position= SummonPos;
        }
    }

    public void SummonAP(){
        if(Money>=10){
            Money-=10;
            UIManager.instance.Show_Gold(Money);
            var obj = WizardPool.instance.SummonWizrd();
            SummonPos = SummonZone1.transform.position;
            SummonPos.x += Random.Range(0,5);
            SummonPos.z += Random.Range(0,5);
            obj.transform.position= SummonPos;
        }
    }

    public void SummonTank(){
        if(Money>=10){
            Money-=10;
            UIManager.instance.Show_Gold(Money);
            var obj = AttackerPool.instance.GetAttacker();
            SummonPos = SummonZone1.transform.position;
            SummonPos.x += Random.Range(0,5);
            SummonPos.z += Random.Range(0,5);
            obj.transform.position= SummonPos;
        }
    }

    // ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ 업그레이드 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

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

    // 공격자 관련
    //물리 딜러
    public void UpGradeArrowAS(){
        if(Money>=ArrowASPrice){
            GameManager.instance.Up_ArrowAS();
            ArrowASPrice+=10;
        }
    }

    public void UpGradeArrowDMG(){
        if(Money>=ArrowDMGPrice){
            GameManager.instance.Up_ArrowDMG();
            ArrowDMGPrice+=10;
        }
    }

    //마법 딜러
    public void UpGradeMagicDMG(){
        if(Money>=MagicDMGPrice){
            GameManager.instance.Up_MagicDMG();
            MagicDMGPrice+=10;
        }
    }
    public void UpGradeMagicIgnore(){
        if(Money>=MagicIgnorePrice){
            GameManager.instance.Up_IgNoreTime();
            MagicIgnorePrice+=20;
        }
    }

    //탱커 


    //타워
    public void UpGradeBulletDMG(){
        if(Money>=BulletDMGPrice){
            GameManager.instance.Up_BulletDMG();
            BulletDMGPrice+=10;
        }
    }
    public void UpGradeBulletAS(){
        if(Money>=BulletASPrice){
            GameManager.instance.Up_BulletAS();
            BulletASPrice+=10;
        }
    }
}
