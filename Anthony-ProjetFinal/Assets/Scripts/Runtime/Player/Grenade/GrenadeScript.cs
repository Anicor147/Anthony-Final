using System;
using System.Collections;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Player.Grenade
{
    public class GrenadeScript : MonoBehaviour
    {
        [SerializeField] private GameObject grenadePrefab;
        private LineRenderer _lineRenderer;
        private Vector3 _mousePosition;
        private bool isTrowingCheck;
        Vector3 initialPoint = new Vector3(0, 0, 0);


        [Header("Bezier Parameters")]
        [SerializeField]  private float middlePointY;
        [SerializeField] private int numberOfPoints = 10;
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
                ResetLigne();
            }
        }
        
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void IsThrowingCheckBool(bool value)
        {
            isTrowingCheck = value;
            
            if (!isTrowingCheck)
            {
                StartCoroutine(ThrowGrenade());
            }
        }
        
        private IEnumerator ThrowGrenade()
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();

            Vector3[] curvePoints = CourbeLine();

            foreach (Vector3 point in curvePoints)
            {
                grenade.transform.position = point;
                yield return new WaitForSeconds(0.05f);
            }
        }
        private Vector3[] CourbeLine()
        {
            initialPoint = transform.position;
            Vector3 middlePoint = (_mousePosition  + initialPoint) / 2f;
            
            _lineRenderer.positionCount = numberOfPoints;
            Vector3[] linePositions = new Vector3[numberOfPoints];
            for (int i = 0; i < numberOfPoints; i++)
            {
                float t = i / (float)(numberOfPoints - 1); 
                linePositions[i] = Bezier(initialPoint, new Vector3(middlePoint.x, middlePoint.y + middlePointY, 0), _mousePosition, t);
            }
            _lineRenderer.SetPositions(linePositions);
            
            return linePositions;
        }

        private void ResetLigne()
        {
            _lineRenderer.positionCount = 0;
        }

        private Vector3 Bezier(Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            return (1 - t) * (1 - t) * p1 + 2 * (1 - t) * t * p2 + t * t * p3;
        }
    }
}