using System.Collections.Generic;
using UnityEngine;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.Extensions
{
    public static class TransformExtensions
    {
        public static List<ComponentGeneric> FindChildrenComponentsByTag<ComponentGeneric>
        (
            this Transform @this
            , string tag
        )
            where ComponentGeneric : Component
        {
            var components = new List<ComponentGeneric>();

            foreach (Transform child in @this)
            {
                if (child && child.CompareTag(tag))
                {
                    var component = child.GetComponent<ComponentGeneric>();

                    if (component)
                    {
                        components.Add(component);
                    }
                }

                components.AddRange(FindChildrenComponentsByTag<ComponentGeneric>(child, tag));
            }

            return components;
        }
    }
}
