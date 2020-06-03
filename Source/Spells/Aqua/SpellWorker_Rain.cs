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
    /// This spell calls forth rain.
    /// </summary>
    public class SpellWorker_Rain : SpellWorker
    {
        public override bool CanSummonNow(Map map)
        {
            if (map.weatherManager.curWeather == WeatherDef.Named("Rain"))
            {
                Messages.Message("MoreDeities_Aqua_AlreadyRaining".Translate(), MessageTypeDefOf.RejectInput, false);
                return false;
            }

            return true;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = parms.target as Map;
            map.weatherManager.TransitionTo(WeatherDef.Named("Rain"));
            return true;
        }
    }
}
