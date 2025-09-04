using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _poolSize = 10;

    private List<GameObject> _pool;

    void Start()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i <= _poolSize; i++)
        {
            GameObject _enemy = Instantiate(_enemyPrefab);
            _enemy.SetActive(false);
            _pool.Add(_enemy);
        }
    }


    public GameObject GetEnemy()
    {
        foreach (var enemy in _pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        // GameObject newEnemy = Instantiate(_enemyPrefab);
        // _pool.Add(newEnemy);
        // return newEnemy;
        return null;
    }
}
