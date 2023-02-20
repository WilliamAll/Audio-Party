using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{

    //PRIVATE

    [SerializeField] float _maxDistance;
    UIsable _target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }

    //METHOD

    private void FindTarget()
    {
        RaycastHit hit;
        Vector3 camPos = Camera.main.transform.position;
        Vector3 camDir = Camera.main.transform.forward;
        Ray ray = new Ray(camPos, camDir);
        if (Physics.Raycast(ray, out hit, _maxDistance))
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * _maxDistance, Color.green);
            Debug.Log("Objet touché : " + hit.collider.name);
        }
    }

    private void UseTarget()
    {

    }

    void ChangeCrossHairState()
    { 

    }

    void RayCastDebug()
    {
        Vector3 camPos = Camera.main.transform.position;
        Vector3 camDir = Camera.main.transform.forward;
        Ray ray = new Ray(camPos, camDir);
        //float rayLength = 100f;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * _maxDistance, Color.green);
    }
}
