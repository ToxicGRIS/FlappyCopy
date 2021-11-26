using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    #region Properties

    Rigidbody2D rb;

	#endregion
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity0 = rb.velocity;
        if (Input.GetKey(KeyCode.A)) velocity0 += new Vector2(-1, 0);
        if (Input.GetKey(KeyCode.D)) velocity0 += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.W)) velocity0 += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S)) velocity0 += new Vector2(0, -1);
        rb.velocity = velocity0;
    }
}
