using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BEF RID: 7151
	internal class TAPSearchTeacherFrame : ClientFrame
	{
		// Token: 0x06011884 RID: 71812 RVA: 0x00519FBE File Offset: 0x005183BE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAPSystem/TAPSearchTeacherFrame";
		}

		// Token: 0x06011885 RID: 71813 RVA: 0x00519FC8 File Offset: 0x005183C8
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<TAPSearchTeacherFrame>(this, false);
			});
			base._AddButton("Root/Controls/BtnChangeAll", new UnityAction(this._ChangeAll));
			base._AddButton("Root/Controls/BtnAddAll", new UnityAction(this._AddAll));
			base._AddButton("Root/BtnSearch", new UnityAction(this._Search));
			this.needPopupMsg = false;
			this.bForceDisable = false;
			this.comTeacherList.Initialize();
			this.comTeacherList.onBindItem = ((GameObject go) => go.GetComponent<ComTAPTeacherInfo>());
			this.comTeacherList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (null != item)
				{
					ComTAPTeacherInfo comTAPTeacherInfo = item.gameObjectBindScript as ComTAPTeacherInfo;
					List<RelationData> searchedTeacherList = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
					if (null != comTAPTeacherInfo && item.m_index >= 0 && item.m_index < searchedTeacherList.Count)
					{
						comTAPTeacherInfo.OnItemVisible(searchedTeacherList[item.m_index]);
					}
				}
			};
			this.m_bWaitSearchRet = false;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowAskTeacherMenu, new ClientEventSystem.UIEventHandler(this._OnPopupTeacherMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSearchedTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedTeacherListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnQueryTeacherChanged, new ClientEventSystem.UIEventHandler(this._OnQueryTeacherChanged));
			DataManager<TAPDataManager>.GetInstance().SendChangeSearchedTeacherList();
			this._Update();
		}

		// Token: 0x06011886 RID: 71814 RVA: 0x0051A120 File Offset: 0x00518520
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowAskTeacherMenu, new ClientEventSystem.UIEventHandler(this._OnPopupTeacherMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSearchedTeacherListChanged, new ClientEventSystem.UIEventHandler(this._OnSearchedTeacherListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryTeacherChanged, new ClientEventSystem.UIEventHandler(this._OnQueryTeacherChanged));
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			InvokeMethod.RmoveInvokeIntervalCall(this);
			InvokeMethod.RemoveInvokeCall(this);
			DataManager<TAPDataManager>.GetInstance().ClearQueryInfo();
		}

		// Token: 0x06011887 RID: 71815 RVA: 0x0051A1D0 File Offset: 0x005185D0
		private void _ChangeAll()
		{
			this.btnChangeAll.enabled = false;
			this.grayChangeAll.enabled = true;
			this.iChangeAllValue = 5;
			if (null != this.changeAllText)
			{
				this.changeAllText.text = TR.Value("relation_change_all_desc_param", this.iChangeAllValue);
			}
			InvokeMethod.RmoveInvokeIntervalCall(this);
			InvokeMethod.InvokeInterval(this, 0f, 1f, 5f, null, delegate
			{
				this.iChangeAllValue--;
				if (null != this.changeAllText)
				{
					this.changeAllText.text = TR.Value("relation_change_all_desc_param", this.iChangeAllValue);
				}
			}, delegate
			{
				this.btnChangeAll.enabled = true;
				this.grayChangeAll.enabled = false;
				this.iChangeAllValue = 0;
				if (null != this.changeAllText)
				{
					this.changeAllText.text = TR.Value("relation_change_all_desc");
				}
			});
			DataManager<TAPDataManager>.GetInstance().SendChangeSearchedTeacherList();
		}

		// Token: 0x06011888 RID: 71816 RVA: 0x0051A26C File Offset: 0x0051866C
		private void _UpdateAddAllStatus()
		{
			bool flag = false;
			List<RelationData> searchedTeacherList = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
			for (int i = 0; i < searchedTeacherList.Count; i++)
			{
				if (DataManager<TAPDataManager>.GetInstance().CanQuery(searchedTeacherList[i].uid))
				{
					flag = true;
					break;
				}
			}
			if (this.bForceDisable)
			{
				flag = false;
			}
			this.grayAddAll.enabled = !flag;
			this.btnAddAll.enabled = flag;
		}

		// Token: 0x06011889 RID: 71817 RVA: 0x0051A2E8 File Offset: 0x005186E8
		private void _AddAll()
		{
			this.bForceDisable = true;
			this.grayAddAll.enabled = true;
			this.btnAddAll.enabled = false;
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

		// Token: 0x0601188A RID: 71818 RVA: 0x0051A39C File Offset: 0x0051879C
		private void _Search()
		{
			if (string.IsNullOrEmpty(this.inputField.text))
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
			worldQueryPlayerReq.name = this.inputField.text;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_TEACHER;
			worldQueryPlayerReq.roleId = 0UL;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x0601188B RID: 71819 RVA: 0x0051A430 File Offset: 0x00518830
		private void _Update()
		{
			List<RelationData> searchedTeacherList = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
			if (searchedTeacherList.Count > 0)
			{
				this.comState.Key = "has_teacher";
			}
			else
			{
				this.comState.Key = "has_no_teacher";
			}
			if (null != this.comTeacherList)
			{
				this.comTeacherList.SetElementAmount(searchedTeacherList.Count);
			}
		}

		// Token: 0x0601188C RID: 71820 RVA: 0x0051A49C File Offset: 0x0051889C
		protected void _OnPopupTeacherMenu(UIEvent uiEvent)
		{
			RelationMenuData userData = uiEvent.Param1 as RelationMenuData;
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			this.m_openMenu = this.frameMgr.OpenFrame<RelationMenuFram>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0601188D RID: 71821 RVA: 0x0051A4EB File Offset: 0x005188EB
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x0601188E RID: 71822 RVA: 0x0051A514 File Offset: 0x00518914
		protected void _OnSearchedTeacherListChanged(UIEvent uiEvent)
		{
			this._Update();
			if (this.needPopupMsg)
			{
				List<RelationData> searchedTeacherList = DataManager<RelationDataManager>.GetInstance().SearchedTeacherList;
				if (searchedTeacherList != null && searchedTeacherList.Count > 0)
				{
					SystemNotifyManager.SystemNotify(8928, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(8929, string.Empty);
				}
			}
			this.needPopupMsg = true;
			this.bForceDisable = false;
			this.grayAddAll.enabled = false;
			this.btnAddAll.enabled = true;
		}

		// Token: 0x0601188F RID: 71823 RVA: 0x0051A598 File Offset: 0x00518998
		protected void _OnQueryTeacherChanged(UIEvent uiEvent)
		{
			this._Update();
			this._UpdateAddAllStatus();
		}

		// Token: 0x0400B661 RID: 46689
		[UIControl("Root/InputField", typeof(InputField), 0)]
		private InputField inputField;

		// Token: 0x0400B662 RID: 46690
		[UIControl("Root", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x0400B663 RID: 46691
		[UIControl("Root/Friends", typeof(ComUIListScript), 0)]
		private ComUIListScript comTeacherList;

		// Token: 0x0400B664 RID: 46692
		private bool needPopupMsg;

		// Token: 0x0400B665 RID: 46693
		[UIControl("Root/Controls/BtnChangeAll/Text", typeof(Text), 0)]
		private Text changeAllText;

		// Token: 0x0400B666 RID: 46694
		[UIControl("Root/Controls/BtnChangeAll", typeof(Button), 0)]
		private Button btnChangeAll;

		// Token: 0x0400B667 RID: 46695
		[UIControl("Root/Controls/BtnChangeAll", typeof(UIGray), 0)]
		private UIGray grayChangeAll;

		// Token: 0x0400B668 RID: 46696
		private int iChangeAllValue;

		// Token: 0x0400B669 RID: 46697
		[UIControl("Root/Controls/BtnAddAll", typeof(Button), 0)]
		private Button btnAddAll;

		// Token: 0x0400B66A RID: 46698
		[UIControl("Root/Controls/BtnAddAll", typeof(UIGray), 0)]
		private UIGray grayAddAll;

		// Token: 0x0400B66B RID: 46699
		private bool bForceDisable;

		// Token: 0x0400B66C RID: 46700
		private bool m_bWaitSearchRet;

		// Token: 0x0400B66D RID: 46701
		private IClientFrame m_openMenu;
	}
}
