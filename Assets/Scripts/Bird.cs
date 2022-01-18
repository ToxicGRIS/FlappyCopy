using UnityEngine;

public class Bird : MonoBehaviour
{
    #region Properties

    [SerializeField] private bool alive;
    [SerializeField] private Counter counter;
    [SerializeField] private AudioSource swoosh;

    private Rigidbody2D rb;
    
    public bool Alive { get => alive; set { alive = value; } }

    #endregion
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && Alive)
		{
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 10 * rb.mass, ForceMode2D.Impulse);
            swoosh.pitch = Random.Range(0.9f, 1.1f);
            swoosh.Play();
		}
        if (Alive)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan(rb.velocity.y / 5));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (Alive)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            counter.GameOver();
        }
	}
}
