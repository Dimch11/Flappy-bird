using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [Header("Interface")]
    public ScoreTextBehaviour scoreTextBehaviour;
    public Button pauseButton;
    public PauseWindowBehaviour pauseWindow;

    public override void InstallBindings()
    {
        BindAsyncProcessor();

        BindInputPanel();

        BindObstacleBehaviour();
        BindObstacleGenerator();

        BindPlayerBehaviour();
        BindPlayer();

        BindObstacleFactory();

        BindScore();
        BindScoreTextBehaviour();

        BindContainerText();

        BindPauseManager();
        BindPauseButton();
        BindButtonToPauseButton();
        BindPauseWindowBehaviour();
        BindPauseWindow();
    }

    private void BindPauseWindow()
    {
        Container
            .Bind<PauseWindow>()
            .AsSingle()
            .NonLazy();
    }

    private void BindPauseWindowBehaviour()
    {
        Container
            .Bind<PauseWindowBehaviour>()
            .FromInstance(pauseWindow)
            .AsSingle();
    }

    private void BindPauseButton()
    {
        Container
            .Bind<PauseButton>()
            .AsSingle()
            .NonLazy();
    }

    private void BindButtonToPauseButton()
    {
        Container
            .Bind<Button>()
            .FromInstance(pauseButton)
            .AsSingle()
            .WhenInjectedInto<PauseButton>();
    }
    private void BindPauseManager()
    {
        Container
            .Bind<PauseManager>()
            .AsSingle()
            .NonLazy();
    }

    private void BindContainerText()
    {
        Container
            .Bind<ScoreText>()
            .AsSingle()
            .NonLazy();
    }

    private void BindScore()
    {
        Container
            .Bind<Score>()
            .AsSingle()
            .NonLazy();
    }
    private void BindScoreTextBehaviour()
    {
        Container
            .Bind<ScoreTextBehaviour>()
            .FromInstance(scoreTextBehaviour)
            .AsSingle();
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
