using Objects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ObjectSelectionController selectionController;

        public override void InstallBindings()
        {
            Container.Bind<ObjectsFactory>().AsSingle();
            Container.Bind<ObjectSelectionController>().FromInstance(selectionController).AsSingle();
        }
    }
}