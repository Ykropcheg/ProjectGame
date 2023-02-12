using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public float damage;
    public Animator anim;
    //public CinemachineVirtualCamera vcam;
    //public Transform obj;
    public bool isAttacking = false;

    private void Update()
    {

        if(timeBtwAttack <= 0){
            if(Input.GetMouseButton(0) && !isAttacking){
                isAttacking = true;
                int choose = UnityEngine.Random.Range(1, 4);
                anim.Play("Attack" + choose);
                //vcam.m_Lens.OrthographicSize = 10;
                //vcam.m_Follow = null;
                Invoke("ResetAttack", 0.5f);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else{
            timeBtwAttack -= Time.deltaTime;
        }
    }


    public void OnAttack(){
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++){
            damage = Random.Range(10f, 50f);
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void ResetAttack(){
        isAttacking = false;
    }
}
