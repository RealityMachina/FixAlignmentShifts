using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FixAlignmentShifts
{
    [HarmonyPatch(typeof(UnitAlignment), "Shift",  new Type[] { typeof(AlignmentShiftDirection), typeof(int), typeof(IAlignmentShiftProvider) })]
    class AlignmentChecker
    {

        private static void Prefix(UnitAlignment __instance, ref AlignmentShiftDirection direction, int value)
        {

            Main.Log("Get current alignment direction " + direction.ToString());
            Main.Log("Get our current alignment " + __instance.m_Value.ToString());

            if(direction == AlignmentShiftDirection.Evil)
            {
                switch (__instance.m_Value)
                {
                    case Alignment.LawfulEvil:
                        direction = AlignmentShiftDirection.LawfulEvil;
                        break;
                    case Alignment.ChaoticEvil:
                        direction = AlignmentShiftDirection.ChaoticEvil;
                        break;
                    default:
                        break;
                }

            }
            else if (direction == AlignmentShiftDirection.Good)
            {
                switch (__instance.m_Value)
                {
                    case Alignment.ChaoticGood:
                        direction = AlignmentShiftDirection.ChaoticGood;
                        break;
                    case Alignment.LawfulGood:
                        direction = AlignmentShiftDirection.LawfulGood;
                        break;
                    default:
                        break;
                }
            }
            Main.Log("Get current alignment direction " + direction.ToString());
            return;
        }

    }
}
