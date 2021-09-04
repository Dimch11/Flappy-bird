using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [Header("Input")]
    public InputPanel inputPanel;
    [Header("Player")]
    public float playerFlyUpSpeed;
    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    [Header("Generator")]
    public ObstacleGeneratorBehaviour obstacleGeneratorBehaviour;

    public override void InstallBindings()
    {
        BindAsyncProcessor();

        BindInputPanel();

        BindObstacleGeneratorBehaviour();
        BindObstacleGenerator();

        BindPlayerBehaviour();
        BindPlayer();
    }

    private void BindAsyncProcessor()
    {
        Container
            .Bind<AsyncProcessor>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
    }

    private void BindInputPanel()
    {
        Container
            .Bind<InputPanel>()
            .FromInstance(inputPanel)
            .AsSingle();
    }
    private void BindObstacleGeneratorBehaviour()
    {
        Container
            .Bind<ObstacleGeneratorBehaviour>()
            .FromInstance(obstacleGeneratorBehaviour)
            .AsSingle();
    }
    private void BindObstacleGenerator()
    {
        Container
            .Bind<ObstacleGenerator>()
            .AsSingle()
            .NonLazy();
    }
    private void BindPlayerBehaviour()
    {
        var playerBehaviour = 
            Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity, null)
            .GetComponent<PlayerBehaviour>();

        Container
            .Bind<PlayerBehaviour>()
            .FromInstance(playerBehaviour)
            .AsSingle();
    }
    private void BindPlayer()
    {
        Container
            .Bind<Player>()
            .AsSingle()
            .NonLazy();
    }
}
