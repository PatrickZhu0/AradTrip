using System;
using System.Reflection;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000048 RID: 72
	internal class ComOpenWindow : MonoBehaviour
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000F560 File Offset: 0x0000D960
		public void Open()
		{
			Type type = typeof(ClientFrame).Assembly.GetType(this.typeName);
			if (type == null)
			{
				return;
			}
			MethodInfo method = type.GetMethod("CommandOpen");
			if (method == null)
			{
				return;
			}
			method.Invoke(null, new object[1]);
			if (this.typeName == "GameClient.LegendFrame")
			{
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Legend");
			}
			else if (this.typeName == "GameClient.ActiveGroupMainFrame")
			{
				Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("Achievement_1");
			}
		}

		// Token: 0x040001A0 RID: 416
		public string typeName;
	}
}
