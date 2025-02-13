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

        text.text = $"player name:          {player.name}\n" + 
                    $"player step number:   {player.stepNum}\n" + 
                    $"player Inning Number: {player.playerInningNum}\n" +
                    $"body length:          {player._body.Count}\n" +
                    $"Inning Add number:    {player.playerInningNum}";

    }
}
