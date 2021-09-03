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

    public override void InstallBindings()
    {
        BindInputPanel();
        BindPlayerBehaviour();
        BindPlayer();
    }
    private void BindInputPanel()
    {
        Container
            .Bind<InputPanel>()
            .FromInstance(inputPanel)
            .AsSingle();
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
