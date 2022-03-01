using System;
using System.Reflection;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200015A RID: 346
	public class OnTimeInvoker : MonoBehaviour
	{
		// Token: 0x060009FC RID: 2556 RVA: 0x000348E1 File Offset: 0x00032CE1
		private void Start()
		{
			this.needUpdate = false;
			this.mf = this.GetMethodInfoFromString(this.callName);
			this.TryInvoke();
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00034902 File Offset: 0x00032D02
		private void OnDestroy()
		{
			this.needUpdate = false;
			this.mf = null;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00034914 File Offset: 0x00032D14
		private void TryInvoke()
		{
			DateTime dateTimeByTimeStamp = TimeUtility.GetDateTimeByTimeStamp((int)DataManager<TimeManager>.GetInstance().GetServerTime());
			if (dateTimeByTimeStamp.Hour == this.hour && dateTimeByTimeStamp.Minute == this.minute && dateTimeByTimeStamp.Second == this.second)
			{
				if (this.mf != null)
				{
					this.mf.Invoke(null, null);
				}
				this.needUpdate = false;
			}
			else
			{
				this.needUpdate = true;
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00034993 File Offset: 0x00032D93
		private void Update()
		{
			if (this.needUpdate)
			{
				this.TryInvoke();
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000349A8 File Offset: 0x00032DA8
		private MethodInfo GetMethodInfoFromString(string methodStr)
		{
			string[] array = methodStr.Split(new char[]
			{
				'.'
			});
			if (array == null || array.Length < 2)
			{
				return null;
			}
			string name = array[array.Length - 1];
			string text = string.Empty;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (i != 0)
				{
					text += ".";
				}
				text += array[i];
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(text);
			if (type == null)
			{
				return null;
			}
			return type.GetMethod(name);
		}

		// Token: 0x04000770 RID: 1904
		[SerializeField]
		private int hour = 6;

		// Token: 0x04000771 RID: 1905
		[SerializeField]
		private int minute;

		// Token: 0x04000772 RID: 1906
		[SerializeField]
		private int second;

		// Token: 0x04000773 RID: 1907
		[SerializeField]
		private string callName = string.Empty;

		// Token: 0x04000774 RID: 1908
		[SerializeField]
		private bool needUpdate;

		// Token: 0x04000775 RID: 1909
		private MethodInfo mf;
	}
}
