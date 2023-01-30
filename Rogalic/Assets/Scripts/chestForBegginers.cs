using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestForBegginers : MonoBehaviour, Interactable
{
    public bool canuseDash = false;

    public void Interact(){
        GetComponent<Animator>().SetTrigger("Open");
    }

    public void PutLoot(){
        CharacterController.haveDash = true;
    }
}
