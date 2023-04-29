﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _powerUpContainer;
    [SerializeField]
    private bool _stopSpawning = false;

    private const float SpawnTime = 5.0f;

    private Transform _enemyContainerTransform;

    void Start()
    {
        _enemyContainerTransform = _enemyContainer.transform;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(powerUpRoutine());
    }

    //IEnumerator SpawnRoutine()
    //{
    //    while (!_stopSpawning)
    //    {
    //        Vector3 posToSpawn = new Vector3(Random.Range(-8f,8f), 7, 0);
    //        GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity, _enemyContainerTransform);
    //        yield return new WaitForSeconds(SpawnTime);
    //    }
    //}
    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            if (_enemyPrefab == null)
            {
                Debug.LogError("Enemy prefab is not assigned!");
                yield break;
            }

            while (!_stopSpawning)
            { 
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity, _enemyContainerTransform);
            yield return new WaitForSeconds(SpawnTime);
            }
        }
    }

    IEnumerator powerUpRoutine()
    {
        while (!_stopSpawning)
        {
            if (_tripleShotPrefab == null)
            {
                Debug.LogError("Power prefab is not assigned!");
                yield break;
            }

            while (!_stopSpawning)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                GameObject newEnemy = Instantiate(_tripleShotPrefab, posToSpawn, Quaternion.identity, _enemyContainerTransform);
                yield return new WaitForSeconds(Random.Range(1f, 20f));
            }
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;

        foreach (Transform child in _enemyContainerTransform)
        {
            Destroy(child.gameObject);
        }
    }



}
