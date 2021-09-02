using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public InputPanel inputPanel;

    public override void InstallBindings()
    {
        Container.Bind<InputPanel>().FromInstance(inputPanel);
    }
}
