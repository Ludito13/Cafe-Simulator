using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interact : MonoBehaviour
{

    #region Variables

    public delegate void InteractionAction();
    public InteractionAction _action;

    #region Publics
    [SerializeField] float distance;
    [SerializeField] float radius;
    [SerializeField] LayerMask interactuable;
    #endregion

    #region Privates
    private RaycastHit _hit;
    private IInteract _interactItem;
    #endregion

    #endregion

    void Start()
    {
    }

    void Update()
    {
        if (Physics.SphereCast(transform.position, radius, transform.forward, out _hit, distance))
        {
            var a = _hit.transform.gameObject.GetComponent<IInteract>() != null;

            if(a)
            {
                _interactItem = _hit.transform.gameObject.GetComponent<IInteract>();
                _interactItem.OnEnter();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _interactItem.TakeItem(_hit.transform);
                }
            }
        }
        else
        {
            if(_interactItem != null) _interactItem.OnExit();

            _interactItem = null;
        }
    }

    public void InteractOn()
    {

    }
   
    public void InteractOff()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * distance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * distance, radius);
    }
}
