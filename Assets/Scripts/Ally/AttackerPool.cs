using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerPool : MonoBehaviour
{
  public static AttackerPool instance;
  private Queue<Attacker> AttackerQueue = new Queue<Attacker>();

  public GameObject AttackPrefab;

  private int count = 30;

  private void Awake() {
        instance = this;
        Initialize(count);
  }

  private void Initialize(int count){
      for(int i=0; i<count; i++){
          AttackerQueue.Enqueue(CreateNewAttacker());
      }

  }

  private Attacker CreateNewAttacker(){
      var newAttacker = Instantiate(AttackPrefab).GetComponent<Attacker>();
      newAttacker.transform.SetParent(transform);
      newAttacker.gameObject.SetActive(false);

      return newAttacker;
  }

  public Attacker GetAttacker(){
      if(AttackerQueue.Count>0){
          var Attackers = AttackerQueue.Dequeue();
          Attackers.transform.SetParent(null);
          Attackers.gameObject.SetActive(true);
          Attackers.SetSpec(GameManager.instance.ChkTankHealth());
          Attackers.SetArrival();

          return Attackers;
      }else{
          var newAttacker = CreateNewAttacker();
          newAttacker.transform.SetParent(null);
          newAttacker.gameObject.SetActive(true);
          newAttacker.SetSpec(GameManager.instance.ChkTankHealth());
          newAttacker.SetArrival();

          return newAttacker;
      }
  }

  public void ReturnAttacker(Attacker obj){
      obj.gameObject.SetActive(false);
      obj.transform.SetParent(instance.transform);
      AttackerQueue.Enqueue(obj);
  }
}
