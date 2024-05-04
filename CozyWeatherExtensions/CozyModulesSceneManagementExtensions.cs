using DistantLands.Cozy;
using UnityEngine.SceneManagement;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.CozyWeatherExtensions
{
    public static class CozyModulesSceneManagementExtensions
    {
        /// <summary>
        /// Handles the scene when it loads.
        /// </summary>
        /// <remarks>
        /// This method would be virtual in the <see cref="CozyModule"/> class.
        /// It does nothing unless explicitly overridden
        /// via an extension method targeting a specific module
        /// and some 'magic' in the primary extension method
        /// <see cref="CozyModuleSceneHandler.HandleModuleOnSceneLoad"/>
        /// </remarks>
        /// <param name="this">
        /// The <see cref="CozyModule"/>.
        /// </param>
        /// <param name="scene">
        /// The scene being loaded.
        /// </param>
        /// <param name="mode">
        /// Used when loading a Scene in a player.
        /// </param>
        public static void OnSceneLoad
        (
            this CozyModule @this
            , Scene scene
            , LoadSceneMode mode
        )
        {
        }

        /// <summary>
        /// Handles the scene when it unloads.
        /// </summary>
        /// <remarks>
        /// This method would be virtual in the <see cref="CozyModule"/> class.
        /// It does nothing unless explicitly overridden
        /// via an extension method targeting a specific module
        /// and some 'magic' in the primary extension method
        /// <see cref="CozyModuleSceneHandler.HandleModuleOnSceneUnload"/>
        /// </remarks>
        /// <param name="this">
        /// The <see cref="CozyModule"/>.
        /// </param>
        /// <param name="scene">
        /// The scene being unloaded.
        /// </param>
        public static void OnSceneUnLoad
        (
            this CozyModule @this
            , Scene scene
        )
        {
        }
    }
}
