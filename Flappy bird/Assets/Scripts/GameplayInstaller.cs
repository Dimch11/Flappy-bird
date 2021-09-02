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
        var playerBehaviour = Container
            .InstantiatePrefabForComponent<PlayerBehaviour>(playerPrefab, playerSpawnPoint.position, Quaternion.identity, null);

        Container
            .Bind<PlayerBehaviour>()
            .FromInstance(playerBehaviour)
            .AsSingle();
    }
    private void BindPlayer()
    {
        var player = new Player(playerFlyUpSpeed);

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
        Container.QueueForInject(player);
    }
}
