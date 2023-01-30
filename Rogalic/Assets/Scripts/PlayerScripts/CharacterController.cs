using UnityEngine;
using System.Collections;
using System;

public class CharacterController : MonoBehaviour 
{
    public Rigidbody2D rb;
    public Vector2 vec;
    public float speed = 2f;
    public float jumpForce = 7f;
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    public Animator anim;
    public SpriteRenderer sr;
    public bool faceRight = true;

    private Interactable interactableObj;

    [Header("Dash Settings")]
    public int dashImpulse = 10000;
    public static bool haveDash = false;
    private bool lockDash = false;

    private bool _dash;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update(){
        Walk();
        Jump();
        CheckGround();
        Reflect();
        Dash();
        DeathZone();
        if (Input.GetKeyDown(KeyCode.E)){
            InteractWithObj();
        }
    }


    //===============MOVE===============
    void Walk(){
        vec.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(vec.x));
        rb.velocity = new Vector2(vec.x * speed, rb.velocity.y);
    }
    //===============JUMP===============
    void Jump(){
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && onGround){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //===============PROVERKA===============
    void CheckGround(){
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    //===============FLIP-TOKA-LUCHSHE===============
    void Reflect(){
        if ((vec.x > 0 && !faceRight) || (vec.x < 0 && faceRight)){
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    //===============Dash===============
    void Dash(){
        if((Input.GetKey(KeyCode.LeftShift) && !lockDash) && haveDash){

            lockDash = true;
            Invoke("LockDash", 2f);

            rb.velocity = new Vector2(0, 0);
            if (rb.transform.localScale.x < 0){
                rb.AddForce(Vector2.left * dashImpulse);
            }
            else{
                rb.AddForce(Vector2.right * dashImpulse);
            }
        }
    }

    void LockDash(){
        lockDash = false;
    }

    //===============DeathZone===============
    void DeathZone(){
        if(transform.position.y <= -2f){
            destroyEventCharacter();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Interactable"){
            interactableObj = collision.gameObject.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Interactable"){
            interactableObj = null;
        }
    }

    public void InteractWithObj(){
        if (interactableObj != null){
            interactableObj.Interact();
        }
    }


    public void destroyEventCharacter()
    {
        Destroy(gameObject);
    } 

}