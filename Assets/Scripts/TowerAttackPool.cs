using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackPool : MonoBehaviour
{
    public static TowerAttackPool instance;

    private Queue<Bullet> BulletQueue = new Queue<Bullet>();

    public GameObject AttackObj;

    public int count = 30;
    private void Awake() {
        instance = this;
        Initialize(count);
    }

    private void Initialize(int count){
        for(int i=0; i<count;i++){
            BulletQueue.Enqueue(CreateNewObj());
        }
    }

    private Bullet CreateNewObj(){
        var newObj = Instantiate(AttackObj).GetComponent<Bullet>();       
        newObj.transform.SetParent(transform);
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    public Bullet GetObj(){
        if(BulletQueue.Count>0){
            var obj = BulletQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            
            return obj;
        }else{
            var newObj = CreateNewObj();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    public void ReturnObj(Bullet obj){        
        obj.transform.SetParent(instance.transform);
        obj.gameObject.SetActive(false);        
        BulletQueue.Enqueue(obj);

    }


}
