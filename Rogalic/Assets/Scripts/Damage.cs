using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float timebtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int dmg;
    //public Animator anim;

    private void Update(){
        if (timebtwAttack <= 0){
            if (Input.GetMouseButton(0)){
                //anim.SetTrigger("attack");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemies.Length; i++){
                    enemies[i].GetComponent<Enemy>().TakeDamage(dmg);
                }
            }
            timebtwAttack = startTimeBtwAttack;
        }
        else{
            timebtwAttack -= Time.deltaTime;
        }
    }
     private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
     }


}
