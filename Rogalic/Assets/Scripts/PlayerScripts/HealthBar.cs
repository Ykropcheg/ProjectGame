using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public float HP;
    public float _maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        HP = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = HP / _maxHealth;
    }
}
