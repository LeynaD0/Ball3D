using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
    }
}
