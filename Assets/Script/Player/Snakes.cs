using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public abstract class Snakes : MonoBehaviour
{
    public GameObject SnakeSegment;
    public GameLogic gameLogic;
    public Snakes opponent;

    [HideInInspector] public int stepNum;
    [HideInInspector] public int playerInningNum;
    [HideInInspector] public int doubleSpeedInningNum;
    [HideInInspector] public int thisInningAddNum;
    [HideInInspector] public bool enableFoodTrigger = true;

    protected Vector2 orientation;
    [HideInInspector] public List<GameObject> _body = new List<GameObject>();
    public List<Vector3> positionHistory = new List<Vector3>();
    protected int stepLength;


    protected void fixPosition()
    {
        if (stepLength > 0)
        {
            this.transform.position = new Vector3(
                Mathf.Round(transform.position.x) + orientation.x,
                Mathf.Round(transform.position.y) + orientation.y,
                0.0f
            );
            this.transform.up = orientation;
            positionHistory.Insert(0, transform.position);

            stepLength -= 1;

            fixBodyPos();
        }
    }
    public void reverseBody()
    {
        this.transform.position = _body[_body.Count - 1].transform.position;
        for (int i = positionHistory.Count; i > 0; i--)
        {
            if (i > _body.Count)
            {
                positionHistory.RemoveAt(i - 1);
            }
            else break;
        }
        positionHistory.Reverse();
        
        fixBodyPos();
        if (_body.Count > 1)
        {
            orientation = new Vector2((this.transform.position - _body[1].transform.position).x, (this.transform.position - _body[1].transform.position).y);
        }

    }
    public void resetInningParameter()
    {
        enableFoodTrigger = true;
        thisInningAddNum = 0;
    }
    protected void fixBodyPos()
    {
        for (int i = 1; i < _body.Count; i++)
        {
            _body[i].transform.position = positionHistory[i];
            _body[i].transform.up = (_body[i - 1].transform.position - _body[i].transform.position).normalized;
        }
    }
    protected void oneStep(Vector2 ori)
    {
        stepNum -= 1;
        gameLogic.step -= 1;
        gameLogic.collectionIsOver = false;
        orientation = ori;

        stepLength = doubleSpeedInningNum > 0 ? 2 : 1;
    }
    protected void move(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
    {
        if (stepNum > 0)
        {
            if (Input.GetKeyDown(up) && orientation != Vector2.down) oneStep(Vector2.up);

            if (Input.GetKeyDown(down) && orientation != Vector2.up) oneStep(Vector2.down);

            if (Input.GetKeyDown(left) && orientation != Vector2.right) oneStep(Vector2.left);

            if (Input.GetKeyDown(right) && orientation != Vector2.left) oneStep(Vector2.right);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            if (enableFoodTrigger)
            {
                if (other.TryGetComponent(out Food f))
                {
                    f.foodSkill(this);
                    print(f.foodName + " : " + f.foodDescription);
                }
            }
            
            gameLogic.collectionIsOver = true;
            Destroy(other.gameObject);
            
        }
        if (((other.tag == "Player") || (other.tag == "Wall")) && (other.gameObject != _body[1]))
        {
            stepNum = 0;
            gameLogic.playGame = false;
        }
    }

    public void AddBody()
    {
        GameObject obj = Instantiate(this.SnakeSegment);
        _body.Add(obj);
        fixBodyPos();
    }
    public void subtractBody(int index)
    {
        while (index > 0 && _body.Count > 1)
        {
            GameObject.Destroy(_body[_body.Count - 1]);
            _body.RemoveAt(_body.Count - 1);
            index -= 1;
        }
    }
}
