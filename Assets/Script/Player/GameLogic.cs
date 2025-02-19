using UnityEngine;
using UnityEngine.UI;

public enum E_PlayerType { TURNA, TURNB }
public class GameLogic : MonoBehaviour
{
    [Header("input parameter")]
    public Snakes playerA;
    public Snakes playerB;
    public Text diceUI;
    public Text tipUI;
    public E_PlayerType playerType;
    public Color playerADiceColor;
    public Color playerBDiceColor;
    [HideInInspector] public int step;
    [HideInInspector] public bool playGame = true;
    [HideInInspector]public float randomTime;
    [HideInInspector]public float randomTimeDefault = 0.5f;
    [HideInInspector]public bool randomDice = true;
    [HideInInspector]public bool collectionIsOver = false;

    [Header("display text")]
    public string playerA_Name = "红方";
    public string playerB_Name = "蓝方";
    public string winText = "";



    void Start()
    {
        playerType = E_PlayerType.TURNA;
        diceUI.color = playerADiceColor;
        tipUIAnimation($"{playerA_Name[0]} {playerA_Name[1]} 回 合");
    }

    void Update()
    {
        if (playGame)
        {
            if (playerType == E_PlayerType.TURNA)
            {
                diceStep(playerA,1);
                if (step == 0 && collectionIsOver)
                {
                    playerType = E_PlayerType.TURNB;
                    playerB.resetInningParameter();
                    randomDice = true;
                    randomTime = randomTimeDefault;
                    tipUIAnimation($"{playerB_Name[0]} {playerB_Name[1]} 回 合");
                    diceUI.color = playerBDiceColor;
                }
            }
            else
            {
                diceStep(playerB,1);
                if (step == 0 && collectionIsOver)
                {
                    playerType = E_PlayerType.TURNA;
                    playerA.resetInningParameter();
                    randomDice = true;
                    randomTime = randomTimeDefault;
                    diceUI.color = playerADiceColor;
                    tipUIAnimation($"{playerA_Name[0]} {playerA_Name[1]} 回 合");
                }
            }
        }
        else
        {
            if (playerType == E_PlayerType.TURNA)
            {
                tipUI.text = $"游 戏 结 束  {winText}";
                diceUI.text = "×";
            }
            else
            {
                tipUI.text = $"游 戏 结 束  {winText}";
                diceUI.text = "×";
            }

        }
    }

    public void diceStep(Snakes player, int inningAdd)
    {
        if (randomDice)
        {
            int randomStep = Random.Range(1, 6);

            randomTime -= Time.deltaTime;
            if (randomTime > 0)
            {
                diceUI.text = randomStep.ToString();
                step = randomStep;
            }
            else
            {
                diceUI.text = randomStep.ToString();
                player.stepNum = randomStep;
                step = randomStep;
                player.playerInningNum += inningAdd;
                player.doubleSpeedInningNum -= 1;
                randomDice = false;
            }
        }
        else
        {
            diceUI.text = player.stepNum.ToString();
        }
    }

    protected void tipUIAnimation(string inputText)
    {
        //float AnimationTime = 1.5f;
        tipUI.text = inputText;

        // AnimationTime -= Time.deltaTime;
        // print(AnimationTime);

        // float s = Mathf.Max(AnimationTime, 1.0f);
        // tipUI.transform.localScale = new Vector3(s, s, s);
    }
}
