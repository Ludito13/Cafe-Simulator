using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller 
{
    public delegate void MovementD();
    private MovementD mov;

    private Player _player;
    private Model _model;

    public Controller(Player p, Model m)
    {
        _player = p;
        _model = m;

        mov = Movement;

        GameManager.instance.moveOn += MoveOn;
        GameManager.instance.moveOff += MoveOff;

        GameManager.instance.OffCoffee += MoveOn;
        GameManager.instance.OnCoffee += MoveOff;
    }

    public void ArtificialUpdate()
    {
        //mov();
    }

    public void ArtificialFixedUpdate()
    {
        mov();
    }

    public void ArtificialLateUpdate()
    {

    }

    #region Movement

    public void MoveOn()
    {
        mov = Movement;
    }

    public void MoveOff()
    {
        mov = delegate { };
    }

    public void Movement()
    {
        _model.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _model.RotationPlayer();
    }
    #endregion
}
