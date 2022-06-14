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

   public Material[] mats;


   public Material getSpriteSlimeGreen(){
        return mats[0];
   }

   public Material getSpriteSlimeBlue(){
        return mats[1];
   }

   public Material getSpriteSlimeRed(){
        return mats[2];
   }

   public Material getSpriteSlimeBlack(){
        return mats[3];
   }

   public Material getSpriteSlimeGreenBoss(){
        return mats[4];
   }

   public Material getSpriteSlimeBlueBoss(){
        return mats[5];
   }

   public Material getSpriteSlimeRedBoss(){
        return mats[6];
   }

   public Material getSpriteSlimeBlackBoss(){
        return mats[7];
   }

   public Material getSpriteWormGreen(){
        return mats[8];
   }

   public Material getSpriteWormBrown(){
        return mats[9];
   }

   public Material getSpriteWormWhite(){
        return mats[10];
   }

   public Material getSpriteWormBlack(){
        return mats[11];
   }

   public Material getSpriteWormGreenBoss(){
        return mats[12];
   }

   public Material getSpriteWormBlueBoss(){
        return mats[13];
   }

   public Material getSpriteWormWhiteBoss(){
        return mats[14];
   }

   public Material getSpriteWormBlackBoss(){
        return mats[15];
   }

   public Material getSprite(int type){
        return mats[type];
   }
}
