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
            helper.Events.Player.Warped += Player_Warped;
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

        private void Player_Warped(object sender, StardewModdingAPI.Events.WarpedEventArgs e)
        {
            Monster[] slimes = new Monster[3];

            if(e.NewLocation.Name == "Custom_Cave_Level1")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to" + e.NewLocation.Name, HUDMessage.error_type));
                slimes[0] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(15 * 64, 20 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[1] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(15 * 64, 25 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[2] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(15 * 64, 30 * 64), Microsoft.Xna.Framework.Color.BlueViolet);

                foreach(Monster slime in slimes)
                {
                    Game1.currentLocation.characters.Add(slime);
                }

                Array.Clear(slimes);
            }

            if (e.NewLocation.Name == "Custom_Cave_Level2")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to" + e.NewLocation.Name, HUDMessage.error_type));
                slimes[0] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(15 * 64, 20 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[1] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(15 * 64, 25 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[2] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(15 * 64, 30 * 64), Microsoft.Xna.Framework.Color.BlueViolet);

                foreach (Monster slime in slimes)
                {
                    Game1.currentLocation.characters.Add(slime);
                }

                Array.Clear(slimes);
            }

            if (e.NewLocation.Name == "Custom_Cave_Level3")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to" + e.NewLocation.Name, HUDMessage.error_type));
                slimes[0] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(20 * 64, 20 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[1] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(20 * 64, 25 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[2] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(20 * 64, 30 * 64), Microsoft.Xna.Framework.Color.BlueViolet);

                foreach (Monster slime in slimes)
                {
                    Game1.currentLocation.characters.Add(slime);
                }

                Array.Clear(slimes);
            }

            else
            {
                Game1.hudMessages.Add(new HUDMessage("NO THIS IS NOT THE RIGHT MAP", HUDMessage.error_type));
            }
        }
    }
}