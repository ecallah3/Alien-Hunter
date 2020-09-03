using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rename to EnemyHealth? --------------------------------------------------------------------------
public class AlienController : MonoBehaviour
{
    [SerializeField]
    int health = 5;

    //materials
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerHitbox"))
        {
            health--;
            sr.material = matWhite;

            if (health <= 0)
            {
                KillSelf();
            }
            else
            {
                Invoke("ResetMaterial", .3f);
            }
        }
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void KillSelf()
    {
        Destroy(gameObject);
    }
}
