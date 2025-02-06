using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public abstract class Snakes : MonoBehaviour
{
    protected Vector2 _position;
    public List<GameObject> _segments;
    public int stepNum;
    protected int stepLength;
    protected int skillStepLength = 1;

    public GameObject SnakeSegment;
    public GameLogic gameLogic;



    
    protected void fixPosition()
    {
        if (stepLength > 0)
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].transform.position = _segments[i - 1].transform.position;
            }

            this.transform.position = new Vector3(
                Mathf.Round(transform.position.x) + _position.x,
                Mathf.Round(transform.position.y) + _position.y,
                0.0f
            );
            stepLength -= 1;
        }
        
    }
    protected void oneStep(Vector2 dir)
    {
        _position = dir;
        stepNum -= 1;
        gameLogic.step -= 1;
        stepLength = skillStepLength;
    }
    protected void move (KeyCode up,KeyCode down,KeyCode left,KeyCode right)
    {
        if (stepNum > 0)
        {
            if (Input.GetKeyDown(up) && _position != Vector2.down)      oneStep(Vector2.up);

            if (Input.GetKeyDown(down) && _position != Vector2.up)      oneStep(Vector2.down);

            if (Input.GetKeyDown(left) && _position != Vector2.right)   oneStep(Vector2.left);

            if (Input.GetKeyDown(right) && _position != Vector2.left)   oneStep(Vector2.right);
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
                skillStepLength *= d.foodNum;
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
        if (((other.tag == "Player") || (other.tag == "Wall")) && (other.gameObject != _segments[1]))
        {
            stepNum = 0;
            gameLogic.playGame = false;
        }
    }

    private void AddBody()
    {
        GameObject segment = Instantiate(this.SnakeSegment);
  
        segment.transform.position = _segments[_segments.Count - 1].transform.position;

        _segments.Add(segment);

    }
    private void subtractBody(int index)
    {
        while(index > 0 && _segments.Count > 1)
        {
            GameObject.Destroy(_segments[_segments.Count - 1]);
            _segments.RemoveAt(_segments.Count - 1);
            index -= 1;
            print("1");
        }
        
    }
}
