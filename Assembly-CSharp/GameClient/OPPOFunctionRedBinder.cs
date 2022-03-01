using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200008E RID: 142
	internal class OPPOFunctionRedBinder : MonoBehaviour
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00018690 File Offset: 0x00016A90
		public static OPPOFunctionRedBinder instance
		{
			get
			{
				return OPPOFunctionRedBinder._instance;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00018697 File Offset: 0x00016A97
		private void Start()
		{
			OPPOFunctionRedBinder._instance = this;
			this._Updata();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600031F RID: 799 RVA: 0x000186CB File Offset: 0x00016ACB
		private void OnEnable()
		{
			this._Updata();
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000186D3 File Offset: 0x00016AD3
		private void Update()
		{
			this._Updata();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000186DB File Offset: 0x00016ADB
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00018703 File Offset: 0x00016B03
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this._Updata();
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0001870C File Offset: 0x00016B0C
		private void _Updata()
		{
			if (this.m_goTarget == null)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			while (!flag && num < this.m_akFunctionTypes.Count)
			{
				flag = this._CheckOK(this.m_akFunctionTypes[num]);
				num++;
			}
			this.m_goTarget.CustomActive(flag);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0001876E File Offset: 0x00016B6E
		public void AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType eOPPOFuctionType)
		{
			if (!this.m_akFunctionTypes.Contains(eOPPOFuctionType))
			{
				this.m_akFunctionTypes.Add(eOPPOFuctionType);
			}
			this._Updata();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00018793 File Offset: 0x00016B93
		public void ClearCheckFunctions()
		{
			this.m_akFunctionTypes.Clear();
			this._Updata();
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000187A8 File Offset: 0x00016BA8
		private bool _CheckOK(OPPOFunctionRedBinder.OPPOFunctionType eOPPOFunctionType)
		{
			if (eOPPOFunctionType == OPPOFunctionRedBinder.OPPOFunctionType.OFT_PRIVILRGR)
			{
				if (SDKInterface.instance.IsOppoPlatform())
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckPrivilrge(12000);
				}
				if (SDKInterface.instance.IsVivoPlatForm())
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckPrivilrge(23000);
				}
			}
			else
			{
				if (eOPPOFunctionType == OPPOFunctionRedBinder.OPPOFunctionType.OFT_LUCKYGUY)
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckLuckyGuy();
				}
				if (eOPPOFunctionType == OPPOFunctionRedBinder.OPPOFunctionType.OFT_DAILYCHECK)
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckDail();
				}
				if (eOPPOFunctionType == OPPOFunctionRedBinder.OPPOFunctionType.OFT_AMBERGIFTBAG)
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckAmberGiftBag();
				}
				if (eOPPOFunctionType == OPPOFunctionRedBinder.OPPOFunctionType.OFT_AMBERPRIVILEGE)
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckAmberPrivilege();
				}
				if (eOPPOFunctionType == OPPOFunctionRedBinder.OPPOFunctionType.OFT_OPPOGROWTHHAOLI)
				{
					return DataManager<OPPOPrivilegeDataManager>.GetInstance()._CheckOPPOGrowthHaoLi();
				}
			}
			return false;
		}

		// Token: 0x040002EE RID: 750
		public List<OPPOFunctionRedBinder.OPPOFunctionType> m_akFunctionTypes = new List<OPPOFunctionRedBinder.OPPOFunctionType>();

		// Token: 0x040002EF RID: 751
		public GameObject m_goTarget;

		// Token: 0x040002F0 RID: 752
		public const int oppoPrivilegeID = 12000;

		// Token: 0x040002F1 RID: 753
		public const int vivoPrivilegeID = 23000;

		// Token: 0x040002F2 RID: 754
		public const int dailID = 15000;

		// Token: 0x040002F3 RID: 755
		public const int luckyGuyID = 17000;

		// Token: 0x040002F4 RID: 756
		public const int tableID = 10001;

		// Token: 0x040002F5 RID: 757
		private int IActivitytEmplateID = 20000;

		// Token: 0x040002F6 RID: 758
		private static OPPOFunctionRedBinder _instance;

		// Token: 0x0200008F RID: 143
		public enum OPPOFunctionType
		{
			// Token: 0x040002F8 RID: 760
			OFT_PRIVILRGR,
			// Token: 0x040002F9 RID: 761
			OFT_LUCKYGUY,
			// Token: 0x040002FA RID: 762
			OFT_DAILYCHECK,
			// Token: 0x040002FB RID: 763
			OFT_AMBERGIFTBAG,
			// Token: 0x040002FC RID: 764
			OFT_AMBERPRIVILEGE,
			// Token: 0x040002FD RID: 765
			OFT_OPPOGROWTHHAOLI
		}
	}
}
