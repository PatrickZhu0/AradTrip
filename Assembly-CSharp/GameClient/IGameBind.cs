using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DD6 RID: 3542
	public interface IGameBind
	{
		// Token: 0x06008F12 RID: 36626
		T GetComponent<T>(string name) where T : Component;

		// Token: 0x06008F13 RID: 36627
		T GetComponentInChildren<T>(string name) where T : Component;
	}
}
