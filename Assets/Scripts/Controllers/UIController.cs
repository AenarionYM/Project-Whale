using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;
    public Slider manaSlider;

    public float staminaRegenRate = 10f;
    public float stamingaRegenDelay = 2f;
    
    public bool isStaminaRegening = true;
    private float staminaRegenTimer;

    public float currentHealth;
    public float currentStamina;
    public float currentMana;
    
    public float maxStamina;
    public float maxHealth;
    public float maxMana;

    private void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        manaSlider.maxValue = maxMana;
        manaSlider.value = maxMana;
    }

    private void Update()
    {
        if (isStaminaRegening)
        {
            StaminaRegen();
        }
        else
        {
            StaminaTimer();
        }
    }


    public void UpdateHealth(float healthChange)
    {
        currentHealth = healthSlider.value;
        currentHealth += healthChange;
        Mathf.Clamp(currentHealth, 0, healthSlider.maxValue);
        healthSlider.value = currentHealth;
    }
    
    public void UpdateStamina(float staminaChange)
    {
        currentStamina = staminaSlider.value;
        currentStamina += staminaChange;
        Mathf.Clamp(currentStamina, 0, staminaSlider.maxValue);
        staminaSlider.value = currentStamina;
        isStaminaRegening = false;
    }

    public void UpdateMana(float manaChange)
    {
        currentMana = manaSlider.value;
        currentMana += manaChange;
        Mathf.Clamp(currentMana, 0, manaSlider.maxValue);
        manaSlider.value = currentMana;
    }

    public void StaminaRegen()
    { 
        currentStamina += staminaRegenRate * Time.deltaTime;
        staminaSlider.value = currentStamina;
    }

    public void StaminaTimer()
    {
        staminaRegenTimer += Time.deltaTime;
        if (staminaRegenTimer >= Time.deltaTime + stamingaRegenDelay)
        {
            isStaminaRegening = true;
            staminaRegenTimer = 0;
        }
    }
}
