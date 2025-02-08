using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerB : Snakes
{
    void Start()
    {
        _body.Add(this.gameObject);
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
