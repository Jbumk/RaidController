using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardPool : MonoBehaviour
{
   public static WizardPool instance;

   public GameObject WizardPrefab;

   private Queue<Wizard> WizardQueue = new Queue<Wizard>();

   private void Awake() {
       instance = this;
       initialize(30);
   }

   private void initialize(int count){
       for(int i=0;i<count;i++){
           WizardQueue.Enqueue(CreateNewWizard());
       }
   }

   private Wizard CreateNewWizard(){
       var obj = Instantiate(WizardPrefab).GetComponent<Wizard>();
       obj.transform.SetParent(transform);
       obj.gameObject.SetActive(false);

       return obj;
   }

   public Wizard SummonWizrd(){
       if(WizardQueue.Count>0){
           var obj = WizardQueue.Dequeue();
           obj.transform.SetParent(null);
           obj.gameObject.SetActive(true);

           return obj;
       }else{
           var obj = CreateNewWizard();
           obj.transform.SetParent(null);
           obj.gameObject.SetActive(true);

           return obj;
       }
   }

   public void ReturnWizard(Wizard obj){
       obj.transform.SetParent(instance.transform);
       obj.gameObject.SetActive(false);
       WizardQueue.Enqueue(obj);
   }
}
