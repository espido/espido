﻿using System;
using AutoSharp.Utils;
using LeagueSharp;
using LeagueSharp.Common;
using EloBuddy.SDK;
using EloBuddy;
using EloBuddy.SDK.Menu.Values;

namespace AutoSharp.Auto.SummonersRift
{
    public static class SRManager
    {
        public static void Load()
        {
            if (Program.Config["autosharp.disablesr"].Cast<CheckBox>().CurrentValue)
            {
                Chat.Print("Disabled for SR, only enable if you don't use SharpAI");
                return;
            }
            RoleSwitcher.Load();
            SRShopAI.Main.Init();
            RoleSwitcher.Unpause();
        }

        public static void Unload()
        {
            //RoleSwitcher.Unload(); #TODO OR NOT TODO: SHIT WILL GO CRAZY YO
            RoleSwitcher.Pause();
        }

        public static void FastHalt()
        {
            Orbwalker.ActiveModesFlags = Orbwalker.ActiveModes.None;
            RoleSwitcher.Pause();
        }

        public static void OnUpdate(EventArgs args)
        {
            if (Heroes.Player.InFountain() && !Heroes.Player.IsDead)
            {
                Shopping.Shop();
                Wizard.AntiAfk();
                Orbwalker.ActiveModesFlags = Orbwalker.ActiveModes.Harass;
            }
        }
    }
}
