using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200021F RID: 543
	internal class VersionSwitch<T>
	{
		// Token: 0x06001218 RID: 4632 RVA: 0x000627C4 File Offset: 0x00060BC4
		public VersionSwitch(string sKey, string sValue)
		{
			if (string.IsNullOrEmpty(sKey) || string.IsNullOrEmpty(sValue))
			{
				return;
			}
			this._switchKey = sKey;
			string[] array = sValue.Split(new char[]
			{
				','
			});
			if (array != null && array.Length > 0)
			{
				this._switchValues = new T[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					this._switchValues[i] = this._TryConvertValueType(array[i]);
				}
			}
			else
			{
				this._switchValues[0] = this._TryConvertValueType(sValue);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06001219 RID: 4633 RVA: 0x00062871 File Offset: 0x00060C71
		public string SwitchKey
		{
			get
			{
				return this._switchKey;
			}
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x0006287C File Offset: 0x00060C7C
		private T _TryConvertValueType(string sValue)
		{
			T result = default(T);
			if (!string.IsNullOrEmpty(sValue))
			{
				try
				{
					if (typeof(T).IsEnum)
					{
						result = (T)((object)Enum.Parse(typeof(T), sValue));
					}
					else
					{
						result = (T)((object)Convert.ChangeType(sValue, typeof(T)));
					}
				}
				catch (Exception ex)
				{
					Debug.LogErrorFormat("[VersionSwitch] - {0} convert to : {1} , failed : {2}!", new object[]
					{
						sValue,
						typeof(T),
						ex.ToString()
					});
				}
			}
			return result;
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x0006292C File Offset: 0x00060D2C
		public T[] GetSwitchValues()
		{
			return this._switchValues;
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x00062934 File Offset: 0x00060D34
		public T GetSwitchValue()
		{
			if (this._switchValues != null && this._switchValues.Length > 0)
			{
				return this._switchValues[0];
			}
			return default(T);
		}

		// Token: 0x04000C0A RID: 3082
		private T[] _switchValues = new T[1];

		// Token: 0x04000C0B RID: 3083
		private string _switchKey;
	}
}
