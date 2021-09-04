using System;
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
    [Header("Obstacles")]
    public GameObject obstaclePrefab;

    public override void InstallBindings()
    {
        BindAsyncProcessor();

        BindInputPanel();

        BindObstacleBehaviour();
        BindObstacleGenerator();

        BindPlayerBehaviour();
        BindPlayer();

        BindObstacleFactory();
    }

    private void BindObstacleFactory()
    {
        Container.BindFactory<Obstacle, Obstacle.Factory>();
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

    private void BindObstacleBehaviour()
    {
        Container.Bind<ObstacleBehaviour>()
            .FromComponentInNewPrefab(obstaclePrefab)
            .AsTransient();
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
