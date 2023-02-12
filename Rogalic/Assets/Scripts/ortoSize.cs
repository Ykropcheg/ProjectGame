using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ortoSize : MonoBehaviour
{ 
    public CinemachineVirtualCamera vcam;
    void Start()
    {

    }

    public void OrtoSize(){
        vcam.m_Lens.OrthographicSize = 10;
    }
}
