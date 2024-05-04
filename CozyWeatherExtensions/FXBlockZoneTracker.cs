using System.Collections.Generic;
using System.Linq;
using DistantLands.Cozy;
using OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.CozyWeatherExtensions
{
    /// <summary>
    /// Extension Methods for the <see cref="CozyWeather"/> class to manage FX Particle triggers,
    /// particularly useful when loading/unloading scenes or runtime object instantiation.
    /// </summary>
    public static class FXBlockZoneTracker
    {
        private static Dictionary<int, List<Collider>> blockZonesPerScene = new();

        public static void AddFromScene
        (
            CozyWeather cozyWeather
            , Scene scene
        )
        {
            var objectsToSearchWithin = scene.GetRootGameObjects();
            
            if (!GetBlockZonesFromObjects(objectsToSearchWithin, cozyWeather.cozyTriggerTag, out var blockZones))
            {
                return;
            }
            
            blockZonesPerScene.Add(scene.buildIndex, blockZones);
            RefreshTriggers(cozyWeather);
        }

        public static void RemoveFromScene
        (
            CozyWeather cozyWeather
            , Scene scene
        )
        {
            blockZonesPerScene.Remove(scene.buildIndex);
            RefreshTriggers(cozyWeather);
        }
        
        private static void RefreshTriggers
        (
            CozyWeather cozyWeather
        )
        {
            var colliders = blockZonesPerScene.Values.SelectMany(collider => collider);
            cozyWeather.cozyTriggers.Clear();
            cozyWeather.cozyTriggers.AddRange(colliders);
            
            var cozyParticles = cozyWeather.particleFXParent.GetComponentsInChildren<CozyParticles>();
            AddParticleTriggers(cozyParticles);
        }

        private static void AddParticleTriggers
        (
            IEnumerable<CozyParticles> cozyParticles
        )
        {
            foreach (var cozyParticle in cozyParticles)
            {
                cozyParticle.SetupTriggers();
            }
        }
        
        private static bool GetBlockZonesFromObjects
        (
            IEnumerable<GameObject> gameObjects
            , string cozyTriggerTag
            , out List<Collider> blockZones
        )
        {
            blockZones = gameObjects
                .SelectMany(gameObject => gameObject.FindChildrenComponentsByTag<Collider>(cozyTriggerTag))
                .ToList();

            return blockZones.Count > 0;
        }
    }
}
