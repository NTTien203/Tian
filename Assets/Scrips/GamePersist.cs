using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist : MonoBehaviour
{
    void Awake() {
        
        int numberPersist= FindObjectsOfType<GamePersist>().Length;
        if(numberPersist>1){
            Destroy(gameObject);
          }
          if(numberPersist==1){
           DontDestroyOnLoad(gameObject);
          }  
          Debug.Log(numberPersist);
    }

   public void ScencePersistence(){
        Destroy(gameObject);
    }
}
