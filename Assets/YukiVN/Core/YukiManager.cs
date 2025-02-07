using UnityEngine;
using YukiVN.VFX;

namespace YukiVN
{
    public class YukiManager : MonoBehaviour
    {
        private SpriteRenderer mSpriteRenderer;

        private void Start()
        {
            mSpriteRenderer = GetComponent<SpriteRenderer>();
            var materialPool = new MaterialPool();
            var material = materialPool.GetMaterial("YukiVN/Fade");

            material.SetFloat("_Duration", 10.0f);

            mSpriteRenderer.material = material;
        }
    }
}

