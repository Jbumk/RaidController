using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPool : MonoBehaviour
{
  public static ArcherPool instance;
  public GameObject ArcherPrefab;

  Queue<Archer> ArcherQueue = new Queue<Archer>();

  private void Awake(){
      instance = this;
      initialize(8);
  }

  private void initialize(int count){
      for(int i=0; i<count; i++){
          ArcherQueue.Enqueue(CreateArcher());
      }
  }

  private Archer CreateArcher(){
      var newObj = Instantiate(ArcherPrefab).GetComponent<Archer>();
      newObj.transform.SetParent(transform);
      newObj.gameObject.SetActive(false);

      return newObj;
  }

  public Archer SummonArcher(){
      if(ArcherQueue.Count>0){
          var obj = ArcherQueue.Dequeue();          
          obj.transform.SetParent(null);
          obj.gameObject.SetActive(true);
          obj.SetSpec(GameManager.instance.ChkADHealth());
          obj.SetArrival();          

          return obj;
      }else{
          var obj = CreateArcher();
          obj.transform.SetParent(null);
          obj.gameObject.SetActive(true);
          obj.SetSpec(GameManager.instance.ChkADHealth());
          obj.SetArrival(); 

          return obj;
      }
  }

  public void ReturnArcher(Archer obj){
      obj.transform.SetParent(instance.transform);
      obj.gameObject.SetActive(false);
      ArcherQueue.Enqueue(obj);
  }
}
