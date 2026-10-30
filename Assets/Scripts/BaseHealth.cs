using UnityEngine;
using TMPro;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public TMP_Text baseHealthText;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdateHealthText();

            Debug.Log("Base Destroyed!");
        }
    }

    void UpdateHealthText()
    {
        baseHealthText.text = "Base Health: " + currentHealth;
    }
}