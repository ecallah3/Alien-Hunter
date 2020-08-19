using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agro script for enemies, so rename for all enemies? ------------------------------------------------------

public class Alien2Agro : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float attackRange;

    [SerializeField]
    GameObject enemyAttackHitbox;

    Rigidbody2D rb2d;
    Animator animator;
    float delay = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyAttackHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Distance check method (raycast could be an alternative)
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
            animator.Play("Alien2_walk");
        }
        else if (distToPlayer < attackRange)
        {
            StartCoroutine(AttackPlayer(delay));
            animator.Play("Alien2_attack");
        }
        else
        {
            StopChasingPlayer();
            animator.Play("Alien2_Stand");
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is left of player = move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            //enemy is right of player = move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    IEnumerator AttackPlayer(float delay)
    {
        enemyAttackHitbox.SetActive(true); ;
        yield return new WaitForSeconds(delay);
        enemyAttackHitbox.SetActive(false);
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }

}
