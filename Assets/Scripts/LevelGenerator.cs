using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefabs;
                       GameObject platformPrefab;
    [SerializeField] int platformPoolSize = 100;
    [SerializeField] float checkInterval = 0.5f;
    [SerializeField] float lastPosY = -4.19f;
    [SerializeField] GameObject player;
    int platformChunk = 20;
    public float levelWidth = 3.5f;
    public float minY = 0.5f;
    float currentMaxY;
    public float maxY = 1.7f;
    public List<GameObject> platformPool = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMaxY = maxY - 0.6f;
        for (int i = 0; i < platformPoolSize; i++)
        {
            int current = Random.Range(0, platformPrefabs.Length);
            platformPrefab = platformPrefabs[current];
            if (platformPrefab != null)
            {
                GameObject platform = Instantiate(platformPrefab);
                platform.SetActive(false);
                platformPool.Add(platform);
            }
        }
        StartCoroutine(CheckPlayerPos());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckPlayerPos()
    {
        while (true)
        {
            if (ShouldGenerateMorePlatforms())
            {
                GenerateMorePlatforms();
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    bool ShouldGenerateMorePlatforms()
    {
        if (player.transform.position.y >= lastPosY - 10f)
        {
            return true;
        }
   
        else
        {
            return false;
        }
    }

    void GenerateMorePlatforms()
    {
        Debug.Log($"Starting generating. Current maxY: {currentMaxY}");
        Vector3 spawnPos = new Vector3();
        spawnPos.y = lastPosY;
        for (int i = 0; i < platformChunk; i++)
        {
            spawnPos.y += Random.Range(minY, currentMaxY);
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            int idx = Random.Range(0, platformPool.Count - 1);
            GameObject platform = platformPool[idx];
            if (platform != null)
            {
                platform.transform.position = spawnPos;
                platform.SetActive(true);
                platformPool.RemoveAt(idx);
            }
        }
        if (currentMaxY < maxY)
        {
            currentMaxY += 0.3f;
        }
        lastPosY = spawnPos.y;
        //Debug.Log($"Finished generating. Current platformPool: {platformPool.Count}");
    }

    public void RecyclePlatforms(GameObject platform)
    {
        platform.SetActive(false);
        SpriteSwitcher spriteSwitcher = platform.GetComponent<SpriteSwitcher>();
        if (spriteSwitcher != null)
        {
            spriteSwitcher.ResetSprite();
        }
        PlatformBreak platformBreak = platform.GetComponent<PlatformBreak>();
        if (platformBreak != null)
        {
            platformBreak.broken = false;
        }
        platformPool.Add(platform);
        //Debug.Log($"Platform returnet to Pool. Current platformPool: {platformPool.Count}");
    }
}
