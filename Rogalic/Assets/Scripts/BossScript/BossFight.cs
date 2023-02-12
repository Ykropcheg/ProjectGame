using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Vector2 vec;
    public bool faceRight = true;
    public Transform SpawnPos;
    public GameObject orb;
    public bool isShooting = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        Reflect();
        //OrbShoot();
    }

    // void OrbShoot(){
    //     if(!isShooting){
    //         isShooting = true;
    //         Invoke("ShootLock", 10f);
    //         Instantiate(orb, SpawnPos.position, Quaternion.identity);
    //     }
        
    // }
    // void ShootLock(){
    //     isShooting = false;
    // }
    void Reflect(){
        if ((vec.x > 0 && !faceRight) || (vec.x < 0 && faceRight)){
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
}
