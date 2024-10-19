using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Variables
    public delegate void InteractEvent(IInteract i, Transform t);
    public InteractEvent interaction;

    public delegate void RefielCoffe(string c);
    public RefielCoffe refiel;

    public delegate void FullCoffee();
    public FullCoffee OnCoffee;

    public delegate void ExitCoffeeMachine();
    public ExitCoffeeMachine OffCoffee;

    public delegate void MoveOn();
    public MoveOn moveOn;

    public delegate void MoveOff();
    public MoveOff moveOff;

    #region Publics
    [SerializeField] public Transform itemFather;
    #endregion

    #region Private
    [HideInInspector] public Transform itemHand;

    #endregion

    #endregion

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// This function change the player hand´s item position and set a new parent. 
    /// When the variable itemHand is null it will full the space, on the other side when its full it will turn it to null.
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public void ChangeItemHandFather(Transform t)
    {
        if(itemHand == null)
        {
            itemHand = t;
            itemHand.SetParent(itemFather);
            itemHand.localPosition = Vector3.zero;
        }
        else
        {
            itemHand.SetParent(t);
            itemHand.localPosition = Vector3.zero;
            itemHand = null;
        }
    }
}
