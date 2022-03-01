using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BC6 RID: 7110
	public interface ICustomClientFrameItem<T1, T2>
	{
		// Token: 0x0601162C RID: 71212
		void Create(T1 frame, GameObject parent);

		// Token: 0x0601162D RID: 71213
		void Destroy();

		// Token: 0x0601162E RID: 71214
		void RefreshView(T2 model);

		// Token: 0x0601162F RID: 71215
		void Show();

		// Token: 0x06011630 RID: 71216
		void Hide();

		// Token: 0x06011631 RID: 71217
		T2 GetViewModel();
	}
}
