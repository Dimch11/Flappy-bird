using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplaySettingsInstaller", menuName = "Installers/GameplaySettingsInstaller")]
public class GameplaySettingsInstaller : ScriptableObjectInstaller<GameplaySettingsInstaller>
{
    public Player.Settings playerSettings;
    public ObstacleGenerator.Settings obstacleGeneratorSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(playerSettings);
        Container.BindInstance(obstacleGeneratorSettings);
    }
}