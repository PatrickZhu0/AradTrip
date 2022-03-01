using System;

namespace GameClient
{
	// Token: 0x0200184D RID: 6221
	public interface IGiftPackActivityView
	{
		// Token: 0x0600F435 RID: 62517
		void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick);

		// Token: 0x0600F436 RID: 62518
		void UpdateData(LimitTimeGiftPackModel model);

		// Token: 0x0600F437 RID: 62519
		void Close();
	}
}
