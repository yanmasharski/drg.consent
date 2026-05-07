using System;
using System.Threading.Tasks;
using DRG.Core.Logs;

namespace DRG.Consent
{
	public class ConsentPlatformProxy : IConsentPlatform
	{
		private readonly IConsentPlatform _impl;

		public ConsentPlatformProxy(IConsentPlatform impl, ILogger logger)
		{
#if UNITY_EDITOR
			_impl = new EditorConsentPlatform(logger);
#else
            _impl = impl;
#endif
		}

		public ConsentState state => _impl.state;

		public bool TryShowConsentDialog(Action<bool> completed) => _impl.TryShowConsentDialog(completed);

		public Task<bool> TryShowConsentDialogAsync() => _impl.TryShowConsentDialogAsync();
	}
}
