using UnityEngine;

public class DemonScript : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float dmg;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private bool canCast = false;
    private Animator anim;
    private HealthBar playerHealth;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight()){
            if (cooldownTimer >= attackCooldown){
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }

        }
        
    }
    private bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x,
        new Vector3(boxCollider.bounds.size.x * colliderDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        
        if (hit.collider != null){
            playerHealth = hit.transform.GetComponent<HealthBar>();
        }

        return hit.collider != null;
    }

    void cast(){
        if (canCast){
            canCast = false;
            Invoke("canCastFunc", 5f);
            anim.Play("Demon_Cast");
        }
    }
    void canCastFunc(){
        canCast = true;
        GetComponent<Chase>().enabled = false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x, 
            new Vector3(boxCollider.bounds.size.x * colliderDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    

    void HealingSpell(){
        GetComponent<Enemy>().health += 50f;
    }

    private void DamagePlayer(){
        if (PlayerInSight()){
            playerHealth.PlayerTakeDamage(dmg);
        }
    }
}
