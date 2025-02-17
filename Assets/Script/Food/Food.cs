using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    protected GameObject currentPlayer;
    public int foodNum;
    public string foodName;
    public string foodDescription;
    public abstract void foodSkill(Snakes snakes);
    private void  OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Player")
        // {
        //     // currentPlayer = other.gameObject;
        //     Destroy(this.gameObject);
        // }
    }
}
