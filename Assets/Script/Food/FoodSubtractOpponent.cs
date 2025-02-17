using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSubtractOpponent : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.opponent.subtractBody(snakes.opponent.thisInningAddNum);
    }

}
