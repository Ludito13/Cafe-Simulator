using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AllButtons
{
    FullCoffee,
    MidCoffee,
    SmallCoffe
}

[System.Serializable]
public struct Buttons
{
    public Button obj;
    public AllButtons name;
}

public class CoffeMachineUI : MonoBehaviour
{
    #region Variables

    #region Publics
    [SerializeField] Buttons[] allButtons;
    #endregion

    #region Private
    private Dictionary<AllButtons, Button> _allButtons = new Dictionary<AllButtons, Button>();
    #endregion

    #endregion


    void Start()
    {
        foreach (var item in allButtons)
        {
            if (!_allButtons.ContainsKey(item.name)) _allButtons.Add(item.name, item.obj);
        }

        _allButtons[AllButtons.FullCoffee].onClick.AddListener(() => SelectCoffe("Full"));
        _allButtons[AllButtons.MidCoffee].onClick.AddListener(() => SelectCoffe("Mid"));
        _allButtons[AllButtons.SmallCoffe].onClick.AddListener(() => SelectCoffe("Small"));
    }

    void Update()
    {
        
    }

    public void SelectCoffe(string typeOfCoffe)
    {
        GameManager.instance.refiel(typeOfCoffe);
        GameManager.instance.OffCoffee();
    }
}
