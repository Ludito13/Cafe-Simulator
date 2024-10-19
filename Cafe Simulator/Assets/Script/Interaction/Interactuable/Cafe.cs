using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : ItemsToInteract
{
    #region Variables

    #region Publics
    public float maxCoffee;
    #endregion

    #region Privates
    public string coffeeName;
    public float _coffeCount;

    public bool _isFull { get;  set; }
    private bool _startToFull;
    private string _typeOfFull;
    private TypeOfCoffee ty;
    #endregion

    #endregion

    public void Start()
    {
        GameManager.instance.refiel += Complete;
    }

    private void Update()
    {
        if(_startToFull) _coffeCount = Mathf.Clamp(_coffeCount += Time.deltaTime, 0f, maxCoffee);


        switch (ty)
        {
            case TypeOfCoffee.Solo:

                if (_coffeCount >= maxCoffee)
                {
                    _isFull = true;
                    _startToFull = false;
                    coffeeName = ty.ToString();
                }
                break;

            case TypeOfCoffee.Vienes:

                if (_coffeCount >= maxCoffee * .5f)
                {
                    _isFull = true;
                    _startToFull = false;
                    coffeeName = ty.ToString();
                }
                break;

            case TypeOfCoffee.Espresso:

                if (_coffeCount >= maxCoffee * .25f)
                {
                    _isFull = true;
                    _startToFull = false;
                    coffeeName = ty.ToString();
                }

                break;

            default:
                break;
        }
    }

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

        GameManager.instance.refiel += Complete;

        //transform.SetParent(GameManager.instance.itemFather);
        //transform.position = GameManager.instance.itemFather.position;
        //GameManager.instance.itemHand = transform;

        GameManager.instance.ChangeItemHandFather(transform);
    }

    public void Complete(TypeOfCoffee typeOfRefield)
    {
        _startToFull = true;
        ty = typeOfRefield;
        GameManager.instance.refiel -= Complete;
    }
}
