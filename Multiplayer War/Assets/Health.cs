using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public const int maxHealth = 100;
    public RectTransform healthBar;

    public int currentHealth = maxHealth;

    public void TakeDamage(int amount){

        currentHealth -= amount;

        if(currentHealth <= 0){
            currentHealth = 0;
            Debug.Log("Dead!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
}
