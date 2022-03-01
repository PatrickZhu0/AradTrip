using System;

namespace GameClient
{
	// Token: 0x0200184E RID: 6222
	public interface IActivityView : IDisposable
	{
		// Token: 0x0600F438 RID: 62520
		void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick);

		// Token: 0x0600F439 RID: 62521
		void UpdateData(ILimitTimeActivityModel data);

		// Token: 0x0600F43A RID: 62522
		void Close();

		// Token: 0x0600F43B RID: 62523
		void Show();

		// Token: 0x0600F43C RID: 62524
		void Hide();
	}
}
