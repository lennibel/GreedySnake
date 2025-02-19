using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTipText : MonoBehaviour
{
    public Snakes player;
    public GameLogic gameLogic;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        text.text = $"玩家名称:{player.name}\n" + 
                    $"剩余步数:{player.stepNum}\n" + 
                    $"总回合数:{player.playerInningNum}\n" +
                    $"身体长度:{player._body.Count}\n" +
                    $"历史步数:{player.positionHistory.Count}\n" +
                    $"本回合加:{player.playerInningNum}";

    }
}
