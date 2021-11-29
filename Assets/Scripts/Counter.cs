using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    #region Properties

    [SerializeField] private GameObject bird;
    [SerializeField] private int count;
    [SerializeField] private PipeGenerator generator;
    [SerializeField] private Text pointsText;

    public List<GameObject> pipes { get; private set; }

	#endregion

	private void Start()
	{
        pipes = new List<GameObject>();
	}

	private void FixedUpdate()
    {
        if (pipes.Count > 0)
            if (pipes[0].transform.position.x < bird.transform.position.x)
            {
                AddPoint();
                pipes.RemoveAt(0);
            }
    }

    private void AddPoint()
	{
        count++;
        pointsText.text = $"Count: {count}";
	}

    public void GameOver()
	{
        generator.Active = false;
        bird.GetComponent<Bird>().Alive = false;
        foreach (var pipe in FindObjectsOfType<Pipe>())
		{
            pipe.Moving = false;
		}
	}
}
