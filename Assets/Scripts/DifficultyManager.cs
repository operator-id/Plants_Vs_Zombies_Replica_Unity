using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    const float EASY = 1f;
    const float NORMAL = 2f;
    const float HARD = 3f;

    [Range(1, 100)]
    [SerializeField] int maxLives = 10;
    [Range(100, 2000)]
    [SerializeField] int maxResources = 2000;
    [Range(1, 10)]
    [SerializeField] int spawnDelay = 5;
    [Range(1, 10)]
    [SerializeField] int spawnInterval = 5;



    float currentDifficulty;
    int startingResources;
    ResourceDisplay resourceDisplay;
    LivesDisplay lives;
    AttackerSpawner[] spawners;
    void Start()
    {   
        currentDifficulty = PlayerPrefferencesController.GetDifficulty();
        lives = FindObjectOfType<LivesDisplay>();
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
        spawners = FindObjectsOfType<AttackerSpawner>();

        ConfigureLevelParametersBasedOnDifficulty();

        lives.UpdateDisplay();
        resourceDisplay.UpdateDisplay();
    }

    private void ConfigureLevelParametersBasedOnDifficulty()
    {
        switch (currentDifficulty)
        {
            case EASY:
                lives.LivesCount = maxLives;
                resourceDisplay.Resources = maxResources;
                foreach(AttackerSpawner spawner in spawners)
                {
                    spawner.StartingSpawnDelay = spawnDelay;
                    spawner.SpawnInterval = spawnInterval;
                }
                break;
            case NORMAL:
                lives.LivesCount = maxLives/2;
                resourceDisplay.Resources = maxResources * 2/3;
                foreach (AttackerSpawner spawner in spawners)
                {
                    spawner.StartingSpawnDelay = spawnDelay - 2;
                    spawner.SpawnInterval = spawnInterval - 2;
                }
                break;
            case HARD:
                lives.LivesCount = maxLives/3;
                resourceDisplay.Resources = maxResources/2;
                foreach (AttackerSpawner spawner in spawners)
                {
                    spawner.StartingSpawnDelay = spawnDelay - 4;
                    spawner.SpawnInterval = spawnInterval - 4;
                }
                break;
        }
    }

}
