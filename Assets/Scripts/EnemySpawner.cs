using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    private Transform _spawner;
    private Transform[] _enemySpawnPoints;
    private Vector3 _spawnPosition;

    private void Awake()
    {
        _spawner = GetComponent<Transform>();
        _enemySpawnPoints = new Transform[_spawner.childCount];

        for (int i = 0; i < _spawner.childCount; i++)
        {
            _enemySpawnPoints[i] = _spawner.GetChild(i);
        }
    }

    private void Start()
    {
        StartCoroutine(InitializeSpawn());
    }

    private IEnumerator InitializeSpawn()
    {
        var twoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _enemySpawnPoints.Length; i++)
        {
            _spawnPosition = _enemySpawnPoints[i].position + Vector3.up;

            Instantiate(_enemyTemplate, _spawnPosition, Quaternion.identity);

            yield return twoSeconds;
        }
    }
}
