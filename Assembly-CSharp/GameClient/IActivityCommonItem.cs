using System;

namespace GameClient
{
	// Token: 0x0200189C RID: 6300
	public interface IActivityCommonItem : IDisposable
	{
		// Token: 0x0600F669 RID: 63081
		void Init(uint id, uint activityId, ILimitTimeActivityTaskDataModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick);

		// Token: 0x0600F66A RID: 63082
		void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick);

		// Token: 0x0600F66B RID: 63083
		void UpdateData(ILimitTimeActivityTaskDataModel data);

		// Token: 0x0600F66C RID: 63084
		void Destroy();
	}
}
