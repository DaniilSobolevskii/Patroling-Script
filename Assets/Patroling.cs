using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{

    [SerializeField] private List<Transform> _points;

    [SerializeField] private float _speed;

    [SerializeField] private float _waitTime;
    
   // private GameObject _patroler;
   private Vector3 _startPossition;
   private Transform _nextPoint;
    private int numberPoint;
    private float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        _nextPoint = _points[0];
        _startPossition = transform.position;
    }

    private void ChangePosition()
    {
        if (numberPoint != _points.Count)
        {
            _nextPoint=_points[numberPoint++];
        }
        else
        {
            numberPoint = 0;
            _nextPoint=_points[numberPoint];
        }

    }

    void Update()
    {

        _currentTime += Time.deltaTime;
        var distance = _currentTime * _speed;
        transform.position = Vector3.Lerp(_startPossition, _nextPoint.position, distance);
        if (transform.position == _nextPoint.position)
        {
            _startPossition = _nextPoint.position;
            ChangePosition();
            _currentTime = 0-_waitTime;
        }
        
            
        
       
        
    }
}
