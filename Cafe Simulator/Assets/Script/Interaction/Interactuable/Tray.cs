using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : ItemsToInteract
{
    #region Variables

    #region Publics
    [SerializeField] Transform item;
    [SerializeField] string itemName;
    #endregion

    #region Privates

    #endregion

    #endregion


    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void TakeItem(Transform t)
    {
        base.TakeItem(t);
    }
}
