using DistantLands.Cozy;
using UnityEngine.SceneManagement;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.CozyWeatherExtensions
{
    /// <summary>
    /// Ideally, these would be added to the CozyWeather system,
    /// but extension methods make this intuitive to use while not editing the class directly.
    /// </summary>
    public static class CozyWeatherExtensions
    {
        public static void OnSceneLoad
        (
            this CozyWeather @this
            , Scene scene
            , LoadSceneMode mode
        )
        {
            FXBlockZoneTracker.AddFromScene(@this, scene);
            CozyModuleSceneHandler.HandleSceneLoad(@this, scene, mode);
        }

        public static void OnSceneUnLoad
        (
            this CozyWeather @this
            , Scene scene
        )
        {
            FXBlockZoneTracker.RemoveFromScene(@this, scene);
            CozyModuleSceneHandler.HandleSceneUnLoad(@this, scene);
        }
    }
}
