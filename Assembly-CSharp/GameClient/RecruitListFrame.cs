using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013C0 RID: 5056
	public class RecruitListFrame : ClientFrame
	{
		// Token: 0x0600C435 RID: 50229 RVA: 0x002F1484 File Offset: 0x002EF884
		protected sealed override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
		}

		// Token: 0x0600C436 RID: 50230 RVA: 0x002F14D9 File Offset: 0x002EF8D9
		protected sealed override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mUIList = null;
		}

		// Token: 0x0600C437 RID: 50231 RVA: 0x002F1505 File Offset: 0x002EF905
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<RecruitListFrame>(this, false);
		}

		// Token: 0x0600C438 RID: 50232 RVA: 0x002F1514 File Offset: 0x002EF914
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/WarriorRecruit/RecruitListFrame";
		}

		// Token: 0x0600C439 RID: 50233 RVA: 0x002F151B File Offset: 0x002EF91B
		protected sealed override void _OnOpenFrame()
		{
			this.InitUIList();
			this.recruitPlayerInfoList = (this.userData as List<RecruitPlayerInfo>);
			this.mUIList.SetElementAmount(this.recruitPlayerInfoList.Count);
		}

		// Token: 0x0600C43A RID: 50234 RVA: 0x002F154A File Offset: 0x002EF94A
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitUIList();
			this.recruitPlayerInfoList.Clear();
		}

		// Token: 0x0600C43B RID: 50235 RVA: 0x002F1560 File Offset: 0x002EF960
		private void InitUIList()
		{
			if (this.mUIList != null)
			{
				this.mUIList.Initialize();
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mUIList;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycleDelegate));
			}
		}

		// Token: 0x0600C43C RID: 50236 RVA: 0x002F1600 File Offset: 0x002EFA00
		private void UnInitUIList()
		{
			if (this.mUIList != null)
			{
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mUIList;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycleDelegate));
			}
		}

		// Token: 0x0600C43D RID: 50237 RVA: 0x002F1693 File Offset: 0x002EFA93
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600C43E RID: 50238 RVA: 0x002F169C File Offset: 0x002EFA9C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.recruitPlayerInfoList.Count)
			{
				Text com = comCommonBind.GetCom<Text>("name");
				Text com2 = comCommonBind.GetCom<Text>("level");
				Text com3 = comCommonBind.GetCom<Text>("state");
				Image com4 = comCommonBind.GetCom<Image>("icon");
				Button com5 = comCommonBind.GetCom<Button>("btteam");
				RecruitPlayerInfo recruitPlayerInfo = this.recruitPlayerInfoList[item.m_index];
				if (com != null)
				{
					com.text = recruitPlayerInfo.name;
				}
				if (com2 != null)
				{
					com2.text = string.Format("Lv.{0}", recruitPlayerInfo.level);
				}
				if (com4 != null)
				{
					string path = string.Empty;
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)recruitPlayerInfo.occu, string.Empty, string.Empty);
					if (tableItem == null)
					{
						return;
					}
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						return;
					}
					path = tableItem2.IconPath;
					ETCImageLoader.LoadSprite(ref com4, path, true);
				}
				if (com3 != null)
				{
					com3.text = this.GetStatesStrByType(recruitPlayerInfo.online);
				}
				if (com5 != null)
				{
					com5.CustomActive(recruitPlayerInfo.online != 2);
					com5.onClick.RemoveAllListeners();
					int iIndex = item.m_index;
					com5.onClick.AddListener(delegate()
					{
						this._OnClickOk(iIndex);
					});
				}
			}
		}

		// Token: 0x0600C43F RID: 50239 RVA: 0x002F1868 File Offset: 0x002EFC68
		private void OnItemRecycleDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind == null)
			{
				return;
			}
			Button com = comCommonBind.GetCom<Button>("btteam");
			com.onClick.RemoveAllListeners();
		}

		// Token: 0x0600C440 RID: 50240 RVA: 0x002F18A8 File Offset: 0x002EFCA8
		private void _OnClickOk(int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.recruitPlayerInfoList.Count)
			{
				return;
			}
			RecruitPlayerInfo recruitPlayerInfo = this.recruitPlayerInfoList[iIndex];
			DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(recruitPlayerInfo.userId);
		}

		// Token: 0x0600C441 RID: 50241 RVA: 0x002F18EC File Offset: 0x002EFCEC
		private string GetStatesStrByType(byte state)
		{
			string result = string.Empty;
			if (state == 0)
			{
				result = TR.Value("RecruitList_Offline_State");
			}
			else
			{
				result = TR.Value("RecruitList_Online_State");
			}
			return result;
		}

		// Token: 0x04006FAF RID: 28591
		private Button mBtClose;

		// Token: 0x04006FB0 RID: 28592
		private ComUIListScript mUIList;

		// Token: 0x04006FB1 RID: 28593
		private List<RecruitPlayerInfo> recruitPlayerInfoList = new List<RecruitPlayerInfo>();
	}
}
