using EntityStates;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace HenryMod.Survivors.Henry.States {
    public class DeathState : GenericCharacterDeath {

        public override bool shouldAutoDestroy => false;

        private const float lifetime = 4f;

        private const float upVelocity = 3f;

        public override void OnEnter() {
            base.OnEnter();
            Vector3 velocity = Vector3.up * upVelocity;

            if (characterMotor) {
                velocity += characterMotor.velocity;
                characterMotor.enabled = false;
            }

            if (cachedModelTransform && cachedModelTransform.TryGetComponent(out RagdollController ragdollController)) {
                ragdollController.BeginRagdoll(velocity);
            }
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (NetworkServer.active && fixedAge > lifetime) {
                Destroy(gameObject);
            }
        }


        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}
