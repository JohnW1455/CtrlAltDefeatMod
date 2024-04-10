using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CaveCultCode
{
    public class Altar
    {
        private IModHelper helper;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }


        public Altar(IModHelper helper) {
            this.helper = helper;
            this.position = new Vector2(21, 31);
        }

        public void activateAltar(CustomWeaponEnchantment customWeapon)
        {
            if(customWeapon.CurrentKills > 5)
            {
                customWeapon.CurrentKills = 0;
                Game1.weatherForTomorrow = "weather_rain";
            }
            else
            {
                Game1.addHUDMessage(new HUDMessage("Hmmm doesn't seem to be working... I should come back when I've charged it up more.", 2)); 
            }
        }
    }
}
