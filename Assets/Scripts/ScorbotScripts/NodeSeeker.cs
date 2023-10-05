using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NodeSeeker : MonoBehaviour
{
    [SerializeField] private Transform[] nodes;
    [SerializeField] private Transform origin, destination;
    private List<Node> connectedNodes = new List<Node>();


    public void Start()
    {
        //Sentido Horario
        connectedNodes.Add(new Node(nodes[0], nodes[1], 1));
        connectedNodes.Add(new Node(nodes[1], nodes[2], 1));
        connectedNodes.Add(new Node(nodes[2], nodes[3], 1));
        connectedNodes.Add(new Node(nodes[3], nodes[4], 1));
        connectedNodes.Add(new Node(nodes[4], nodes[5], 1));
        connectedNodes.Add(new Node(nodes[5], nodes[6], 1));
        connectedNodes.Add(new Node(nodes[6], nodes[7], 1));
        connectedNodes.Add(new Node(nodes[7], nodes[0], 1));

        //Sentido Anti-Horario
        connectedNodes.Add(new Node(nodes[7], nodes[6], 1));
        connectedNodes.Add(new Node(nodes[6], nodes[5], 1));
        connectedNodes.Add(new Node(nodes[5], nodes[4], 1));
        connectedNodes.Add(new Node(nodes[4], nodes[3], 1));
        connectedNodes.Add(new Node(nodes[3], nodes[2], 1));
        connectedNodes.Add(new Node(nodes[2], nodes[1], 1));
        connectedNodes.Add(new Node(nodes[1], nodes[0], 1));
        connectedNodes.Add(new Node(nodes[0], nodes[7], 1));
    }

    public class Node
    {
        public Transform nodeA, nodeB;
        public float weight;

        public Node(Transform nodeA, Transform nodeB, float weight)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
            this.weight = weight;
        }
    }

    public void InvokeShortestPath()
    {
        Debug.Log(GetClosestNode(origin));
    }

    private Transform GetClosestNode(Transform pos)
    {
        float closestDistance = float.MaxValue;
        Transform closestNode = null;
        foreach (Node node in connectedNodes)
        {
            float distance = Vector3.Distance(pos.position,node.nodeA.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNode = node.nodeA.transform;
            }
        }
    
        return closestNode;
    }
}