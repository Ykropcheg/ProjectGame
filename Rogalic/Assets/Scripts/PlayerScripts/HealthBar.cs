using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float HP;
    public GameObject go;
    public float _maxHealth = 100f;
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GetComponent<Image>();
        HP = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerTakeDamage(float dmg){
        _anim.Play("Hurt");
        HP -= dmg;
        healthBar.fillAmount = HP / _maxHealth;
        if(HP <= 0){
            Destroy(go);
        }
    }
}
