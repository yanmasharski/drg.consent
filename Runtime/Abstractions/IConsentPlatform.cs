using System;
using System.Threading.Tasks;

namespace DRG.Consent
{
	public interface IConsentPlatform
	{
		ConsentState state { get; }
		bool TryShowConsentDialog(Action<bool> completed);
		Task<bool> TryShowConsentDialogAsync();
	}
}
