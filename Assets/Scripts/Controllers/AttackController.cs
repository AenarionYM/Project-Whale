using System;
using UnityEditor.Timeline;
using Controllers;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;


public class AttackController : MonoBehaviour
{
    public int damage;
    public float criticalChance = 0.2f;
    public float criticalDamageMultiplier = 2f;
    public AudioClip criticalSound;
    private AudioSource _audioSource;
    public GameObject criticalHitEffect;
    
    private bool markedForDeath;
    private float markedForDeathBonusCriticalChance;
    private float markedForDeathBonusCriticalDamageMultiplier;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameObj = other.gameObject;
        EnemyController enemyController = gameObj.GetComponent<EnemyController>();
        MarkedForDeath marked = gameObj.GetComponent<MarkedForDeath>();
        if (marked != null)
        {
            markedForDeath = true;
            markedForDeathBonusCriticalChance = marked.GetBonusCriticalChance();
            markedForDeathBonusCriticalDamageMultiplier = marked.GetBonusDamageMultiplier();
        }
        else
        {
            markedForDeath = false;
        }

        if (enemyController != null)
        {
            enemyController.TakeDamage(CalculateCriticalDamage(damage));
        }
    }
    
    // Check if critical is true
    public bool IsCritical()
    {
        float rng = Random.Range(0f, 1f);
        
        if (markedForDeath)
        {
            return rng <= criticalChance + markedForDeathBonusCriticalChance;
        }
        else
        {
            return rng <= criticalChance;
        }
        
    }

    public int CalculateCriticalDamage(int baseDamage)
    {
        if (IsCritical())
        {
            _audioSource = GetComponentInParent<AudioSource>();
            _audioSource.PlayOneShot(criticalSound);
            if (markedForDeath)
            {
                TriggerCriticalHitEffect();
                return Mathf.RoundToInt(baseDamage * (criticalDamageMultiplier + markedForDeathBonusCriticalDamageMultiplier));
            }
            else
            {
                TriggerCriticalHitEffect();
                return Mathf.RoundToInt(baseDamage * criticalDamageMultiplier);
            }
            
        }
        return baseDamage;
    }

    public void TriggerCriticalHitEffect()
    {
        if (criticalHitEffect != null)
        {
            Instantiate(criticalHitEffect, transform.position, Quaternion.identity);
        }
    }
}
