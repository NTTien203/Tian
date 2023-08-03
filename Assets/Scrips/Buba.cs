using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buba : MonoBehaviour
{
    Rigidbody2D MyRigidBody;
    [SerializeField] float MoveSpeed=1f;
    void Start()
    {
        MyRigidBody=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MyRigidBody.velocity= new Vector2(MoveSpeed,0f);        
    }
      void OnTriggerExit2D(Collider2D other) {
          MoveSpeed=-MoveSpeed;
        FlipEnermyFacing();    
     }
    void FlipEnermyFacing(){
        transform.localScale=new Vector2(Mathf.Sign(MoveSpeed),1f);
    }
}
