using System.Collections.Generic;
using UnityEngine;

namespace OneTrilliumGames.Integrations.Cozy_3_Stylized_Weather.Scripts.Extensions
{
    public static class GameObjectExtensions
    {
        public static List<ComponentGeneric> FindChildrenComponentsByTag<ComponentGeneric>
        (
            this GameObject @this
            , string tag
        )
            where ComponentGeneric : Component
        {
            return @this.transform.FindChildrenComponentsByTag<ComponentGeneric>(tag);
        }
    }
}
