using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoodDoubleStep : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.doubleSpeedInningNum = Mathf.Max(snakes.doubleSpeedInningNum, 0);
        snakes.doubleSpeedInningNum += 2;
    }
}
