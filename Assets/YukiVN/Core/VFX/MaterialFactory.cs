using System;
using System.Collections.Generic;
using UnityEngine;

namespace YukiVN.VFX
{
    public class MaterialFactory : IDisposable
    {
        private readonly Dictionary<string, Material> mMaterials = new();

        public Material GetMaterial(string shaderName)
        {
            if (mMaterials.TryGetValue(shaderName, out var material))
            {
                return material;
            }

            var shader = Shader.Find(shaderName);
            if (shader == null)
            {
                throw new ArgumentException($"YukiVN: Shader not found: {shaderName}");
            }

            int index = shaderName.LastIndexOf('/') + 1;
            string name = shaderName[index..];
            material = new Material(shader)
            {
                name = $"YukiVN - {name}",
                hideFlags = HideFlags.DontSave,
            };

            mMaterials.Add(shaderName, material);
            return material;
        }

        public void Dispose()
        {
            foreach (var m in mMaterials.Values)
            {
                YukiUtils.DestroyObject(m);
            }

            mMaterials.Clear();
        }
    }
}
