using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    #region Properties

    [SerializeField] bool alive;
    [SerializeField] Counter counter;

    Rigidbody2D rb;
    
    public bool Alive { get => alive; set { alive = value; } }

    #endregion
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Alive)
		{
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 10 * rb.mass, ForceMode2D.Impulse);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        counter.GameOver();
	}
}
