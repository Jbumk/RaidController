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

    

    
    
    //버튼으로 할것

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



}
