using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE0 RID: 7136
	internal class TapMissionNoticeListFrame : ClientFrame
	{
		// Token: 0x060117DE RID: 71646 RVA: 0x00516106 File Offset: 0x00514506
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamBeInvitedListFrame";
		}

		// Token: 0x060117DF RID: 71647 RVA: 0x00516110 File Offset: 0x00514510
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPupilDataUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMyPupilMissionUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			this.InitMainTabUIList();
			this.InitInterface();
		}

		// Token: 0x060117E0 RID: 71648 RVA: 0x00516160 File Offset: 0x00514560
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPupilDataUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMyPupilMissionUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
			this.ClearData();
			this.UnInitMainTabUIList();
		}

		// Token: 0x060117E1 RID: 71649 RVA: 0x005161B0 File Offset: 0x005145B0
		private void InitMainTabUIList()
		{
			if (this.mMainTabs != null)
			{
				this.mMainTabs.Initialize();
				ComUIListScript comUIListScript = this.mMainTabs;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabs;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x060117E2 RID: 71650 RVA: 0x00516228 File Offset: 0x00514628
		private void UnInitMainTabUIList()
		{
			if (this.mMainTabs != null)
			{
				ComUIListScript comUIListScript = this.mMainTabs;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabs;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x060117E3 RID: 71651 RVA: 0x00516294 File Offset: 0x00514694
		private TeamInvitedTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<TeamInvitedTabItem>();
		}

		// Token: 0x060117E4 RID: 71652 RVA: 0x0051629C File Offset: 0x0051469C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			TeamInvitedTabItem teamInvitedTabItem = item.gameObjectBindScript as TeamInvitedTabItem;
			if (teamInvitedTabItem != null && item.m_index >= 0 && item.m_index < this.mMainTabDataList.Count)
			{
				InvitedTabData invitedTabData = this.mMainTabDataList[item.m_index];
				if (this.invitedTabType != InvitedTabType.ITT_None)
				{
					teamInvitedTabItem.InitTab(invitedTabData, new OnInvitedTabClick(this.OnInvitedTabClick), invitedTabData.mInvitedTabType == this.invitedTabType);
				}
				else
				{
					teamInvitedTabItem.InitTab(invitedTabData, new OnInvitedTabClick(this.OnInvitedTabClick), item.m_index == 0);
				}
			}
		}

		// Token: 0x060117E5 RID: 71653 RVA: 0x00516342 File Offset: 0x00514742
		private void OnInvitedTabClick(InvitedTabData invitedTabData)
		{
			if (invitedTabData == null)
			{
				return;
			}
			this.invitedTabType = invitedTabData.mInvitedTabType;
			this.UpdateEleObjList();
		}

		// Token: 0x060117E6 RID: 71654 RVA: 0x00516360 File Offset: 0x00514760
		private void OnNewInviteNoticeUpdate(UIEvent iEvent)
		{
			List<RelationData> taskFinishedPupils = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils;
			if (taskFinishedPupils.Count <= 0)
			{
				this.invitedTabType = InvitedTabType.ITT_None;
			}
			this.UpdateMainTabList();
			this.UpdateEleObjList();
		}

		// Token: 0x060117E7 RID: 71655 RVA: 0x00516398 File Offset: 0x00514798
		private void ClearData()
		{
			for (int i = 0; i < this.EleObjList.Count; i++)
			{
				if (!(this.EleObjList[i] == null))
				{
					ComCommonBind component = this.EleObjList[i].GetComponent<ComCommonBind>();
					if (!(component == null))
					{
						GameObject gameObject = component.GetGameObject("BtAgree");
						gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
					}
				}
			}
			this.EleObjList.Clear();
			this.invitedTabType = InvitedTabType.ITT_None;
			if (this.mMainTabDataList != null)
			{
				this.mMainTabDataList.Clear();
			}
			DataManager<TAPNewDataManager>.GetInstance().ClearFinishTaskInfo();
		}

		// Token: 0x060117E8 RID: 71656 RVA: 0x00516450 File Offset: 0x00514850
		private void OnReject(int index)
		{
			if (this.invitedTabType == InvitedTabType.ITT_None)
			{
				List<RelationData> taskFinishedPupils = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils;
				if (index < 0 || index > taskFinishedPupils.Count)
				{
					return;
				}
				taskFinishedPupils.RemoveAt(index);
			}
			this.UpdateEleObjList();
			if (DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils.Count <= 0)
			{
				this.frameMgr.CloseFrame<TapMissionNoticeListFrame>(this, false);
			}
		}

		// Token: 0x060117E9 RID: 71657 RVA: 0x005164B8 File Offset: 0x005148B8
		private void OnAgree(int index)
		{
			if (this.invitedTabType == InvitedTabType.ITT_None)
			{
				List<RelationData> taskFinishedPupils = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils;
				if (index < 0 || index > taskFinishedPupils.Count)
				{
					return;
				}
				RelationFrameNew.CommandOpen(new RelationFrameData
				{
					eRelationOptionType = RelationOptionType.ROT_TEACHERANDPUPIL
				});
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSwitchPupilSelect, taskFinishedPupils[index], null, null, null);
				taskFinishedPupils.RemoveAt(index);
				if (taskFinishedPupils.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			this.UpdateEleObjList();
			DataManager<TAPNewDataManager>.GetInstance().RemoveFinishTaskInfo(index);
			if (DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils.Count <= 0)
			{
				this.frameMgr.CloseFrame<TapMissionNoticeListFrame>(this, false);
			}
		}

		// Token: 0x060117EA RID: 71658 RVA: 0x00516568 File Offset: 0x00514968
		private void InitInterface()
		{
			if (this.mTitle != null)
			{
				this.mTitle.text = "师徒任务消息列表";
			}
			this.UpdateMainTabList();
		}

		// Token: 0x060117EB RID: 71659 RVA: 0x00516594 File Offset: 0x00514994
		private void UpdateMainTabList()
		{
			if (this.mMainTabDataList != null)
			{
				this.mMainTabDataList.Clear();
			}
			for (int i = 0; i < 5; i++)
			{
				if (i == 0)
				{
					int count = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils.Count;
					if (count > 0)
					{
						InvitedTabData invitedTabData = new InvitedTabData();
						invitedTabData.mInvitedTabType = InvitedTabType.ITT_None;
						invitedTabData.mTabName = "师徒";
						this.mMainTabDataList.Add(invitedTabData);
					}
				}
			}
			this.mMainTabs.SetElementAmount(this.mMainTabDataList.Count);
		}

		// Token: 0x060117EC RID: 71660 RVA: 0x00516624 File Offset: 0x00514A24
		private void UpdateEleObjList()
		{
			int count = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils.Count;
			if (count > this.EleObjList.Count)
			{
				int num = count - this.EleObjList.Count;
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.BeInvitedListElePath, true, 0U);
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.mEleRoot, false);
						this.EleObjList.Add(gameObject);
					}
				}
			}
			for (int j = 0; j < this.EleObjList.Count; j++)
			{
				if (j < count)
				{
					ComCommonBind component = this.EleObjList[j].GetComponent<ComCommonBind>();
					if (component == null)
					{
						this.EleObjList[j].SetActive(false);
					}
					else
					{
						GameObject gameObject2 = component.GetGameObject("Icon");
						Image component2 = gameObject2.GetComponent<Image>();
						GameObject gameObject3 = component.GetGameObject("LevelBack");
						GameObject gameObject4 = component.GetGameObject("Name");
						GameObject gameObject5 = component.GetGameObject("Level");
						GameObject gameObject6 = component.GetGameObject("Target");
						GameObject gameObject7 = component.GetGameObject("BtReject");
						GameObject gameObject8 = component.GetGameObject("BtAgree");
						Text component3 = gameObject4.GetComponent<Text>();
						if (this.invitedTabType == InvitedTabType.ITT_None)
						{
							List<RelationData> taskFinishedPupils = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils;
							RelationData relationData = taskFinishedPupils[j];
							if (relationData == null)
							{
								return;
							}
							component3.text = relationData.name;
							gameObject5.GetComponent<Text>().text = string.Format("Lv.{0}", relationData.level);
							int occu = (int)relationData.occu;
							JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occu, string.Empty, string.Empty);
							if (tableItem != null)
							{
								ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									ETCImageLoader.LoadSprite(ref component2, tableItem2.IconPath, true);
								}
							}
							gameObject3.gameObject.SetActive(true);
							if (relationData.IsDisciple())
							{
								gameObject6.GetComponent<Text>().SafeSetText(TR.Value("tap_Notice_Finish_Mission"));
							}
							else
							{
								gameObject6.GetComponent<Text>().SafeSetText(TR.Value("tap_Notice_Publish_Mission"));
							}
						}
						gameObject7.CustomActive(false);
						Button component4 = gameObject8.GetComponent<Button>();
						component4.onClick.RemoveAllListeners();
						component4.GetComponentInChildren<Text>().SafeSetText("查看");
						int iIndex = j;
						component4.onClick.AddListener(delegate()
						{
							this.OnAgree(iIndex);
						});
						this.EleObjList[j].SetActive(true);
					}
				}
				else
				{
					this.EleObjList[j].SetActive(false);
				}
			}
		}

		// Token: 0x060117ED RID: 71661 RVA: 0x00516914 File Offset: 0x00514D14
		protected override void _bindExUI()
		{
			this.mBtRejectAll = this.mBind.GetCom<Button>("BtRejectAll");
			this.mBtRejectAll.onClick.AddListener(new UnityAction(this._onBtRejectAllButtonClick));
			this.mEleRoot = this.mBind.GetGameObject("EleRoot");
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mMainTabs = this.mBind.GetCom<ComUIListScript>("MainTabs");
		}

		// Token: 0x060117EE RID: 71662 RVA: 0x005169C8 File Offset: 0x00514DC8
		protected override void _unbindExUI()
		{
			this.mBtRejectAll.onClick.RemoveListener(new UnityAction(this._onBtRejectAllButtonClick));
			this.mBtRejectAll = null;
			this.mEleRoot = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mTitle = null;
			this.mMainTabs = null;
		}

		// Token: 0x060117EF RID: 71663 RVA: 0x00516A30 File Offset: 0x00514E30
		private void _onBtRejectAllButtonClick()
		{
			if (this.invitedTabType == InvitedTabType.ITT_None)
			{
				List<RelationData> taskFinishedPupils = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils;
				taskFinishedPupils.Clear();
			}
			this.invitedTabType = InvitedTabType.ITT_None;
			this.UpdateEleObjList();
			this.frameMgr.CloseFrame<TapMissionNoticeListFrame>(this, false);
		}

		// Token: 0x060117F0 RID: 71664 RVA: 0x00516A73 File Offset: 0x00514E73
		private void _onBtCloseButtonClick()
		{
			DataManager<TAPNewDataManager>.GetInstance().ClearFinishTaskInfo();
			this.frameMgr.CloseFrame<TapMissionNoticeListFrame>(this, false);
		}

		// Token: 0x0400B5E2 RID: 46562
		private string BeInvitedListElePath = "UIFlatten/Prefabs/Team/TeamBeInvitedEle";

		// Token: 0x0400B5E3 RID: 46563
		private List<GameObject> EleObjList = new List<GameObject>();

		// Token: 0x0400B5E4 RID: 46564
		private InvitedTabType invitedTabType;

		// Token: 0x0400B5E5 RID: 46565
		private List<InvitedTabData> mMainTabDataList = new List<InvitedTabData>();

		// Token: 0x0400B5E6 RID: 46566
		private Button mBtRejectAll;

		// Token: 0x0400B5E7 RID: 46567
		private GameObject mEleRoot;

		// Token: 0x0400B5E8 RID: 46568
		private Button mBtClose;

		// Token: 0x0400B5E9 RID: 46569
		public Text mTitle;

		// Token: 0x0400B5EA RID: 46570
		private ComUIListScript mMainTabs;
	}
}
