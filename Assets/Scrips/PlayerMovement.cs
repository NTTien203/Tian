using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed=2f;
    [SerializeField] float JumpSpeed=2f;
     float CurrentGravity=10f;
    Vector2 MoveInput;
    Rigidbody2D MyRigidbody;
    Animator MyAnimator;
    CapsuleCollider2D MyCapSuleCollider;
    BoxCollider2D TianFeetCollider;
    SpriteRenderer MySprite;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Place;
    bool IsAlive=true;
  
     void Start() {
     MyRigidbody=GetComponent<Rigidbody2D>();
     MyAnimator=GetComponent<Animator>();
     MyCapSuleCollider=GetComponent<CapsuleCollider2D>();
    TianFeetCollider=GetComponent<BoxCollider2D>();
    MySprite=GetComponent<SpriteRenderer>();
     CurrentGravity=MyRigidbody.gravityScale; 
    }
    void Update()
    {
        if(!IsAlive){
            return;
        }
        run();
        FlipSprite();
        climbing();
        Died();
      
    }
    void FlipSprite(){
        bool PlayerDerection=Mathf.Abs(MyRigidbody.velocity.x)>Mathf.Epsilon;
    if(PlayerDerection){
         transform.localScale=new Vector2(Mathf.Sign(MyRigidbody.velocity.x),1);   
    }
    }
     
    void OnJump(InputValue value){
        if(!TianFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}
        if(value.isPressed){
            MyRigidbody.velocity+=new Vector2(0f,JumpSpeed);
        }
    }

   
    void run(){
        if(!IsAlive){
            return;
        }
        MyRigidbody.velocity= new Vector2(MoveInput.x*MoveSpeed,MyRigidbody.velocity.y);
         bool PlayerHasHorizontalSpeed=Mathf.Abs(MyRigidbody.velocity.x)>Mathf.Epsilon;
            MyAnimator.SetBool("IsRunning",PlayerHasHorizontalSpeed);
    }
     void OnMove(InputValue value){
        MoveInput=value.Get<Vector2>();
    }
    void climbing(){
        if(!IsAlive){
            return;
        }
         bool PlayerHasHorizontalSpeed=Mathf.Abs(MyRigidbody.velocity.y)>Mathf.Epsilon;
        if(TianFeetCollider.IsTouchingLayers(LayerMask.GetMask("Stair"))){
             MyRigidbody.velocity=new Vector2(MyRigidbody.velocity.x,MoveInput.y*MoveSpeed);
             MyRigidbody.gravityScale=0f;
             MyAnimator.SetBool("IsClimbing",PlayerHasHorizontalSpeed);
        }else{
            MyRigidbody.gravityScale=CurrentGravity;
           MyAnimator.SetBool("IsClimbing",false);
        }
    }    
    
    void Died(){
        if(MyRigidbody.IsTouchingLayers(LayerMask.GetMask("Enermy","Hazard"))){
            IsAlive=false;
            MyAnimator.SetTrigger("die");
             MyRigidbody.velocity+=new Vector2(3f,JumpSpeed);
            MySprite.color=Color.green;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
    void OnFire(InputValue value){
        Instantiate(Bullet,Place.position,transform.rotation);
    }
}
