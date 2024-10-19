using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding 
{
    public List<Node> AStarPath(Node starting, Node goal)
    {
        if (starting == null || goal == null) return new List<Node>();

        PriorityQueue<Node> frontier = new PriorityQueue<Node>();
        frontier.Enqueue(starting, 0);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(starting, null);

        Dictionary<Node, int> costSoFar = new Dictionary<Node, int>();
        costSoFar.Add(starting, 0);

        while(frontier.count > 0)
        {
            Node current = frontier.Dequeue();

            if(current == goal)
            {
                List<Node> path = new List<Node>();

                while(current != starting)
                {
                    path.Add(current);
                    current = cameFrom[current];
                }
                path.Add(starting);
                path.Reverse();
                return path;
            }

            foreach (var item in current.GetNeighbors())
            {
                if (item.isBlock) continue;

                int newCost = (int)((int)costSoFar[current] + item.cost);

                if(!costSoFar.ContainsKey(item))
                {
                    float priority = newCost + Vector3.Distance(item.transform.position, goal.transform.position);
                    costSoFar.Add(item, newCost);
                    frontier.Enqueue(item, priority);
                    cameFrom.Add(item, current);
                }
                else if (newCost < costSoFar[item])
                {
                    float priority = newCost + Vector3.Distance(item.transform.position, goal.transform.position);
                    costSoFar[item] = newCost;
                    cameFrom[item] = current;
                    frontier.Enqueue(item, priority);
                }

            }
        }

        return new List<Node>();
    }
}
