using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    #region Properties

    [SerializeField] private GameObject Up;
    [SerializeField] private GameObject Down;
    [SerializeField] private float Speed;
    [SerializeField] private bool moving;

    public GameObject bird { get; set; }

    public bool Moving { get; set; }

    #endregion

    private void FixedUpdate()
    {
        if (Moving)
            transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    public void SetPos(float y, float height)
	{
        Up.transform.localPosition = new Vector3(Up.transform.localPosition.x, y + height, Up.transform.localPosition.z);
        Down.transform.localPosition = new Vector3(Down.transform.localPosition.x, y - height / 2, Down.transform.localPosition.z);
	}
}
