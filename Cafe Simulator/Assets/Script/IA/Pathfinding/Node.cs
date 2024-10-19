using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Node : MonoBehaviour
{
    #region Variables

    #region Publics

    [SerializeField] public bool isBlock;
    [SerializeField] LayerMask wall;
    [SerializeField] public float cost;
    #endregion

    #region Private
    private List<Node> _neighbors = new List<Node>();
    private RaycastHit _hit;
    #endregion

    #endregion

    public List<Node> GetNeighbors()
    {
        if (_neighbors.Count > 0) return _neighbors;

        return GameManager.instance.allNodes.Aggregate(_neighbors, (x, y) =>
        {

            if (Physics.Raycast(transform.position, transform.forward, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, -transform.forward, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, transform.right, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, -transform.right, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, transform.forward + transform.right, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, -transform.forward - transform.right, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, transform.right - transform.forward, out _hit, float.MaxValue, wall) ||
               Physics.Raycast(transform.position, -transform.right + transform.forward, out _hit, float.MaxValue, wall))
            {
                if (_hit.transform.GetComponent<Node>() == y) x.Add(y);

                Debug.Log(_hit.transform.name);
            }


            return x;
        });

        //foreach (var item in GameManager.instance.allNodes)
        //{
        //    if (item == this || _neighbors.Contains(item)) continue;

        //    Vector3 dir = item.transform.position - transform.position;

        //    if (Physics.Raycast(transform.position, item.transform.position)) _neighbors.Add(item);

        //    Debug.DrawRay(transform.position, item.transform.position);
        //}


        //    return _neighbors;
    }

    private void Start()
    {
        GameManager.instance.allNodes.Add(this);

        StartCoroutine(WaitToAdd());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * float.MaxValue);
        Gizmos.DrawRay(transform.position, -transform.forward);
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.DrawRay(transform.position, -transform.right);
        Gizmos.DrawRay(transform.position, (transform.forward + transform.right));
        Gizmos.DrawRay(transform.position, -transform.forward - transform.right);
        Gizmos.DrawRay(transform.position, transform.right - transform.forward);
        Gizmos.DrawRay(transform.position, -transform.right + transform.forward);

    }

    IEnumerator WaitToAdd()
    {
        yield return new WaitForSeconds(0.5f);
        GetNeighbors();

    }
}
