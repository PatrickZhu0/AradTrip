using System;

namespace GameClient
{
	// Token: 0x02000E49 RID: 3657
	internal interface ITownFadingFrame
	{
		// Token: 0x170018EC RID: 6380
		// (get) Token: 0x06009195 RID: 37269
		int CurrentProgress { get; }

		// Token: 0x06009196 RID: 37270
		void FadingOut(float fadeOutTime);

		// Token: 0x06009197 RID: 37271
		void FadingIn(float fadeInTime);

		// Token: 0x06009198 RID: 37272
		bool IsClosed();

		// Token: 0x06009199 RID: 37273
		bool IsOpened();
	}
}
