using Backtrace.Unity;
using Backtrace.Unity.Model;
using UnityEngine;

public class IntegrationFactory {
    public static BacktraceClient CreateErrorReporter() {
        var configuration = ScriptableObject.CreateInstance<BacktraceConfiguration>();
        configuration.ServerUrl = "https://yolo.sp.backtrace.io:6098/post?format=json&token=533c6e267998b8562e4b878c891bf7fc509beec7839f991bdaa1d43220d0f497";
        configuration.Enabled = true;
        configuration.PerformanceStatistics = true;
        configuration.DatabasePath = "${Application.persistentDataPath}/backtrace";
        configuration.CreateDatabase = true;
#if UNITY_ANDROID || UNITY_IOS
        configuration.CaptureNativeCrashes = true;
#endif

        return BacktraceClient.Initialize(configuration);
    }
}