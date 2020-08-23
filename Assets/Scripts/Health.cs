using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
         
            StartCoroutine(Die());

        }
    }
    IEnumerator Die()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
    }
    public float getHealth()
    {
        return health;
    }
}
