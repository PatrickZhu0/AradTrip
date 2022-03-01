using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BD2 RID: 7122
	public class TAPFrame : ClientFrame
	{
		// Token: 0x060116EA RID: 71402 RVA: 0x0050E859 File Offset: 0x0050CC59
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPFrame";
		}

		// Token: 0x060116EB RID: 71403 RVA: 0x0050E860 File Offset: 0x0050CC60
		protected sealed override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this._InitData();
			this._InitUI();
		}

		// Token: 0x060116EC RID: 71404 RVA: 0x0050E874 File Offset: 0x0050CC74
		protected sealed override void _OnCloseFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPMissionFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TAPMissionFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPPublishMissionFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TAPPublishMissionFrame>(null, false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPLearningFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TAPLearningFrame>(null, false);
			}
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x060116ED RID: 71405 RVA: 0x0050E8E8 File Offset: 0x0050CCE8
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshClassmateDic, new ClientEventSystem.UIEventHandler(this._OnRefreshClassmate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPupilDataUpdate, new ClientEventSystem.UIEventHandler(this._OnPupilDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTeacherDataUpdate, new ClientEventSystem.UIEventHandler(this._OnTeacherDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReSelectTAPToggle, new ClientEventSystem.UIEventHandler(this._OnReSelectTAPToggle));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowPupilRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowTeacherRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPOpenSearchFrame, new ClientEventSystem.UIEventHandler(this._OnRefreshToggleRedPoint));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSwitchPupilSelect, new ClientEventSystem.UIEventHandler(this.SwitchPupilSelect));
		}

		// Token: 0x060116EE RID: 71406 RVA: 0x0050EA70 File Offset: 0x0050CE70
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshClassmateDic, new ClientEventSystem.UIEventHandler(this._OnRefreshClassmate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPupilDataUpdate, new ClientEventSystem.UIEventHandler(this._OnPupilDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTeacherDataUpdate, new ClientEventSystem.UIEventHandler(this._OnTeacherDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReSelectTAPToggle, new ClientEventSystem.UIEventHandler(this._OnReSelectTAPToggle));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowPupilRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowTeacherRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPApplyToggleRedPointUpdate, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPOpenSearchFrame, new ClientEventSystem.UIEventHandler(this._OnRefreshToggleRedPoint));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSwitchPupilSelect, new ClientEventSystem.UIEventHandler(this.SwitchPupilSelect));
		}

		// Token: 0x060116EF RID: 71407 RVA: 0x0050EBF8 File Offset: 0x0050CFF8
		private void _InitData()
		{
			this.haveInitMissionFrame = false;
			this.haveInitLearningFrame = false;
			this.haveTrueTeacher = false;
			this.teacherList.Clear();
			this.pupilList.Clear();
			this.classmateList.Clear();
			this.myRewardList.Clear();
			this.TAPToggleList.Clear();
			this.curPublishState = MasterDailyTaskState.MDTST_UNPUBLISHED;
			this.curRelationData = new RelationData();
			DataManager<TAPNewDataManager>.GetInstance().GetClassmateInformation();
		}

		// Token: 0x060116F0 RID: 71408 RVA: 0x0050EC70 File Offset: 0x0050D070
		private void _InitUI()
		{
			this.TAPToggleList.Add(this.mFunc1);
			this.TAPToggleList.Add(this.mFunc2);
			this.TAPToggleList.Add(this.mFunc3);
			this.mFunc1.isOn = true;
			this._UpdateTeacherPanel();
			this._UpdatePupilPanel();
			this._UpdateClassmatePanel();
			this._UpdatePublishFrame();
			this._UpdateToggleSelect();
			if (this.pupilList.Count == 0 && !this.haveTrueTeacher)
			{
				this.mCannotGo.CustomActive(true);
				this.mPeopleRoot.CustomActive(false);
				this.mRewardRoot.CustomActive(true);
				this.mFunc1RedPoint.CustomActive(false);
				if (DataManager<TAPDataManager>.GetInstance().CheckTapRedPointIsShow())
				{
					if (!DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP)
					{
						this.mFunc1RedPoint.CustomActive(true);
					}
					else
					{
						this.mFunc1RedPoint.CustomActive(false);
					}
				}
				this.mGoShop2.CustomActive(false);
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() >= TAPType.TeacherSoon)
				{
					this.mMiddleTeacher.CustomActive(true);
					this.mMiddlePupil.CustomActive(false);
					if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
					{
						this.mGoShop2.CustomActive(true);
					}
					else
					{
						this.mGoShop2.CustomActive(false);
					}
				}
				else
				{
					this.mMiddleTeacher.CustomActive(false);
					this.mMiddlePupil.CustomActive(true);
				}
				this._InitRewardUI();
			}
			else
			{
				this.mCannotGo.CustomActive(false);
				this.mPeopleRoot.CustomActive(true);
				this.mRewardRoot.CustomActive(false);
			}
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher && !this.haveTrueTeacher)
			{
				this.mGoShop.CustomActive(true);
				this.mPublishTime.text = DataManager<TAPNewDataManager>.GetInstance().getPublishTime(TAPType.Pupil);
			}
			else
			{
				this.mGoShop.CustomActive(false);
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
				{
					this.mPublishTime.text = DataManager<TAPNewDataManager>.GetInstance().getPublishTime(TAPType.Teacher);
				}
			}
			bool flag = DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint();
			if (flag)
			{
				this.mSearchBtnRedPoint.CustomActive(true);
			}
			else
			{
				this.mSearchBtnRedPoint.CustomActive(false);
			}
		}

		// Token: 0x060116F1 RID: 71409 RVA: 0x0050EEB0 File Offset: 0x0050D2B0
		private void _InitRewardUI()
		{
			this._InitComUIList();
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
			{
				this.mSearchPupil.CustomActive(false);
				this.mSearchTeacher.CustomActive(true);
				this.mTitleText.text = "我的师父";
				this.mTitleContentText.text = "暂无师父";
				this.myRewardList = DataManager<TAPNewDataManager>.GetInstance()._GetRewardList(7);
			}
			else
			{
				this.mSearchPupil.CustomActive(true);
				this.mSearchTeacher.CustomActive(false);
				this.mTitleText.text = "我的徒弟";
				this.mTitleContentText.text = "暂无徒弟";
				this.myRewardList = DataManager<TAPNewDataManager>.GetInstance()._GetRewardList(6);
			}
			if (this.myRewardList.Count != 0)
			{
				this.mRewardScrollView.SetElementAmount(this.myRewardList.Count);
			}
		}

		// Token: 0x060116F2 RID: 71410 RVA: 0x0050EF90 File Offset: 0x0050D390
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

		// Token: 0x060116F3 RID: 71411 RVA: 0x0050EFE8 File Offset: 0x0050D3E8
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
			int count = this.myRewardList[item.m_index].count;
			if (count > 10000 && count % 10000 == 0)
			{
				ItemDetailData.Count = 0;
				string tempStrCount = (count / 10000).ToString();
				comItem.SetCountFormatter((ComItem var) => tempStrCount + "万");
			}
			else
			{
				ItemDetailData.Count = this.myRewardList[item.m_index].count;
				comItem.SetCountFormatter(null);
			}
			comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(ItemDetailData);
			});
		}

		// Token: 0x060116F4 RID: 71412 RVA: 0x0050F134 File Offset: 0x0050D534
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x060116F5 RID: 71413 RVA: 0x0050F150 File Offset: 0x0050D550
		private void _ClearData()
		{
			this.haveInitMissionFrame = false;
			this.haveInitLearningFrame = false;
			this.haveTrueTeacher = false;
			this.teacherList.Clear();
			this.pupilList.Clear();
			this.classmateList.Clear();
			this.myRewardList.Clear();
			this.TAPToggleList.Clear();
			this.curRelationData = null;
			this.curPublishState = MasterDailyTaskState.MDTST_UNPUBLISHED;
		}

		// Token: 0x060116F6 RID: 71414 RVA: 0x0050F1B7 File Offset: 0x0050D5B7
		private void _ClearUI()
		{
		}

		// Token: 0x060116F7 RID: 71415 RVA: 0x0050F1BC File Offset: 0x0050D5BC
		private void _UpdateTeacherPanel()
		{
			for (int i = 0; i < this.teacherList.Count; i++)
			{
				this.teacherList[i].DestoryGo();
			}
			this.teacherList.Clear();
			RelationData teacher = DataManager<RelationDataManager>.GetInstance().GetTeacher();
			if (teacher != null)
			{
				this._AddTeacher(teacher, true);
				this.haveTrueTeacher = true;
			}
			else
			{
				this.haveTrueTeacher = false;
				this._AddTeacher(new RelationData
				{
					name = DataManager<PlayerBaseData>.GetInstance().Name,
					occu = (byte)DataManager<PlayerBaseData>.GetInstance().JobTableID,
					headFrame = (uint)HeadPortraitFrameDataManager.WearHeadPortraitFrameID
				}, false);
			}
		}

		// Token: 0x060116F8 RID: 71416 RVA: 0x0050F268 File Offset: 0x0050D668
		private void _AddTeacher(RelationData relationData, bool haveTeacher)
		{
			TeacherItem teacherItem = new TeacherItem(relationData, haveTeacher, this.mMyPupilRoot);
			this.teacherList.Add(teacherItem);
			if (teacherItem.ThisGameObject != null)
			{
				Utility.AttachTo(teacherItem.ThisGameObject, this.mMyTeacherRoot, false);
			}
		}

		// Token: 0x060116F9 RID: 71417 RVA: 0x0050F2B4 File Offset: 0x0050D6B4
		private void _UpdatePupilPanel()
		{
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			for (int i = 0; i < this.pupilList.Count; i++)
			{
				if (i >= relation.Count)
				{
					this.pupilList[i].DestoryGo();
					this.pupilList.RemoveAt(i);
				}
			}
			for (int j = 0; j < relation.Count; j++)
			{
				if (j < this.pupilList.Count)
				{
					this.pupilList[j].UpdateUI(relation[j]);
				}
				else
				{
					this._AddPupil(relation[j]);
				}
			}
			if (relation.Count == 0)
			{
				this.mMyPupilRoot.CustomActive(false);
			}
			else
			{
				this.mMyPupilRoot.CustomActive(true);
			}
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher && relation.Count < 2 && !this.haveTrueTeacher)
			{
				this.mSearchFriendGo.CustomActive(true);
			}
			else
			{
				this.mSearchFriendGo.CustomActive(false);
			}
		}

		// Token: 0x060116FA RID: 71418 RVA: 0x0050F3D8 File Offset: 0x0050D7D8
		private void _AddPupil(RelationData relationData)
		{
			PupilItem pupilItem = new PupilItem(relationData, this.mMyPupilRoot);
			this.pupilList.Add(pupilItem);
			if (pupilItem.ThisGameObject != null)
			{
				Utility.AttachTo(pupilItem.ThisGameObject, this.mMyPupilRoot, false);
			}
		}

		// Token: 0x060116FB RID: 71419 RVA: 0x0050F424 File Offset: 0x0050D824
		private void _UpdatePublishFrame()
		{
			if (this.pupilList.Count == 0 && !this.haveTrueTeacher)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPPublishMissionFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPPublishMissionFrame>(this.mPublishMission, null, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateTAPPublishFrame, null, null, null, null);
				}
			}
		}

		// Token: 0x060116FC RID: 71420 RVA: 0x0050F48C File Offset: 0x0050D88C
		private void _UpdateToggleSelect()
		{
			if (this.haveTrueTeacher)
			{
				this.teacherList[0].SetToggleSelect();
				this.teacherList[0].UpdateSelect();
			}
			else if (this.pupilList.Count > 0)
			{
				bool flag = false;
				for (int i = 0; i < this.pupilList.Count; i++)
				{
					if (this.pupilList[i].GetUid() == this.curRelationData.uid)
					{
						this.pupilList[i].SetToggleSelect();
						this.pupilList[i].UpdateSelect();
						flag = true;
					}
				}
				if (!flag)
				{
					this.pupilList[0].SetToggleSelect();
					this.pupilList[0].UpdateSelect();
				}
			}
			if (!this.haveTrueTeacher && this.pupilList.Count == 0)
			{
				this.mPublishMission.CustomActive(true);
				this.mMissionRoot.CustomActive(false);
				this.mLearningRoot.CustomActive(false);
			}
		}

		// Token: 0x060116FD RID: 71421 RVA: 0x0050F5A8 File Offset: 0x0050D9A8
		private void _UpdateClassmatePanel()
		{
			for (int i = 0; i < this.classmateList.Count; i++)
			{
				this.classmateList[i].DestoryGo();
			}
			this.classmateList.Clear();
			Dictionary<ulong, ClassmateRelationData> classmateRelationDic = DataManager<TAPNewDataManager>.GetInstance().GetClassmateRelationDic();
			foreach (KeyValuePair<ulong, ClassmateRelationData> keyValuePair in classmateRelationDic)
			{
				if (keyValuePair.Value.level != 0 && keyValuePair.Value.isFinSch == 0)
				{
					this._AddClassmate(keyValuePair.Value);
				}
			}
			if (this.classmateList.Count == 0)
			{
				this.mMyClassmatesRoot.CustomActive(false);
			}
			else
			{
				this.mMyClassmatesRoot.CustomActive(true);
			}
		}

		// Token: 0x060116FE RID: 71422 RVA: 0x0050F698 File Offset: 0x0050DA98
		private void _AddClassmate(ClassmateRelationData relationData)
		{
			ClassmateItem classmateItem = new ClassmateItem(relationData);
			this.classmateList.Add(classmateItem);
			if (classmateItem.ThisGameObject != null)
			{
				Utility.AttachTo(classmateItem.ThisGameObject, this.mMyClassmatesRoot, false);
			}
		}

		// Token: 0x060116FF RID: 71423 RVA: 0x0050F6DB File Offset: 0x0050DADB
		private void _OnRefreshClassmate(UIEvent uiEvent)
		{
			this._UpdateClassmatePanel();
		}

		// Token: 0x06011700 RID: 71424 RVA: 0x0050F6E4 File Offset: 0x0050DAE4
		private void SwitchPupilSelect(UIEvent uiEvent)
		{
			RelationData relationData = null;
			if (uiEvent != null)
			{
				relationData = (uiEvent.Param1 as RelationData);
			}
			if (relationData != null)
			{
				this.curRelationData = relationData;
				this._OnRelationChanged(null);
			}
		}

		// Token: 0x06011701 RID: 71425 RVA: 0x0050F71C File Offset: 0x0050DB1C
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			this._UpdateTeacherPanel();
			this._UpdatePupilPanel();
			this._UpdatePublishFrame();
			this._UpdateToggleSelect();
			if (this.pupilList.Count == 0 && !this.haveTrueTeacher)
			{
				this.mCannotGo.CustomActive(true);
				this.mPeopleRoot.CustomActive(false);
				this.mRewardRoot.CustomActive(true);
				this.mFunc1RedPoint.CustomActive(false);
				if (DataManager<TAPDataManager>.GetInstance().CheckTapRedPointIsShow())
				{
					if (!DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP)
					{
						this.mFunc1RedPoint.CustomActive(true);
					}
					else
					{
						this.mFunc1RedPoint.CustomActive(false);
					}
				}
				if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() >= TAPType.TeacherSoon)
				{
					this.mMiddleTeacher.CustomActive(true);
					this.mMiddlePupil.CustomActive(false);
					this.mGoShop2.CustomActive(false);
					if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
					{
						this.mGoShop2.CustomActive(true);
					}
					else
					{
						this.mGoShop2.CustomActive(false);
					}
				}
				else
				{
					this.mMiddleTeacher.CustomActive(false);
					this.mMiddlePupil.CustomActive(true);
				}
				this._InitRewardUI();
			}
			else
			{
				this.mCannotGo.CustomActive(false);
				this.mPeopleRoot.CustomActive(true);
				this.mRewardRoot.CustomActive(false);
			}
		}

		// Token: 0x06011702 RID: 71426 RVA: 0x0050F874 File Offset: 0x0050DC74
		private void _OnPupilDataUpdate(UIEvent uiEvent)
		{
			this.mPublishMission.CustomActive(false);
			this.mMissionRoot.CustomActive(false);
			this.mLearningRoot.CustomActive(false);
			RelationData relationData = (RelationData)uiEvent.Param1;
			if (DataManager<TAPNewDataManager>.GetInstance().HaveTAPDailyRedPointForID(relationData.uid))
			{
				this.mFunc1RedPoint.CustomActive(true);
			}
			else
			{
				this.mFunc1RedPoint.CustomActive(false);
			}
			this.curRelationData = relationData;
			this.mTimeTips.text = string.Format("你们在{0}成为师徒", Function.GetOneData((int)relationData.createTime));
			this.curPublishState = (MasterDailyTaskState)relationData.dailyTaskState;
			if (relationData.dailyTaskState == 0)
			{
				if (this.TAPToggleList[0].isOn)
				{
					this.mPublishMission.CustomActive(true);
				}
				else
				{
					this.mLearningRoot.CustomActive(true);
				}
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPPublishMissionFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPPublishMissionFrame>(this.mPublishMission, relationData, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateTAPPublishFrame, relationData, null, null, null);
				}
			}
			else if (this.TAPToggleList[0].isOn)
			{
				this.mMissionRoot.CustomActive(true);
			}
			else
			{
				this.mLearningRoot.CustomActive(true);
			}
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPMissionFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<TAPMissionFrame>(this.mMissionRoot, relationData, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMyPupilMissionUpdate, relationData, null, null, null);
			}
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPLearningFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<TAPLearningFrame>(this.mLearningRoot, relationData, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPLearningUpdate, relationData, null, null, null);
			}
		}

		// Token: 0x06011703 RID: 71427 RVA: 0x0050FA4C File Offset: 0x0050DE4C
		private void _OnTeacherDataUpdate(UIEvent uiEvent)
		{
			this.mPublishMission.CustomActive(false);
			this.mMissionRoot.CustomActive(false);
			this.mLearningRoot.CustomActive(false);
			RelationData relationData = (RelationData)uiEvent.Param1;
			if (DataManager<TAPNewDataManager>.GetInstance().HaveTAPDailyRedPointForID(relationData.uid))
			{
				this.mFunc1RedPoint.CustomActive(true);
			}
			else
			{
				this.mFunc1RedPoint.CustomActive(false);
			}
			this.curRelationData = relationData;
			this.mTimeTips.text = string.Format("你们在{0}成为师徒", Function.GetOneData((int)relationData.createTime));
			this.curPublishState = (MasterDailyTaskState)relationData.dailyTaskState;
			if (relationData.dailyTaskState == 0)
			{
				if (this.TAPToggleList[0].isOn)
				{
					this.mPublishMission.CustomActive(true);
				}
				else
				{
					this.mLearningRoot.CustomActive(true);
				}
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPPublishMissionFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPPublishMissionFrame>(this.mPublishMission, relationData, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateTAPPublishFrame, relationData, null, null, null);
				}
			}
			else if (this.TAPToggleList[0].isOn)
			{
				this.mMissionRoot.CustomActive(true);
			}
			else
			{
				this.mLearningRoot.CustomActive(true);
			}
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPMissionFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<TAPMissionFrame>(this.mMissionRoot, relationData, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMyPupilMissionUpdate, relationData, null, null, null);
			}
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TAPLearningFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<TAPLearningFrame>(this.mLearningRoot, relationData, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPLearningUpdate, relationData, null, null, null);
			}
		}

		// Token: 0x06011704 RID: 71428 RVA: 0x0050FC24 File Offset: 0x0050E024
		private void _OnReSelectTAPToggle(UIEvent uiEvent)
		{
			int num = (int)uiEvent.Param1;
			if (this.TAPToggleList.Count > num)
			{
				this.TAPToggleList[num].isOn = true;
			}
		}

		// Token: 0x06011705 RID: 71429 RVA: 0x0050FC60 File Offset: 0x0050E060
		protected void _OnShowPupilRealMenu(UIEvent uiEvent)
		{
			RelationMenuData userData = uiEvent.Param1 as RelationMenuData;
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			this.m_openMenu = this.frameMgr.OpenFrame<RelationMenuFram>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x06011706 RID: 71430 RVA: 0x0050FCAF File Offset: 0x0050E0AF
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x06011707 RID: 71431 RVA: 0x0050FCD8 File Offset: 0x0050E0D8
		private void _OnRefreshInviteList(UIEvent uiEvent)
		{
			bool flag = DataManager<TAPNewDataManager>.GetInstance().HaveApplyRedPoint();
			if (flag)
			{
				this.mSearchBtnRedPoint.CustomActive(true);
			}
			else
			{
				this.mSearchBtnRedPoint.CustomActive(false);
			}
		}

		// Token: 0x06011708 RID: 71432 RVA: 0x0050FD13 File Offset: 0x0050E113
		private void _OnRefreshToggleRedPoint(UIEvent uiEvent)
		{
			if (!DataManager<TAPNewDataManager>.GetInstance().HaveSearchTAP)
			{
				this.mFunc1RedPoint.CustomActive(true);
			}
			else
			{
				this.mFunc1RedPoint.CustomActive(false);
			}
		}

		// Token: 0x06011709 RID: 71433 RVA: 0x0050FD44 File Offset: 0x0050E144
		protected override void _bindExUI()
		{
			this.mMyTeacherRoot = this.mBind.GetGameObject("MyTeacherRoot");
			this.mMyClassmatesRoot = this.mBind.GetGameObject("MyClassmatesRoot");
			this.mMyPupilRoot = this.mBind.GetGameObject("MyPupilRoot");
			this.mSearchFriendGo = this.mBind.GetGameObject("SearchFriendGo");
			this.mSearchPupilBt = this.mBind.GetCom<Button>("SearchPupilBt");
			if (null != this.mSearchPupilBt)
			{
				this.mSearchPupilBt.onClick.AddListener(new UnityAction(this._onSearchPupilBtButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
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
			this.mFunc3 = this.mBind.GetCom<Toggle>("Func3");
			if (null != this.mFunc3)
			{
				this.mFunc3.onValueChanged.AddListener(new UnityAction<bool>(this._onFunc3ToggleValueChange));
			}
			this.mMissionRoot = this.mBind.GetGameObject("MissionRoot");
			this.mLearningRoot = this.mBind.GetGameObject("LearningRoot");
			this.mPublishMission = this.mBind.GetGameObject("PublishMission");
			this.mRewardRoot = this.mBind.GetGameObject("RewardRoot");
			this.mPeopleRoot = this.mBind.GetGameObject("PeopleRoot");
			this.mTitleText = this.mBind.GetCom<Text>("TitleText");
			this.mTitleContentText = this.mBind.GetCom<Text>("TitleContentText");
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
			this.mSetInformation = this.mBind.GetCom<Button>("SetInformation");
			if (null != this.mSetInformation)
			{
				this.mSetInformation.onClick.AddListener(new UnityAction(this._onSetInformationButtonClick));
			}
			this.mRewardScrollView = this.mBind.GetCom<ComUIListScript>("RewardScrollView");
			this.mGoShop = this.mBind.GetCom<Button>("GoShop");
			if (null != this.mGoShop)
			{
				this.mGoShop.onClick.AddListener(new UnityAction(this._onGoShopButtonClick));
			}
			this.mSetInformation2 = this.mBind.GetCom<Button>("SetInformation2");
			if (null != this.mSetInformation2)
			{
				this.mSetInformation2.onClick.AddListener(new UnityAction(this._onSetInformation2ButtonClick));
			}
			this.mCannotGo = this.mBind.GetCom<Button>("cannotGo");
			if (null != this.mCannotGo)
			{
				this.mCannotGo.onClick.AddListener(new UnityAction(this._onCannotGoButtonClick));
			}
			this.mPublishTime = this.mBind.GetCom<Text>("publishTime");
			this.mTimeTips = this.mBind.GetCom<Text>("TimeTips");
			this.mMiddleTeacher = this.mBind.GetGameObject("MiddleTeacher");
			this.mMiddlePupil = this.mBind.GetGameObject("MiddlePupil");
			this.mGoShop2 = this.mBind.GetCom<Button>("GoShop2");
			if (null != this.mGoShop2)
			{
				this.mGoShop2.onClick.AddListener(new UnityAction(this._onGoShop2ButtonClick));
			}
			this.mFunc1RedPoint = this.mBind.GetGameObject("Func1RedPoint");
			this.mSearchBtnRedPoint = this.mBind.GetGameObject("SearchBtnRedPoint");
		}

		// Token: 0x0601170A RID: 71434 RVA: 0x00510204 File Offset: 0x0050E604
		protected override void _unbindExUI()
		{
			this.mMyTeacherRoot = null;
			this.mMyClassmatesRoot = null;
			this.mMyPupilRoot = null;
			this.mSearchFriendGo = null;
			if (null != this.mSearchPupilBt)
			{
				this.mSearchPupilBt.onClick.RemoveListener(new UnityAction(this._onSearchPupilBtButtonClick));
			}
			this.mSearchPupilBt = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
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
			if (null != this.mFunc3)
			{
				this.mFunc3.onValueChanged.RemoveListener(new UnityAction<bool>(this._onFunc3ToggleValueChange));
			}
			this.mFunc3 = null;
			this.mMissionRoot = null;
			this.mLearningRoot = null;
			this.mPublishMission = null;
			this.mRewardRoot = null;
			this.mPeopleRoot = null;
			this.mTitleText = null;
			this.mTitleContentText = null;
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
			if (null != this.mSetInformation)
			{
				this.mSetInformation.onClick.RemoveListener(new UnityAction(this._onSetInformationButtonClick));
			}
			this.mSetInformation = null;
			this.mRewardScrollView = null;
			if (null != this.mGoShop)
			{
				this.mGoShop.onClick.RemoveListener(new UnityAction(this._onGoShopButtonClick));
			}
			this.mGoShop = null;
			if (null != this.mSetInformation2)
			{
				this.mSetInformation2.onClick.RemoveListener(new UnityAction(this._onSetInformation2ButtonClick));
			}
			this.mSetInformation2 = null;
			if (null != this.mCannotGo)
			{
				this.mCannotGo.onClick.RemoveListener(new UnityAction(this._onCannotGoButtonClick));
			}
			this.mCannotGo = null;
			this.mPublishTime = null;
			this.mTimeTips = null;
			this.mMiddleTeacher = null;
			this.mMiddlePupil = null;
			if (null != this.mGoShop2)
			{
				this.mGoShop2.onClick.RemoveListener(new UnityAction(this._onGoShop2ButtonClick));
			}
			this.mGoShop2 = null;
			this.mFunc1RedPoint = null;
			this.mSearchBtnRedPoint = null;
		}

		// Token: 0x0601170B RID: 71435 RVA: 0x005104FF File Offset: 0x0050E8FF
		private void _onSearchPupilBtButtonClick()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x0601170C RID: 71436 RVA: 0x0051053E File Offset: 0x0050E93E
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TAPFrame>(this, false);
		}

		// Token: 0x0601170D RID: 71437 RVA: 0x00510550 File Offset: 0x0050E950
		private void _onFunc1ToggleValueChange(bool changed)
		{
			if (this.curPublishState == MasterDailyTaskState.MDTST_UNPUBLISHED)
			{
				if (changed)
				{
					this.mPublishMission.CustomActive(true);
					this.mMissionRoot.CustomActive(false);
				}
				else
				{
					this.mPublishMission.CustomActive(false);
					this.mMissionRoot.CustomActive(false);
				}
			}
			else if (changed)
			{
				this.mPublishMission.CustomActive(false);
				this.mMissionRoot.CustomActive(true);
			}
			else
			{
				this.mPublishMission.CustomActive(false);
				this.mMissionRoot.CustomActive(false);
			}
		}

		// Token: 0x0601170E RID: 71438 RVA: 0x005105E3 File Offset: 0x0050E9E3
		private void _onFunc2ToggleValueChange(bool changed)
		{
			this.mLearningRoot.CustomActive(changed);
		}

		// Token: 0x0601170F RID: 71439 RVA: 0x005105F1 File Offset: 0x0050E9F1
		private void _onFunc3ToggleValueChange(bool changed)
		{
		}

		// Token: 0x06011710 RID: 71440 RVA: 0x005105F3 File Offset: 0x0050E9F3
		private void _onSearchTeacherButtonClick()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x06011711 RID: 71441 RVA: 0x00510632 File Offset: 0x0050EA32
		private void _onSearchPupilButtonClick()
		{
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.TeacherSoon)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_searchFrame"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSearchFrame>(FrameLayer.Middle, 0, string.Empty);
			}
		}

		// Token: 0x06011712 RID: 71442 RVA: 0x00510671 File Offset: 0x0050EA71
		private void _onSetInformationButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPQuestionnaireFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06011713 RID: 71443 RVA: 0x00510685 File Offset: 0x0050EA85
		private void _onGoShopButtonClick()
		{
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(20, 0, 0, -1);
		}

		// Token: 0x06011714 RID: 71444 RVA: 0x00510698 File Offset: 0x0050EA98
		private void _onSetInformation2ButtonClick()
		{
			if (this.haveTrueTeacher)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_haveteacher_cannot_go_questionframe"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (!DataManager<TAPNewDataManager>.GetInstance().canSearchPupil())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_havepupil_cannot_go_questionframe"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPQuestionnaireFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x06011715 RID: 71445 RVA: 0x005106FD File Offset: 0x0050EAFD
		private void _onCannotGoButtonClick()
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("tap_cannot_enter_graduation"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x06011716 RID: 71446 RVA: 0x00510710 File Offset: 0x0050EB10
		private void _onGoShop2ButtonClick()
		{
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(20, 0, 0, -1);
		}

		// Token: 0x0400B4FD RID: 46333
		private bool haveInitMissionFrame;

		// Token: 0x0400B4FE RID: 46334
		private bool haveInitLearningFrame;

		// Token: 0x0400B4FF RID: 46335
		private bool haveTrueTeacher;

		// Token: 0x0400B500 RID: 46336
		private List<PupilItem> pupilList = new List<PupilItem>();

		// Token: 0x0400B501 RID: 46337
		private List<TeacherItem> teacherList = new List<TeacherItem>();

		// Token: 0x0400B502 RID: 46338
		private List<ClassmateItem> classmateList = new List<ClassmateItem>();

		// Token: 0x0400B503 RID: 46339
		private List<TAPMissionReward> myRewardList = new List<TAPMissionReward>();

		// Token: 0x0400B504 RID: 46340
		private List<Toggle> TAPToggleList = new List<Toggle>();

		// Token: 0x0400B505 RID: 46341
		private MasterDailyTaskState curPublishState;

		// Token: 0x0400B506 RID: 46342
		private RelationData curRelationData = new RelationData();

		// Token: 0x0400B507 RID: 46343
		private const string TAPMissionFramePath = "UIFlatten/Prefabs/TAP/TAPMissionFrame";

		// Token: 0x0400B508 RID: 46344
		private IClientFrame m_openMenu;

		// Token: 0x0400B509 RID: 46345
		private GameObject mMyTeacherRoot;

		// Token: 0x0400B50A RID: 46346
		private GameObject mMyClassmatesRoot;

		// Token: 0x0400B50B RID: 46347
		private GameObject mMyPupilRoot;

		// Token: 0x0400B50C RID: 46348
		private GameObject mSearchFriendGo;

		// Token: 0x0400B50D RID: 46349
		private Button mSearchPupilBt;

		// Token: 0x0400B50E RID: 46350
		private Button mClose;

		// Token: 0x0400B50F RID: 46351
		private Toggle mFunc1;

		// Token: 0x0400B510 RID: 46352
		private Toggle mFunc2;

		// Token: 0x0400B511 RID: 46353
		private Toggle mFunc3;

		// Token: 0x0400B512 RID: 46354
		private GameObject mMissionRoot;

		// Token: 0x0400B513 RID: 46355
		private GameObject mLearningRoot;

		// Token: 0x0400B514 RID: 46356
		private GameObject mPublishMission;

		// Token: 0x0400B515 RID: 46357
		private GameObject mRewardRoot;

		// Token: 0x0400B516 RID: 46358
		private GameObject mPeopleRoot;

		// Token: 0x0400B517 RID: 46359
		private Text mTitleText;

		// Token: 0x0400B518 RID: 46360
		private Text mTitleContentText;

		// Token: 0x0400B519 RID: 46361
		private Button mSearchTeacher;

		// Token: 0x0400B51A RID: 46362
		private Button mSearchPupil;

		// Token: 0x0400B51B RID: 46363
		private Button mSetInformation;

		// Token: 0x0400B51C RID: 46364
		private ComUIListScript mRewardScrollView;

		// Token: 0x0400B51D RID: 46365
		private Button mGoShop;

		// Token: 0x0400B51E RID: 46366
		private Button mSetInformation2;

		// Token: 0x0400B51F RID: 46367
		private Button mCannotGo;

		// Token: 0x0400B520 RID: 46368
		private Text mPublishTime;

		// Token: 0x0400B521 RID: 46369
		private Text mTimeTips;

		// Token: 0x0400B522 RID: 46370
		private GameObject mMiddleTeacher;

		// Token: 0x0400B523 RID: 46371
		private GameObject mMiddlePupil;

		// Token: 0x0400B524 RID: 46372
		private Button mGoShop2;

		// Token: 0x0400B525 RID: 46373
		private GameObject mFunc1RedPoint;

		// Token: 0x0400B526 RID: 46374
		private GameObject mSearchBtnRedPoint;
	}
}
