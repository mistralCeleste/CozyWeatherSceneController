using System.Linq;
using DistantLands.Cozy;
using UnityEngine.SceneManagement;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.CozyWeatherExtensions
{
    /// <summary>
    /// Handles the loading and unloading of scenes for CozyModules.
    /// </summary>
    public static class CozyModuleSceneHandler
    {
        public static void HandleSceneLoad
        (
            CozyWeather cozyWeather
            , Scene scene
            , LoadSceneMode mode
        )
        {
            var modulesToRefresh = cozyWeather.modules.Where(module => module.isActiveAndEnabled);

            foreach (var module in modulesToRefresh)
            {
                HandleModuleOnSceneLoad(module, scene, mode);
            }
        }

        public static void HandleSceneUnLoad
        (
            CozyWeather cozyWeather
            , Scene scene
        )
        {
            var modulesToRefresh = cozyWeather.modules.Where(module => module.isActiveAndEnabled);

            foreach (var module in modulesToRefresh)
            {
                HandleModuleOnSceneUnload(module, scene);
            }
        }
        
        /// <summary>
        /// Handles the <see cref="CozyModule"/>s when a scene is loaded.
        /// </summary>
        /// <remarks>
        /// To simulate the overriding of the virtual method in the <see cref="CozyModule"/>
        /// or a class that inherits it,
        /// add to the conditional in the method using the pattern:
        ///   <code>
        ///     else if (module is CozySpecificModule specificModule)
        ///     {
        ///         specificModule.OnSceneLoad(scene, mode);
        ///     }
        ///   </code>
        /// and then create a handler for that modules OnSceneLoad method, see
        /// <see cref="CozyModuleExtensions"/> for more details.
        /// </remarks>
        /// <param name="module">
        /// The <see cref="CozyModule"/>.
        /// </param>
        /// <param name="scene">
        /// The scene being loaded.
        /// </param>
        /// <param name="mode">
        /// Used when loading a Scene in a player.
        /// </param>
        private static void HandleModuleOnSceneLoad
        (
            CozyModule module
            , Scene scene
            , LoadSceneMode mode
        )
        {
            if (module is CozyReflectionsModule reflectionsModule)
            {
                reflectionsModule.OnSceneLoad(scene, mode);
            }
            else
            {
                module.OnSceneLoad(scene, mode);
            }
        }

        /// <summary>
        /// Handles the <see cref="CozyModule"/>s when a scene is unloaded.
        /// </summary>
        /// <remarks>
        /// To simulate the overriding of the virtual method in the <see cref="CozyModule"/>
        /// or a class that inherits it,
        /// add to the conditional in the method using the pattern:
        ///   <code>
        ///     else if (module is CozySpecificModule specificModule)
        ///     {
        ///         specificModule.OnSceneUnLoad(scene, mode);
        ///     }
        ///   </code>
        /// and then create a handler for that modules OnSceneUnLoad method, see
        /// <see cref="CozyModuleExtensions"/> for more details.
        /// </remarks>
        /// <param name="module">
        /// The <see cref="CozyModule"/>.
        /// </param>
        /// <param name="scene">
        /// The scene being unloaded.
        /// </param>
        private static void HandleModuleOnSceneUnload
        (
            CozyModule module
            , Scene scene
        )
        {
            if (module is CozyReflectionsModule reflectionsModule)
            {
                reflectionsModule.OnSceneUnLoad(scene);
            }
            else
            {
                module.OnSceneUnLoad(scene);
            }
        }
    }
}
