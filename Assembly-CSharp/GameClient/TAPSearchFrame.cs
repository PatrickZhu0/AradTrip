using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BDD RID: 7133
	public class TAPSearchFrame : ClientFrame
	{
		// Token: 0x060117B2 RID: 71602 RVA: 0x00514C7E File Offset: 0x0051307E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPSearchFrame";
		}

		// Token: 0x060117B3 RID: 71603 RVA: 0x00514C88 File Offset: 0x00513088
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.curToggleIndex = (int)this.userData;
			}
			else
			{
				this.curToggleIndex = 0;
			}
			if (this.HaveApplys())
			{
				this.curToggleIndex = 1;
			}
			this._RegisterUIEvent();
			this._InitData();
			this._InitUI();
			this._UpdateUI();
			DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPOpenSearchFrame, null, null, null, null);
		}

		// Token: 0x060117B4 RID: 71604 RVA: 0x00514D08 File Offset: 0x00513108
		private bool HaveApplys()
		{
			List<RelationData> list = new List<RelationData>();
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyPupils;
			}
			else if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyTeachers;
			}
			return list.Count > 0;
		}

		// Token: 0x060117B5 RID: 71605 RVA: 0x00514D65 File Offset: 0x00513165
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x060117B6 RID: 71606 RVA: 0x00514D7C File Offset: 0x0051317C
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSearchedPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedPupilListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSearchedTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedTeacherListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnTAPApplyToggleRedPointUpdate));
		}

		// Token: 0x060117B7 RID: 71607 RVA: 0x00514DDC File Offset: 0x005131DC
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSearchedPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedPupilListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSearchedTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedTeacherListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnTAPApplyToggleRedPointUpdate));
		}

		// Token: 0x060117B8 RID: 71608 RVA: 0x00514E3C File Offset: 0x0051323C
		private void _InitData()
		{
			this.curTime = 0;
			this.searchList.Clear();
			this.mainToggle.Clear();
			this.tapApplyList.Clear();
			List<RelationData> list = new List<RelationData>();
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				DataManager<TAPNewDataManager>.GetInstance().SendChangeSearchedPupilList(RelationFindType.Disciple);
				list = DataManager<RelationDataManager>.GetInstance().SearchedPupilList;
				this.mName.text = "查找徒弟";
			}
			else
			{
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() != TAPType.Pupil)
				{
					return;
				}
				if (TAPNewDataManager.FindmasterIsSendServer)
				{
					DataManager<TAPNewDataManager>.GetInstance().SendChangeSearchedPupilList(RelationFindType.Master);
				}
				list = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
				this.mName.text = "查找师父";
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.searchList.Add(list[i]);
			}
		}

		// Token: 0x060117B9 RID: 71609 RVA: 0x00514F24 File Offset: 0x00513324
		private void _InitUI()
		{
			this.mainToggle.Add(this.mFunc1);
			this.mainToggle.Add(this.mFunc2);
			this.mainToggle[this.curToggleIndex].isOn = true;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPApplyPupilFrame>(this.mApplyRoot, null, string.Empty);
			this._Func2RedPointUpdate();
		}

		// Token: 0x060117BA RID: 71610 RVA: 0x00514F87 File Offset: 0x00513387
		private void _ClearData()
		{
			this.curTime = 0;
			this.searchList.Clear();
			this.mainToggle.Clear();
			this.tapApplyList.Clear();
			TAPNewDataManager.FindmasterIsSendServer = false;
		}

		// Token: 0x060117BB RID: 71611 RVA: 0x00514FB8 File Offset: 0x005133B8
		private void _UpdateUI()
		{
			for (int i = 0; i < this.tapApplyList.Count; i++)
			{
				this.tapApplyList[i].DestoryGo();
			}
			if (this.curTime * 4 >= this.searchList.Count)
			{
				this.curTime = 0;
			}
			int num = 20;
			if (this.searchList.Count == 0)
			{
				this.mTips.CustomActive(true);
			}
			else
			{
				this.mTips.CustomActive(false);
			}
			for (int j = this.curTime * 4; j < this.searchList.Count; j++)
			{
				PupilApplyItem pupilApplyItem = new PupilApplyItem(this.searchList[j], num);
				if (pupilApplyItem != null)
				{
					this.tapApplyList.Add(pupilApplyItem);
					Utility.AttachTo(pupilApplyItem.ThisGameObject, this.mRight, false);
				}
				num++;
			}
			this.curTime++;
		}

		// Token: 0x060117BC RID: 71612 RVA: 0x005150AD File Offset: 0x005134AD
		private void _ClearUI()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPApplyPupilFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TAPApplyPupilFrame>(null, false);
			}
		}

		// Token: 0x060117BD RID: 71613 RVA: 0x005150CB File Offset: 0x005134CB
		private void _Func2RedPointUpdate()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint())
			{
				this.mFunc2RedPoint.CustomActive(true);
			}
			else
			{
				this.mFunc2RedPoint.CustomActive(false);
			}
		}

		// Token: 0x060117BE RID: 71614 RVA: 0x005150FC File Offset: 0x005134FC
		private void _OnSearchedPupilListChanged(UIEvent uiEvent)
		{
			this.searchList.Clear();
			List<RelationData> list = new List<RelationData>();
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				list = DataManager<RelationDataManager>.GetInstance().SearchedPupilList;
				this.mName.text = "查找徒弟";
				this.mTabText1.text = "查找徒弟";
			}
			else
			{
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() != TAPType.Pupil)
				{
					return;
				}
				list = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
				this.mName.text = "查找师父";
				this.mTabText1.text = "查找师父";
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.searchList.Add(list[i]);
			}
			this._UpdateUI();
		}

		// Token: 0x060117BF RID: 71615 RVA: 0x005151CC File Offset: 0x005135CC
		private void _OnSearchedTeacherListChanged(UIEvent uiEvent)
		{
			this.searchList.Clear();
			List<RelationData> list = new List<RelationData>();
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				list = DataManager<RelationDataManager>.GetInstance().SearchedPupilList;
			}
			else
			{
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() != TAPType.Pupil)
				{
					return;
				}
				list = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.searchList.Add(list[i]);
			}
			this._UpdateUI();
		}

		// Token: 0x060117C0 RID: 71616 RVA: 0x0051525A File Offset: 0x0051365A
		private void _OnTAPApplyToggleRedPointUpdate(UIEvent uiEvent)
		{
			this._Func2RedPointUpdate();
		}

		// Token: 0x060117C1 RID: 71617 RVA: 0x00515264 File Offset: 0x00513664
		protected override void _bindExUI()
		{
			this.mBtnChangeAll = this.mBind.GetCom<Button>("BtnChangeAll");
			if (null != this.mBtnChangeAll)
			{
				this.mBtnChangeAll.onClick.AddListener(new UnityAction(this._onBtnChangeAllButtonClick));
			}
			this.mBtnAddAll = this.mBind.GetCom<Button>("BtnAddAll");
			if (null != this.mBtnAddAll)
			{
				this.mBtnAddAll.onClick.AddListener(new UnityAction(this._onBtnAddAllButtonClick));
			}
			this.mFunc1 = this.mBind.GetCom<Toggle>("Func1");
			if (null != this.mFunc1)
			{
				this.mFunc1.onValueChanged.AddListener(new UnityAction<bool>(this._onFunc1ToggleValueChange));
			}
			this.mFunc2 = this.mBind.GetCom<Toggle>("Func2");
			if (null != this.mFunc2)
			{
				this.mFunc2.onValueChanged.AddListener(new UnityAction<bool>(this._onFunc2ToggleValueChange));
			}
			this.mBtnSearch = this.mBind.GetCom<Button>("BtnSearch");
			if (null != this.mBtnSearch)
			{
				this.mBtnSearch.onClick.AddListener(new UnityAction(this._onBtnSearchButtonClick));
			}
			this.mRight = this.mBind.GetGameObject("Right");
			this.mChangeAllGray = this.mBind.GetCom<UIGray>("ChangeAllGray");
			this.mChangeAllText = this.mBind.GetCom<Text>("ChangeAllText");
			this.mAddAllGray = this.mBind.GetCom<UIGray>("AddAllGray");
			this.mInputField = this.mBind.GetCom<InputField>("InputField");
			this.mBtnOpenQuestionaire = this.mBind.GetCom<Button>("BtnOpenQuestionaire");
			if (null != this.mBtnOpenQuestionaire)
			{
				this.mBtnOpenQuestionaire.onClick.AddListener(new UnityAction(this._onBtnOpenQuestionaireButtonClick));
			}
			this.mBtnOpenApply = this.mBind.GetCom<Button>("BtnOpenApply");
			if (null != this.mBtnOpenApply)
			{
				this.mBtnOpenApply.onClick.AddListener(new UnityAction(this._onBtnOpenApplyButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mTips = this.mBind.GetGameObject("Tips");
			this.mSearchRoot = this.mBind.GetGameObject("SearchRoot");
			this.mApplyRoot = this.mBind.GetGameObject("ApplyRoot");
			this.mSetButtonCD = this.mBind.GetCom<SetButtonCD>("SetButtonCD");
			this.mTabText1 = this.mBind.GetCom<Text>("TabText1");
			this.mFunc2RedPoint = this.mBind.GetGameObject("RedPoint");
		}

		// Token: 0x060117C2 RID: 71618 RVA: 0x00515594 File Offset: 0x00513994
		protected override void _unbindExUI()
		{
			if (null != this.mBtnChangeAll)
			{
				this.mBtnChangeAll.onClick.RemoveListener(new UnityAction(this._onBtnChangeAllButtonClick));
			}
			this.mBtnChangeAll = null;
			if (null != this.mBtnAddAll)
			{
				this.mBtnAddAll.onClick.RemoveListener(new UnityAction(this._onBtnAddAllButtonClick));
			}
			this.mBtnAddAll = null;
			if (null != this.mFunc1)
			{
				this.mFunc1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onFunc1ToggleValueChange));
			}
			this.mFunc1 = null;
			if (null != this.mFunc2)
			{
				this.mFunc2.onValueChanged.RemoveListener(new UnityAction<bool>(this._onFunc2ToggleValueChange));
			}
			this.mFunc2 = null;
			if (null != this.mBtnSearch)
			{
				this.mBtnSearch.onClick.RemoveListener(new UnityAction(this._onBtnSearchButtonClick));
			}
			this.mBtnSearch = null;
			this.mRight = null;
			this.mChangeAllGray = null;
			this.mChangeAllText = null;
			this.mAddAllGray = null;
			this.mInputField = null;
			if (null != this.mBtnOpenQuestionaire)
			{
				this.mBtnOpenQuestionaire.onClick.RemoveListener(new UnityAction(this._onBtnOpenQuestionaireButtonClick));
			}
			this.mBtnOpenQuestionaire = null;
			if (null != this.mBtnOpenApply)
			{
				this.mBtnOpenApply.onClick.RemoveListener(new UnityAction(this._onBtnOpenApplyButtonClick));
			}
			this.mBtnOpenApply = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mName = null;
			this.mTips = null;
			this.mSearchRoot = null;
			this.mApplyRoot = null;
			this.mSetButtonCD = null;
			this.mTabText1 = null;
			this.mFunc2RedPoint = null;
		}

		// Token: 0x060117C3 RID: 71619 RVA: 0x00515798 File Offset: 0x00513B98
		private void _onBtnChangeAllButtonClick()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				DataManager<TAPNewDataManager>.GetInstance().SendChangeSearchedPupilList(RelationFindType.Disciple);
			}
			else if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
			{
				DataManager<TAPNewDataManager>.GetInstance().SendChangeSearchedPupilList(RelationFindType.Master);
			}
			this.mSetButtonCD.StartBtCD();
		}

		// Token: 0x060117C4 RID: 71620 RVA: 0x005157EC File Offset: 0x00513BEC
		private void _onBtnAddAllButtonClick()
		{
			this.bForceDisable = true;
			this.mAddAllGray.enabled = true;
			this.mBtnAddAll.enabled = false;
			List<RelationData> searchedTeacherList = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
			for (int i = 0; i < searchedTeacherList.Count; i++)
			{
				RelationData relationData = searchedTeacherList[i];
				if (relationData != null)
				{
					string name = relationData.name;
					ulong uid = relationData.uid;
					InvokeMethod.Invoke(this, (float)i * 0.2f, delegate()
					{
						DataManager<TAPDataManager>.GetInstance().AddQueryInfo(uid);
						DataManager<TAPDataManager>.GetInstance().SendApplyTeacher(uid);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAskTeacherMsgSended, uid, null, null, null);
					});
				}
			}
			InvokeMethod.Invoke(this, 0.2f * (float)searchedTeacherList.Count, delegate()
			{
				this.bForceDisable = false;
			});
		}

		// Token: 0x060117C5 RID: 71621 RVA: 0x005158A0 File Offset: 0x00513CA0
		private void _onBtnSearchButtonClick()
		{
			if (string.IsNullOrEmpty(this.mInputField.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_search_name_empty"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_bWaitSearchRet)
			{
				return;
			}
			this.m_bWaitSearchRet = true;
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
				this.m_bWaitSearchRet = false;
			});
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.name = this.mInputField.text;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_TEACHER;
			worldQueryPlayerReq.roleId = 0UL;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x060117C6 RID: 71622 RVA: 0x00515934 File Offset: 0x00513D34
		private void _onBtnOpenQuestionaireButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPQuestionnaireFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060117C7 RID: 71623 RVA: 0x00515948 File Offset: 0x00513D48
		private void _onBtnOpenApplyButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPApplyFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060117C8 RID: 71624 RVA: 0x0051595C File Offset: 0x00513D5C
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TAPSearchFrame>(this, false);
		}

		// Token: 0x060117C9 RID: 71625 RVA: 0x0051596B File Offset: 0x00513D6B
		private void _onFunc1ToggleValueChange(bool changed)
		{
			this.mSearchRoot.CustomActive(changed);
			this.mApplyRoot.CustomActive(!changed);
			if (changed)
			{
				this._UpdateUI();
			}
		}

		// Token: 0x060117CA RID: 71626 RVA: 0x00515994 File Offset: 0x00513D94
		private void _onFunc2ToggleValueChange(bool changed)
		{
			this.mSearchRoot.CustomActive(!changed);
			this.mApplyRoot.CustomActive(changed);
		}

		// Token: 0x0400B5B5 RID: 46517
		private int iChangeAllValue;

		// Token: 0x0400B5B6 RID: 46518
		private bool bForceDisable = true;

		// Token: 0x0400B5B7 RID: 46519
		private bool m_bWaitSearchRet;

		// Token: 0x0400B5B8 RID: 46520
		private List<RelationData> searchList = new List<RelationData>();

		// Token: 0x0400B5B9 RID: 46521
		private List<Toggle> mainToggle = new List<Toggle>();

		// Token: 0x0400B5BA RID: 46522
		private List<PupilApplyItem> tapApplyList = new List<PupilApplyItem>();

		// Token: 0x0400B5BB RID: 46523
		private const int peopleNum = 4;

		// Token: 0x0400B5BC RID: 46524
		private int curTime;

		// Token: 0x0400B5BD RID: 46525
		private int curToggleIndex;

		// Token: 0x0400B5BE RID: 46526
		private Button mBtnChangeAll;

		// Token: 0x0400B5BF RID: 46527
		private Button mBtnAddAll;

		// Token: 0x0400B5C0 RID: 46528
		private Toggle mFunc1;

		// Token: 0x0400B5C1 RID: 46529
		private Toggle mFunc2;

		// Token: 0x0400B5C2 RID: 46530
		private Button mBtnSearch;

		// Token: 0x0400B5C3 RID: 46531
		private GameObject mRight;

		// Token: 0x0400B5C4 RID: 46532
		private UIGray mChangeAllGray;

		// Token: 0x0400B5C5 RID: 46533
		private Text mChangeAllText;

		// Token: 0x0400B5C6 RID: 46534
		private UIGray mAddAllGray;

		// Token: 0x0400B5C7 RID: 46535
		private InputField mInputField;

		// Token: 0x0400B5C8 RID: 46536
		private Button mBtnOpenQuestionaire;

		// Token: 0x0400B5C9 RID: 46537
		private Button mBtnOpenApply;

		// Token: 0x0400B5CA RID: 46538
		private Button mClose;

		// Token: 0x0400B5CB RID: 46539
		private Text mName;

		// Token: 0x0400B5CC RID: 46540
		private GameObject mTips;

		// Token: 0x0400B5CD RID: 46541
		private GameObject mSearchRoot;

		// Token: 0x0400B5CE RID: 46542
		private GameObject mApplyRoot;

		// Token: 0x0400B5CF RID: 46543
		private SetButtonCD mSetButtonCD;

		// Token: 0x0400B5D0 RID: 46544
		private Text mTabText1;

		// Token: 0x0400B5D1 RID: 46545
		private GameObject mFunc2RedPoint;
	}
}
