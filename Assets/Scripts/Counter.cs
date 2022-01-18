using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    #region Properties

    [SerializeField] private GameObject bird;
    [SerializeField] private int count;
    [SerializeField] private PipeGenerator generator;
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject textGameOver;
    [SerializeField] private AudioSource point;
    [SerializeField] private AudioSource gameOver;

    public List<GameObject> pipes { get; private set; }

    public bool Paused { get; private set; }

	#endregion

	private void Start()
	{
        pipes = new List<GameObject>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || 
            (!bird.GetComponent<Bird>().Alive && 
            (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))))
		{
            SceneManager.LoadScene("MainMenu");
		}
	}

	private void FixedUpdate()
    {
        if (pipes.Count > 0 && pipes[0] != null)
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
        point.pitch = Random.Range(0.9f, 1.1f);
        point.Play();
	}

    public void GameOver()
	{
        gameOver.Play();
        generator.Active = false;
        bird.GetComponent<Bird>().Alive = false;
        foreach (var pipe in FindObjectsOfType<Pipe>())
		{
            pipe.Moving = false;
		}
        textGameOver.SetActive(true);
        if (PlayerPrefs.GetInt("Record") < count) PlayerPrefs.SetInt("Record", count);
	}
}
