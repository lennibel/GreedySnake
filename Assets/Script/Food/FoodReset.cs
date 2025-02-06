using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReset : Food
{
    public override void foodSkill()
    {
        CreateFood c = transform.parent.GetComponent<CreateFood>();
        c.createFoods();
    }

}