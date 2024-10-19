using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsToInteract : MonoBehaviour, IInteract
{
    #region Variables

    #region Publics
    #endregion

    #region Privates

    #endregion

    #endregion

    public virtual void OnEnter()
    {
        Debug.Log("Interactuo");
        //GameManager.instance.interaction = TakeItem;
    }

    public virtual void OnExit()
    {
        Debug.Log("No interactuo");
    }

    public virtual void TakeItem(Transform t)
    {
        Debug.Log("Agarre el item");
    }
  
    public virtual void Action()
    {

    }
}
