using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T>
{
    Dictionary<T, float> _allNodes = new Dictionary<T, float>();

    public int count { get => _allNodes.Count; }

    public void Enqueue(T elem, float cost)
    {
        if (!_allNodes.ContainsKey(elem)) _allNodes.Add(elem, cost);
        else _allNodes[elem] = cost;
    }

    public T Dequeue()
    {
        T min = default;
        float currentValue = Mathf.Infinity;

        foreach (var item in _allNodes)
        {
            if(item.Value < currentValue)
            {
                min = item.Key;
                currentValue = item.Value;
            }
        }

        _allNodes.Remove(min);
        return min;
    }
}
