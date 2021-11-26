using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backet : MonoBehaviour
{
    #region Properties

    [SerializeField] LayerMask Food;
    [SerializeField] Collider2D Target;

    #endregion
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.GetComponent<Food>() != null)
            Debug.Log("EEEEEEEE");
	}
}
