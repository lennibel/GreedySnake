using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerB : Snakes
{
    void Start()
    {
        _body.Add(this.gameObject);
        positionHistory.Insert(0,transform.position);
    }
    void Update()
    {
        move(KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.LeftArrow,KeyCode.RightArrow); 
    }
    private void FixedUpdate() 
    {
        fixPosition();
    }
}
