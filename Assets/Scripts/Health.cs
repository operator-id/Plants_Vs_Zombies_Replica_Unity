using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] Slider healthSlider;

     private void Start()
    {
        
        healthSlider.maxValue = health;
        healthSlider.gameObject.SetActive(false);
        healthSlider.value = health;
    }

 
    public void DealDamage(float damage)
    {
        health -= damage;
        healthSlider.value -= damage;
        StartCoroutine(ShowHealthBar(4.5f));

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

    IEnumerator ShowHealthBar(float time)
    {
        healthSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        healthSlider.gameObject.SetActive(false);
    }
}
