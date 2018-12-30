﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{

    public class Move : Ability
    {

        string name = "Move";
        public float speed = 1.0f;
        GameObject objToMove;

        public Move(GameObject obj, float totalCharge, float cooldownRate, Cursor cursor) : base(cursor)
        {
            this.objToMove = obj;
            this.currentCharge = totalCharge;
            this.totalCharge = totalCharge;
            this.cdRate = cooldownRate;
        }

        public override void Use(Vector3 target)
        {
            
            if (!ready) return;

            base.Use(target);

            float dist = Vector3.Distance(objToMove.transform.position, target);

            Hashtable parameters = new Hashtable();

            parameters.Add("position", target);
            parameters.Add("time", dist / speed);
            parameters.Add("oncomplete", "ReadyToRecharge");

            iTween.MoveTo(objToMove, parameters);

            this.currentCharge = 0;

            ReadyToRecharge();

        }
    }

}

