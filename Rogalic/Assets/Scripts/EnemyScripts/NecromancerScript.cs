using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnPoint;
    public Transform player;
    public GameObject SkeletonHead;
    public Animator aniim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("AnimPlay", 5f);
    }

    public void SkeletonCast(){
        Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
    }

    public void AnimPlay(){
        aniim.Play("Necromancer_Priziv");
    }
}
