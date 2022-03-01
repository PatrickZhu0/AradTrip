using System;

namespace GameClient
{
	// Token: 0x0200138B RID: 5003
	public interface IActivityDungeonUpdateData
	{
		// Token: 0x0600C1FB RID: 49659
		bool IsChanged();

		// Token: 0x0600C1FC RID: 49660
		void Update(float delta);

		// Token: 0x0600C1FD RID: 49661
		void Reset();
	}
}
