using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car_movement : MonoBehaviour
{
    //PUBLIC AND EXPOSED
    [SerializeField] float speed, _maxDistance, _minDistance;


    //PRIVATE

    bool isFacingNorth;
    Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        PushFoward();
    }

    private void Update()
    {
        //Debug.Log("transform.z value : " + transform.position.z);
        if(transform.position.z >= _maxDistance) //si la distance max est atteint on fait demi tour
        {
            UTurn();
            //_maxDistance = 0; //reset
        }
        if(transform.position.z < _minDistance)
        {
            UTurn();
        }
    }


    void PushFoward() // avancer
    {
        _rb.velocity = transform.forward * speed;
    }

    void UTurn() //demi tour
    {
        Debug.Log("Demi tour");
        transform.forward = -transform.forward;
        isFacingNorth = !isFacingNorth;
        PushFoward();
    }

}
