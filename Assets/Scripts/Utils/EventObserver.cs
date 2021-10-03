using System;
using System.Collections;
using System.Collections.Generic;

namespace SpellCombat {

    public static class EventObserver {

        public static Action StartCombatPhaseEvent;

        public static Action StartTurnPhaseEvent;

        public static Action ShowProbabilityTurnEvent;
    
        public static Action ShowChangeProbabilityHUDEvent;

        public static Action ShowCombatActionHUDEvent;

        public static Action ShowSpellOptionHUDEvent;

        public static Action ShowItemOptionHUDEvent;

        public static Action ShowGuardConfirmHUDEvent;

        public static Action ShowRestConfirmHUDEvent;
    }
}
