using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAdd : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.AddBody();
        snakes.thisInningAddNum += 1;
    }


}
