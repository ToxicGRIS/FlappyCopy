using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    #region Properties

    [SerializeField] private GameObject PipePrefab;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private bool active = false;
    [SerializeField] private GameObject bird;
    [SerializeField] private Counter counter;

    private TimerCD timer;

    public bool Active { get => active; set { active = value; } }

    #endregion
    private void Start()
    {
        timer = GetComponent<TimerCD>();
    }

    private void FixedUpdate()
    {
        if(Active && (timer?.Ready ?? false))
        {
            float y = Random.Range(minY, maxY);
            float height = Random.Range(minHeight, maxHeight);
            GameObject spawnedPipe = Instantiate(PipePrefab);
            timer?.ActivateCD();
            spawnedPipe.GetComponent<Pipe>().SetPos(y, height);
            spawnedPipe.GetComponent<Pipe>().bird = bird;
            spawnedPipe.GetComponent<Pipe>().Moving = true;
            spawnedPipe.transform.position = transform.position;
            counter.pipes.Add(spawnedPipe);
        }
    }
}
