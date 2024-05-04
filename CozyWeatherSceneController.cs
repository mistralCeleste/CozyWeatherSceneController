using DistantLands.Cozy;
using OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.CozyWeatherExtensions;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts
{
    /// <summary>
    /// Behavior that handles scene changes for Cozy Weather.
    /// </summary>
    [
        AddComponentMenu
        (
            menuName: "One Trillium Games/Weather/Cozy Scene Controller"
            , order: 0
        )
    ]
    public class CozyWeatherSceneController
        : MonoBehaviour
    {
        protected void OnEnable()
        {
            this.AssertHasCozyWeather();
            this.RegisterSceneManagementEvents();
        }

        protected void OnDisable()
        {
            this.UnRegisterSceneManagementEvents();
        }
        
        protected void RegisterSceneManagementEvents()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
            SceneManager.sceneUnloaded += OnSceneUnLoad;
        }
        
        protected void UnRegisterSceneManagementEvents()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
            SceneManager.sceneUnloaded -= OnSceneUnLoad;
        }
        
        public void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            CozyWeather.instance.OnSceneLoad(scene, mode);
        }
        
        public void OnSceneUnLoad(Scene scene)
        {
            CozyWeather.instance.OnSceneUnLoad(scene);
        }
        
        private void AssertHasCozyWeather()
        {
            var errorMessage =
                $"Disabling script {this.name} because Cozy Weather is not instantiated."
                + " Please make sure it is added to the scene since the script is trying to access it.";
            
            Assert.IsNotNull(CozyWeather.instance, errorMessage);
        }
    }
}
