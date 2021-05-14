using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<ScriptableInstaller>
    {
        public GameSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(settings);
        }
    }
}
