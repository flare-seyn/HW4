using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePairPrefab;
    [SerializeField] private float spawnInterval = 2.5f;
    [SerializeField] private float minY = -2f;
    [SerializeField] private float maxY = 2f;
    [SerializeField] private float spawnX = 10f;

    private float timer;

    private void Update()
    {
        if (GameController.IsGameOver) return;
        if (pipePairPrefab == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        float y = Random.Range(minY, maxY);
        Instantiate(pipePairPrefab, new Vector3(spawnX, y, 0f), Quaternion.identity);
    }
}
