using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public float damage;
    
    void FixedUpdate()
    {
        transform.Translate(speed*dir*Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
        
    }
}
