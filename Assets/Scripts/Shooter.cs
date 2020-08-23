using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject bow;
    [SerializeField] float attackCooldown;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    float health;
    float cooldownTimer;

    const string PROJECTILE_PARENT_NAME = "Projectiles";
    GameObject projectileParent;
    private void Start()
    {

        animator = GetComponent<Animator>();
        SetLaneSpawner();

        SetProjectileParent();
    }

    private void SetProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()

    {
        health = GetComponent<Health>().getHealth();
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
        }
        // to be done
        else if (animator.GetBool("IsIdling") && IsAttackerInLane())
        {
            
            cooldownTimer += Time.deltaTime;
            animator.SetBool("IsAttacking", false);

            if (cooldownTimer> attackCooldown)
            {
                Debug.Log("Archer idling");
                animator.SetBool("IsAttacking", true);
                animator.SetBool("IsIdling", false);
                cooldownTimer = 0;
            }
            
        }
        else if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
           
           
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(attackerSpawner.transform.position.y - this.transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                Debug.Log("Found spawner!" + attackerSpawner.transform.position.y);
                myLaneSpawner = attackerSpawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, bow.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

    public void DoAttackCooldown()
    {
        animator.SetBool("IsIdling", true);
    }
}