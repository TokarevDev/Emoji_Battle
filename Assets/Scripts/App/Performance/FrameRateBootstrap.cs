using UnityEngine;

public static class FrameRateBootstrap
{
    private const int MinFrameRate = 60;
    private const int MidFrameRate = 90;
    private const int HighFrameRate = 120;

    public static int CurrentTargetFrameRate { get; private set; } = MinFrameRate;

    public static void Apply()
    {
        int targetFrameRate = SelectTargetFrameRate();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;

        CurrentTargetFrameRate = targetFrameRate;
    }

    private static int SelectTargetFrameRate()
    {
        int displayLimit = GetDisplayFrameRateLimit();
        int deviceLimit = GetDeviceFrameRateLimit();
        int safeLimit = Mathf.Min(displayLimit, deviceLimit);

        if (safeLimit >= HighFrameRate)
            return HighFrameRate;

        if (safeLimit >= MidFrameRate)
            return MidFrameRate;

        return MinFrameRate;
    }

    private static int GetDisplayFrameRateLimit()
    {
        double refreshRate = Screen.currentResolution.refreshRateRatio.value;

        if (refreshRate <= 0)
            return MinFrameRate;

        int roundedRefreshRate = Mathf.RoundToInt((float)refreshRate);

        if (roundedRefreshRate >= HighFrameRate)
            return HighFrameRate;

        if (roundedRefreshRate >= MidFrameRate)
            return MidFrameRate;

        return MinFrameRate;
    }

    private static int GetDeviceFrameRateLimit()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (IsHighEndMobileDevice())
            return HighFrameRate;

        if (IsMidEndMobileDevice())
            return MidFrameRate;

        return MinFrameRate;
#else
        return HighFrameRate;
#endif
    }

#if UNITY_ANDROID || UNITY_IOS
    private static bool IsHighEndMobileDevice()
    {
        return SystemInfo.systemMemorySize >= 6000 &&
               SystemInfo.processorCount >= 6 &&
               SystemInfo.graphicsShaderLevel >= 45;
    }

    private static bool IsMidEndMobileDevice()
    {
        return SystemInfo.systemMemorySize >= 3500 &&
               SystemInfo.processorCount >= 4 &&
               SystemInfo.graphicsShaderLevel >= 35;
    }
#endif
}
