using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSubtract : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.subtractBody(foodNum);
    }

}
