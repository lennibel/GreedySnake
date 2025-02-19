using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCutTail : Food
{
    public override void foodSkill(Snakes snakes)
    {
        for(int i = snakes.thisInningAddNum; i > 0 ; i--)
        {
            snakes._body[snakes._body.Count - 1].GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.5f,0.5f);

            snakes._body.RemoveAt(snakes._body.Count -1);
        }
        snakes.thisInningAddNum = 0;
    }
}
