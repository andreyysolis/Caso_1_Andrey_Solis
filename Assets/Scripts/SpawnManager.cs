using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField]
    Transform[] spawningObjects;

    [SerializeField]
    Transform[] spawningPoints;

    [SerializeField]
    float timeBetweenSpawn = 3.0F;

    float _currentTime;
    float _speedMultiplier;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _currentTime = timeBetweenSpawn;
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        _speedMultiplier += Time.deltaTime * 0.07F;

        if (_currentTime >= timeBetweenSpawn)
        {
            _currentTime = 0.0F;

            int spawningIndex = Random.Range(0, spawningObjects.Length);
            Transform prefab = spawningObjects[spawningIndex];

            SpawningObjectController controller = prefab.GetComponent<SpawningObjectController>();
            int[] spawningPoints = controller.GetSpawningPoints();
            spawningIndex = spawningPoints[Random.Range(0, spawningPoints.Length)];

            foreach (Transform point in this.spawningPoints)
            {
                if (point.gameObject.name.Equals("Point " + spawningIndex.ToString()))
                {
                    Instantiate(prefab, point.position, Quaternion.identity);
                    break;
                }
            }

        }
    }

    public float GetSpeedMultiplier()
    {
        return _speedMultiplier;
    }
}
