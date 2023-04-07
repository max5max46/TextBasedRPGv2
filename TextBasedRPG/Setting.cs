using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    public static class Setting
    {
        public const int OFFSET_X = 1;
        public const int OFFSET_Y = 1;

        //Player Setting
        public const int PLAYER_HEALTH = 5;
        public const int PLAYER_DAMAGE = 1;

        //Enemy Setting
        public const int CHASER_HEALTH = 3;
        public const int CHASER_DAMAGE = 1;

        public const int RUNNER_HEALTH = 2;
        public const int RUNNER_DAMAGE = 0;

        public const int BOUNCER_HEALTH = 5;
        public const int BOUNCER_DAMAGE = 2;

        public const int BOSS_HEALTH = 20;
        public const int BOSS_DAMAGE = 4;

        //Item Setting
        public const int DAMAGE_UP_AMOUNT = 1;
        public const int MAX_HEALTH_UP_AMOUNT = 2;
        public const int HEAL_AMOUNT = 5;
    }
}
