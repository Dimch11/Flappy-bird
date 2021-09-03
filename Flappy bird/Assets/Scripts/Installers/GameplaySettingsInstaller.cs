using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameplaySettingsInstaller", menuName = "Installers/GameplaySettingsInstaller")]
public class GameplaySettingsInstaller : ScriptableObjectInstaller<GameplaySettingsInstaller>
{
    public Player.Settings playerSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(playerSettings);
    }
}