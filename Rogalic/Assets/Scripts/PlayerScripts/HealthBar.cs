using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float HP;
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
            GameObject obj = GameObject.Find("Knight");
            CharacterController script1 = obj.GetComponent<CharacterController>();
            PlayerAttack script2 = obj.GetComponent<PlayerAttack>();
            script1.enabled = false;
            script2.enabled = false;
            _anim.Play("Death");
        }
    }

    public void SceneReload(){
        SceneManager.LoadScene(1);
    }
}
