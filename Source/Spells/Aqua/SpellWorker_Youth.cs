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
    /// This spell makes the cultists younger
    /// </summary>
    public class SpellWorker_Youth : SpellWorker
    {
        const long YEAR_TICKS = 3600000;
        const int MIN_AGE = 13;
        
        public override bool CanSummonNow(Map map)
        {
            Pawn p = altar(map).tempExecutioner;

            if (p.ageTracker.AgeBiologicalYears <= MIN_AGE)
            {
                Messages.Message("MoreDeities_Aqua_TooYoung".Translate(p.Name.ToStringShort), p, MessageTypeDefOf.RejectInput, false);
                return false;
            }
            return true;
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = parms.target as Map;
            Pawn p = altar(map).tempExecutioner;

            // Generate random 1-10
            System.Random random = new System.Random();

            int years = random.Next(5, 11);
            int deAged = 0;

            while (p.ageTracker.AgeBiologicalYears > MIN_AGE && deAged < years)
            {
                p.ageTracker.AgeBiologicalTicks -= YEAR_TICKS;
                deAged++;
            }

            Messages.Message("MoreDeities_Aqua_Youth".Translate(
                    p.Name.ToStringShort, 
                    yrs(deAged),
                    yrs(p.ageTracker.AgeBiologicalYears)
                ), p, MessageTypeDefOf.PositiveEvent);

            return true;
        }

        private string yrs(int num) {
            return num.ToString() + (num == 1 ? " year" : " years");
        }
    }
}
