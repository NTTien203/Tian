using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
           StartCoroutine(Nextlevel());
        }
    }
    IEnumerator Nextlevel(){
        yield return new WaitForSecondsRealtime(2);
            int currenScenceIndex= SceneManager.GetActiveScene().buildIndex;
            int  nextScenceIndex = currenScenceIndex+1;
            if(nextScenceIndex==SceneManager.sceneCountInBuildSettings){
                nextScenceIndex=0;
            }
            FindObjectOfType<GamePersist>().ScencePersistence();
            SceneManager.LoadScene(nextScenceIndex);
    }
}
