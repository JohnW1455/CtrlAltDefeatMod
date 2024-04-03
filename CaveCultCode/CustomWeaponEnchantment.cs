using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Enchantments;
using StardewValley.Tools;
using StardewValley.Monsters;
using System.Diagnostics;

namespace CaveCultCode
{
    public class CustomWeaponEnchantment: BaseWeaponEnchantment
    {

        private int currentKills = 0;
        public int CurrentKills
        {
            get { return currentKills; }
            set { currentKills = value; }
        }
        public CustomWeaponEnchantment()
        {

        }

        protected override void _OnMonsterSlay(Monster m, GameLocation location, Farmer who)
        {
            currentKills++;
        }
    }
}
