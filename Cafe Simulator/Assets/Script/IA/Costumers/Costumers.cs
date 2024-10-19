using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfCoffee
{
    Solo,
    Vienes,
    Espresso
}

public class Costumers : ItemsToInteract
{
    [SerializeField] string order;

    public float maxWaitTimer;
    public TypeOfCoffee[] _foods;
    public Transform myOrder;

    void Start()
    {
        order = GameManager.instance.GetRandomEnumValue(_foods).ToString();

        StartCoroutine(WaitOrder());
    }

    void Update()
    {
        if (myOrder == null)
        {
            Debug.Log("Buenas tardes, quiero " + order + " por favor");
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

        //if(myOrder == null)
        //{
        //    Debug.Log("Buenas tardes, quiero " + order + " por favor");
        //}

        GameManager.instance.GiveOrderToCostumer(order, myOrder);

    }

    IEnumerator WaitOrder()
    {
        yield return new WaitForSeconds(maxWaitTimer);
        Debug.Log("Que mal servicio que es este, me voy");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
