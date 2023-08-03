using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int PlayerLife=3;
     [SerializeField] int FScore=0;
    [SerializeField] TextMeshProUGUI livestext;
     [SerializeField] TextMeshProUGUI scorestext;

    void Awake() {
        
        int numbersession= FindObjectsOfType<GameSession>().Length;
        if(numbersession>1){
            Destroy(gameObject);
          }
          if(numbersession==1){
           DontDestroyOnLoad(gameObject);
          }  
          Debug.Log(numbersession);
    }
    void Start() {
        livestext.text=PlayerLife.ToString(); 
        scorestext.text= FScore.ToString();
        
    }
    public void ProcessPlayerDeath(){
        if(PlayerLife>1){
            TakeLife();
        }else{
            ResetGameSession();
        }
    }

     void TakeLife()
    {
        PlayerLife--;
        var CurrentScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);
         livestext.text=PlayerLife.ToString();    
       
    }

    void ResetGameSession()
    {
        FindObjectOfType<GamePersist>().ScencePersistence();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void Score(int pointAtTo){
       FScore+=pointAtTo;
        scorestext.text= FScore.ToString();
    }

    void Update()
    {
        
    }
}
