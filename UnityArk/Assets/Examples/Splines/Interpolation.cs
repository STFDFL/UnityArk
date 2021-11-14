using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolation : MonoBehaviour
{

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _pointC;
    [SerializeField] private Transform _pointD;
    [SerializeField] private Transform _pointAB;
    [SerializeField] private Transform _pointBC;
    [SerializeField] private Transform _pointCD;
    [SerializeField] private Transform _pointAB_BC;
    [SerializeField] private Transform _pointBC_CD;
    [SerializeField] private Transform _pointABCD;

    private float _interpolateAmount;


    
    void Update()
    {
        _interpolateAmount = (_interpolateAmount + Time.deltaTime) % 1f;

        _pointAB.position = Vector3.Lerp(_pointA.position, _pointB.position, _interpolateAmount);
        _pointBC.position = Vector3.Lerp(_pointB.position, _pointC.position, _interpolateAmount);
        _pointCD.position = Vector3.Lerp(_pointC.position, _pointD.position, _interpolateAmount);

        _pointAB_BC.position = Vector3.Lerp(_pointAB.position, _pointBC.position, _interpolateAmount);
        _pointBC_CD.position = Vector3.Lerp(_pointBC.position, _pointCD.position, _interpolateAmount);

        _pointABCD.position = Vector3.Lerp(_pointAB_BC.position, _pointBC_CD.position, _interpolateAmount);
    }
}
