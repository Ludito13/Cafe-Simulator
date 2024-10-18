using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract 
{
    public void OnEnter();
    public void OnExit();

    public void TakeItem(Transform t);
}
