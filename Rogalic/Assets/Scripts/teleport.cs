using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class teleport : MonoBehaviour
{
    public GameObject portal;
    private GameObject player;
    public CinemachineVirtualCamera vcam;
    public Transform follower;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            vcam.m_Lens.OrthographicSize = 7;
            vcam.m_Follow = follower;
        }
    }
}
