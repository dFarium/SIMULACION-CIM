using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class NodeSeeker : MonoBehaviour
{
    [SerializeField] private Transform[] nodes;
    [SerializeField] private Transform origin, destination;
    private List<Node> connectedNodes = new List<Node>();


    public void Start()
    {
        if (nodes.Length == 0) Debug.LogError("NO HAY NODOS REGISTRADOS");
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

    private Transform GetClosestNode(Transform pos)
    {
        float closestDistance = float.MaxValue;
        Transform closestNode = null;
        foreach (Node node in connectedNodes)
        {
            float distance = Vector3.Distance(pos.position, node.nodeA.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNode = node.nodeA.transform;
            }
        }

        return closestNode;
    }

    public List<Transform> GenerateShortestPath()
    {
        Transform closestOriginNode = GetClosestNode(origin);
        Transform closestDestinationNode = GetClosestNode(destination);

        Dictionary<Transform, Node> nodeToParentMap = Dijkstra(closestOriginNode);
        List<Transform> shortestPath = ReconstructPath(nodeToParentMap, closestDestinationNode);

        //Si ya esta en la posicion destino, no agregar nodo cercano al origen a la lista
        if (origin.position != destination.position)
        {
            shortestPath.Insert(0, GetClosestNode(origin));
        }

        //Añadir posicion destino
        shortestPath.Add(destination);

        GetHeightSteps(shortestPath);
        return shortestPath;
    }

    //Obtener pasos de altura entre el origen y destino 
    public float GetHeightSteps(List<Transform> animationList)
    {
        return ((destination.position.y - origin.position.y) / (animationList.Count + 2f));
    }

    //Algoritmo Dijkstra
    private Dictionary<Transform, Node> Dijkstra(Transform startNode)
    {
        Dictionary<Transform, float> distance = new Dictionary<Transform, float>();
        Dictionary<Transform, Node> parent = new Dictionary<Transform, Node>();
        HashSet<Transform> visited = new HashSet<Transform>();

        foreach (Transform node in nodes)
        {
            distance[node] = float.MaxValue;
        }

        distance[startNode] = 0;

        PriorityQueue<Transform> priorityQueue = new PriorityQueue<Transform>();
        priorityQueue.Enqueue(startNode, 0);

        while (priorityQueue.count > 0)
        {
            Transform currentNode = priorityQueue.Dequeue();

            if (visited.Contains(currentNode))
                continue;

            visited.Add(currentNode);

            //Iterar en nodos vecinos
            foreach (Node neighborNode in connectedNodes)
            {
                if (neighborNode.nodeA == currentNode)
                {
                    Transform neighbor = neighborNode.nodeB;

                    float newDistance = distance[currentNode] + neighborNode.weight;
                    // Actualizar la distancia y el nodo padre si se un camino más corto
                    if (newDistance < distance[neighbor])
                    {
                        distance[neighbor] = newDistance;
                        parent[neighbor] = neighborNode;
                        priorityQueue.Enqueue(neighbor, newDistance);
                    }
                }
            }
        }

        return parent;
    }

    private List<Transform> ReconstructPath(Dictionary<Transform, Node> parentMap, Transform destinationNode)
    {
        List<Transform> path = new List<Transform>();
        Transform current = destinationNode;

        while (parentMap.ContainsKey(current))
        {
            path.Add(current);
            current = parentMap[current].nodeA;
        }

        path.Reverse();
        return path;
    }
}