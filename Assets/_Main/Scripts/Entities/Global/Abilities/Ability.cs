using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public class Ability
    {
        
        public string name = "";
        public float currentCharge = 1.0f;
        public float totalCharge = 1.0f;
        public float cdRate = 0.01f;//Rate at which abilty recharges by frame

        public bool hold = false;//Is player about to launch the ability
        public bool ready = true;//Is ability ready to use
        public bool recharging = false;

        Cursor cursor;

        public Ability(Cursor cursor)
        {

            this.cursor = cursor;

        }

        public void Recharge()
        {
            
            if (currentCharge + cdRate >= totalCharge)
            {
                currentCharge = totalCharge;
                recharging = false;

                ready = true;
                Debug.Log("Ability ready");
            }
            else
            {
                currentCharge += cdRate;
            }

        }

        public void ReadyToRecharge()
        {

            Debug.Log("Charging...");
            recharging = true;
        }

        public virtual void Use()
        {

            ready = false;

        }

        public virtual void Use(Vector3 target)
        {

            ready = false;

        }

        public virtual void Use(GameObject target)
        {

            ready = false;
        }

        public void ToggleHold()
        {
            hold = !hold;

            //Also toggle cursor visibility
            if(cursor != null) cursor.ToggleVisibility();
        }
    }
}