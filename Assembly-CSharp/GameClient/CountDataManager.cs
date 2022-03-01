using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x0200122D RID: 4653
	internal class CountDataManager : DataManager<CountDataManager>
	{
		// Token: 0x0600B2EC RID: 45804 RVA: 0x0027C070 File Offset: 0x0027A470
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.CountDataManager;
		}

		// Token: 0x0600B2ED RID: 45805 RVA: 0x0027C073 File Offset: 0x0027A473
		public override void Initialize()
		{
		}

		// Token: 0x0600B2EE RID: 45806 RVA: 0x0027C075 File Offset: 0x0027A475
		public override void Clear()
		{
			this.m_arrCountInfos.Clear();
		}

		// Token: 0x0600B2EF RID: 45807 RVA: 0x0027C084 File Offset: 0x0027A484
		public void SetCount(string a_strKey, uint a_value)
		{
			CounterInfo counterInfo = this.m_arrCountInfos.Find((CounterInfo x) => x.name == a_strKey);
			if (counterInfo == null)
			{
				counterInfo = new CounterInfo
				{
					name = a_strKey,
					value = a_value
				};
				this.m_arrCountInfos.Add(counterInfo);
			}
			else
			{
				counterInfo.value = a_value;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCountValueChange, a_strKey, null, null, null);
		}

		// Token: 0x0600B2F0 RID: 45808 RVA: 0x0027C108 File Offset: 0x0027A508
		public void SetCountWithoutUiEvent(string strKey, uint strValue)
		{
			CounterInfo counterInfo = this.m_arrCountInfos.Find((CounterInfo x) => x.name == strKey);
			if (counterInfo == null)
			{
				counterInfo = new CounterInfo
				{
					name = strKey,
					value = strValue
				};
				this.m_arrCountInfos.Add(counterInfo);
			}
			else
			{
				counterInfo.value = strValue;
			}
		}

		// Token: 0x0600B2F1 RID: 45809 RVA: 0x0027C174 File Offset: 0x0027A574
		public int GetCount(string name, int id)
		{
			string name2 = string.Format("{0}{1}", name, id);
			return this.GetCount(name2);
		}

		// Token: 0x0600B2F2 RID: 45810 RVA: 0x0027C19C File Offset: 0x0027A59C
		public int GetCount(string name)
		{
			int result = 0;
			for (int i = 0; i < this.m_arrCountInfos.Count; i++)
			{
				if (!(name != this.m_arrCountInfos[i].name))
				{
					return (int)this.m_arrCountInfos[i].value;
				}
			}
			return result;
		}

		// Token: 0x0600B2F3 RID: 45811 RVA: 0x0027C1FB File Offset: 0x0027A5FB
		public List<CounterInfo> GetCountInfos()
		{
			return this.m_arrCountInfos;
		}

		// Token: 0x0600B2F4 RID: 45812 RVA: 0x0027C204 File Offset: 0x0027A604
		public CounterInfo GetCountInfo(string a_strKey)
		{
			for (int i = 0; i < this.m_arrCountInfos.Count; i++)
			{
				if (!(a_strKey != this.m_arrCountInfos[i].name))
				{
					return this.m_arrCountInfos[i];
				}
			}
			return null;
		}

		// Token: 0x040064D7 RID: 25815
		private List<CounterInfo> m_arrCountInfos = new List<CounterInfo>();
	}
}
