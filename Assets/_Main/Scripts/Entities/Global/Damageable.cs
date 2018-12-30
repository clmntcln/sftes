using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{

    public int hp = 10;
    [Range(1, 100)]
    public int maxHP = 10;

    // Start is called before the first frame update
    void Start()
    {

        hp = maxHP;

        //TODO
        //Instantiate health bar and and damage overhead figures

        //TODO
        //Get the animator for feedback
        //Get audio for feedback

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if(hp - amount <= 0)
        {

            hp = 0;
            Die();

        } else {

            hp -= amount;
            //Audio + Visual feedback

        }
    }

    void Die()
    {
        Debug.Log("im ded");
    }
}
