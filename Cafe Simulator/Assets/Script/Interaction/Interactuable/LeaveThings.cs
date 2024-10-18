using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveThings : ItemsToInteract
{
    #region Variables

    #region Publics
    [SerializeField] Transform pos;
    #endregion

    #region Private

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

        if (GameManager.instance.itemHand == null) return;

        GameManager.instance.itemHand.SetParent(pos);
        GameManager.instance.itemHand.position = pos.transform.position;
        GameManager.instance.itemHand = null;
    }

    private void Update()
    {
        
    }
}
