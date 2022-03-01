using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BED RID: 7149
	internal class TAPRelationInfoFrame : ClientFrame
	{
		// Token: 0x06011859 RID: 71769 RVA: 0x00518FFD File Offset: 0x005173FD
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAPSystem/TAPRelationInfoFrame";
		}

		// Token: 0x0601185A RID: 71770 RVA: 0x00519004 File Offset: 0x00517404
		private void _Init()
		{
			if (null != this.tapOpenLevel)
			{
				this.tapOpenLevel.text = TR.Value("tap_open_level_desc", DataManager<TAPDataManager>.GetInstance().teacherMinLevel);
			}
			base._AddButton("Friends/TeacherPanel/BtnSearchTeacher", new UnityAction(DataManager<TAPDataManager>.GetInstance().OpenSearchTeacherFrame));
			base._AddButton("Friends/PupilPanel/BtnApplyList", new UnityAction(DataManager<TAPDataManager>.GetInstance().OpenApplyPupilFrame));
			base._AddButton("Friends/PupilPanel/BtnSearch", new UnityAction(DataManager<TAPDataManager>.GetInstance().OpenSearchPupilFrame));
			this.comPupilList.Initialize();
			this.comPupilList.onBindItem = ((GameObject go) => go.GetComponent<ComTAPPupilInfo>());
			this.comPupilList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				if (relation != null && null != item && item.m_index >= 0 && item.m_index < relation.Count)
				{
					ComTAPPupilInfo comTAPPupilInfo = item.gameObjectBindScript as ComTAPPupilInfo;
					if (null != comTAPPupilInfo)
					{
						comTAPPupilInfo.SetValue(relation[item.m_index]);
					}
				}
			};
		}

		// Token: 0x0601185B RID: 71771 RVA: 0x005190F4 File Offset: 0x005174F4
		private void _UpdatePupilCount()
		{
			if (null != this.pupilCount)
			{
				int num = 0;
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				if (relation != null)
				{
					num = relation.Count;
				}
				this.pupilCount.text = TR.Value("tap_puipls_count", num, DataManager<TAPDataManager>.GetInstance().pupilMaxCount);
			}
		}

		// Token: 0x0601185C RID: 71772 RVA: 0x00519158 File Offset: 0x00517558
		private void _RegisterEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowPupilRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowTeacherRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x0601185D RID: 71773 RVA: 0x005191F8 File Offset: 0x005175F8
		private void _UnRegisterEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowPupilRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowTeacherRealMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilRealMenu));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x0601185E RID: 71774 RVA: 0x00519298 File Offset: 0x00517698
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			RelationData relationData = uiEvent.Param1 as RelationData;
			bool flag = (bool)uiEvent.Param2;
			this._UpdateTeacherPanel();
			this._UpdatePupilPanel();
		}

		// Token: 0x0601185F RID: 71775 RVA: 0x005192CC File Offset: 0x005176CC
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

		// Token: 0x06011860 RID: 71776 RVA: 0x0051931B File Offset: 0x0051771B
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x06011861 RID: 71777 RVA: 0x00519341 File Offset: 0x00517741
		private void _OnLevelChanged(int iPre, int iCur)
		{
			this._UpdatePupilPanel();
		}

		// Token: 0x06011862 RID: 71778 RVA: 0x0051934C File Offset: 0x0051774C
		private void _UpdateTeacherPanel()
		{
			if (null != this.comTeacherController)
			{
				if (DataManager<RelationDataManager>.GetInstance().HasTeacher())
				{
					this.comTeacherController.Key = this.state_has_teacher;
					if (null != this.comTapTeacher)
					{
						this.comTapTeacher.SetValue(DataManager<RelationDataManager>.GetInstance().GetTeacher());
					}
				}
				else
				{
					this.comTeacherController.Key = this.state_has_no_teacher;
				}
			}
		}

		// Token: 0x06011863 RID: 71779 RVA: 0x005193C8 File Offset: 0x005177C8
		private void _UpdatePupilPanel()
		{
			if (null != this.comTeacherController)
			{
				if (!DataManager<TAPDataManager>.GetInstance().canGetpupil)
				{
					this.comPupilController.Key = this.state_locked;
				}
				else if (!DataManager<TAPDataManager>.GetInstance().hasPupil)
				{
					this.comPupilController.Key = this.state_no_pupil;
				}
				else if (DataManager<TAPDataManager>.GetInstance().isPupilFull)
				{
					this.comPupilController.Key = this.state_has_pupil_full;
				}
				else
				{
					this.comPupilController.Key = this.state_has_pupil_not_full;
				}
			}
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			if (null != this.comPupilList)
			{
				if (relation == null)
				{
					this.comPupilList.SetElementAmount(0);
				}
				else
				{
					this.comPupilList.SetElementAmount(relation.Count);
				}
			}
			this._UpdatePupilCount();
		}

		// Token: 0x06011864 RID: 71780 RVA: 0x005194B1 File Offset: 0x005178B1
		protected override void _OnOpenFrame()
		{
			this._Init();
			this._RegisterEvent();
			this._UpdateTeacherPanel();
			this._UpdatePupilPanel();
		}

		// Token: 0x06011865 RID: 71781 RVA: 0x005194CC File Offset: 0x005178CC
		protected override void _OnCloseFrame()
		{
			this._UnRegisterEvent();
			if (null != this.comPupilList)
			{
				this.comPupilList.onBindItem = null;
				this.comPupilList.onItemVisiable = null;
				this.comPupilList = null;
			}
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x0400B644 RID: 46660
		[UIControl("Friends/TeacherPanel", typeof(StateController), 0)]
		private StateController comTeacherController;

		// Token: 0x0400B645 RID: 46661
		[UIControl("Friends/PupilPanel", typeof(StateController), 0)]
		private StateController comPupilController;

		// Token: 0x0400B646 RID: 46662
		[UIControl("Friends/PupilPanel/OpenLevel", typeof(Text), 0)]
		private Text tapOpenLevel;

		// Token: 0x0400B647 RID: 46663
		[UIControl("Friends/TeacherPanel/TeacherInfo", typeof(ComTAPRelation), 0)]
		private ComTAPRelation comTapTeacher;

		// Token: 0x0400B648 RID: 46664
		[UIControl("Friends/PupilPanel/Text", typeof(Text), 0)]
		private Text pupilCount;

		// Token: 0x0400B649 RID: 46665
		private string state_has_teacher = "has_teacher";

		// Token: 0x0400B64A RID: 46666
		private string state_has_no_teacher = "has_no_teacher";

		// Token: 0x0400B64B RID: 46667
		private string state_locked = "locked";

		// Token: 0x0400B64C RID: 46668
		private string state_no_pupil = "no_pupil";

		// Token: 0x0400B64D RID: 46669
		private string state_has_pupil_not_full = "has_pupil_not_full";

		// Token: 0x0400B64E RID: 46670
		private string state_has_pupil_full = "has_pupil_full";

		// Token: 0x0400B64F RID: 46671
		[UIControl("Friends/PupilPanel", typeof(ComUIListScript), 0)]
		private ComUIListScript comPupilList;

		// Token: 0x0400B650 RID: 46672
		private IClientFrame m_openMenu;
	}
}
