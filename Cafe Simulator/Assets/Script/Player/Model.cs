using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model 
{
    private Player _player;
    private Movement _mov;

    public Model(Player p, Rigidbody r, Transform c)
    {
        _player = p;

        _mov = new Movement(p, r, c);
    }

    public void MovePlayer(float x, float z) => _mov.PlayerMovement(x, z);

    public void RotationPlayer() => _mov.PlayerRotation();

}
