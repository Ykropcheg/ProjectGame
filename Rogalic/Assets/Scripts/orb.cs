using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    private float dmg = 20.5f;
    
    void FixedUpdate()
    {
        transform.Translate(speed*dir*Time.deltaTime, Space.World);
        Invoke("destr", 2f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            other.GetComponent<HealthBar>().PlayerTakeDamage(dmg);
            Destroy(gameObject);
        } 
    }
    private void destr(){
        Destroy(gameObject);
    }
}
