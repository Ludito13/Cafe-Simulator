using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Variables
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

}
