using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Vector2 vec;
    public bool faceRight = true;
    public Transform SpawnPos;
    public GameObject[] orb;
    public bool isShooting = false;
    public Transform player;
    
    void Start()
    {
        
    }

    void Update()
    {
        Reflect();
        OrbShoot();
    }

    void OrbShoot(){
        if(!isShooting){
            isShooting = true;
            Invoke("ShootLock", 10f);
            int i = 0;
            if(player.position.x > SpawnPos.position.x){
                i = 0;
            }
            if(player.position.x < SpawnPos.position.x){
                i = 1;
            }
            Instantiate(orb[i], SpawnPos.position, Quaternion.identity);
        }
        
    }
    void ShootLock(){
        isShooting = false;
    }
    void Reflect(){
        if ((vec.x > 0 && !faceRight) || (vec.x < 0 && faceRight)){
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
}
