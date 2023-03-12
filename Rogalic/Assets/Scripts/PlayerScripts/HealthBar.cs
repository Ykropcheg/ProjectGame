using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Image HealApple;
    public float HP;
    public float _maxHealth = 100f;
    public Animator _anim;
    private bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GetComponent<Image>();
        HP = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > _maxHealth){
            HP = _maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.R) && HealApple.fillAmount > 0){
            Heal();
        }
        if(HP <= 0){
            canTakeDamage = false;
            GameObject obj = GameObject.Find("Knight");
            CharacterController script1 = obj.GetComponent<CharacterController>();
            PlayerAttack script2 = obj.GetComponent<PlayerAttack>();
            HealthBar script3 = obj.GetComponent<HealthBar>();
            script1.enabled = false;
            script2.enabled = false;
            script3.enabled = false;
            _anim.Play("Death");
            
        }
        
        
    }

    public void PlayerTakeDamage(float dmg){
        if (canTakeDamage){
            _anim.Play("Hurt");
            HP -= dmg;
            healthBar.fillAmount = HP / _maxHealth;
        }
    }

    public void SceneReload(){
        SceneManager.LoadScene(1);
    }

    void Heal(){
        HP += 25;
        healthBar.fillAmount = HP / _maxHealth;
        HealApple.fillAmount -= 0.25f;
    }

}
