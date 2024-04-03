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

namespace CaveCultCode
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        CustomWeaponEnchantment customEnchant = new CustomWeaponEnchantment();

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }



        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            if (e.Button == SButton.V)
            {
                SpawnWeapon();
            }
            if(e.Button == SButton.B)
            {
                this.Monitor.Log($"Ritual dagger has {customEnchant.CurrentKills}", LogLevel.Debug);
            }

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }

        public void SpawnWeapon()
        {
            MeleeWeapon weapon = new MeleeWeapon("65");
            weapon.AddEnchantment(customEnchant);
            weapon.ParentSheetIndex = 65;
            Game1.player.addItemToInventory(weapon);
        }
    }
}