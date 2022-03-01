using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001BD0 RID: 7120
	public class TAPApplyFrame : ClientFrame
	{
		// Token: 0x060116DD RID: 71389 RVA: 0x0050E483 File Offset: 0x0050C883
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAP/TAPApplyFrame";
		}

		// Token: 0x060116DE RID: 71390 RVA: 0x0050E48C File Offset: 0x0050C88C
		protected override void _OnOpenFrame()
		{
			DataManager<RelationDataManager>.GetInstance().MakeDebugApplyPupilDatas();
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<TAPApplyFrame>(this, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnApplyPupilListChanged, null, null, null, null);
			});
			base._AddButton("Root/BtnClearAll", new UnityAction(this._ClearAll));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyPupilListChanged, new ClientEventSystem.UIEventHandler(this._OnApplyPupilListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnApplyTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnApplyTeacherListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowPupilApplyMenu, new ClientEventSystem.UIEventHandler(this._OnShowPupilApplyMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			DataManager<RelationDataManager>.GetInstance().RemoveApplyPupilNotify();
			this._updateData();
		}

		// Token: 0x060116DF RID: 71391 RVA: 0x0050E54D File Offset: 0x0050C94D
		private void _OnApplyPupilListChanged(UIEvent uiEvent)
		{
			this._updateData();
		}

		// Token: 0x060116E0 RID: 71392 RVA: 0x0050E555 File Offset: 0x0050C955
		private void _OnApplyTeacherListChanged(UIEvent uiEvent)
		{
			this._updateData();
		}

		// Token: 0x060116E1 RID: 71393 RVA: 0x0050E560 File Offset: 0x0050C960
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

		// Token: 0x060116E2 RID: 71394 RVA: 0x0050E5AF File Offset: 0x0050C9AF
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x060116E3 RID: 71395 RVA: 0x0050E5D5 File Offset: 0x0050C9D5
		private void _ClearAll()
		{
			DataManager<RelationDataManager>.GetInstance().RefuseAllApplyPupils();
		}

		// Token: 0x060116E4 RID: 71396 RVA: 0x0050E5E4 File Offset: 0x0050C9E4
		private void _updateData()
		{
			bool flag = false;
			TAPType taptype = DataManager<TAPNewDataManager>.GetInstance().IsTeacher();
			if (taptype > TAPType.Pupil)
			{
				flag = true;
			}
			List<RelationData> list = new List<RelationData>();
			if (flag)
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyTeachers;
			}
			else
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyPupils;
			}
			if (list.Count == 0)
			{
				list = DataManager<RelationDataManager>.GetInstance().ApplyPupils;
			}
			if (list.Count > 0)
			{
				this.mBtnClearAll.CustomActive(true);
				this.mHint.CustomActive(false);
			}
			else
			{
				this.mBtnClearAll.CustomActive(false);
				this.mHint.CustomActive(true);
			}
			int num = 25;
			for (int i = 0; i < list.Count; i++)
			{
				if (i < 6)
				{
					PupilApplyItem pupilApplyItem = new PupilApplyItem(list[i], num);
					if (pupilApplyItem != null)
					{
						Utility.AttachTo(pupilApplyItem.ThisGameObject, this.mFriends, false);
					}
				}
				num++;
			}
		}

		// Token: 0x060116E5 RID: 71397 RVA: 0x0050E6DC File Offset: 0x0050CADC
		protected override void _OnCloseFrame()
		{
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

		// Token: 0x060116E6 RID: 71398 RVA: 0x0050E77C File Offset: 0x0050CB7C
		protected override void _bindExUI()
		{
			this.mBtnClearAll = this.mBind.GetGameObject("BtnClearAll");
			this.mHint = this.mBind.GetGameObject("Hint");
			this.mFriends = this.mBind.GetGameObject("Friends");
		}

		// Token: 0x060116E7 RID: 71399 RVA: 0x0050E7CB File Offset: 0x0050CBCB
		protected override void _unbindExUI()
		{
			this.mBtnClearAll = null;
			this.mHint = null;
			this.mFriends = null;
		}

		// Token: 0x0400B4F0 RID: 46320
		private IClientFrame m_openMenu;

		// Token: 0x0400B4F1 RID: 46321
		private GameObject mBtnClearAll;

		// Token: 0x0400B4F2 RID: 46322
		private GameObject mHint;

		// Token: 0x0400B4F3 RID: 46323
		private GameObject mFriends;
	}
}
