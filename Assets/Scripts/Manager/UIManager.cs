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
    

}
