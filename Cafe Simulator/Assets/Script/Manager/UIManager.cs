using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    #region Variables

    public delegate void FullCoffee();
    public FullCoffee fullCoffe;

    #region Publics

    #endregion

    #region Private

    #endregion

    #endregion

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
