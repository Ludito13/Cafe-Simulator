using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen : MonoBehaviour, IScreen
{
    public Screen nextScreen;

    //public Button button;

    private void Start()
    {
        //button.onClick.AddListener(() => BTN_Active());

        GameManager.instance.OnCoffee += BTN_Active;
        GameManager.instance.OffCoffee += BTN_Desactive;
    }

    public void BTN_Active()
    {
        if (nextScreen != null)
        {
            ScreenManager.instance.ActiveScreen(nextScreen);
        }
    }

    public void BTN_Desactive()
    {
        ScreenManager.instance.Pop();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
