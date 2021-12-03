using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float Speed;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x < -24.48f) transform.position = new Vector3(24.48f, transform.position.y, transform.position.z);
    }
}
