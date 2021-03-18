using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace RWF_Code
{
    [StaticConstructorOnStartup]
    internal static class RWF_Initializer
    {

        public class FilthExtension : DefModExtension
        {
            public bool rainWashes = true;
        }

        static RWF_Initializer()
        {
            LongEventHandler.QueueLongEvent(Setup, "LibraryStartup", false, null);
        }


        public static void Setup()
        {

            //Lists it all
            List<ThingDef> allDefsListForReading = DefDatabase<ThingDef>.AllDefsListForReading;
            allDefsListForReading.Where((ThingDef x) => ((Def)x).HasModExtension<FilthExtension>());


             for (int i = 0; i < allDefsListForReading.Count; i++)
            {

                if (allDefsListForReading[i].defName == "Filth_AnimalFilth")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_AnimalFilth;
                    if (Controller.Settings.Filth_AnimalFilth.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "Filth_Trash")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_Trash;
                    if (Controller.Settings.Filth_Trash.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "Filth_Sand")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_Sand;
                    if (Controller.Settings.Filth_Sand.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "Filth_RubbleRock")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_RubbleRock;
                    if (Controller.Settings.Filth_RubbleRock.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "Filth_RubbleBuilding")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_RubbleBuilding;
                    if (Controller.Settings.Filth_RubbleBuilding.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "SlagRubble")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.SlagRubble;
                    if (Controller.Settings.SlagRubble.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "SandbagRubble")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.SandbagRubble;
                    if (Controller.Settings.SandbagRubble.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "Filth_MachineBits")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_MachineBits;
                    if (Controller.Settings.Filth_MachineBits.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
                if (((Def)allDefsListForReading[i]).defName == "Filth_Ash")
                {
                    allDefsListForReading[i].filth.rainWashes = Controller.Settings.Filth_Ash;
                    if (Controller.Settings.Filth_Ash.Equals(true))
                    {
                        allDefsListForReading[i].filth.rainWashes = true;
                    }
                }
            }
        }

        public class Controller : Mod
        {
            public static Settings Settings;
            public override string SettingsCategory()
            {
                return "RWF.Name".Translate();
            }
            public override void DoSettingsWindowContents(Rect canvas)
            {
                Settings.DoWindowContents(canvas);
            }
            public Controller(ModContentPack content) : base(content)
            {
                Settings = GetSettings<Settings>();
            }
        }

        public class Settings : ModSettings
        {
            public bool Filth_AnimalFilth = false;
            public bool Filth_Trash = false;
            public bool Filth_Sand = false;
            public bool Filth_RubbleRock = false;
            public bool Filth_RubbleBuilding = false;
            public bool SlagRubble = false;
            public bool SandbagRubble = false;
            public bool Filth_MachineBits = false;
            public bool Filth_Ash = false;

            public void DoWindowContents(Rect canvas)
            {
                Listing_Standard list = new Listing_Standard();
                list.ColumnWidth = canvas.width;
                list.Begin(canvas);
                list.Gap();
                list.Label("RWF.Notes".Translate());
                list.Gap();
                list.CheckboxLabeled("RWF.FilthAnimal".Translate(), ref Filth_AnimalFilth);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthTrash".Translate(), ref Filth_Trash);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthSand".Translate(), ref Filth_Sand);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthRubbleRock".Translate(), ref Filth_RubbleRock);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthRubbleBuilding".Translate(), ref Filth_RubbleBuilding);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthRubbleSlag".Translate(), ref SlagRubble);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthRubbleSandBag".Translate(), ref SandbagRubble);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthMachineBits".Translate(), ref Filth_MachineBits);
                list.Gap();
                list.CheckboxLabeled("RWF.FilthAsh".Translate(), ref Filth_Ash);
                list.Gap();

                list.End();
            }


            public override void ExposeData()
            {

                Scribe_Values.Look(ref Filth_AnimalFilth, "rainWashesAnimalFilth", false);
                Scribe_Values.Look(ref Filth_Trash, "rainWashesTrash", false);
                Scribe_Values.Look(ref Filth_Sand, "rainWashesSand", false);
                Scribe_Values.Look(ref Filth_RubbleRock, "rainWashesRubbleRock", false);
                Scribe_Values.Look(ref Filth_RubbleBuilding, "rainWashesRubbleBuilding", false);
                Scribe_Values.Look(ref SlagRubble, "rainWashesSlagRubble", false);
                Scribe_Values.Look(ref SandbagRubble, "rainWashesSandBagRubble", false);
                Scribe_Values.Look(ref Filth_MachineBits, "rainWashesMachineBits", false);
                Scribe_Values.Look(ref Filth_Ash, "rainWashesFilthAsh", false);
                base.ExposeData();


            }
        }

    }
}
