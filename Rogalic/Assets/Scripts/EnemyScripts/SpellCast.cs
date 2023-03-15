using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    private Transform player;
    private float dmg = 25;
    [SerializeField]private bool canDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Knight" && canDamage)
            other.GetComponent<HealthBar>().PlayerTakeDamage(dmg);
    }

    void DeathHand(){
        canDamage = true;
    }

}
