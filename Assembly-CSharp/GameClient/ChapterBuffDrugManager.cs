using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001523 RID: 5411
	public sealed class ChapterBuffDrugManager : DataManager<ChapterBuffDrugManager>
	{
		// Token: 0x0600D28A RID: 53898 RVA: 0x003416E1 File Offset: 0x0033FAE1
		public override void Initialize()
		{
		}

		// Token: 0x0600D28B RID: 53899 RVA: 0x003416E3 File Offset: 0x0033FAE3
		public override void Clear()
		{
			this.ResetAllMarkedBuffDrugs();
		}

		// Token: 0x0600D28C RID: 53900 RVA: 0x003416EC File Offset: 0x0033FAEC
		private static bool _buffDrugFree2Use(int id)
		{
			BuffDrugConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffDrugConfigTable>(id, string.Empty, string.Empty);
			return tableItem != null && tableItem.FreeUseLevel >= (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x0600D28D RID: 53901 RVA: 0x0034172C File Offset: 0x0033FB2C
		public static ChapterBuffDrugManager.eBuffDrugUseType GetBuffDrugType(int id)
		{
			if (ChapterBuffDrugManager._buffDrugFree2Use(id))
			{
				return ChapterBuffDrugManager.eBuffDrugUseType.FreeUse;
			}
			if (ChapterBuffDrugManager.GetBuffDrugCount(id) > 0)
			{
				return ChapterBuffDrugManager.eBuffDrugUseType.PackageUse;
			}
			CostItemManager.CostInfo buffDrugCost = ChapterBuffDrugManager.GetBuffDrugCost(id);
			if (DataManager<CostItemManager>.GetInstance().IsEnough2Cost(buffDrugCost))
			{
				return ChapterBuffDrugManager.eBuffDrugUseType.PayUse;
			}
			return ChapterBuffDrugManager.eBuffDrugUseType.NotEnoughPay2Use;
		}

		// Token: 0x0600D28E RID: 53902 RVA: 0x0034176E File Offset: 0x0033FB6E
		public static int GetBuffDrugCount(int id)
		{
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(id, true);
		}

		// Token: 0x0600D28F RID: 53903 RVA: 0x0034177C File Offset: 0x0033FB7C
		public static CostItemManager.CostInfo GetBuffDrugCost(int id)
		{
			QuickBuyTable tableItem = Singleton<TableManager>.instance.GetTableItem<QuickBuyTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return new CostItemManager.CostInfo
				{
					nMoneyID = tableItem.CostItemID,
					nCount = tableItem.CostNum
				};
			}
			return null;
		}

		// Token: 0x0600D290 RID: 53904 RVA: 0x003417C8 File Offset: 0x0033FBC8
		public void ResetAllMarkedBuffDrugs()
		{
			this.mMark2UseBuffDrugs.Clear();
		}

		// Token: 0x0600D291 RID: 53905 RVA: 0x003417D8 File Offset: 0x0033FBD8
		public bool IsBuffDrugMarked(int id)
		{
			for (int i = 0; i < this.mMark2UseBuffDrugs.Count; i++)
			{
				if (id == this.mMark2UseBuffDrugs[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D292 RID: 53906 RVA: 0x00341816 File Offset: 0x0033FC16
		public int[] GetAllMarkedBuffDrugs()
		{
			return this.mMark2UseBuffDrugs.ToArray();
		}

		// Token: 0x0600D293 RID: 53907 RVA: 0x00341824 File Offset: 0x0033FC24
		public void SetMarkedBuffDrugsAtLocal()
		{
			for (int i = 0; i < this.mMark2UseBuffDrugs.Count; i++)
			{
				if (PlayerPrefs.GetInt(this._getBuffDrugSettingString(this.mMark2UseBuffDrugs[i]), 0) == 0)
				{
					PlayerPrefs.SetInt(this._getBuffDrugSettingString(this.mMark2UseBuffDrugs[i]), 1);
				}
			}
		}

		// Token: 0x0600D294 RID: 53908 RVA: 0x00341884 File Offset: 0x0033FC84
		public void ResetAllLocalMarkedBuffDrugs(IList<int> buffDrugConfig)
		{
			for (int i = 0; i < buffDrugConfig.Count; i++)
			{
				PlayerPrefs.SetInt(this._getBuffDrugSettingString(buffDrugConfig[i]), 0);
			}
		}

		// Token: 0x0600D295 RID: 53909 RVA: 0x003418BC File Offset: 0x0033FCBC
		public void ResetBuffDrugsFromLocal(IList<int> drugs)
		{
			if (drugs == null)
			{
				return;
			}
			for (int i = 0; i < drugs.Count; i++)
			{
				if (this.IsBuffDrugSetted(drugs[i]))
				{
					this.MarkBuffDrug2Use(drugs[i]);
				}
			}
		}

		// Token: 0x0600D296 RID: 53910 RVA: 0x00341907 File Offset: 0x0033FD07
		public bool IsBuffDrugSetted(int id)
		{
			return PlayerPrefs.GetInt(this._getBuffDrugSettingString(id), 0) != 0;
		}

		// Token: 0x0600D297 RID: 53911 RVA: 0x00341920 File Offset: 0x0033FD20
		private void _deleteSettedBuffDrug(int id)
		{
			string text = this._getBuffDrugSettingString(id);
			if (PlayerPrefs.HasKey(text))
			{
				PlayerPrefs.DeleteKey(text);
			}
		}

		// Token: 0x0600D298 RID: 53912 RVA: 0x00341948 File Offset: 0x0033FD48
		private string _getBuffDrugSettingString(int id)
		{
			string arg = string.Empty;
			string arg2 = string.Empty;
			if (ClientApplication.playerinfo != null)
			{
				arg = ClientApplication.playerinfo.serverID.ToString();
			}
			if (DataManager<PlayerBaseData>.GetInstance() != null)
			{
				arg2 = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
			}
			return TR.Value("chapter_buffdrug_setting", arg, arg2, id.ToString());
		}

		// Token: 0x0600D299 RID: 53913 RVA: 0x003419BD File Offset: 0x0033FDBD
		public void SetBuffDrugToggleState(bool isOn)
		{
			if (isOn)
			{
				PlayerPrefs.SetInt(this._getBuffDrugToggleString(), 1);
			}
			else
			{
				PlayerPrefs.SetInt(this._getBuffDrugToggleString(), 0);
			}
		}

		// Token: 0x0600D29A RID: 53914 RVA: 0x003419E2 File Offset: 0x0033FDE2
		public bool IsBuffDrugToggleOn()
		{
			return PlayerPrefs.GetInt(this._getBuffDrugToggleString(), 0) == 1;
		}

		// Token: 0x0600D29B RID: 53915 RVA: 0x003419FC File Offset: 0x0033FDFC
		private string _getBuffDrugToggleString()
		{
			string arg = string.Empty;
			string arg2 = string.Empty;
			if (ClientApplication.playerinfo != null)
			{
				arg = ClientApplication.playerinfo.serverID.ToString();
			}
			if (DataManager<PlayerBaseData>.GetInstance() != null)
			{
				arg2 = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString();
			}
			return TR.Value("chapter_buffdrug_toggleIsOn", arg, arg2);
		}

		// Token: 0x0600D29C RID: 53916 RVA: 0x00341A64 File Offset: 0x0033FE64
		public bool MarkBuffDrug2Use(int id)
		{
			if (!this.IsBuffDrugMarked(id))
			{
				this.mMark2UseBuffDrugs.Add(id);
				return true;
			}
			return false;
		}

		// Token: 0x0600D29D RID: 53917 RVA: 0x00341A84 File Offset: 0x0033FE84
		public bool UnMarkBuffDrug2Use(int id)
		{
			if (this.IsBuffDrugMarked(id))
			{
				this.mMark2UseBuffDrugs.RemoveAll((int x) => id == x);
				return true;
			}
			return false;
		}

		// Token: 0x0600D29E RID: 53918 RVA: 0x00341ACC File Offset: 0x0033FECC
		private void _addCostInfo(List<CostItemManager.CostInfo> costs, CostItemManager.CostInfo costInfo)
		{
			if (costs != null && costInfo != null)
			{
				bool flag = false;
				for (int i = 0; i < costs.Count; i++)
				{
					if (costInfo.nMoneyID == costs[i].nMoneyID)
					{
						costs[i].nCount += costInfo.nCount;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					costs.Add(costInfo);
				}
			}
		}

		// Token: 0x0600D29F RID: 53919 RVA: 0x00341B44 File Offset: 0x0033FF44
		public List<uint> GetAllMarkedBuffDrugsByDungeonID(int dungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			IList<int> buffDrugConfig = tableItem.BuffDrugConfig;
			List<uint> list = new List<uint>();
			for (int i = 0; i < buffDrugConfig.Count; i++)
			{
				if (this.IsBuffDrugMarked(buffDrugConfig[i]))
				{
					list.Add((uint)buffDrugConfig[i]);
				}
			}
			return list;
		}

		// Token: 0x0600D2A0 RID: 53920 RVA: 0x00341BB4 File Offset: 0x0033FFB4
		public List<CostItemManager.CostInfo> GetAllMarkedBuffDrugsCost(int dungeonID)
		{
			List<uint> allMarkedBuffDrugsByDungeonID = this.GetAllMarkedBuffDrugsByDungeonID(dungeonID);
			if (allMarkedBuffDrugsByDungeonID == null)
			{
				return null;
			}
			List<CostItemManager.CostInfo> list = new List<CostItemManager.CostInfo>();
			for (int i = 0; i < allMarkedBuffDrugsByDungeonID.Count; i++)
			{
				ChapterBuffDrugManager.eBuffDrugUseType buffDrugType = ChapterBuffDrugManager.GetBuffDrugType((int)allMarkedBuffDrugsByDungeonID[i]);
				if (buffDrugType == ChapterBuffDrugManager.eBuffDrugUseType.PayUse || buffDrugType == ChapterBuffDrugManager.eBuffDrugUseType.NotEnoughPay2Use)
				{
					CostItemManager.CostInfo buffDrugCost = ChapterBuffDrugManager.GetBuffDrugCost((int)allMarkedBuffDrugsByDungeonID[i]);
					this._addCostInfo(list, buffDrugCost);
				}
			}
			return list;
		}

		// Token: 0x0600D2A1 RID: 53921 RVA: 0x00341C24 File Offset: 0x00340024
		private byte _getBuffDrugIdx(int dungeonID, int itemid)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				IList<int> buffDrugConfig = tableItem.BuffDrugConfig;
				for (int i = 0; i < buffDrugConfig.Count; i++)
				{
					if (buffDrugConfig[i] == itemid)
					{
						return (byte)i;
					}
				}
			}
			return byte.MaxValue;
		}

		// Token: 0x0600D2A2 RID: 53922 RVA: 0x00341C80 File Offset: 0x00340080
		private IEnumerator _useItem(int itemID)
		{
			MessageEvents msg = new MessageEvents();
			SceneQuickUseItemRet res = new SceneQuickUseItemRet();
			SceneQuickUseItemReq req = new SceneQuickUseItemReq();
			int id = ChapterBaseFrame.sDungeonID;
			req.dungenid = (uint)id;
			req.idx = this._getBuffDrugIdx(id, itemID);
			yield return MessageUtility.Wait<SceneQuickUseItemReq, SceneQuickUseItemRet>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			if (!msg.IsAllMessageReceived() || res.code != 0U)
			{
			}
			yield break;
		}

		// Token: 0x0600D2A3 RID: 53923 RVA: 0x00341CA4 File Offset: 0x003400A4
		private void _usePackageItem(int id)
		{
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(id, true, true);
			DataManager<ItemDataManager>.GetInstance().UseItem(itemByTableID, false, 0, 0);
		}

		// Token: 0x0600D2A4 RID: 53924 RVA: 0x00341CD0 File Offset: 0x003400D0
		public IEnumerator UseBuffDrug(int id)
		{
			ChapterBuffDrugManager.eBuffDrugUseType type = ChapterBuffDrugManager.GetBuffDrugType(id);
			if (type == ChapterBuffDrugManager.eBuffDrugUseType.FreeUse)
			{
				yield return this._useItem(id);
				Singleton<GameStatisticManager>.instance.DoStatDrugUse(id, "free");
			}
			else if (type == ChapterBuffDrugManager.eBuffDrugUseType.PackageUse)
			{
				this._usePackageItem(id);
				Singleton<GameStatisticManager>.instance.DoStatDrugUse(id, "package");
			}
			else if (type == ChapterBuffDrugManager.eBuffDrugUseType.PayUse)
			{
				CostItemManager.CostInfo info = ChapterBuffDrugManager.GetBuffDrugCost(id);
				yield return this._useItem(id);
				Singleton<GameStatisticManager>.instance.DoStatDrugUse(id, "pay&use");
			}
			yield break;
		}

		// Token: 0x0600D2A5 RID: 53925 RVA: 0x00341CF4 File Offset: 0x003400F4
		public IEnumerator UseAllMarkBuffDrug(int dungeonID)
		{
			List<uint> node = this.GetAllMarkedBuffDrugsByDungeonID(dungeonID);
			if (node != null)
			{
				for (int i = 0; i < node.Count; i++)
				{
					yield return this.UseBuffDrug((int)node[i]);
				}
			}
			this.ResetAllMarkedBuffDrugs();
			yield break;
		}

		// Token: 0x04007B3E RID: 31550
		private List<int> mMark2UseBuffDrugs = new List<int>();

		// Token: 0x02001524 RID: 5412
		public enum eBuffDrugUseType
		{
			// Token: 0x04007B40 RID: 31552
			None,
			// Token: 0x04007B41 RID: 31553
			FreeUse,
			// Token: 0x04007B42 RID: 31554
			PackageUse,
			// Token: 0x04007B43 RID: 31555
			PayUse,
			// Token: 0x04007B44 RID: 31556
			NotEnoughPay2Use
		}
	}
}
