using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerA : Snakes
{
    void Start()
    {
        _segments.Add(this.gameObject);
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
