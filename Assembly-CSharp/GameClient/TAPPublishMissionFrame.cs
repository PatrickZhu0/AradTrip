using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BDA RID: 7130
	public class TAPPublishMissionFrame : ClientFrame
	{
		// Token: 0x06011778 RID: 71544 RVA: 0x00512A43 File Offset: 0x00510E43
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPPublishMissionFrame";
		}

		// Token: 0x06011779 RID: 71545 RVA: 0x00512A4C File Offset: 0x00510E4C
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.relationData = (RelationData)this.userData;
			}
			else
			{
				this.relationData = null;
			}
			this._RegisterUIEvent();
			this._InitComUIList();
			this._InitData();
			this._InitUI();
		}

		// Token: 0x0601177A RID: 71546 RVA: 0x00512A99 File Offset: 0x00510E99
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0601177B RID: 71547 RVA: 0x00512AB0 File Offset: 0x00510EB0
		private void _InitComUIList()
		{
			this.mRewardScrollView.Initialize();
			this.mRewardScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateRewardBind(item);
				}
			};
			this.mRewardScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
		}

		// Token: 0x0601177C RID: 71548 RVA: 0x00512B08 File Offset: 0x00510F08
		private void _InitRewardList()
		{
			this.myRewardList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MasterSysGiftTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				MasterSysGiftTable masterSysGiftTable = keyValuePair.Value as MasterSysGiftTable;
				if (masterSysGiftTable.Type == 1)
				{
					GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(masterSysGiftTable.GiftId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						FlatBufferArray<int> items = tableItem.Items;
						for (int i = 0; i < items.Length; i++)
						{
							GiftTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items[i], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								this.myRewardList.Add(new TAPMissionReward(tableItem2.ItemID, tableItem2.ItemCount));
							}
						}
					}
				}
			}
		}

		// Token: 0x0601177D RID: 71549 RVA: 0x00512BFC File Offset: 0x00510FFC
		private void _UpdateRewardBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			if (this.myRewardList.Count <= 0)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("rewardRoot");
			ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(gameObject);
			}
			ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(this.myRewardList[item.m_index].tableID, 100, 0);
			if (ItemDetailData == null)
			{
				return;
			}
			ItemDetailData.Count = this.myRewardList[item.m_index].count;
			comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(ItemDetailData);
			});
		}

		// Token: 0x0601177E RID: 71550 RVA: 0x00512CD9 File Offset: 0x005110D9
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0601177F RID: 71551 RVA: 0x00512CF4 File Offset: 0x005110F4
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateTAPPublishFrame, new ClientEventSystem.UIEventHandler(this._OnUpdateTAPPublishFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPPublishMissionSuccess, new ClientEventSystem.UIEventHandler(this._OnTAPPublishMissionSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateTAPPublishFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateTAPPublishFrame));
		}

		// Token: 0x06011780 RID: 71552 RVA: 0x00512D70 File Offset: 0x00511170
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateTAPPublishFrame, new ClientEventSystem.UIEventHandler(this._OnUpdateTAPPublishFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPPublishMissionSuccess, new ClientEventSystem.UIEventHandler(this._OnTAPPublishMissionSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateTAPPublishFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnUpdateTAPPublishFrame));
		}

		// Token: 0x06011781 RID: 71553 RVA: 0x00512DE9 File Offset: 0x005111E9
		private void _InitData()
		{
			this._InitRewardList();
			if (this.myRewardList.Count != 0)
			{
				this.mRewardScrollView.SetElementAmount(this.myRewardList.Count);
			}
		}

		// Token: 0x06011782 RID: 71554 RVA: 0x00512E18 File Offset: 0x00511218
		private void _InitUI()
		{
			this._UpdateUI();
			bool flag = false;
			if (this.relationData == null)
			{
				TAPType taptype = DataManager<TAPNewDataManager>.GetInstance().IsTeacher();
				if (taptype > TAPType.Pupil)
				{
					flag = true;
				}
			}
			else if (this.relationData.tapType == TAPType.Pupil)
			{
				flag = true;
			}
			if (flag)
			{
				this.myRewardList = DataManager<TAPNewDataManager>.GetInstance()._GetRewardList(1);
			}
			else
			{
				this.myRewardList = DataManager<TAPNewDataManager>.GetInstance()._GetRewardList(2);
			}
			if (this.myRewardList.Count != 0)
			{
				this.mRewardScrollView.SetElementAmount(this.myRewardList.Count);
			}
		}

		// Token: 0x06011783 RID: 71555 RVA: 0x00512EB8 File Offset: 0x005112B8
		private void _UpdateUI()
		{
			this.mSearchTeacher.CustomActive(false);
			this.mSearchPupil.CustomActive(false);
			this.mReceiveReward.CustomActive(false);
			this.mTalkTeacher.CustomActive(false);
			bool flag = false;
			if (this.relationData == null)
			{
				TAPType taptype = DataManager<TAPNewDataManager>.GetInstance().IsTeacher();
				if (taptype > TAPType.Pupil)
				{
					flag = true;
				}
			}
			else if (this.relationData.tapType == TAPType.Pupil)
			{
				flag = true;
			}
			if (flag)
			{
				if (this.relationData == null || this.relationData.uid == 0UL)
				{
					this.mSearchPupil.CustomActive(true);
					this.mTitleText.text = TR.Value("tap_search_pupil_title_text");
					this.mSearchPupilRedPoint.CustomActive(false);
					if (DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint())
					{
						this.mSearchPupilRedPoint.CustomActive(true);
					}
					else if (DataManager<TAPDataManager>.GetInstance().CheckTapRedPointIsShow())
					{
						if (DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP)
						{
							this.mSearchPupilRedPoint.CustomActive(false);
						}
						else
						{
							this.mSearchPupilRedPoint.CustomActive(true);
						}
					}
				}
				else
				{
					this.mReceiveReward.CustomActive(true);
					this.mTitleText.text = TR.Value("tap_receive_reward_title_text");
					if (this.relationData != null)
					{
						this.mPublishMissionRedPoint.CustomActive(this.relationData.dailyTaskState == 0);
					}
				}
			}
			else if (this.relationData == null || this.relationData.uid == 0UL)
			{
				this.mSearchTeacher.CustomActive(true);
				this.mTitleText.text = TR.Value("tap_search_teacher_title_text");
				if (DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint())
				{
					this.mSearchTeacherRedPoint.CustomActive(true);
				}
				else if (DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP)
				{
					this.mSearchTeacherRedPoint.CustomActive(false);
				}
				else
				{
					this.mSearchTeacherRedPoint.CustomActive(true);
				}
			}
			else
			{
				this.mTalkTeacher.CustomActive(true);
				this.mTitleText.text = TR.Value("tap_talk_teacher_title_text");
				if (this.relationData != null)
				{
					bool bActive = DataManager<TAPNewDataManager>.GetInstance().HaveTAPDailyRedPointForID(this.relationData.uid);
					this.mTalkTeacherRedPoint.CustomActive(bActive);
				}
			}
		}

		// Token: 0x06011784 RID: 71556 RVA: 0x00513105 File Offset: 0x00511505
		private void _ClearData()
		{
			this.myRewardList.Clear();
		}

		// Token: 0x06011785 RID: 71557 RVA: 0x00513112 File Offset: 0x00511512
		private void _ClearUI()
		{
			this.relationData = null;
		}

		// Token: 0x06011786 RID: 71558 RVA: 0x0051311C File Offset: 0x0051151C
		private void _OnUpdateTAPPublishFrame(UIEvent uiEvent)
		{
			RelationData relationData = (RelationData)uiEvent.Param1;
			this.relationData = relationData;
			this._UpdateUI();
		}

		// Token: 0x06011787 RID: 71559 RVA: 0x00513144 File Offset: 0x00511544
		private void _OnTAPPublishMissionSuccess(UIEvent uiEvent)
		{
			string talkStr = TR.Value("tap_talk_pupil_get_mission");
			DataManager<TAPNewDataManager>.GetInstance()._TalkToPeople(this.relationData, talkStr);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPSetRedPoint, null, null, null, null);
			this.frameMgr.CloseFrame<TAPPublishMissionFrame>(this, false);
		}

		// Token: 0x06011788 RID: 71560 RVA: 0x00513190 File Offset: 0x00511590
		protected override void _bindExUI()
		{
			this.mRewardScrollView = this.mBind.GetCom<ComUIListScript>("RewardScrollView");
			this.mSearchTeacher = this.mBind.GetCom<Button>("SearchTeacher");
			if (null != this.mSearchTeacher)
			{
				this.mSearchTeacher.onClick.AddListener(new UnityAction(this._onSearchTeacherButtonClick));
			}
			this.mSearchPupil = this.mBind.GetCom<Button>("SearchPupil");
			if (null != this.mSearchPupil)
			{
				this.mSearchPupil.onClick.AddListener(new UnityAction(this._onSearchPupilButtonClick));
			}
			this.mTalkTeacher = this.mBind.GetCom<Button>("TalkTeacher");
			if (null != this.mTalkTeacher)
			{
				this.mTalkTeacher.onClick.AddListener(new UnityAction(this._onTalkTeacherButtonClick));
			}
			this.mReceiveReward = this.mBind.GetCom<Button>("receiveReward");
			if (null != this.mReceiveReward)
			{
				this.mReceiveReward.onClick.AddListener(new UnityAction(this._onReceiveRewardButtonClick));
			}
			this.mTalkTeacherRedPoint = this.mBind.GetGameObject("TalkTeacherRedPoint");
			this.mPublishMissionRedPoint = this.mBind.GetGameObject("PublishMissionRedPoint");
			this.mSearchTeacherRedPoint = this.mBind.GetGameObject("SearchTeacherRedPoint");
			this.mSearchPupilRedPoint = this.mBind.GetGameObject("SearchPupilRedPoint");
			this.mTitleText = this.mBind.GetCom<Text>("TitleText");
		}

		// Token: 0x06011789 RID: 71561 RVA: 0x00513330 File Offset: 0x00511730
		protected override void _unbindExUI()
		{
			this.mRewardScrollView = null;
			if (null != this.mSearchTeacher)
			{
				this.mSearchTeacher.onClick.RemoveListener(new UnityAction(this._onSearchTeacherButtonClick));
			}
			this.mSearchTeacher = null;
			if (null != this.mSearchPupil)
			{
				this.mSearchPupil.onClick.RemoveListener(new UnityAction(this._onSearchPupilButtonClick));
			}
			this.mSearchPupil = null;
			if (null != this.mTalkTeacher)
			{
				this.mTalkTeacher.onClick.RemoveListener(new UnityAction(this._onTalkTeacherButtonClick));
			}
			this.mTalkTeacher = null;
			if (null != this.mReceiveReward)
			{
				this.mReceiveReward.onClick.RemoveListener(new UnityAction(this._onReceiveRewardButtonClick));
			}
			this.mReceiveReward = null;
			this.mTalkTeacherRedPoint = null;
			this.mPublishMissionRedPoint = null;
			this.mSearchTeacherRedPoint = null;
			this.mSearchPupilRedPoint = null;
			this.mTitleText = null;
		}

		// Token: 0x0601178A RID: 71562 RVA: 0x00513437 File Offset: 0x00511837
		private void _onReceiveRewardButtonClick()
		{
			DataManager<TAPNewDataManager>.GetInstance().SendMissionToPupil(this.relationData.uid);
		}

		// Token: 0x0601178B RID: 71563 RVA: 0x00513450 File Offset: 0x00511850
		private void _onSearchPupilButtonClick()
		{
			this.mSearchPupilRedPoint.CustomActive(false);
			DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP = true;
			DataManager<TAPDataManager>.GetInstance().OnFirstCheckFlag = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPOpenSearchFrame, null, null, null, null);
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x0601178C RID: 71564 RVA: 0x005134D0 File Offset: 0x005118D0
		private void _onTalkTeacherButtonClick()
		{
			string talkStr = TR.Value("tap_talk_teacher_publish_mission");
			DataManager<TAPNewDataManager>.GetInstance()._TalkToPeople(this.relationData, talkStr);
			DataManager<TAPNewDataManager>.GetInstance().SetHaveTalkTeacher(true);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPSetRedPoint, null, null, null, null);
		}

		// Token: 0x0601178D RID: 71565 RVA: 0x00513518 File Offset: 0x00511918
		private void _onSearchTeacherButtonClick()
		{
			if (!DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint())
			{
				this.mSearchTeacherRedPoint.CustomActive(false);
			}
			DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP = true;
			TAPNewDataManager.FindmasterIsSendServer = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPOpenSearchFrame, null, null, null, null);
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x0400B570 RID: 46448
		private List<TAPMissionReward> myRewardList = new List<TAPMissionReward>();

		// Token: 0x0400B571 RID: 46449
		private RelationData relationData;

		// Token: 0x0400B572 RID: 46450
		private ComUIListScript mRewardScrollView;

		// Token: 0x0400B573 RID: 46451
		private Button mSearchTeacher;

		// Token: 0x0400B574 RID: 46452
		private Button mSearchPupil;

		// Token: 0x0400B575 RID: 46453
		private Button mTalkTeacher;

		// Token: 0x0400B576 RID: 46454
		private Button mReceiveReward;

		// Token: 0x0400B577 RID: 46455
		private GameObject mTalkTeacherRedPoint;

		// Token: 0x0400B578 RID: 46456
		private GameObject mPublishMissionRedPoint;

		// Token: 0x0400B579 RID: 46457
		private GameObject mSearchTeacherRedPoint;

		// Token: 0x0400B57A RID: 46458
		private GameObject mSearchPupilRedPoint;

		// Token: 0x0400B57B RID: 46459
		private Text mTitleText;
	}
}
