using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    #region Publics
    [SerializeField] PlayerCamera cam;
    [SerializeField] Rigidbody rb;
    [SerializeField] float maxMovSpeed;
    [SerializeField] float maxRotSpeed;
    [SerializeField] LayerMask floor;
    #endregion

    #region Private
    private Controller _controller;
    private Model _model;
    private View _view;

    private float _currentMovSpeed;
    private float _currentRotSpeed;
    #endregion

    #region Getter and Setter

    public float CurrentMovSpeed
    {
        get => _currentMovSpeed;

        set => _currentMovSpeed = value;
    }

    public float CurrentRotSpeed
    {
        get => _currentRotSpeed;

        set => _currentRotSpeed = value;
    }
    #endregion

    #endregion


    void Start()
    {
        _currentMovSpeed = maxMovSpeed;
        _currentRotSpeed = maxRotSpeed;

        _model = new Model(this, rb, cam.transform);
        _controller = new Controller(this, _model);
        _view = new View(this);
    }

    void Update()
    {
        _controller.ArtificialUpdate();
    }

    private void FixedUpdate()
    {
        _controller.ArtificialFixedUpdate();
    }
}
