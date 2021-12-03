using UnityEngine;

public class MenuBird : MonoBehaviour
{
    #region Properties

    [SerializeField] private AudioSource swoosh;

    private Rigidbody2D rb;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan(rb.velocity.y / 5));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 15 * rb.mass, ForceMode2D.Impulse);
        swoosh.pitch = Random.Range(0.9f, 1.1f);
        swoosh.Play();
    }
}
