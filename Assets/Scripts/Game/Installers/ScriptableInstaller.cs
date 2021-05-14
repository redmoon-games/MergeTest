using Game.Databases;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "ScriptableInstaller", menuName = "Installers/ScriptableInstaller")]
    public class ScriptableInstaller : ScriptableObjectInstaller<ScriptableInstaller>
    {
        [SerializeField] private ResourceDatabase resourceDatabase;
        [SerializeField] private SpawnChainDatabase spawnChainDatabase;
        
        public override void InstallBindings()
        {
            Container.Bind<ResourceDatabase>().FromScriptableObject(resourceDatabase).AsSingle();
            Container.Bind<SpawnChainDatabase>().FromScriptableObject(spawnChainDatabase).AsSingle();
        }
    }
}
