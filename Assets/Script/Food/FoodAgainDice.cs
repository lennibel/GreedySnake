using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAgainDice : Food
{
    public override void foodSkill(Snakes snakes)
    {
        snakes.gameLogic.randomDice = true;
        snakes.gameLogic.randomTime = snakes.gameLogic.randomTimeDefault;
        snakes.gameLogic.diceStep(snakes, 0);
    }

}
