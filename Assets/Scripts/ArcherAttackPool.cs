using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttackPool : MonoBehaviour
{
  public static ArcherAttackPool instance;

  public GameObject ArrowPrefab;  
  
  Queue<Arrow> ArrowQueue = new Queue<Arrow>();

  private void Awake(){
    instance=this;
    initialize(30);
  }
  private void initialize(int count){
    for(int i=0;i<count;i++){
      ArrowQueue.Enqueue(CreateNewArrow());
    }
  }

  private Arrow CreateNewArrow(){
    var obj = Instantiate(ArrowPrefab).GetComponent<Arrow>();
    obj.transform.SetParent(transform);
    obj.gameObject.SetActive(false);

    return obj;
  }
    
  public Arrow GetArrow(){
    if(ArrowQueue.Count>0){
      var obj = ArrowQueue.Dequeue();
      obj.transform.SetParent(null);
      obj.gameObject.SetActive(true);

      return obj;
    }else{
      var obj = CreateNewArrow();
      obj.transform.SetParent(null);
      obj.gameObject.SetActive(true);

      return obj;
    }
  }

  public void ReturnArrow(Arrow obj){
    obj.transform.SetParent(instance.transform);
    obj.gameObject.SetActive(false);
    ArrowQueue.Enqueue(obj);
  }
}
