﻿using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Velocity : Module
    {
        public int velocityCounter = 0;
        public Velocity() : base("Velocity", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Speed", 10, 10, 50);
        }

        public override void onTick()
        {
            base.onTick();
            if (velocityCounter > 25)
            {
                if (KeybindHandler.isKeyDown('W') | KeybindHandler.isKeyDown('S') | KeybindHandler.isKeyDown('A') | KeybindHandler.isKeyDown('D'))
                {
                    try
                    {
                        if (SDK.instance.player.onGround > 0)
                        {
                            SDK.instance.player.velX *= sliderSettings[0].value / 10F;
                            SDK.instance.player.velZ *= sliderSettings[0].value / 10F;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                velocityCounter = 0;
                return;
            }
            velocityCounter++;
        }
    }
}
