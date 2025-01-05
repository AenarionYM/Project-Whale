using System;
using UnityEngine;

public class MarkedForDeath : MonoBehaviour
{
    [Header("Marked For Death Settings")]
    public float bonusCriticalChance = 0.2f;
    public float bonusDamageMultiplier = 1.5f;
    public float duration = 10f;

    private bool _isMarked = false;
    private float _markTimer = 0f;

    public void MarkEnemy()
    {
        if (!_isMarked)
        {
            _isMarked = true;
            _markTimer = duration;
            Debug.Log("Marked For Death!");
            //Add Visual
        }
    }

    private void Update()
    {
        if (_isMarked)
        {
            _markTimer -= Time.deltaTime;
            if (_markTimer <= 0f)
            {
                UnmarkEnemy();
            }
        }
    }

    private void UnmarkEnemy()
    {
        _isMarked = false;
        Debug.Log("Mark is expired");
        Destroy(this);
        //Remove Visual
    }

    public bool IsMarked()
    {
        return _isMarked;
    }
    
    // Apply bonus effects (critical chance and damage) if the enemy is marked
    public float GetBonusCriticalChance()
    {
        return bonusCriticalChance;
    }

    public float GetBonusDamageMultiplier()
    {
        return bonusDamageMultiplier;
    }
    
    
}
