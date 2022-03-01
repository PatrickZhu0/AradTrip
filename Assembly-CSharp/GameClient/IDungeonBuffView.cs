using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200184C RID: 6220
	public interface IDungeonBuffView
	{
		// Token: 0x0600F432 RID: 62514
		void Init(ILimitTimeActivityModel model, UnityAction callBack);

		// Token: 0x0600F433 RID: 62515
		void Close();

		// Token: 0x0600F434 RID: 62516
		void Dispose();
	}
}
