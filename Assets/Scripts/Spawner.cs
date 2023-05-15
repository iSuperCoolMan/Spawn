using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mob _spawnObject;
    [SerializeField] private float _spawnDelayInSeconds;

    private List<Transform> _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().ToList();
        _spawnPoints.Remove(_spawnPoints[0]);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitingTime = new WaitForSeconds(_spawnDelayInSeconds);

        while (true)
        {
            foreach(Transform spawnPoint in _spawnPoints)
            {
                Instantiate(_spawnObject, spawnPoint.position, spawnPoint.rotation);
                yield return waitingTime;
            }
        }
    }
}
