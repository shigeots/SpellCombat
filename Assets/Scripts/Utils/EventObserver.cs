using System;
using System.Collections;
using System.Collections.Generic;

namespace SpellCombat {

    public static class EventObserver {

        public static Action StartCombatPhaseEvent;

        public static Action StartTurnPhaseEvent;

        public static Action ShowProbabilityTurnEvent;

        public static Action UpdateProbabilityTurnEvent;

        public static Action UpdatePlayerStatsHUDEvent;

        public static Action UpdateEnemyStatsHUDEvent;
    
        public static Action ShowChangeProbabilityHUDEvent;

        public static Action ShowCombatActionHUDEvent;

        public static Action ShowSpellOptionHUDEvent;

        public static Action ShowItemOptionHUDEvent;

        public static Action ShowGuardConfirmHUDEvent;

        public static Action ShowRestConfirmHUDEvent;

        public static Action VerifyChangeWizardElementEvent;

        public static Action ChangeWizardElementalTypeEvent;

        public static Action NoChangeWizardElementalTypeEvent;

        public static Action ExecuteThePlayerActionEvent;

        public static Action ShowMessagePlayerActionEvent;

        public static Action CheckEnemyIsAliveEvent;

        public static Action ExecuteTheEnemyActionEvent;

        public static Action ShowMessageEnemyActionEvent;

        public static Action CheckPlayerIsAliveEvent;

        public static Action WinCombatActionEvent;

        public static Action LoseCombatActionEvent;
    }
}
