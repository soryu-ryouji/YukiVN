using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace YukiVN
{
    public static class YukiUtils
    {
        public static void DestroyObject(UnityObject obj)
        {
            if (obj == null) return;
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                UnityObject.Destroy(obj);
            }
            else
            {
                UnityObject.DestroyImmediate(obj);
            }
#else
            UnityObject.Destroy(obj);
#endif
        }
    }
}