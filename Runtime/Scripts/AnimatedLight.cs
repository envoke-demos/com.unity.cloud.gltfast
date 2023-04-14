using UnityEngine;

namespace GLTFast {
    public class AnimatedLight : MonoBehaviour {
        private Light m_TargetLight;
        private float m_intensityMultiplier;
        public Color Color;
        public float Intensity;
        public float Range;
        public float OuterConeAngle;
        public float InnerConeAngle;

        public void SetTargetLight(Light light) {
            m_TargetLight = light;
        }

        public void SetIntensityMultiplier(float intensity) {
            m_intensityMultiplier = intensity;
        }

        void Update() {
            m_TargetLight.innerSpotAngle = InnerConeAngle * Mathf.Rad2Deg * 2f;
            m_TargetLight.spotAngle = OuterConeAngle * Mathf.Rad2Deg * 2f;
            m_TargetLight.color = Color.gamma;
            m_TargetLight.range = Range > 0 ? Range : 100_000;

            // TODO: See LightPunctualExtension.LightAssignIntensity for required calculations.
            m_TargetLight.intensity = Intensity * m_intensityMultiplier;
        }
    }
}
