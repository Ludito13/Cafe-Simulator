using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    private Player _player;
    private Rigidbody _rb;
    private Transform _camera;

    public Movement(Player p, Rigidbody r, Transform c)
    {
        _player = p;
        _rb = r;
        _camera = c;
    }

    public void PlayerMovement(float x, float z)
    {
        Vector3 inputMov = _camera.transform.forward * z + _camera.transform.right * x; 

        _rb.MovePosition(_player.transform.position + inputMov.normalized * _player.CurrentMovSpeed * Time.deltaTime);
    }

    public void PlayerRotation()
    {
        //float rotY = _camera.transform.rotation.eulerAngles.y;

        //_player.transform.eulerAngles = Vector3.ClampMagnitude(_player.transform.eulerAngles, _player.CurrentRotSpeed);

        //Quaternion rot = Quaternion.Euler(0f, rotY, 0f);

        //_player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, rot, _player.CurrentRotSpeed * Time.fixedDeltaTime).normalized;

    }
}
