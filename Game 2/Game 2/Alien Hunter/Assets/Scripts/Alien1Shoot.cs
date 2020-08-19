using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien1Shoot : MonoBehaviour
{
    [SerializeField]
    Transform player;

    public GameObject projectile;

    [SerializeField]
    float moveSpeed;

    private float timeBtwShots;
    public float startTimeBtwShots;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float shootRange;

    Rigidbody2D rb2d;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
            animator.Play("Alien_walk");
        }
        else if (distToPlayer < shootRange)
        {
            ShootPlayer();
            animator.Play("Alien_shoot");
        }
        else
        {
            StopChasingPlayer();
            animator.Play("Alien_idle");
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

    private void ShootPlayer()
    {
        rb2d.velocity = Vector2.zero;

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }
}
