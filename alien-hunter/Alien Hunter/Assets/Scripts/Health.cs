using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player Health Script -------------------------------------------------------------

public class Health : MonoBehaviour
{
    public int health;
    public int numOfTicks;

    public Image[] ticks;
    public Sprite fullTick;
    public Sprite emptyTick;

    private void Update()
    {
        if (health > numOfTicks)
        {
            health = numOfTicks;
        }

        for (int i = 0; i < ticks.Length; i++)
        {
            if (i < health)
            {
                ticks[i].sprite = fullTick;
            }
            else
            {
                ticks[i].sprite = emptyTick;
            }
            if (i < numOfTicks)
            {
                ticks[i].enabled = true;
            }
            else
            {
                ticks[i].enabled = false;
            }
        }
    }
}
