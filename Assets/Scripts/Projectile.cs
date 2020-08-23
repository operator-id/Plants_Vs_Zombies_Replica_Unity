using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float damage = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (attacker && health)
        {
            attacker.HitTheAttacker();
            health.DealDamage(damage);

            Destroy(gameObject);
        }
    }
}
