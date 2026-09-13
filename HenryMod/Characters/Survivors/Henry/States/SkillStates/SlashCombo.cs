using HenryMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace HenryMod.Survivors.Henry.States {
    public class SlashCombo : BaseMeleeAttack {
        public override void OnEnter() {
            hitboxGroupName = "SwordGroup";

            damageType = DamageTypeCombo.GenericPrimary;
            damageCoefficient = HenryStaticValues.swordDamageCoefficient;
            procCoefficient = 1f;
            pushForce = 300f;
            bonusForce = Vector3.zero;
            baseDuration = 1f;

            attackStartPercentTime = 0.2f;
            attackEndPercentTime = 0.4f;

            earlyExitPercentTime = 0.6f;

            hitStopDuration = 0.012f;
            attackRecoil = 0.5f;
            hitHopVelocity = 4f;

            swingSoundString = "HenrySwordSwing";
            hitSoundString = "";
            muzzleString = swingIndex % 2 == 0 ? "SwingLeft" : "SwingRight";
            playbackRateParam = "Slash.playbackRate";
            swingEffectPrefab = HenryAssets.swordSwingEffect;
            hitEffectPrefab = HenryAssets.swordHitImpactEffect;

            impactSound = HenryAssets.swordHitSoundEvent.index;

            base.OnEnter();
        }

        protected override void PlayAttackAnimation() {
            PlayCrossfade("Gesture, Override", "Slash" + (1 + swingIndex), playbackRateParam, duration, 0.1f * duration);
        }

        protected override void PlaySwingEffect() {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority() {
            base.OnHitEnemyAuthority();
        }

        public override void OnExit() {
            base.OnExit();
        }
    }
}