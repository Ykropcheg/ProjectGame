using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonHead : MonoBehaviour
{
    private Transform playerTarget;
    public int speed = 5;
    public float dmg = 10;
    // Update is called once per frame
    private void Start() {
        playerTarget = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        Move();
    }

    void Move(){
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == GameObject.FindWithTag("Player")){
            other.GetComponent<HealthBar>().PlayerTakeDamage(dmg);
            Destroy(gameObject);
        }  
    }
}
