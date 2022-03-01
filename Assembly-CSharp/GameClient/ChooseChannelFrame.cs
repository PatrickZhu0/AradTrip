using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001162 RID: 4450
	public class ChooseChannelFrame : GameFrame
	{
		// Token: 0x0600A9ED RID: 43501 RVA: 0x00242FD0 File Offset: 0x002413D0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Login/Publish/ChooseChannel";
		}

		// Token: 0x0600A9EE RID: 43502 RVA: 0x00242FD7 File Offset: 0x002413D7
		protected override void OnOpenFrame()
		{
			this.InitTestComUIList();
			this.UpdateTestComUIList();
		}

		// Token: 0x0600A9EF RID: 43503 RVA: 0x00242FE5 File Offset: 0x002413E5
		protected override void OnCloseFrame()
		{
			this.UninitData();
		}

		// Token: 0x0600A9F0 RID: 43504 RVA: 0x00242FED File Offset: 0x002413ED
		protected override void _bindExUI()
		{
			this.selectBtnUIList = this.mBind.GetCom<ComUIListScript>("ComUIList");
		}

		// Token: 0x0600A9F1 RID: 43505 RVA: 0x00243005 File Offset: 0x00241405
		protected override void _unbindExUI()
		{
			this.selectBtnUIList = null;
		}

		// Token: 0x0600A9F2 RID: 43506 RVA: 0x0024300E File Offset: 0x0024140E
		protected override void OnBindUIEvent()
		{
			base.BindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600A9F3 RID: 43507 RVA: 0x00243027 File Offset: 0x00241427
		protected override void OnUnBindUIEvent()
		{
			base.UnBindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600A9F4 RID: 43508 RVA: 0x00243040 File Offset: 0x00241440
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600A9F5 RID: 43509 RVA: 0x00243043 File Offset: 0x00241443
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600A9F6 RID: 43510 RVA: 0x00243048 File Offset: 0x00241448
		private void InitTestComUIList()
		{
			if (this.selectBtnUIList == null)
			{
				return;
			}
			this.selectBtnUIList.Initialize();
			this.selectBtnUIList.onBindItem = ((GameObject go) => go);
			this.selectBtnUIList.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				if (this.selectBtnComUIListDatas == null)
				{
					return;
				}
				this._OnBind(go);
			};
		}

		// Token: 0x0600A9F7 RID: 43511 RVA: 0x002430B1 File Offset: 0x002414B1
		private void UninitData()
		{
			this.selectBtnComUIListDatas = null;
		}

		// Token: 0x0600A9F8 RID: 43512 RVA: 0x002430BA File Offset: 0x002414BA
		private void CalcTestComUIListDatas()
		{
			this.selectBtnComUIListDatas = new List<ChooseChannelInfo>();
			this.selectBtnComUIListDatas = Singleton<ChooseChannelManager>.GetInstance().GetInfoList();
		}

		// Token: 0x0600A9F9 RID: 43513 RVA: 0x002430D8 File Offset: 0x002414D8
		private void UpdateTestComUIList()
		{
			if (this.selectBtnUIList == null)
			{
				return;
			}
			this.CalcTestComUIListDatas();
			if (this.selectBtnComUIListDatas == null || this.selectBtnComUIListDatas.Count <= 0)
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<ChooseChannelFrame>(null, false);
				return;
			}
			this.selectBtnUIList.SetElementAmount(this.selectBtnComUIListDatas.Count);
		}

		// Token: 0x0600A9FA RID: 43514 RVA: 0x0024313C File Offset: 0x0024153C
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x0600A9FB RID: 43515 RVA: 0x00243140 File Offset: 0x00241540
		private void _OnBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component != null)
			{
				Text com = component.GetCom<Text>("name");
				Button com2 = component.GetCom<Button>("btn");
				if (com != null)
				{
					com.text = this.selectBtnComUIListDatas[item.m_index].showName;
				}
				if (com2 != null)
				{
					com2.onClick.AddListener(delegate()
					{
						this._onClickSelectBtn(item);
					});
				}
				return;
			}
		}

		// Token: 0x0600A9FC RID: 43516 RVA: 0x002431E4 File Offset: 0x002415E4
		private void _onClickSelectBtn(ComUIListElementScript item)
		{
			string serverChannel = this.selectBtnComUIListDatas[item.m_index].serverChannel;
			string serverList = this.selectBtnComUIListDatas[item.m_index].serverList;
			if (Singleton<ChooseChannelManager>.GetInstance().IsSelectDiffChannel(serverChannel))
			{
				Singleton<ChooseChannelManager>.GetInstance().ChangeChannelInfo(serverChannel, serverList);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.onSelectChannelSuccess, true, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.onSelectChannelSuccess, false, null, null, null);
			}
			Singleton<ChooseChannelManager>.GetInstance().SaveSelectChannelInfo(string.Format("{0},{1}", serverChannel, serverList));
			Singleton<ClientSystemManager>.instance.CloseFrame<ChooseChannelFrame>(null, false);
		}

		// Token: 0x04005F3B RID: 24379
		private List<ChooseChannelInfo> selectBtnComUIListDatas;

		// Token: 0x04005F3C RID: 24380
		private ComUIListScript selectBtnUIList;
	}
}
