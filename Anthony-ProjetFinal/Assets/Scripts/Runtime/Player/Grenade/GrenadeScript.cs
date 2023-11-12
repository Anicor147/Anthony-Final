using System;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.Grenade
{
    public class GrenadeScript : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private Vector3 _mousePosition;
        private bool isTrowingCheck;
        Vector3 initialPoint = new Vector3(0, 0, 0);


        private void Start()
        {
            EventManager.Instance.OnThrowingChanged += IsThrowingCheckBool;
        }

        private void Update()
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
            
            if (isTrowingCheck)
            {
                CourbeLine();
            }
            else
            {
                _lineRenderer.positionCount = 0;
            }
        }

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void IsThrowingCheckBool(bool value)
        {
            isTrowingCheck = value;
        }

        private void CourbeLine()
        {
            initialPoint = transform.position;
            Vector3 middlePoint = _mousePosition / 2f;
            int numberOfPoints = 10;


            _lineRenderer.positionCount = numberOfPoints;
            Vector3[] linePositions = new Vector3[numberOfPoints];
            for (int i = 0; i < numberOfPoints; i++)
            {
                float t = i / (float)(numberOfPoints - 1); 
                linePositions[i] = Bezier(initialPoint, new Vector3(middlePoint.x, 6f, 0), _mousePosition, t);
                Debug.Log("Point " + i + ": " + linePositions[i] + "t :"+ t);
            }
            _lineRenderer.SetPositions(linePositions);
        }

        private void ResetLigne()
        {
            
        }

        private Vector3 Bezier(Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            return (1 - t) * (1 - t) * p1 + 2 * (1 - t) * t * p2 + t * t * p3;
        }
    }
}