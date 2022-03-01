using System;

namespace GameClient
{
	// Token: 0x0200133C RID: 4924
	public interface ITimeModel
	{
		// Token: 0x0600BF48 RID: 48968
		string GetRemainString();

		// Token: 0x0600BF49 RID: 48969
		float GetRemainTime();

		// Token: 0x0600BF4A RID: 48970
		void Update(float deltaTime);
	}
}
