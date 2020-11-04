using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> refs/remotes/origin/master

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
<<<<<<< HEAD
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

=======

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
         
>>>>>>> refs/remotes/origin/master
            StartCoroutine(Die());

        }
    }
    IEnumerator Die()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
<<<<<<< HEAD

=======
        
>>>>>>> refs/remotes/origin/master
    }
    public float getHealth()
    {
        return health;
    }
<<<<<<< HEAD

    IEnumerator ShowHealthBar(float time)
    {
        healthSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        healthSlider.gameObject.SetActive(false);
    }
=======
>>>>>>> refs/remotes/origin/master
}
