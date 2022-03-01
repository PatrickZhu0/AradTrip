using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BEA RID: 7146
	internal class TAPApplyPupilFrame : ClientFrame
	{
		// Token: 0x0601183E RID: 71742 RVA: 0x0051865C File Offset: 0x00516A5C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAPSystem/TAPApplyPupilFrame";
		}

		// Token: 0x0601183F RID: 71743 RVA: 0x00518664 File Offset: 0x00516A64
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<TAPApplyPupilFrame>(this, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyPupilListChanged, null, null, null, null);
			});
			base._AddButton("Root/BtnClearAll", new UnityAction(this._ClearAll));
			this.comPupilApplyList.Initialize();
			this.comPupilApplyList.onBindItem = delegate(GameObject go)
			{
				if (null != go)
				{
					return go.GetComponent<ComApplyPupilInfo>();
				}
				return null;
			};
			this.comPupilApplyList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (null != item)
				{
					ComApplyPupilInfo comApplyPupilInfo = item.gameObjectBindScript as ComApplyPupilInfo;
					if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
					{
						List<RelationData> applyPupils = DataManager<RelationDataManager>.GetInstance().ApplyPupils;
						if (null != comApplyPupilInfo && item.m_index >= 0 && item.m_index < applyPupils.Count)
						{
							comApplyPupilInfo.OnItemVisible(applyPupils[item.m_index]);
						}
					}
					else if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
					{
						List<RelationData> applyTeachers = DataManager<RelationDataManager>.GetInstance().ApplyTeachers;
						if (null != comApplyPupilInfo && item.m_index >= 0 && item.m_index < applyTeachers.Count)
						{
							comApplyPupilInfo.OnItemVisible(applyTeachers[item.m_index]);
						}
					}
				}
			};
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnApplyPupilListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnApplyTeacherListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowPupilApplyMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilApplyMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			DataManager<RelationDataManager>.GetInstance().RemoveApplyPupilNotify();
			this._updateData();
		}

		// Token: 0x06011840 RID: 71744 RVA: 0x00518776 File Offset: 0x00516B76
		private void _OnApplyPupilListChanged(UIEvent uiEvent)
		{
			this._updateData();
		}

		// Token: 0x06011841 RID: 71745 RVA: 0x0051877E File Offset: 0x00516B7E
		private void _OnApplyTeacherListChanged(UIEvent uiEvent)
		{
			this._updateData();
		}

		// Token: 0x06011842 RID: 71746 RVA: 0x00518788 File Offset: 0x00516B88
		protected void _OnShowPupilApplyMenu(UIEvent uiEvent)
		{
			RelationMenuData userData = uiEvent.Param1 as RelationMenuData;
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			this.m_openMenu = this.frameMgr.OpenFrame<RelationMenuFram>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x06011843 RID: 71747 RVA: 0x005187D7 File Offset: 0x00516BD7
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x06011844 RID: 71748 RVA: 0x005187FD File Offset: 0x00516BFD
		private void _ClearAll()
		{
			DataManager<RelationDataManager>.GetInstance().RefuseAllApplyPupils();
			DataManager<RelationDataManager>.GetInstance().RefuseAllApplyTeachers();
		}

		// Token: 0x06011845 RID: 71749 RVA: 0x00518814 File Offset: 0x00516C14
		private void _updateData()
		{
			List<RelationData> list = new List<RelationData>();
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyPupils;
				this.mText.text = "收他为徒";
			}
			else if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyTeachers;
				this.mText.text = "拜他为师";
			}
			if (list.Count > 0)
			{
				this.comState.Key = "has_apply";
			}
			else
			{
				this.comState.Key = "no_apply";
			}
			if (null != this.comPupilApplyList)
			{
				this.comPupilApplyList.SetElementAmount(list.Count);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPApplyToggleRedPointUpdate, null, null, null, null);
		}

		// Token: 0x06011846 RID: 71750 RVA: 0x005188E8 File Offset: 0x00516CE8
		protected override void _OnCloseFrame()
		{
			if (null != this.comPupilApplyList)
			{
				this.comPupilApplyList.onBindItem = null;
				this.comPupilApplyList.onItemVisiable = null;
				this.comPupilApplyList = null;
			}
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnApplyPupilListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnApplyTeacherListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowPupilApplyMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilApplyMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
		}

		// Token: 0x06011847 RID: 71751 RVA: 0x005189B8 File Offset: 0x00516DB8
		protected override void _bindExUI()
		{
			this.comPupilApplyList = this.mBind.GetCom<ComUIListScript>("comPupilApplyList");
			this.mText = this.mBind.GetCom<Text>("Text");
			this.comState = this.mBind.GetCom<StateController>("comState");
		}

		// Token: 0x06011848 RID: 71752 RVA: 0x00518A07 File Offset: 0x00516E07
		protected override void _unbindExUI()
		{
			this.comPupilApplyList = null;
			this.mText = null;
			this.comState = null;
		}

		// Token: 0x0400B637 RID: 46647
		private IClientFrame m_openMenu;

		// Token: 0x0400B638 RID: 46648
		private ComUIListScript comPupilApplyList;

		// Token: 0x0400B639 RID: 46649
		private Text mText;

		// Token: 0x0400B63A RID: 46650
		private StateController comState;
	}
}
