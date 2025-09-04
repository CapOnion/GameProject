using UnityEngine;

public class TargetPoints : MonoBehaviour
{
    public static TargetPoints Instance { get; private set; }
    [SerializeField] private Transform[] _targetPoints;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public Transform[] GetPoints()
    {
        return _targetPoints;
    }
}
