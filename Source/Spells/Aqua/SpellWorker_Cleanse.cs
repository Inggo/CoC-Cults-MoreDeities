using CultOfCthulhu;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using UnityEngine;

namespace Inggo.MoreDeities.Aqua
{
    /// <summary>
    /// This spell clears all filth in the map.
    /// </summary>
    public class SpellWorker_Cleanse : SpellWorker
    {
        public override bool CanSummonNow(Map map)
        {
            return true;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = parms.target as Map;
            
            Filth f;
            
            List<Thing> mapFilths = map.listerThings.ThingsInGroup(ThingRequestGroup.Filth);
            
            for (int i = mapFilths.Count - 1; i >= 0; i--)
            {
                f = (Filth)mapFilths[i];
                f.DeSpawn();

                if (!f.Destroyed)
                {
                    f.Destroy(DestroyMode.Vanish);
                }

                if (!f.Discarded)
                {
                    f.Discard();
                }
            }
            
            return true;
        }
    }
}
