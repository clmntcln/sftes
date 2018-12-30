using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{

    public class Shoot : Ability
    {

        public string name = "Shoot";
        public int damage = 1;

        int damageableLayer;

        public Shoot(float totalCharge, float cooldownRate, Cursor cursor) : base(cursor)
        {
            this.currentCharge = totalCharge;
            this.totalCharge = totalCharge;
            this.cdRate = cooldownRate;

            damageableLayer = LayerMask.GetMask("Damageable");
        }

        public override void Use(GameObject target)
        {

            if (!ready) return;

            base.Use(target);

            Debug.Log("Shoot");

            if (target != null)
            {

                Damageable damageableEntity = target.GetComponent<Damageable>();

                damageableEntity.TakeDamage(damage);

                Debug.Log("Hit");

            }

            this.currentCharge = 0;

            ReadyToRecharge();

        }
    }

}

