using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMagicPool : MonoBehaviour
{
    public static WizardMagicPool instance;

    public GameObject MagicPrefab;

    private Queue<Magic> MagicQueue = new Queue<Magic>();

    private void Awake() {
        instance=this;
        initialize(30);
    }

    private void initialize(int count){
        for(int i=0;i<count;i++){
            MagicQueue.Enqueue(CreateNewMagic());            
        }
    }

    private Magic CreateNewMagic(){
        var obj = Instantiate(MagicPrefab).GetComponent<Magic>();
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);

        return obj;
    }

    public Magic GetMagic(){
        if(MagicQueue.Count>0){
            var obj = MagicQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }else{
          var obj = CreateNewMagic();
          obj.transform.SetParent(null);
          obj.gameObject.SetActive(true);

          return obj;  
        }
    }

    public void ReturnMagic(Magic obj){
        obj.transform.SetParent(instance.transform);
        obj.gameObject.SetActive(false);
        MagicQueue.Enqueue(obj);
    }
}
