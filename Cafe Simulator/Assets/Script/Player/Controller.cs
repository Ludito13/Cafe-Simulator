using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller 
{
    private Player _player;
    private Model _model;

    public Controller(Player p, Model m)
    {
        _player = p;
        _model = m;
    }

    public void ArtificialUpdate()
    {

    }

    public void ArtificialFixedUpdate()
    {
        Movement();
    }

    public void ArtificialLateUpdate()
    {

    }

    #region Movement

    public void Movement()
    {
        _model.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _model.RotationPlayer();
    }
    #endregion
}
