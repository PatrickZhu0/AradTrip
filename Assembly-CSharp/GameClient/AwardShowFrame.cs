using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019AF RID: 6575
	internal class AwardShowFrame : ClientFrame
	{
		// Token: 0x060100EC RID: 65772 RVA: 0x00475FF8 File Offset: 0x004743F8
		public static void Open(int id)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AwardShowFrame>(null, false);
			MissionManager.MissionScoreData missionScoreData = DataManager<MissionManager>.GetInstance().MissionScoreDatas.Find((MissionManager.MissionScoreData x) => x.missionScoreItem.ID == id);
			if (missionScoreData != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AwardShowFrame>(FrameLayer.Middle, missionScoreData, string.Empty);
			}
		}

		// Token: 0x060100ED RID: 65773 RVA: 0x00476052 File Offset: 0x00474452
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/AwardShow";
		}

		// Token: 0x060100EE RID: 65774 RVA: 0x0047605C File Offset: 0x0047445C
		protected override void _OnOpenFrame()
		{
			this.m_kData = null;
			AwardRankItem awardRankItem = this.userData as AwardRankItem;
			if (awardRankItem != null)
			{
				this.m_kData = new MissionManager.MissionScoreData();
				for (int i = 0; i < awardRankItem.arrItems.Count; i++)
				{
					AwardItemData awardItemData = new AwardItemData();
					awardItemData.ID = awardRankItem.arrItems[i].TableID;
					awardItemData.Num = awardRankItem.arrItems[i].Count;
					this.m_kData.awards.Add(awardItemData);
				}
			}
			this._InitItemAwardObjects();
			this._UpdateItemAwardObjects();
		}

		// Token: 0x060100EF RID: 65775 RVA: 0x004760FA File Offset: 0x004744FA
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
		}

		// Token: 0x060100F0 RID: 65776 RVA: 0x00476103 File Offset: 0x00474503
		[UIEventHandle("BtnOK")]
		private void _OnClickClose()
		{
			this.frameMgr.CloseFrame<AwardShowFrame>(this, false);
		}

		// Token: 0x060100F1 RID: 65777 RVA: 0x00476112 File Offset: 0x00474512
		private void OnDailyScoreChanged(int score)
		{
			this._UpdateItemAwardObjects();
			this._UpdateHintInfo();
		}

		// Token: 0x060100F2 RID: 65778 RVA: 0x00476120 File Offset: 0x00474520
		private void OnChestIdsChanged()
		{
			this._UpdateItemAwardObjects();
			this._UpdateHintInfo();
		}

		// Token: 0x060100F3 RID: 65779 RVA: 0x0047612E File Offset: 0x0047452E
		private void _InitItemAwardObjects()
		{
			this.m_goParent = Utility.FindChild(this.frame, "AwardArray");
			this.m_goPrefab = Utility.FindChild(this.frame, "AwardArray/AwardItem");
			this.m_goPrefab.CustomActive(false);
		}

		// Token: 0x060100F4 RID: 65780 RVA: 0x00476168 File Offset: 0x00474568
		private void _UnInitItemAwardObjects()
		{
			this.m_akAwardItemObjects.DestroyAllObjects();
			this.m_goParent = null;
			this.m_goPrefab = null;
		}

		// Token: 0x060100F5 RID: 65781 RVA: 0x00476184 File Offset: 0x00474584
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

		// Token: 0x060100F6 RID: 65782 RVA: 0x00476204 File Offset: 0x00474604
		private void _InitHintInfo()
		{
			this.hint = Utility.FindComponent<Text>(this.frame, "AwardHint", true);
			this.button = Utility.FindComponent<Button>(this.frame, "BtnAward", true);
			this.gray = Utility.FindComponent<UIGray>(this.frame, "BtnAward", true);
			this.button.onClick.RemoveAllListeners();
			this.button.onClick.AddListener(new UnityAction(this._OnClickAcquired));
		}

		// Token: 0x060100F7 RID: 65783 RVA: 0x00476284 File Offset: 0x00474684
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

		// Token: 0x060100F8 RID: 65784 RVA: 0x004763BC File Offset: 0x004747BC
		private void _UnInitHintInfo()
		{
			this.hint = null;
			this.button.onClick.RemoveAllListeners();
			this.button = null;
			this.gray = null;
		}

		// Token: 0x060100F9 RID: 65785 RVA: 0x004763E3 File Offset: 0x004747E3
		private void _OnClickAcquired()
		{
			DataManager<MissionManager>.GetInstance().SendAcquireAwards(this.m_kData.missionScoreItem.ID);
			this.frameMgr.CloseFrame<AwardShowFrame>(this, false);
		}

		// Token: 0x0400A220 RID: 41504
		private MissionManager.MissionScoreData m_kData;

		// Token: 0x0400A221 RID: 41505
		private CachedObjectListManager<AwardShowFrame.AwardItemObject> m_akAwardItemObjects = new CachedObjectListManager<AwardShowFrame.AwardItemObject>();

		// Token: 0x0400A222 RID: 41506
		private GameObject m_goParent;

		// Token: 0x0400A223 RID: 41507
		private GameObject m_goPrefab;

		// Token: 0x0400A224 RID: 41508
		private Text hint;

		// Token: 0x0400A225 RID: 41509
		private Button button;

		// Token: 0x0400A226 RID: 41510
		private UIGray gray;

		// Token: 0x020019B0 RID: 6576
		private class AwardItemObject : CachedObject
		{
			// Token: 0x060100FB RID: 65787 RVA: 0x00476414 File Offset: 0x00474814
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.data = (param[2] as AwardItemData);
				this.THIS = (param[3] as AwardShowFrame);
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

			// Token: 0x060100FC RID: 65788 RVA: 0x004764D1 File Offset: 0x004748D1
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x060100FD RID: 65789 RVA: 0x004764D9 File Offset: 0x004748D9
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x060100FE RID: 65790 RVA: 0x004764F8 File Offset: 0x004748F8
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060100FF RID: 65791 RVA: 0x00476517 File Offset: 0x00474917
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06010100 RID: 65792 RVA: 0x00476520 File Offset: 0x00474920
			public override void OnRefresh(object[] param)
			{
				if (param != null && param.Length > 0)
				{
					this.data = (param[0] as AwardItemData);
				}
				this._UpdateItem();
			}

			// Token: 0x06010101 RID: 65793 RVA: 0x00476545 File Offset: 0x00474945
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x06010102 RID: 65794 RVA: 0x00476548 File Offset: 0x00474948
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

			// Token: 0x06010103 RID: 65795 RVA: 0x004766CB File Offset: 0x00474ACB
			private void _OnItemClicked(GameObject obj, ItemData item)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}

			// Token: 0x0400A227 RID: 41511
			protected GameObject goLocal;

			// Token: 0x0400A228 RID: 41512
			protected GameObject goParent;

			// Token: 0x0400A229 RID: 41513
			protected GameObject goPrefab;

			// Token: 0x0400A22A RID: 41514
			private ComItem comItem;

			// Token: 0x0400A22B RID: 41515
			private Text awardDesc;

			// Token: 0x0400A22C RID: 41516
			private AwardItemData data;

			// Token: 0x0400A22D RID: 41517
			private ItemData itemData;

			// Token: 0x0400A22E RID: 41518
			private AwardShowFrame THIS;
		}
	}
}
