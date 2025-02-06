using UnityEngine;
using UnityEngine.UI;

public enum E_PlayerType { TURNA, TURNB }
public class GameLogic : MonoBehaviour
{
    [Header("input parameter")]
    public Snakes playerA;
    public Snakes playerB;
    [HideInInspector]public int playerAInningNum;
    [HideInInspector]public int playerBInningNum;
    public Text diceUI;
    public Text tipUI;
    public E_PlayerType playerType;
    [HideInInspector] public int step;
    [HideInInspector] public bool playGame = true;
    protected float randomTime = 1;
    protected bool randomDice = true;

    [Header("display text")]
    public string playerA_Name = "红方";
    public string playerB_Name = "蓝方";
    public string winText = "";



    void Start()
    {
        playerAInningNum = 0;
        playerBInningNum = 0;
        playerType = E_PlayerType.TURNA;
        diceUI.color = new Color(.8f, 0, 0, 0.5f);
        tipUIAnimation($"{playerA_Name[0]} {playerA_Name[1]} 回 合");
    }

    void Update()
    {
        if (playGame)
        {
            if (playerType == E_PlayerType.TURNA)
            {
                diceStep(playerA,ref playerAInningNum);
                if (step == 0)
                {
                    playerType = E_PlayerType.TURNB;
                    randomDice = true;
                    randomTime = 1;
                    tipUIAnimation($"{playerB_Name[0]} {playerB_Name[1]} 回 合");
                    diceUI.color = new Color(0, 0, 1, 0.5f);
                }
            }
            else
            {
                diceStep(playerB,ref playerBInningNum);
                if (step == 0)
                {
                    playerType = E_PlayerType.TURNA;
                    randomDice = true;
                    randomTime = 1;
                    diceUI.color = new Color(.8f, 0, 0, 0.5f);
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

    public void diceStep(Snakes player,ref int inningNum)
    {
        if (randomDice)
        {
            int randomStep = Random.Range(1, 7);

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
                inningNum += 1;
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
