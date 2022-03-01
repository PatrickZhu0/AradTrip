using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200164F RID: 5711
	internal class GuildRequesterListFrame : ClientFrame
	{
		// Token: 0x0600E0B8 RID: 57528 RVA: 0x003980D1 File Offset: 0x003964D1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildRequesterList";
		}

		// Token: 0x0600E0B9 RID: 57529 RVA: 0x003980D8 File Offset: 0x003964D8
		protected override void _OnOpenFrame()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				return;
			}
			this._InitRequesterList();
			this._InitSort();
			this._RegisterUIEvent();
			DataManager<GuildDataManager>.GetInstance().RequestGuildRequesters();
		}

		// Token: 0x0600E0BA RID: 57530 RVA: 0x00398106 File Offset: 0x00396506
		protected override void _OnCloseFrame()
		{
			this.m_eSortType = GuildRequesterListFrame.EColType.Level;
			this.m_arrSortInfos.Clear();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E0BB RID: 57531 RVA: 0x00398120 File Offset: 0x00396520
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildRequestersUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildRequestersUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildProcessRequesterSuccess, new ClientEventSystem.UIEventHandler(this._OnProcessRequesterSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600E0BC RID: 57532 RVA: 0x00398180 File Offset: 0x00396580
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildRequestersUpdated, new ClientEventSystem.UIEventHandler(this._OnGuildRequestersUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildProcessRequesterSuccess, new ClientEventSystem.UIEventHandler(this._OnProcessRequesterSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600E0BD RID: 57533 RVA: 0x003981DE File Offset: 0x003965DE
		private void _InitRequesterList()
		{
			this.m_comRequesterList.Initialize();
			this.m_comRequesterList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				List<GuildRequesterData> arrRequesters = DataManager<GuildDataManager>.GetInstance().myGuild.arrRequesters;
				if (arrRequesters == null)
				{
					Logger.LogErrorFormat("【公会申请列表】【_InitRequesterList】列表数据为空", new object[0]);
					return;
				}
				if (item.m_index < 0 || item.m_index >= arrRequesters.Count)
				{
					Logger.LogErrorFormat("【公会申请列表】【_InitRequesterList】刷新索引{0}无效，当前数据范围是{1}，{2}", new object[]
					{
						item.m_index,
						0,
						arrRequesters.Count - 1
					});
					return;
				}
				GameObject gameObject = item.gameObject;
				GuildRequesterData data = arrRequesters[item.m_index];
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogErrorFormat("公会玩家申请列表item丢失绑定组件ComCommonBind！！！", new object[0]);
					return;
				}
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(data.nJobID, string.Empty, string.Empty);
				Utility.GetComponetInChild<Text>(gameObject, "Job/Name").text = tableItem.Name;
				string path = string.Empty;
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
				Image componetInChild = Utility.GetComponetInChild<Image>(gameObject, "Job/Face");
				ETCImageLoader.LoadSprite(ref componetInChild, path, true);
				Text componetInChild2 = Utility.GetComponetInChild<Text>(gameObject, "Name/Text");
				if (data.remark != null && data.remark != string.Empty)
				{
					componetInChild2.text = data.remark;
				}
				else
				{
					componetInChild2.text = data.strName;
				}
				Button com = component.GetCom<Button>("Job");
				com.SafeAddOnClickListener(delegate
				{
					DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(data.uGUID, 0U, 0U);
				});
				Utility.GetComponetInChild<Text>(gameObject, "Level/Text").text = string.Format("Lv{0}", data.nLevel);
				ulong uGUID = data.uGUID;
				Button componetInChild3 = Utility.GetComponetInChild<Button>(gameObject, "Oper/Agree");
				componetInChild3.onClick.RemoveAllListeners();
				componetInChild3.onClick.AddListener(delegate()
				{
					DataManager<GuildDataManager>.GetInstance().ProcessRequester(uGUID, true);
				});
				Button componetInChild4 = Utility.GetComponetInChild<Button>(gameObject, "Oper/Refuse");
				componetInChild4.onClick.RemoveAllListeners();
				componetInChild4.onClick.AddListener(delegate()
				{
					DataManager<GuildDataManager>.GetInstance().ProcessRequester(uGUID, false);
				});
			};
		}

		// Token: 0x0600E0BE RID: 57534 RVA: 0x00398214 File Offset: 0x00396614
		private void _UpdateRequesterList(bool a_bResetScrollPos = false)
		{
			if (DataManager<GuildDataManager>.GetInstance().myGuild.arrRequesters != null)
			{
				this.m_comRequesterList.SetElementAmount(DataManager<GuildDataManager>.GetInstance().myGuild.arrRequesters.Count);
				if (a_bResetScrollPos)
				{
					this.m_comRequesterList.m_scrollRect.verticalNormalizedPosition = 1f;
				}
			}
			else
			{
				Logger.LogErrorFormat("【公会申请列表】【_UpdateRequesterList】列表数据为空", new object[0]);
			}
		}

		// Token: 0x0600E0BF RID: 57535 RVA: 0x00398284 File Offset: 0x00396684
		private void _InitSort()
		{
			for (int i = 0; i < 3; i++)
			{
				this.m_arrSortInfos.Add(new GuildRequesterListFrame.SortInfo());
			}
			this.m_arrSortInfos[0].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "Content/ScrollView/Title/Job/Sort");
			this.m_arrSortInfos[1].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "Content/ScrollView/Title/Name/Sort");
			this.m_arrSortInfos[2].imgAscending = Utility.GetComponetInChild<Image>(this.frame, "Content/ScrollView/Title/Level/Sort");
			for (int j = 0; j < this.m_arrSortInfos.Count; j++)
			{
				this.m_arrSortInfos[j].imgAscending.gameObject.SetActive(false);
			}
			GuildRequesterListFrame.SortInfo sortInfo = this.m_arrSortInfos[(int)this.m_eSortType];
			sortInfo.imgAscending.gameObject.SetActive(true);
			sortInfo.imgAscending.transform.localRotation = ((!sortInfo.bAscending) ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 180f));
		}

		// Token: 0x0600E0C0 RID: 57536 RVA: 0x003983BC File Offset: 0x003967BC
		private void _UpdateSort()
		{
			int eSortType = (int)this.m_eSortType;
			if (eSortType < 0 && eSortType >= this.m_arrSortInfos.Count)
			{
				return;
			}
			for (int i = 0; i < this.m_arrSortInfos.Count; i++)
			{
				this.m_arrSortInfos[i].imgAscending.gameObject.SetActive(false);
			}
			GuildRequesterListFrame.SortInfo sortInfo = this.m_arrSortInfos[(int)this.m_eSortType];
			sortInfo.imgAscending.gameObject.SetActive(true);
			sortInfo.imgAscending.transform.localRotation = ((!sortInfo.bAscending) ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 180f));
		}

		// Token: 0x0600E0C1 RID: 57537 RVA: 0x0039848C File Offset: 0x0039688C
		private void _ChangeSortRule(GuildRequesterListFrame.EColType a_colType)
		{
			if (a_colType >= GuildRequesterListFrame.EColType.Job && a_colType < (GuildRequesterListFrame.EColType)this.m_arrSortInfos.Count)
			{
				this.m_eSortType = a_colType;
				this.m_arrSortInfos[(int)a_colType].bAscending = !this.m_arrSortInfos[(int)a_colType].bAscending;
				this._UpdateSort();
				this._SortRequesterData();
				this._UpdateRequesterList(false);
			}
		}

		// Token: 0x0600E0C2 RID: 57538 RVA: 0x003984F4 File Offset: 0x003968F4
		private void _SortRequesterData()
		{
			int eSortType = (int)this.m_eSortType;
			if (eSortType >= 0 && eSortType < this.m_arrSortInfos.Count)
			{
				List<GuildRequesterData> arrRequesters = DataManager<GuildDataManager>.GetInstance().myGuild.arrRequesters;
				if (arrRequesters == null)
				{
					Logger.LogErrorFormat("【公会申请列表】【_SortRequesterData】列表数据为空", new object[0]);
					return;
				}
				int nSign = (!this.m_arrSortInfos[eSortType].bAscending) ? -1 : 1;
				GuildRequesterListFrame.EColType eSortType2 = this.m_eSortType;
				if (eSortType2 != GuildRequesterListFrame.EColType.Job)
				{
					if (eSortType2 != GuildRequesterListFrame.EColType.Name)
					{
						if (eSortType2 == GuildRequesterListFrame.EColType.Level)
						{
							arrRequesters.Sort((GuildRequesterData a_left, GuildRequesterData a_right) => (a_left.nLevel - a_right.nLevel) * nSign);
						}
					}
					else
					{
						arrRequesters.Sort((GuildRequesterData a_left, GuildRequesterData a_right) => string.Compare(a_left.strName, a_right.strName) * nSign);
					}
				}
				else
				{
					arrRequesters.Sort((GuildRequesterData a_left, GuildRequesterData a_right) => (a_left.nJobID - a_right.nJobID) * nSign);
				}
			}
		}

		// Token: 0x0600E0C3 RID: 57539 RVA: 0x003985D5 File Offset: 0x003969D5
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildRequesterListFrame>(this, false);
		}

		// Token: 0x0600E0C4 RID: 57540 RVA: 0x003985E4 File Offset: 0x003969E4
		private void _OnGuildRequestersUpdate(UIEvent a_event)
		{
			this._SortRequesterData();
			this._UpdateRequesterList(true);
		}

		// Token: 0x0600E0C5 RID: 57541 RVA: 0x003985F3 File Offset: 0x003969F3
		private void _OnProcessRequesterSuccess(UIEvent a_event)
		{
			this._UpdateRequesterList(false);
		}

		// Token: 0x0600E0C6 RID: 57542 RVA: 0x003985FC File Offset: 0x003969FC
		[UIEventHandle("Content/Refresh")]
		private void _OnRefreshClicked()
		{
			DataManager<GuildDataManager>.GetInstance().RequestGuildRequesters();
		}

		// Token: 0x0600E0C7 RID: 57543 RVA: 0x00398608 File Offset: 0x00396A08
		[UIEventHandle("Content/Clear")]
		private void _OnClearClicked()
		{
			DataManager<GuildDataManager>.GetInstance().ProcessRequester(0UL, false);
		}

		// Token: 0x0600E0C8 RID: 57544 RVA: 0x00398617 File Offset: 0x00396A17
		[UIEventHandle("Content/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildRequesterListFrame>(this, false);
		}

		// Token: 0x0600E0C9 RID: 57545 RVA: 0x00398626 File Offset: 0x00396A26
		[UIEventHandle("Content/ScrollView/Title/Job")]
		private void _OnTitleJobClicked()
		{
			this._ChangeSortRule(GuildRequesterListFrame.EColType.Job);
		}

		// Token: 0x0600E0CA RID: 57546 RVA: 0x0039862F File Offset: 0x00396A2F
		[UIEventHandle("Content/ScrollView/Title/Name")]
		private void _OnTitleNameClicked()
		{
			this._ChangeSortRule(GuildRequesterListFrame.EColType.Name);
		}

		// Token: 0x0600E0CB RID: 57547 RVA: 0x00398638 File Offset: 0x00396A38
		[UIEventHandle("Content/ScrollView/Title/Level")]
		private void _OnTitleLevelClicked()
		{
			this._ChangeSortRule(GuildRequesterListFrame.EColType.Level);
		}

		// Token: 0x040085B2 RID: 34226
		[UIControl("Content/ScrollView", null, 0)]
		private ComUIListScript m_comRequesterList;

		// Token: 0x040085B3 RID: 34227
		private List<GuildRequesterListFrame.SortInfo> m_arrSortInfos = new List<GuildRequesterListFrame.SortInfo>();

		// Token: 0x040085B4 RID: 34228
		private GuildRequesterListFrame.EColType m_eSortType = GuildRequesterListFrame.EColType.Level;

		// Token: 0x02001650 RID: 5712
		private enum EColType
		{
			// Token: 0x040085B7 RID: 34231
			Job,
			// Token: 0x040085B8 RID: 34232
			Name,
			// Token: 0x040085B9 RID: 34233
			Level,
			// Token: 0x040085BA RID: 34234
			Count
		}

		// Token: 0x02001651 RID: 5713
		private class SortInfo
		{
			// Token: 0x040085BB RID: 34235
			public bool bAscending;

			// Token: 0x040085BC RID: 34236
			public Image imgAscending;
		}
	}
}
