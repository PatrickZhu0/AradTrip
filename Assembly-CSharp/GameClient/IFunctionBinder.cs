using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DD4 RID: 3540
	public interface IFunctionBinder
	{
		// Token: 0x06008F08 RID: 36616
		void install(IClientFrame clientFrame, GameObject frame);

		// Token: 0x06008F09 RID: 36617
		void refresh();

		// Token: 0x06008F0A RID: 36618
		void uninstall();
	}
}
