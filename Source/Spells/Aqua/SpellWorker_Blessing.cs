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
    /// This spell blesses her cult
    /// </summary>
    public class SpellWorker_Blessing : SpellWorker
    {
        public override bool CanSummonNow(Map map)
        {
            return true;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = parms.target as Map;

            foreach (Pawn p in altar(map).AvailableWorshippers)
            {
                // Set health to maximum
                p.HitPoints = p.MaxHitPoints;
                // Add Aqua's blessing
                p.needs.mood.thoughts.memories.TryGainMemory(DefDatabase<ThoughtDef>.GetNamed("MoreDeities_Thoughts_Aqua_Blessed", true));
                // Increase all need values
                p.needs.AllNeeds.ForEach(delegate (Need n)
                {
                    n.CurLevel += 0.5f;
                });
            }

            return true;
        }
    }
}
