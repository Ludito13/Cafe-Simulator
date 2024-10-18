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
     public float _coffeCount;

    public bool _isFull { get;  set; }
    private bool _startToFull;
    private string _typeOfFull;
    #endregion

    #endregion

    public void Start()
    {
        GameManager.instance.refiel += Complete;
    }

    private void Update()
    {
        if(_startToFull) _coffeCount = Mathf.Clamp(_coffeCount += Time.deltaTime, 0f, maxCoffee);


        switch (_typeOfFull)
        {
            case "Full":
                if (_coffeCount >= maxCoffee)
                {
                    _isFull = true;
                    _startToFull = false;
                }
                break;

            case "Mid":

                if (_coffeCount >= maxCoffee * .5f)
                {
                    _isFull = true;
                    _startToFull = false;
                }
                break;

            case "Small":

                if (_coffeCount >= maxCoffee * .25f)
                {
                    _isFull = true;
                    _startToFull = false;
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

        transform.SetParent(GameManager.instance.itemFather);
        transform.position = GameManager.instance.itemFather.position;
        GameManager.instance.itemHand = transform;
    }

    public void Complete(string typeOfRefield)
    {
        _startToFull = true;
        _typeOfFull = typeOfRefield;

    }
}
