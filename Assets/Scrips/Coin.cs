using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip CoinCollectSFX;
    [SerializeField] int PointCollectScore=1000;
    bool Collected=false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player" && !Collected){
            AudioSource.PlayClipAtPoint(CoinCollectSFX,Camera.main.transform.position);
            Collected=true;
            Destroy(gameObject);
            FindObjectOfType<GameSession>().Score(PointCollectScore);
        }
    }
    
}
