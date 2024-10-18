using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Variables

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
