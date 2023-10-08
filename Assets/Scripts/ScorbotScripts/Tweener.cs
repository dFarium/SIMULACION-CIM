using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    [SerializeField] private NodeSeeker nodeSeeker;
    private Sequence tweenSequence;
    [SerializeField] private float tweenSpeed;
    private float offsetDistance;

    public void TweenBetweenNodes()
    {
        List<Transform> shortestPath = nodeSeeker.GenerateShortestPath();
        float step = nodeSeeker.GetHeightSteps(shortestPath);
        
        //Inicializacion de secuencia DOTween
        tweenSequence = null;
        tweenSequence = DOTween.Sequence();
        //Curva de animacion para el primer punto
        offsetDistance = 0;
        Vector3 offsetPosition = AddOffset(shortestPath[0], step);
        tweenSequence.Append(transform.DOMove(offsetPosition, tweenSpeed).SetEase(Ease.InSine));
        //tweenSequence.Append(transform.DOMove(shortestPath[0].position, tweenSpeed).SetEase(Ease.InSine));

        //Animacion lineal para los puntos intermedios
        for (int i = 1; i < shortestPath.Count - 1; i++)
        {
            offsetPosition = AddOffset(shortestPath[i], step);
            var path = transform.DOMove(offsetPosition, tweenSpeed).SetEase(Ease.Linear);
            tweenSequence.Append(path);
        }

        //Curva de animacion para el ultimo punto
        tweenSequence.Append(transform.DOMove(shortestPath[^1].position, tweenSpeed).SetEase(Ease.OutSine));
        // offsetPosition = AddOffset(shortestPath[^1], step);
        // tweenSequence.Append(transform.DOMove(offsetPosition, tweenSpeed).SetEase(Ease.OutSine));
        
    }

    //Offset para la animacion de traslado
    private Vector3 AddOffset(Transform node, float step)
    {
        Vector3 offsetPosition = node.position;
        offsetPosition.y += offsetDistance;
        offsetDistance += step;
        return offsetPosition;
    }

    //Iniciar secuencia de animaciones
    public void PlaySequence()
    {
        TweenBetweenNodes();
        tweenSequence.Play();
    }

    //Cancelar secuencia de animaciones
    public void StopSequence()
    {
        tweenSequence.Kill();
    }
}