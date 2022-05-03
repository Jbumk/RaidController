using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject SummonZone1;
    private Vector3 SummonPos;
    public void SummonAlly1(){
        //재화 체크, 소모

        //Ally pool에서 생성
        var Ally = AllyPool.instance.SummonAlly();
        SummonPos = SummonZone1.transform.position;
        SummonPos.x += Random.Range(0,5);
        SummonPos.z += Random.Range(0,5);
        Ally.transform.position = SummonPos;
    }
}
