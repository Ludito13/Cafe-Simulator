using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : ItemsToInteract
{
    #region Variables

    #region Publics
    [SerializeField] public float maxCoffee;
    #endregion

    #region Privates
    [HideInInspector] public float _coffeCount;
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

        if (GameManager.instance.itemHand != null) return;

        transform.SetParent(GameManager.instance.itemFather);
        transform.position = GameManager.instance.itemFather.position;
        GameManager.instance.itemHand = transform;
    }

    public void Complete()
    {
        _coffeCount += Mathf.Clamp(_coffeCount += Time.deltaTime, 0f, maxCoffee);
    }
}
