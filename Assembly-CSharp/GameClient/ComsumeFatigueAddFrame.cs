using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F77 RID: 3959
	public class ComsumeFatigueAddFrame : ClientFrame
	{
		// Token: 0x06009919 RID: 39193 RVA: 0x001D7230 File Offset: 0x001D5630
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/ComsumeFatigueAdd";
		}

		// Token: 0x0600991A RID: 39194 RVA: 0x001D7237 File Offset: 0x001D5637
		public static void CommandOpen(object argv)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ComsumeFatigueAddFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ComsumeFatigueAddFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600991B RID: 39195 RVA: 0x001D725C File Offset: 0x001D565C
		protected override void _bindExUI()
		{
			this.mAdd0 = this.mBind.GetCom<Button>("add0");
			this.mAdd0.onClick.AddListener(new UnityAction(this._onAdd0ButtonClick));
			this.mAdd1 = this.mBind.GetCom<Button>("add1");
			this.mAdd1.onClick.AddListener(new UnityAction(this._onAdd1ButtonClick));
			this.mAdd2 = this.mBind.GetCom<Button>("add2");
			this.mAdd2.onClick.AddListener(new UnityAction(this._onAdd2ButtonClick));
			this.mNocountroots[0] = this.mBind.GetGameObject("nocountroot0");
			this.mNocountroots[1] = this.mBind.GetGameObject("nocountroot1");
			this.mNocountroots[2] = this.mBind.GetGameObject("nocountroot2");
			this.mDrugs[0] = this.mBind.GetCom<ComItemList>("drug0");
			this.mDrugs[1] = this.mBind.GetCom<ComItemList>("drug1");
			this.mDrugs[2] = this.mBind.GetCom<ComItemList>("drug2");
			this.mCountroots[0] = this.mBind.GetGameObject("countroot0");
			this.mCountroots[1] = this.mBind.GetGameObject("countroot1");
			this.mCountroots[2] = this.mBind.GetGameObject("countroot2");
		}

		// Token: 0x0600991C RID: 39196 RVA: 0x001D73D8 File Offset: 0x001D57D8
		protected override void _unbindExUI()
		{
			this.mAdd0.onClick.RemoveListener(new UnityAction(this._onAdd0ButtonClick));
			this.mAdd0 = null;
			this.mAdd1.onClick.RemoveListener(new UnityAction(this._onAdd1ButtonClick));
			this.mAdd1 = null;
			this.mAdd2.onClick.RemoveListener(new UnityAction(this._onAdd2ButtonClick));
			this.mAdd2 = null;
			this.mNocountroots[0] = null;
			this.mNocountroots[1] = null;
			this.mNocountroots[2] = null;
			this.mDrugs[0] = null;
			this.mDrugs[1] = null;
			this.mDrugs[2] = null;
			this.mCountroots[0] = null;
			this.mCountroots[1] = null;
			this.mCountroots[2] = null;
		}

		// Token: 0x0600991D RID: 39197 RVA: 0x001D749F File Offset: 0x001D589F
		private void _onAdd0ButtonClick()
		{
			this._useItem(0);
		}

		// Token: 0x0600991E RID: 39198 RVA: 0x001D74A8 File Offset: 0x001D58A8
		private void _onAdd1ButtonClick()
		{
			this._useItem(1);
		}

		// Token: 0x0600991F RID: 39199 RVA: 0x001D74B1 File Offset: 0x001D58B1
		private void _onAdd2ButtonClick()
		{
			this._useItem(2);
		}

		// Token: 0x06009920 RID: 39200 RVA: 0x001D74BA File Offset: 0x001D58BA
		protected override void _OnOpenFrame()
		{
			this._updateCount(null);
			this._bindEvent();
		}

		// Token: 0x06009921 RID: 39201 RVA: 0x001D74C9 File Offset: 0x001D58C9
		protected override void _OnCloseFrame()
		{
			this._unbindEvent();
		}

		// Token: 0x06009922 RID: 39202 RVA: 0x001D74D1 File Offset: 0x001D58D1
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._updateCount));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._updateCount));
		}

		// Token: 0x06009923 RID: 39203 RVA: 0x001D7509 File Offset: 0x001D5909
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._updateCount));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemCountChanged, new ClientEventSystem.UIEventHandler(this._updateCount));
		}

		// Token: 0x06009924 RID: 39204 RVA: 0x001D7544 File Offset: 0x001D5944
		private void _updateCount(UIEvent ui)
		{
			for (int i = 0; i < this.mDrugs.Length; i++)
			{
				ComItemList comItemList = this.mDrugs[i];
				if (null != comItemList && comItemList.mItemDatas.Length > 0)
				{
					int id = comItemList.mItemDatas[0].id;
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(id, true);
					if (ownedItemCount <= 0)
					{
						this.mNocountroots[i].SetActive(true);
						this.mCountroots[i].SetActive(false);
					}
					else
					{
						this.mNocountroots[i].SetActive(false);
						this.mCountroots[i].SetActive(true);
					}
				}
			}
		}

		// Token: 0x06009925 RID: 39205 RVA: 0x001D75EC File Offset: 0x001D59EC
		protected void _useItem(int idx)
		{
			if (idx >= 0 && idx < this.mDrugs.Length)
			{
				ComItemList comItemList = this.mDrugs[idx];
				if (null != comItemList && comItemList.mItemDatas.Length > 0)
				{
					int id = comItemList.mItemDatas[0].id;
					ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(id, false, true);
					if (itemByTableID != null && itemByTableID.Count > 0)
					{
						DataManager<ItemDataManager>.GetInstance().UseItem(itemByTableID, false, 0, 0);
					}
					else
					{
						ItemComeLink.OnLink(id, 0, false, delegate
						{
							this.frameMgr.CloseFrame<ComsumeFatigueAddFrame>(this, true);
						}, false, false, false, null, string.Empty);
					}
				}
			}
		}

		// Token: 0x04004ED8 RID: 20184
		private Button mAdd0;

		// Token: 0x04004ED9 RID: 20185
		private Button mAdd1;

		// Token: 0x04004EDA RID: 20186
		private Button mAdd2;

		// Token: 0x04004EDB RID: 20187
		private GameObject[] mNocountroots = new GameObject[3];

		// Token: 0x04004EDC RID: 20188
		private ComItemList[] mDrugs = new ComItemList[3];

		// Token: 0x04004EDD RID: 20189
		private GameObject[] mCountroots = new GameObject[3];
	}
}
