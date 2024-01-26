using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private float _speed = 2.5f;
    private float _distance = 50f;
    private float _spawnInterval = 5f;

    private void OnEnable()
    {
        UIManager.OnSpeedChanged += UpdateSpeed;
        UIManager.OnDistanceChanged += UpdateDistance;
        UIManager.OnSpawnIntervalChanged += UpdateSpawnInterval;
    }

    private void OnDisable()
    {
        UIManager.OnSpeedChanged -= UpdateSpeed;
        UIManager.OnDistanceChanged -= UpdateDistance;
        UIManager.OnSpawnIntervalChanged -= UpdateSpawnInterval;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCube), 0f, _spawnInterval);
    }

    private void SpawnCube()
    {
        GameObject cube = ObjectPool.Instance.GetCube();
        cube.transform.position = transform.position;
        CubeMover mover = cube.GetComponent<CubeMover>();
        mover.Initialize(_speed, _distance);
    }

    private void UpdateSpawnInterval(float newInterval)
    {
        _spawnInterval = newInterval;
        CancelInvoke(nameof(SpawnCube));
        InvokeRepeating(nameof(SpawnCube), 0f, _spawnInterval);
    }

    private void UpdateSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    private void UpdateDistance(float newDistance)
    {
        _distance = newDistance;
    }
}
