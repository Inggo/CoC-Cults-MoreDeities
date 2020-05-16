using RimWorld;
using UnityEngine;
using Verse;

namespace Inggo.MoreDeities
{
    public class MoreDeities : Mod
    {
        Settings settings;
        public MoreDeities(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<Settings>();
        }
    }

    public class Settings : ModSettings
    {

    }
}
