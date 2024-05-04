using DistantLands.Cozy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.CozyWeatherExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="CozyReflectionsModule"/> class.
    /// </summary>
    public static class CozyReflectionsModuleSceneManagementExtensions
    {
        /// <summary>
        /// Handles the scene when it loads
        /// by rendering the cubemap.
        /// </summary>
        /// <param name="this">
        /// The <see cref="CozyReflectionsModule"/>.
        /// </param>
        /// <param name="scene">
        /// The scene being loaded.
        /// </param>
        /// <param name="mode">
        /// Used when loading a Scene in a player.
        /// </param>
        public static void OnSceneLoad
        (
            this CozyReflectionsModule @this
            , Scene scene
            , LoadSceneMode mode
        )
        {
            if (!@this)
            {
                return;
            }

            @this.RenderReflections();
        }
        
        /// <summary>
        /// Handles the scene when it unloads
        /// by restoring the cubemap to the default one provided by the module.
        /// </summary>
        /// <param name="this">
        /// The <see cref="CozyReflectionsModule"/>.
        /// </param>
        /// <param name="scene">
        /// The scene being unloaded.
        /// </param>
        public static void OnSceneUnLoad
        (
            this CozyReflectionsModule @this
            , Scene scene
        )
        {
            if (!@this)
            {
                return;
            }

            var cubemapResourcePath = "Materials/Reflection Cubemap";
            @this.reflectionCubemap = Resources.Load(cubemapResourcePath) as Cubemap;
        }
    }
}
