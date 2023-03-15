using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField] private float rangeSight;
    [SerializeField] private float colliderDistanceSight;
    [SerializeField] private BoxCollider2D boxColliderSight;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float speed;
    [SerializeField] private Transform enemy;
    private Rigidbody2D rb;
    private Vector3 initScale;
    private Transform player;
    private void Awake() {
        initScale = enemy.localScale;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSightInDistance()){
            if (enemy.position.x < player.position.x)
            MoveInDirection(1);
            else{
                MoveInDirection(-1);
            }
        }
            
    }
    private bool PlayerInSightInDistance(){
        RaycastHit2D hitSight = Physics2D.BoxCast(boxColliderSight.bounds.center + transform.right * rangeSight * transform.localScale.x,
        new Vector3(boxColliderSight.bounds.size.x * colliderDistanceSight, boxColliderSight.bounds.size.y, boxColliderSight.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        
        if (hitSight.collider != null){
            player = GameObject.FindWithTag("Player").transform;
        }

        return hitSight.collider != null;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxColliderSight.bounds.center + transform.right * rangeSight * transform.localScale.x, 
            new Vector3(boxColliderSight.bounds.size.x * colliderDistanceSight, boxColliderSight.bounds.size.y, boxColliderSight.bounds.size.z));
    }

    private void MoveInDirection(int _directional){
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _directional * -1, initScale.y, initScale.z);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _directional * speed, transform.position.y, transform.position.z);
    }
}
