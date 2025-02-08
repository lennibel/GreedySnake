using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerA : Snakes
{
    void Start()
    {
        _body.Add(this.gameObject);
        positionHistory.Insert(0,transform.position);
    }
    void Update()
    {
        move(KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D); 
    }
    private void FixedUpdate() 
    {
        fixPosition();
    }
}
