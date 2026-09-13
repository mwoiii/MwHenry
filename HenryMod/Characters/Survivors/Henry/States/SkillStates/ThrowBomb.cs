using EntityStates;
using RoR2;
using RoR2.Projectile;

namespace HenryMod.Survivors.Henry.States {
    public class ThrowBomb : GenericProjectileBaseState {
        public static float BaseDuration = 0.65f;

        public static float BaseDelayDuration = 0.0f;

        public static float DamageCoefficient = 16f;

        public override void OnEnter() {
            projectilePrefab = HenryAssets.bombProjectilePrefab;

            attackSoundString = "HenryBombThrow";

            baseDuration = BaseDuration;
            baseDelayBeforeFiringProjectile = BaseDelayDuration;

            damageCoefficient = DamageCoefficient;

            force = 80f;

            recoilAmplitude = 0.1f;
            bloom = 10;

            base.OnEnter();
        }

        public override void ModifyProjectileInfo(ref FireProjectileInfo fireProjectileInfo) {
            base.ModifyProjectileInfo(ref fireProjectileInfo);
            fireProjectileInfo.damageTypeOverride = DamageTypeCombo.GenericSpecial;
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Skill;
        }

        public override void PlayAnimation(float duration) {

            if (GetModelAnimator()) {
                PlayAnimation("Gesture, Override", "ThrowBomb", "ThrowBomb.playbackRate", this.duration);
            }
        }
    }
}