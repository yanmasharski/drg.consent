#if UNITY_EDITOR
namespace DRG.Consent
{
    using System;
    using System.Threading.Tasks;
    using DRG.Core.Logs;

/// <summary>
/// Editor-only implementation of <see cref="IConsentPlatform"/>.
/// Shows dialog in the Unity Editor.
/// </summary>
    public class EditorConsentPlatform : IConsentPlatform
    {
        private readonly ILogger logger;
        private ConsentState currentState = ConsentState.Unknown;

        public EditorConsentPlatform(ILogger logger)
        {
            this.logger = logger ?? NullLogger.instance;
        }

        public ConsentState state => currentState;

        public bool TryShowConsentDialog(Action<bool> completed)
        {
            DRG.Utils.EditorNativeDialog.Choose(
                title: "Consent",
                message: "Consent dialog is not available in the Unity Editor.\nSimulate that the user accepted?",
                primary: "Accept",
                onPrimary: () =>
                {
                    currentState = ConsentState.Accepted;
                    logger.Log("EditorConsentPlatform: simulated accept.");
                    completed?.Invoke(true);
                },
                secondary: "Decline",
                onSecondary: () =>
                {
                    currentState = ConsentState.Declined;
                    logger.Log("EditorConsentPlatform: simulated decline.");
                    completed?.Invoke(false);
                },
                tertiary: "Cancel",
                onTertiary: () =>
                {
                    logger.Log("EditorConsentPlatform: cancelled.");
                    completed?.Invoke(false);
                });

            return true;
        }

        public Task<bool> TryShowConsentDialogAsync()
        {
            var tcs = new TaskCompletionSource<bool>();
            TryShowConsentDialog(result => tcs.TrySetResult(result));
            return tcs.Task;

        }

        private sealed class NullLogger : ILogger
        {
            public static readonly NullLogger instance = new NullLogger();

            public void Log(Func<string> message) { }

            public void LogWarning(Func<string> message) { }

            public void LogError(Func<string> message) { }

            public void LogException(Func<Exception> exception) { }
        }
    }
}
#endif