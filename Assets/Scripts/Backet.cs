using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Backet : MonoBehaviour
{
    #region Properties

    [SerializeField] LayerMask Food;
    [SerializeField] Collider2D Target;
    [SerializeField] UnityEvent FinishEvent;

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
            FinishEvent.Invoke();
	}
}
