using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int startingHealth = 50;
    [SerializeField] private TextMeshProUGUI healthText;
    private int currentHealth;

    void Start()
    {
        currentHealth = Mathf.Clamp(startingHealth, 0, maxHealth);
        UpdateHealthText();
    }


  


    public void Health(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP" + currentHealth + "/" + maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Heal(int healAmount)
    {
        throw new NotImplementedException();
    }
}
