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

    [HideInInspector]public int stepNum;

    protected Vector2 orientation;
    protected List<GameObject> _body = new List<GameObject>();
    protected List<Vector3> positionHistory = new List<Vector3>();
    protected int stepLength = 10;
    protected int skillStepLength = 1;



    
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
            stepLength -= 1;
            
            fixBodyPos();
        }
        
    }
    protected void fixBodyPos()
    {
        for (int i = 1; i < _body.Count; i++)
            { 
                _body[i].transform.position = positionHistory[i - 1];
                _body[i].transform.up = (_body[i - 1].transform.position - _body[i].transform.position).normalized;
            }
    }
    protected void oneStep(Vector2 ori)
    {
        stepNum -= 1;
        gameLogic.step -= 1;
        orientation = ori;
        stepLength = skillStepLength;
        positionHistory.Insert(0,transform.position);
    }
    protected void move (KeyCode up,KeyCode down,KeyCode left,KeyCode right)
    {
        if (stepNum > 0)
        {
            if (Input.GetKeyDown(up) && orientation != Vector2.down)      oneStep(Vector2.up);

            if (Input.GetKeyDown(down) && orientation != Vector2.up)      oneStep(Vector2.down);

            if (Input.GetKeyDown(left) && orientation != Vector2.right)   oneStep(Vector2.left);

            if (Input.GetKeyDown(right) && orientation != Vector2.left)   oneStep(Vector2.right);
        }
    }

    private void  OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            if (other.TryGetComponent(out FoodAdd a))
            {
                AddBody();
            }
            else if (other.TryGetComponent(out FoodSubtract s))
            {
                subtractBody(s.foodNum);
            }
            else if (other.TryGetComponent(out FoodDoubleStep d))
            {
                stepLength = 2;
            }
            // else if (other.TryGetComponent())
            // {
                
            // }
            else if (other.TryGetComponent(out FoodReset r))
            {
                r.foodSkill();
            }

            Destroy(other.gameObject);
        }
        if (((other.tag == "Player") || (other.tag == "Wall")) && (other.gameObject != _body[1]))
        {
            stepNum = 0;
            gameLogic.playGame = false;
        }
    }

    private void AddBody()
    {
        GameObject obj = Instantiate(this.SnakeSegment);
        _body.Add(obj);
        fixBodyPos();
    }
    private void subtractBody(int index)
    {
        while(index > 0 && _body.Count > 1)
        {
            GameObject.Destroy(_body[_body.Count - 1]);
            _body.RemoveAt(_body.Count - 1);
            index -= 1;
        }
    }
}
