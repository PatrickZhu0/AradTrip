using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017C6 RID: 6086
	internal class MissionScoreAwardFrame : ClientFrame
	{
		// Token: 0x0600F012 RID: 61458 RVA: 0x00409D90 File Offset: 0x00408190
		public static void Open(int id)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<MissionScoreAwardFrame>(null, false);
			MissionManager.MissionScoreData missionScoreData = DataManager<MissionManager>.GetInstance().MissionScoreDatas.Find((MissionManager.MissionScoreData x) => x.missionScoreItem.ID == id);
			if (missionScoreData != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MissionScoreAwardFrame>(FrameLayer.Middle, missionScoreData, string.Empty);
			}
		}

		// Token: 0x0600F013 RID: 61459 RVA: 0x00409DEA File Offset: 0x004081EA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/MissionScoreAwardFrame";
		}

		// Token: 0x0600F014 RID: 61460 RVA: 0x00409DF4 File Offset: 0x004081F4
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as MissionManager.MissionScoreData);
			this._InitItemAwardObjects();
			this._UpdateItemAwardObjects();
			this._InitHintInfo();
			this._UpdateHintInfo();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Combine(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Combine(instance2.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this.OnChestIdsChanged));
		}

		// Token: 0x0600F015 RID: 61461 RVA: 0x00409E78 File Offset: 0x00408278
		protected override void _OnCloseFrame()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Remove(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onChestIdsChanged = (MissionManager.OnChestIdsChanged)Delegate.Remove(instance2.onChestIdsChanged, new MissionManager.OnChestIdsChanged(this.OnChestIdsChanged));
			this._UnInitHintInfo();
			this._UnInitItemAwardObjects();
			this.m_kData = null;
		}

		// Token: 0x0600F016 RID: 61462 RVA: 0x00409EE4 File Offset: 0x004082E4
		[UIEventHandle("Close")]
		private void _OnClickClose()
		{
			this.frameMgr.CloseFrame<MissionScoreAwardFrame>(this, false);
		}

		// Token: 0x0600F017 RID: 61463 RVA: 0x00409EF3 File Offset: 0x004082F3
		private void OnDailyScoreChanged(int score)
		{
			this._UpdateItemAwardObjects();
			this._UpdateHintInfo();
		}

		// Token: 0x0600F018 RID: 61464 RVA: 0x00409F01 File Offset: 0x00408301
		private void OnChestIdsChanged()
		{
			this._UpdateItemAwardObjects();
			this._UpdateHintInfo();
		}

		// Token: 0x0600F019 RID: 61465 RVA: 0x00409F0F File Offset: 0x0040830F
		private void _InitItemAwardObjects()
		{
			this.m_goParent = Utility.FindChild(this.frame, "AwardArray");
			this.m_goPrefab = Utility.FindChild(this.frame, "AwardArray/AwardItem");
			this.m_goPrefab.CustomActive(false);
		}

		// Token: 0x0600F01A RID: 61466 RVA: 0x00409F49 File Offset: 0x00408349
		private void _UnInitItemAwardObjects()
		{
			this.m_akAwardItemObjects.DestroyAllObjects();
			this.m_goParent = null;
			this.m_goPrefab = null;
		}

		// Token: 0x0600F01B RID: 61467 RVA: 0x00409F64 File Offset: 0x00408364
		private void _UpdateItemAwardObjects()
		{
			this.m_akAwardItemObjects.RecycleAllObject();
			if (this.m_kData != null)
			{
				for (int i = 0; i < this.m_kData.awards.Count; i++)
				{
					this.m_akAwardItemObjects.Create(new object[]
					{
						this.m_goParent,
						this.m_goPrefab,
						this.m_kData.awards[i],
						this
					});
				}
			}
		}

		// Token: 0x0600F01C RID: 61468 RVA: 0x00409FE4 File Offset: 0x004083E4
		private void _InitHintInfo()
		{
			this.hint = Utility.FindComponent<Text>(this.frame, "AwardHint", true);
			this.button = Utility.FindComponent<Button>(this.frame, "BtnAward", true);
			this.gray = Utility.FindComponent<UIGray>(this.frame, "BtnAward", true);
			this.button.onClick.RemoveAllListeners();
			this.button.onClick.AddListener(new UnityAction(this._OnClickAcquired));
		}

		// Token: 0x0600F01D RID: 61469 RVA: 0x0040A064 File Offset: 0x00408464
		private void _UpdateHintInfo()
		{
			bool flag = DataManager<MissionManager>.GetInstance().AcquiredChestIDs.Contains(this.m_kData.missionScoreItem.ID);
			if (this.m_kData.missionScoreItem.Score <= DataManager<MissionManager>.GetInstance().Score && !flag)
			{
				this.button.enabled = true;
				this.gray.enabled = false;
				this.hint.text = string.Format(TR.Value("mission_score_enable"), this.m_kData.missionScoreItem.Score);
			}
			else
			{
				this.button.enabled = false;
				this.gray.enabled = true;
				if (this.m_kData.missionScoreItem.Score > DataManager<MissionManager>.GetInstance().Score)
				{
					this.hint.text = string.Format(TR.Value("mission_score_disable"), this.m_kData.missionScoreItem.Score);
				}
				else
				{
					this.hint.text = string.Format(TR.Value("mission_score_enable"), this.m_kData.missionScoreItem.Score);
				}
			}
		}

		// Token: 0x0600F01E RID: 61470 RVA: 0x0040A19C File Offset: 0x0040859C
		private void _UnInitHintInfo()
		{
			this.hint = null;
			this.button.onClick.RemoveAllListeners();
			this.button = null;
			this.gray = null;
		}

		// Token: 0x0600F01F RID: 61471 RVA: 0x0040A1C3 File Offset: 0x004085C3
		private void _OnClickAcquired()
		{
			DataManager<MissionManager>.GetInstance().SendAcquireAwards(this.m_kData.missionScoreItem.ID);
			this.frameMgr.CloseFrame<MissionScoreAwardFrame>(this, false);
		}

		// Token: 0x04009328 RID: 37672
		private MissionManager.MissionScoreData m_kData;

		// Token: 0x04009329 RID: 37673
		private CachedObjectListManager<MissionScoreAwardFrame.AwardItemObject> m_akAwardItemObjects = new CachedObjectListManager<MissionScoreAwardFrame.AwardItemObject>();

		// Token: 0x0400932A RID: 37674
		private GameObject m_goParent;

		// Token: 0x0400932B RID: 37675
		private GameObject m_goPrefab;

		// Token: 0x0400932C RID: 37676
		private Text hint;

		// Token: 0x0400932D RID: 37677
		private Button button;

		// Token: 0x0400932E RID: 37678
		private UIGray gray;

		// Token: 0x020017C7 RID: 6087
		private class AwardItemObject : CachedObject
		{
			// Token: 0x0600F021 RID: 61473 RVA: 0x0040A1F4 File Offset: 0x004085F4
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.data = (param[2] as AwardItemData);
				this.THIS = (param[3] as MissionScoreAwardFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.comItem = this.THIS.CreateComItem(Utility.FindChild(this.goLocal, "AwardIcon"));
					this.awardDesc = Utility.FindComponent<Text>(this.goLocal, "AwardDesc", true);
				}
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x0600F022 RID: 61474 RVA: 0x0040A2B1 File Offset: 0x004086B1
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600F023 RID: 61475 RVA: 0x0040A2B9 File Offset: 0x004086B9
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600F024 RID: 61476 RVA: 0x0040A2D8 File Offset: 0x004086D8
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600F025 RID: 61477 RVA: 0x0040A2F7 File Offset: 0x004086F7
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600F026 RID: 61478 RVA: 0x0040A300 File Offset: 0x00408700
			public override void OnRefresh(object[] param)
			{
				if (param != null && param.Length > 0)
				{
					this.data = (param[0] as AwardItemData);
				}
				this._UpdateItem();
			}

			// Token: 0x0600F027 RID: 61479 RVA: 0x0040A325 File Offset: 0x00408725
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600F028 RID: 61480 RVA: 0x0040A328 File Offset: 0x00408728
			private void _UpdateItem()
			{
				this.awardDesc.text = null;
				this.itemData = ItemDataManager.CreateItemDataFromTable(this.data.ID, 100, 0);
				bool bGrey = false;
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.data.ID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					bGrey = (tableItem.Color2 == 1);
				}
				if (this.itemData != null)
				{
					this.itemData.Count = this.data.Num;
					string text;
					if (this.itemData.Type == ItemTable.eType.INCOME)
					{
						text = string.Format("<color={0}>{1}{2}</color>", ItemData.GetQualityInfo(this.itemData.Quality, bGrey, false).ColStr, this.itemData.Count, this.itemData.Name);
					}
					else if (this.itemData.Count > 1)
					{
						text = string.Format("<color={0}>{1}X{2}</color>", ItemData.GetQualityInfo(this.itemData.Quality, bGrey, false).ColStr, this.itemData.Name, this.itemData.Count);
					}
					else
					{
						text = string.Format("<color={0}>{1}</color>", ItemData.GetQualityInfo(this.itemData.Quality, bGrey, false).ColStr, this.itemData.Name);
					}
					this.awardDesc.text = text;
				}
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this._OnItemClicked));
			}

			// Token: 0x0600F029 RID: 61481 RVA: 0x0040A4AB File Offset: 0x004088AB
			private void _OnItemClicked(GameObject obj, ItemData item)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}

			// Token: 0x0400932F RID: 37679
			protected GameObject goLocal;

			// Token: 0x04009330 RID: 37680
			protected GameObject goParent;

			// Token: 0x04009331 RID: 37681
			protected GameObject goPrefab;

			// Token: 0x04009332 RID: 37682
			private ComItem comItem;

			// Token: 0x04009333 RID: 37683
			private Text awardDesc;

			// Token: 0x04009334 RID: 37684
			private AwardItemData data;

			// Token: 0x04009335 RID: 37685
			private ItemData itemData;

			// Token: 0x04009336 RID: 37686
			private MissionScoreAwardFrame THIS;
		}
	}
}
