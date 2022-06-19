using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
   public static SpriteManager instance{
        get{
            if(m_inst==null){
                m_inst=FindObjectOfType<SpriteManager>();
            }
            return m_inst;
        }
   }

   private static SpriteManager m_inst;

   public Material[] Mats; 
   public Material[] BossMats;

   public Material getSprite(int type){
        return Mats[type];
   }

   public Material getBossSprite(int type){
        return BossMats[type];
   }
}
