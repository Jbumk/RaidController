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
    private int Money=100;
    private int MoneyIncrease=10;
    private double MoneyInterval=5.0;
    private float MoneyTimer=0;
    

    
    [Header("Item")]
    public GameObject SummonZone1;
    private Vector3 SummonPos;
    
    //재화 관리 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //생산가
    private int SummonAlly1Price = 10;
    //수급량 증가 가격
    private int IncreasePrice=10;
    //수급 시간 단축 가격
    private int IntervalPrice=10;
   
   
    //물리 딜러 관련  
    private int ADDMGPrice=10;
    private int ADDMGCount=0;
   
    private int ADHPPrice=10;
    private int ADHPCount=0;

    private int ADASPrice=10;
    private int ADASCount=0;

    //마법 딜러 관련   
    private int APDMGPrice=10;
    private int APDMGCount=0;
  
    private int APHPPrice=10;
    private int APHPCount=0;

    private int APTimePrice=20;
    private int APTimeCount=0;
  
    private int APSizePrice=10;
    private int APSizeCount=0;
    

    //타워   
    private int TowerDMGPrice=10;
    private int TowerDMGCount=0;

    private int TowerASPrice=10;
    private int TowerASCount=0;

    //탱커 관련

    private int TankHPPrice=10;
    private int TankHPCount=0;

    private int TankDEFPrice=10;
    private int TankDEFCount=0;
    

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
    public void UpGradeADAS(){
        if(Money>=ADASPrice && ADASCount<5){
            GameManager.instance.Up_ArrowAS();
            Money-=ADASPrice;
            ADASPrice+=10;
            ADASCount++;
            UIManager.instance.SetPriceADAS(ADASPrice,ADASCount);
            UIManager.instance.Show_Gold(Money);
        }
    }

    public void UpGradeADDMG(){
        if(Money>=ADDMGPrice && ADDMGCount<5){
            GameManager.instance.Up_ArrowDMG();
            Money-=ADDMGPrice;
            ADDMGPrice+=10;
            ADDMGCount++;
            UIManager.instance.SetPriceADDMG(ADDMGPrice,ADDMGCount);
            UIManager.instance.Show_Gold(Money);
        }
    }

    public void UPGradeADHP(){
        if(Money>=ADHPPrice && ADHPCount<5){
            GameManager.instance.Up_ADHealth();
            Money-=ADHPPrice;
            ADHPPrice+=10;
            ADHPCount++;
            UIManager.instance.SetPriceADHP(ADHPPrice,ADHPCount);
            UIManager.instance.Show_Gold(Money);
        }
    }

    

    //마법 딜러
    public void UpGradeAPDMG(){
        if(Money>=APDMGPrice && APDMGCount<5){
            GameManager.instance.Up_MagicDMG();
            Money-=APDMGPrice;
            APDMGPrice+=10;
            APDMGCount++;
            UIManager.instance.SetPriceAPDMG(APDMGPrice,APDMGCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
    public void UpGradeAPTime(){
        if(Money>=APTimePrice && APTimeCount<5){
            GameManager.instance.Up_IgNoreTime();
            Money-=APTimePrice;
            APTimePrice+=20;
            APTimeCount++;
            UIManager.instance.SetPriceAPTime(APTimePrice,APTimeCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
    public void UpGradeAPHP(){
        if(Money>=APHPPrice && APHPCount<5){
            GameManager.instance.Up_APHealth();
            Money-=APHPPrice;
            APHPPrice+=10;
            APHPCount++;
            UIManager.instance.SetPriceAPHP(APHPPrice,APHPCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
    public void UpGradeAPSize(){
        if(Money>=APSizePrice && APSizeCount<5){
            GameManager.instance.Up_MagicSize();
            Money-=APSizePrice;
            APSizePrice+=10;
            APSizeCount++;
            UIManager.instance.SetPriceAPSize(APSizePrice,APSizeCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
    //탱커 
    public void UpGradeTankHP(){
        if(Money>=TankHPPrice && TankHPCount<5){
            GameManager.instance.Up_TankHealth();
            Money-=TankHPPrice;
            TankHPPrice+=10;
            TankHPCount++;
            UIManager.instance.SetPriceTankHealth(TankHPPrice,TankHPCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
    public void UpGradeTankDEF(){
        if(Money>=TankDEFPrice && TankDEFCount<5){
            GameManager.instance.Up_TankDEF();
            Money-=TankDEFPrice;
            TankDEFPrice+=10;
            TankDEFCount++;
            UIManager.instance.SetPriceTankDEF(TankDEFPrice,TankDEFCount);
            UIManager.instance.Show_Gold(Money);
        }
    }


    //타워
    public void UpGradeTowerDMG(){
        if(Money>=TowerDMGPrice && TowerDMGCount<5){
            GameManager.instance.Up_BulletDMG();
            Money-=TowerDMGPrice;
            TowerDMGPrice+=10;          
            TowerDMGCount++;
            UIManager.instance.SetPriceTowerDMG(TowerDMGPrice,TowerDMGCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
    public void UpGradeTowerAS(){
        if(Money>=TowerASPrice && TowerASCount<5){
            GameManager.instance.Up_BulletAS();
            Money-=TowerASPrice;
            TowerASPrice+=10;
            TowerASCount++;
            UIManager.instance.SetPriceTowerAS(TowerASPrice,TowerASCount);
            UIManager.instance.Show_Gold(Money);
        }
    }
}
