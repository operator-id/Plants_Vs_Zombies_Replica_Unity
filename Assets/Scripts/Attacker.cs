using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float preferredWalkSpeed = 1f;
    [SerializeField] float timeStunned = .5f;
    [SerializeField] float attackCooldown = .5f;
    [SerializeField] float damage = 50f;
    private Animator animator;
    private float stunTimer;
    private float cooldownTimer;
    private float health;
    private GameObject target;
    private float currentSpeed;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerDestroyed();
        }
        
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = preferredWalkSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<Health>().getHealth();


        if (animator.GetBool("IsHit"))
        {

            if (health <= 0)
            {
                animator.SetBool("IsDead", true);


            }
            if (stunTimer >= timeStunned)
            {
                stunTimer = 0;
                animator.SetBool("IsHit", false);
            }
            else
            {
                stunTimer += Time.deltaTime;
            }
        }
        else if (animator.GetBool("IsIdling"))
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer > attackCooldown)
            {
                Debug.Log("End Idling");
                animator.SetBool("IsIdling", false);
                cooldownTimer = 0;
            }
            
        }
        else if (animator.GetBool("IsAttacking"))
        {
            if (!target)
            {
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsIdling", false);
            }

        }

        else if (animator.GetBool("IsDead") == false) 
        {
            //currentSpeed = preferredWalkSpeed;
            transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
            
            
        }
    }
    public void Attack(GameObject target)
    {
        
        animator.SetBool("IsAttacking", true);
        this.target = target;
    }

    public void StrikeTarget()
    {
        if (!target) { return; }
        Health health = target.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
    public void HitTheAttacker()
    {
        animator.SetBool("IsHit", true);
  
    }
    public void DoAttackCooldown()
    {
        animator.SetBool("IsIdling", true);
    }
}
