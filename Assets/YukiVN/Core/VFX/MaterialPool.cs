using UnityEngine;

namespace YukiVN.VFX
{
    public class MaterialPool
    {
        private Material mDefaultMaterial;

        public Material DefaultMaterial
        {
            get => mDefaultMaterial;
            set
            {
                if (mDefaultMaterial == value) return;

                YukiUtils.DestroyObject(mDefaultMaterial);
                mDefaultMaterial = value;
            }
        }

        public readonly MaterialFactory Factory = new();

        public Material GetMaterial(string shaderName)
        {
            return Factory.GetMaterial(shaderName);
        }
    }
}