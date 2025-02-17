using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEnableTrigger : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.enableFoodTrigger = false;
    }


}
