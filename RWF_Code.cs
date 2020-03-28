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
        static RWF_Initializer()
        {
            LongEventHandler.QueueLongEvent(Setup, "LibraryStartup", false, null);
        }
        public static void Setup()
        {
            //Loads ThingDef Name
            ThingDef thingDef;
            thingDef = ThingDef.Named("BaseFilth");
            
            //Lists it all
            List<ThingDef> ThingDefs = DefDatabase<ThingDef>.AllDefsListForReading;
            for (int i = 0; i < ThingDefs.Count; i++)
            {
                if (ThingDefs[i].defName == "Filth_Dirt")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_Dirt;
                    if (Controller.Settings.Filth_Dirt.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_AnimalFilth")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_AnimalFilth;
                    if (Controller.Settings.Filth_AnimalFilth.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_Trash")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_Trash;
                    if (Controller.Settings.Filth_Trash.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_Sand")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_Sand;
                    if (Controller.Settings.Filth_Sand.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_RubbleRock")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_RubbleRock;
                    if (Controller.Settings.Filth_RubbleRock.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_RubbleBuilding")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_RubbleBuilding;
                    if (Controller.Settings.Filth_RubbleBuilding.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "SlagRubble")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.SlagRubble;
                    if (Controller.Settings.SlagRubble.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "SandbagRubble")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.SandbagRubble;
                    if (Controller.Settings.SandbagRubble.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_MachineBits")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_MachineBits;
                    if (Controller.Settings.Filth_MachineBits.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
                }
                if (ThingDefs[i].defName == "Filth_Ash")
                {
                    ThingDefs[i].filth.rainWashes = Controller.Settings.Filth_Ash;
                    if (Controller.Settings.Filth_Ash.Equals(true))
                    {
                        ThingDefs[i].filth.rainWashes = true;
                    }
                    break;
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
            public bool Filth_Dirt = false;
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
                list.CheckboxLabeled("RWF.FilthDirt".Translate(), ref Filth_Dirt);
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

                    Scribe_Values.Look(ref Filth_Dirt, "rainWashesDirt", false);
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
