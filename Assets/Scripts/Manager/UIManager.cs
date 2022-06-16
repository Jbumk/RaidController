using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance{
        get{
            if(m_inst==null){
                m_inst=FindObjectOfType<UIManager>();
            }
            return m_inst;
        }
    }

    private static UIManager m_inst;

    [Header("Warning")]
    public TextMeshProUGUI WarnIncrease;
    public TextMeshProUGUI WarnInterval;

    [Header("Panels")]
    public GameObject PanMain;
    public GameObject PanSet;
    public GameObject PanRank;
    public GameObject PanInGame;
    public GameObject PanMoveCam;
    public GameObject PanPause;
    [Header("PanGameSub")]
    public GameObject PanSummon;
    public GameObject PanBuff;
    public GameObject PanUpGrade;

    [Header("InGame")]
    public TextMeshProUGUI Gold;


    
    [Header("UpGradeTank")]
    //탱커
    public TextMeshProUGUI TankHealth;
    public TextMeshProUGUI TankHealthCount;
    public TextMeshProUGUI TankDEF;
    public TextMeshProUGUI TankDEFCount;
    [Header("UpGradeTower")]
    //타워
    public TextMeshProUGUI TowerDMG;
    public TextMeshProUGUI TowerDMGCount;
    public TextMeshProUGUI TowerAS;
    public TextMeshProUGUI TowerASCount;
    [Header("UpGradeDoor")]
    //문
    public TextMeshProUGUI DoorHealth;
    public TextMeshProUGUI DoorHealthCount;
    public TextMeshProUGUI DoorHeal;
    public TextMeshProUGUI DoorHealCount;
    [Header("UpGradeAD")]
    //AD
    public TextMeshProUGUI ADDMG;
    public TextMeshProUGUI ADDMGCount;
    public TextMeshProUGUI ADHealth;
    public TextMeshProUGUI ADHealthCount;
    public TextMeshProUGUI ADAS;
    public TextMeshProUGUI ADASCount;
    [Header("UpGradeAP")]
    //AP
    public TextMeshProUGUI APDMG;
    public TextMeshProUGUI APDMGCount;
    public TextMeshProUGUI APHealth;
    public TextMeshProUGUI APHealthCount;
    public TextMeshProUGUI APSize;
    public TextMeshProUGUI APSizeCount;
    public TextMeshProUGUI APIgnoreTime;
    public TextMeshProUGUI APIgnoreTimeCount;
    

    
    
    //버튼으로 할것 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    public void Main_Start(){
        PanMain.SetActive(false);
        PanInGame.SetActive(true);
    }

    public void Main_Set(){
        PanMain.SetActive(false);
        PanSet.SetActive(true);
    }
    

    public void Main_Rank(){
        PanMain.SetActive(false);
        PanRank.SetActive(true);
    }

    public void Main_Exit(){
        Application.Quit();
    }

    public void Set_Home(){
        PanSet.SetActive(false);
        PanMain.SetActive(true);
    }

    public void Rank_Home(){
        PanRank.SetActive(false);
        PanMain.SetActive(true);
    }

    public void Game_Summon(){
        PanSummon.SetActive(true);
    }

    public void Game_CloseSummon(){
        PanSummon.SetActive(false);
    }

    public void Game_Buff(){
        PanBuff.SetActive(true);
    }

    public void Game_CloseBuff(){
        PanBuff.SetActive(false);
    }

    public void Game_UpGrade(){
        PanUpGrade.SetActive(true);
    }

    public void Game_CLoseUpGrade(){
        PanUpGrade.SetActive(false);
    }

    public void Game_MoveCam(){
        PanMoveCam.SetActive(true);
    }

    public void Game_CloseMoveCam(){
        PanMoveCam.SetActive(false);
    }

    public void Game_Pause(){
        PanPause.SetActive(true);
        Time.timeScale=0f;
    }

    public void Pause_Resume(){
        PanPause.SetActive(false);
        Time.timeScale=1f;
    }

    public void Pause_ReStart(){
        PanPause.SetActive(false);
        Time.timeScale=1f;
    }

    public void Pause_Set(){
        //셋팅판
    }

    public void Pasue_Exit(){
        PanPause.SetActive(false);
        PanInGame.SetActive(false);
        PanMain.SetActive(transform);
        //홈화면으로
    }
    //버튼 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

    //골드 표시
    public void Show_Gold(int Money){
        Gold.text = string.Format("{0} G", Money);
    }

    //업그레이드 가격 설정
    //탱커
    public void SetPriceTankHealth(int Price,int Count){
        TankHealth.text = string.Format(Price+" G");
        TankHealthCount.text = string.Format(Count +" / 5");
    }
    public void SetPriceTankDEF(int Price,int Count){
        TankDEF.text = string.Format(Price+" G");
        TankDEFCount.text = string.Format(Count +" / 5");
    }

    //타워
    public void SetPriceTowerDMG(int Price,int Count){
        TowerDMG.text =string.Format(Price+" G");
        TowerDMGCount.text = string.Format(Count +" / 5");
    }
    public void SetPriceTowerAS(int Price,int Count){
        TowerAS.text = string.Format(Price+" G");
        TowerASCount.text = string.Format(Count + " / 5");
    }

    //문
    public void SetPriceDoorHP(int Price,int Count){
        DoorHealth.text = string.Format(Price+" G");
        DoorHealCount.text = string.Format(Count +" / 5");
    }
    public void SetPriceDoorHeal(int Price,int Count){
        DoorHeal.text = string.Format(Price + " G");
        DoorHealCount.text = string.Format(Count + " / 5");
    }
    
    //물리딜러
    public void SetPriceADDMG(int Price,int Count){
        ADDMG.text = string.Format(Price +" G");
        ADDMGCount.text = string.Format(Count + " / 5");
    }
    public void SetPriceADHP(int Price,int Count){
        ADHealth.text = string.Format(Price + " G");
        ADHealthCount.text =string.Format(Count + " / 5");
    }
    public void SetPriceADAS(int Price,int Count){
        ADAS.text = string.Format(Price + " G");
        ADASCount.text = string.Format(Count + " / 5");
    }

    //마법딜러
    public void SetPriceAPDMG(int Price,int Count){
        APDMG.text = string.Format(Price + " G");
        APDMGCount.text = string.Format(Count +" / 5");
    }
    public void SetPriceAPHP(int Price,int Count){
        APHealth.text = string.Format(Price + " G");
        APHealthCount.text = string.Format(Count + " / 5");
    }
    public void SetPriceAPSize(int Price,int Count){
        APSize.text = string.Format(Price + " G");
        APSizeCount.text = string.Format(Count + " / 5");
    }
    public void SetPriceAPTime(int Price,int Count){
        APIgnoreTime.text = string.Format(Price + " G");
        APIgnoreTimeCount.text = string.Format(Count + " / 5");
    }
}
