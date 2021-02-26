using Backtrace.Unity;
using Backtrace.Unity.Model;
using UnityEngine;

public class IntegrationFactory {
    public static BacktraceClient CreateErrorReporter(string universe, string token) {
        var configuration = ScriptableObject.CreateInstance<BacktraceConfiguration>();
        configuration.ServerUrl = $"https://{universe}:6098/post?format=json&token={token}";
        configuration.Enabled = true;
        configuration.PerformanceStatistics = true;
        configuration.DatabasePath = "${Application.persistentDataPath}/backtrace";
        configuration.CreateDatabase = true;
#if UNITY_ANDROID || UNITY_IOS
        configuration.CaptureNativeCrashes = true;
        configuration.HandleANR = true;
#endif

        return BacktraceClient.Initialize(configuration);
    }
}