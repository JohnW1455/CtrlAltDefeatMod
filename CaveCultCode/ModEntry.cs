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

<<<<<<< Updated upstream
=======
        public void activateAltar(int numberOfKills)
        {
            if (numberOfKills > 5)
            {
                this.numberOfKills = 0;
                Game1.addHUDMessage(new HUDMessage("Something happened", 2));
                rainTomorrow(Game1.player);

            }
            else
            {
                Game1.addHUDMessage(new HUDMessage("Hmmm doesn't seem to be working... I should come back when I've charged it up more.", 2));
            }
        }

        private void rainTomorrow(Farmer who)
        {
            GameLocation currentLocation = who.currentLocation;
            string text = currentLocation.GetLocationContextId();
            LocationContextData locationContext = currentLocation.GetLocationContext();
            if (!locationContext.AllowRainTotem)
            {
                Game1.showRedMessageUsingLoadString("Strings\\UI:Item_CantBeUsedHere");
                return;
            }

            if (locationContext.RainTotemAffectsContext != null)
            {
                text = locationContext.RainTotemAffectsContext;
            }

            bool flag = false;
            if (text == "Default")
            {
                if (!Utility.isFestivalDay(Game1.dayOfMonth + 1, Game1.season))
                {
                    Game1.netWorldState.Value.WeatherForTomorrow = (Game1.weatherForTomorrow = "Rain");
                    flag = true;
                }
            }
            else
            {
                currentLocation.GetWeather().WeatherForTomorrow = "Rain";
                flag = true;
            }

            if (flag)
            {
                Game1.pauseThenMessage(2000, Game1.content.LoadString("Strings\\StringsFromCSFiles:Object.cs.12822"));
            }
        }

>>>>>>> Stashed changes
        private void Player_Warped(object sender, StardewModdingAPI.Events.WarpedEventArgs e)
        {
            Monster[] slimes = new Monster[3];

            if(e.NewLocation.Name == "Custom_Cave_Level1")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to" + e.NewLocation.Name, HUDMessage.error_type));
                slimes[0] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(20 * 64, 25 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[1] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(26 * 64, 26 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[2] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(30 * 64, 28 * 64), Microsoft.Xna.Framework.Color.BlueViolet);

                foreach(Monster slime in slimes)
                {
                    Game1.currentLocation.characters.Add(slime);
                }

                Array.Clear(slimes);
            }

            if (e.NewLocation.Name == "Custom_Cave_Level2")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to" + e.NewLocation.Name, HUDMessage.error_type));
                slimes[0] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(9 * 64, 15 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[1] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(16 * 64, 16 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[2] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(25 * 64, 13 * 64), Microsoft.Xna.Framework.Color.BlueViolet);

                foreach (Monster slime in slimes)
                {
                    Game1.currentLocation.characters.Add(slime);
                }

                Array.Clear(slimes);
            }

            if (e.NewLocation.Name == "Custom_Cave_Level3")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to" + e.NewLocation.Name, HUDMessage.error_type));
                slimes[0] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(10 * 64, 19 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[1] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(18 * 64, 20 * 64), Microsoft.Xna.Framework.Color.BlueViolet);
                slimes[2] = new GreenSlime(new Microsoft.Xna.Framework.Vector2(26 * 64, 17 * 64), Microsoft.Xna.Framework.Color.BlueViolet);

                foreach (Monster slime in slimes)
                {
                    Game1.currentLocation.characters.Add(slime);
                }

                Array.Clear(slimes);
            }
        }
    }
}