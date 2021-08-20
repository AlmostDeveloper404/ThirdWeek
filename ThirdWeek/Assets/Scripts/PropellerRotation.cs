using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
    [SerializeField]float rotationSpeed = 20f;
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed*Time.deltaTime,0f,0f));
    }
}
