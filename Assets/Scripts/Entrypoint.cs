using UnityEngine;

public class Entrypoint
{
    private const float windowScaleRatio = 2f / 3;
    private const float windowSizeRatio = 9f / 16;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void EntryPoint()
    {
#if !UNITY_EDITOR
        var width = Screen.currentResolution.width;
        var height = Screen.currentResolution.height;
        if (width / (float) height < 16f / 9f)
        {
            var w = width * windowScaleRatio;
            var h = w * windowSizeRatio;
            Screen.SetResolution((int)w, (int)h, false);
        }
        else
        {
            var h = width * windowScaleRatio;
            var w = h / windowSizeRatio;
            Screen.SetResolution((int)w, (int)h, false);
        }
#endif
    }
}
