using UnityEngine;

public class SpellcastController : MonoBehaviour
{
    
    private GameObject _player;
    
    public LayerMask enemyLayer; 
    public float markRange = 10f;

    public bool markForDeath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Start()
    {
        CastMarkSpell();
    }
    
    void CastMarkSpell()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        // Find the nearest enemy within range
        Collider2D[] hits = Physics2D.OverlapCircleAll(_player.transform.position, markRange, enemyLayer);
        if (hits.Length > 0)
        {
            // Mark the first enemy in range
            GameObject enemy = hits[0].gameObject;
            if (enemy.GetComponent<MarkedForDeath>() == null)
            {
                enemy.AddComponent<MarkedForDeath>();
                MarkedForDeath markedComponent = enemy.GetComponent<MarkedForDeath>();
                markedComponent.MarkEnemy();
            }
            else
            {
                Debug.Log("Enemy is marked");
            }

        }
        else
        {
            Debug.Log("No enemy in range to mark!");
        }
    }
}
