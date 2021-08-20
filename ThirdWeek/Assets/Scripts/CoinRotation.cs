using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{

    [SerializeField] float coinRotationSpeed = 60f;
    private void Update()
    {
        transform.Rotate(new Vector3(0f,0f, coinRotationSpeed*Time.deltaTime));
    }
}
