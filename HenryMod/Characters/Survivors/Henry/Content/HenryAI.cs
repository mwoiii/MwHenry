using RoR2;
using RoR2.CharacterAI;
using UnityEngine;

namespace HenryMod.Survivors.Henry {
    public static class HenryAI {
        public static void Init(GameObject bodyPrefab, string masterName) {
            GameObject master = Modules.Prefabs.CreateBlankMasterPrefab(bodyPrefab, masterName);

            BaseAI baseAI = master.GetComponent<BaseAI>();
            baseAI.aimVectorDampTime = 0.1f;
            baseAI.aimVectorMaxSpeed = 360;

            #region Primary
            AISkillDriver primaryDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            primaryDriver.customName = "Use Primary";
            primaryDriver.skillSlot = SkillSlot.Primary;
            primaryDriver.requiredSkill = null; //usually used when you have skills that override other skillslots like engi harpoons
            primaryDriver.requireSkillReady = false; //usually false for primaries
            primaryDriver.requireEquipmentReady = false;
            primaryDriver.minUserHealthFraction = float.NegativeInfinity;
            primaryDriver.maxUserHealthFraction = float.PositiveInfinity;
            primaryDriver.minTargetHealthFraction = float.NegativeInfinity;
            primaryDriver.maxTargetHealthFraction = float.PositiveInfinity;
            primaryDriver.minDistance = 0;
            primaryDriver.maxDistance = 8;
            primaryDriver.selectionRequiresTargetLoS = false;
            primaryDriver.selectionRequiresOnGround = false;
            primaryDriver.selectionRequiresAimTarget = false;
            primaryDriver.maxTimesSelected = -1;

            //Behavior
            primaryDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            primaryDriver.activationRequiresTargetLoS = false;
            primaryDriver.activationRequiresAimTargetLoS = false;
            primaryDriver.activationRequiresAimConfirmation = false;
            primaryDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            primaryDriver.moveInputScale = 1;
            primaryDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            primaryDriver.ignoreNodeGraph = false; //will chase relentlessly but be kind of stupid
            primaryDriver.shouldSprint = false;
            primaryDriver.shouldFireEquipment = false;
            primaryDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;

            //Transition Behavior
            primaryDriver.driverUpdateTimerOverride = -1;
            primaryDriver.resetCurrentEnemyOnNextDriverSelection = false;
            primaryDriver.noRepeat = false;
            primaryDriver.nextHighPriorityOverride = null;
            #endregion

            #region Secondary
            AISkillDriver secondaryDriver = master.AddComponent<AISkillDriver>();
            secondaryDriver.customName = "Use Secondary";
            secondaryDriver.skillSlot = SkillSlot.Secondary;
            secondaryDriver.requireSkillReady = true;
            secondaryDriver.minDistance = 0;
            secondaryDriver.maxDistance = 25;
            secondaryDriver.selectionRequiresTargetLoS = false;
            secondaryDriver.selectionRequiresOnGround = false;
            secondaryDriver.selectionRequiresAimTarget = false;
            secondaryDriver.maxTimesSelected = -1;

            //Behavior
            secondaryDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            secondaryDriver.activationRequiresTargetLoS = false;
            secondaryDriver.activationRequiresAimTargetLoS = false;
            secondaryDriver.activationRequiresAimConfirmation = true;
            secondaryDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            secondaryDriver.moveInputScale = 1;
            secondaryDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            secondaryDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;
            #endregion

            #region Utility
            AISkillDriver utilityDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            utilityDriver.customName = "Use Utility";
            utilityDriver.skillSlot = SkillSlot.Utility;
            utilityDriver.requireSkillReady = true;
            utilityDriver.minDistance = 8;
            utilityDriver.maxDistance = 20;
            utilityDriver.selectionRequiresTargetLoS = true;
            utilityDriver.selectionRequiresOnGround = false;
            utilityDriver.selectionRequiresAimTarget = false;
            utilityDriver.maxTimesSelected = -1;

            //Behavior
            utilityDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            utilityDriver.activationRequiresTargetLoS = false;
            utilityDriver.activationRequiresAimTargetLoS = false;
            utilityDriver.activationRequiresAimConfirmation = false;
            utilityDriver.movementType = AISkillDriver.MovementType.StrafeMovetarget;
            utilityDriver.moveInputScale = 1;
            utilityDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            utilityDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;
            #endregion

            #region Special
            AISkillDriver bombDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            bombDriver.customName = "Use Special";
            bombDriver.skillSlot = SkillSlot.Special;
            bombDriver.requireSkillReady = true;
            bombDriver.minDistance = 0;
            bombDriver.maxDistance = 20;
            bombDriver.selectionRequiresTargetLoS = false;
            bombDriver.selectionRequiresOnGround = false;
            bombDriver.selectionRequiresAimTarget = false;
            bombDriver.maxTimesSelected = -1;

            //Behavior
            bombDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            bombDriver.activationRequiresTargetLoS = false;
            bombDriver.activationRequiresAimTargetLoS = false;
            bombDriver.activationRequiresAimConfirmation = false;
            bombDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            bombDriver.moveInputScale = 1;
            bombDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            bombDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;

            AISkillDriver chaseDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            chaseDriver.customName = "Chase";
            chaseDriver.skillSlot = SkillSlot.None;
            chaseDriver.requireSkillReady = false;
            chaseDriver.minDistance = 0;
            chaseDriver.maxDistance = float.PositiveInfinity;

            //Behavior
            chaseDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            chaseDriver.activationRequiresTargetLoS = false;
            chaseDriver.activationRequiresAimTargetLoS = false;
            chaseDriver.activationRequiresAimConfirmation = false;
            chaseDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            chaseDriver.moveInputScale = 1;
            chaseDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            chaseDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;
            #endregion
        }
    }
}
