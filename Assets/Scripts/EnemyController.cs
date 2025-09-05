using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private NavMeshAgent _enemyAgent;

    private int _currentHealth;
    private Transform _currentPoint;
    private Transform[] _targetPoints;
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetParams();
    }

    private void OnEnable()
    {
        SetParams();
    }

    private void SetParams()
    {
        _currentHealth = _maxHealth;
        _targetPoints = TargetPoints.Instance.GetPoints();
        _currentPoint = _targetPoints[Random.Range(0, _targetPoints.Length)];
        _enemyAgent.SetDestination(_currentPoint.position);
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }

}
