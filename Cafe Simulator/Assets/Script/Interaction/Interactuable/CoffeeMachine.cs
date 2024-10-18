using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

public class CoffeeMachine : ItemsToInteract
{
    #region Variables

    public delegate void ActionMachine();
    public ActionMachine machine;

    #region Publics
    [SerializeField] Transform[] allSpaces;
    [SerializeField] Transform[] completeSpace;
    [SerializeField] string nameNeed;
    #endregion

    #region Private
    private bool _start;
    private int _index;
    private Transform _cup;
    private Transform[] _allCups;
    #endregion

    #endregion

    private void Start()
    {
        _allCups = new Transform[allSpaces.Length];

        machine = EmptyFunction;
    }

    private void Update()
    {
        for (int i = 0; i < _allCups.Length; i++)
        {
            for (int J = 0; J < completeSpace.Length; J++)
            {
                if(_allCups[i] != null)
                {
                    if(_allCups[i].gameObject.GetComponent<Cafe>()._isFull)
                    {
                        _allCups[i].SetParent(completeSpace[J]);
                        _allCups[i].position = completeSpace[J].position;
                        _allCups[i] = null;
                    }
                }
            }
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
        Debug.Log(GameManager.instance.itemHand.name);
        Debug.Log("-2");

        if (t == null) return;
        
        Debug.Log("-1");

        if (GameManager.instance.itemHand.name != nameNeed) return;
        
        Debug.Log("0");

        for (int i = 0; i < allSpaces.Length; i++)
        {
            Debug.Log("1");
            if(allSpaces[i].childCount <= 0)
            {
                Debug.Log("2");
                _allCups[i] = GameManager.instance.itemHand;
                GameManager.instance.itemHand = null;

                _allCups[i].SetParent(allSpaces[i]);
                _allCups[i].position = allSpaces[i].position;

                GameManager.instance.OnCoffee();
            }
            //else if(allSpaces[i].childCount > 0 && GameManager.instance.itemHand != null)
            //{
            //    Debug.Log("3");
            //    _allCups[i].SetParent(GameManager.instance.itemFather);
            //    _allCups[i].transform.position = Vector3.zero;
            //    GameManager.instance.itemHand = _cup;
            //    _allCups[i] = null;
            //}
        }
        
        //if (allSpaces[_index].childCount <= 0)
        //{
        //    _cup = GameManager.instance.itemHand;
        //    GameManager.instance.itemHand = null;

        //    _cup.SetParent(allSpaces[_index]);
        //    _cup.position = allSpaces[_index].position;

        //    _index += Mathf.Clamp(_index++, 0, allSpaces.Length);
        //}
        //else if(allSpaces.Where(x => x.childCount > 0).FirstOrDefault().childCount > 0)
        //{
        //    _cup.SetParent(GameManager.instance.itemFather);
        //    _cup.transform.position = Vector3.zero;
        //    GameManager.instance.itemHand = _cup;
        //    _cup = null;
        //}

        
    }

    void NoCollision()
    {
        int newIndex = _index < 0 ? 0 : _index - 1;

        if (_cup.parent != allSpaces[newIndex]) _cup = null;

        if (_cup == null)
        {
            gameObject.GetComponent<Collider>().enabled = true;
            machine = EmptyFunction;
        }
    }

    void EmptyFunction()
    {

    }
}
