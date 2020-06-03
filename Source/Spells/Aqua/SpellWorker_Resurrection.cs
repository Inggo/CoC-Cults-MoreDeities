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
    /// This spell resurrects all dead colonists in the map
    /// </summary>
    public class SpellWorker_Resurrection : SpellWorker
    {
        public override bool CanSummonNow(Map map)
        {
            Faction faction = altar(map).Faction;

            foreach (Pawn p in map.PlayerPawnsForStoryteller)
            {
                if (p.Dead && p.Faction == faction)
                {
                    return true;
                }
            }

            Messages.Message("MoreDeities_Aqua_NoDead".Translate(), MessageTypeDefOf.RejectInput, false);
            return false;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = parms.target as Map;
            Faction faction = altar(map).Faction;

            foreach (Pawn p in map.PlayerPawnsForStoryteller)
            {
                if (p.Dead && p.Faction == faction)
                {
                    ResurrectionUtility.Resurrect(p);
                    Messages.Message("MoreDeities_Aqua_Resurrected".Translate(), p, MessageTypeDefOf.PositiveEvent);
                }
            }

            return true;
        }
    }
}
