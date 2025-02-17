using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReverse : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.opponent.reverseBody();
        if (foodNum == 2) snakes.reverseBody();
    }

}
