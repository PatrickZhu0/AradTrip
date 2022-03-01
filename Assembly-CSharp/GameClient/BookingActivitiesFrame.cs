using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E14 RID: 3604
	public class BookingActivitiesFrame : ClientFrame
	{
		// Token: 0x0600904F RID: 36943 RVA: 0x001AAD0F File Offset: 0x001A910F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/BookingActivitiesFrame";
		}

		// Token: 0x06009050 RID: 36944 RVA: 0x001AAD18 File Offset: 0x001A9118
		protected override void _bindExUI()
		{
			this.mJobImg = this.mBind.GetCom<Image>("JobImg");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mDes = this.mBind.GetCom<Text>("Des");
			this.mItem1Root = this.mBind.GetGameObject("item1Root");
			this.mItem2Root = this.mBind.GetGameObject("item2Root");
			this.mItem3Root = this.mBind.GetGameObject("item3Root");
			this.mClose = this.mBind.GetCom<Button>("close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x06009051 RID: 36945 RVA: 0x001AADEC File Offset: 0x001A91EC
		protected override void _unbindExUI()
		{
			this.mJobImg = null;
			this.mName = null;
			this.mDes = null;
			this.mItem1Root = null;
			this.mItem2Root = null;
			this.mItem3Root = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x06009052 RID: 36946 RVA: 0x001AAE57 File Offset: 0x001A9257
		private void _onCloseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<BookingActivitiesFrame>(this, false);
		}

		// Token: 0x06009053 RID: 36947 RVA: 0x001AAE65 File Offset: 0x001A9265
		protected sealed override void _OnOpenFrame()
		{
			this.mApponintenRoleID = (int)this.userData;
			DataManager<PlayerBaseData>.GetInstance().JobTableID = this.mApponintenRoleID;
			this.InitRewardItem();
			this.SetJobTableId(this.mApponintenRoleID);
		}

		// Token: 0x06009054 RID: 36948 RVA: 0x001AAE9A File Offset: 0x001A929A
		protected sealed override void _OnCloseFrame()
		{
			this.mApponintenRoleID = 0;
		}

		// Token: 0x06009055 RID: 36949 RVA: 0x001AAEA4 File Offset: 0x001A92A4
		private void InitRewardItem()
		{
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(479, string.Empty, string.Empty).Value;
			int value2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(480, string.Empty, string.Empty).Value;
			int value3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(481, string.Empty, string.Empty).Value;
			this.CreateItem(this.mItem1Root, value);
			this.CreateItem(this.mItem2Root, value2);
			this.CreateItem(this.mItem3Root, value3);
		}

		// Token: 0x06009056 RID: 36950 RVA: 0x001AAF38 File Offset: 0x001A9338
		private void CreateItem(GameObject root, int id)
		{
			ComItem comItem = root.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(root);
			}
			ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
			if (ItemDetailData != null)
			{
				ItemDetailData.Count = 1;
				comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
				{
					this._OnShowTips(ItemDetailData);
				});
			}
		}

		// Token: 0x06009057 RID: 36951 RVA: 0x001AAFAB File Offset: 0x001A93AB
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, false);
		}

		// Token: 0x06009058 RID: 36952 RVA: 0x001AAFC4 File Offset: 0x001A93C4
		private void SetJobTableId(int id)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this._setName(tableItem.Name);
			this._setJobImg(tableItem.AppointmentJobImage);
			this._setAppointmentRoleDes(tableItem.prejob);
		}

		// Token: 0x06009059 RID: 36953 RVA: 0x001AB012 File Offset: 0x001A9412
		private void _setName(string name)
		{
			if (name == null)
			{
				return;
			}
			this.mName.text = name;
		}

		// Token: 0x0600905A RID: 36954 RVA: 0x001AB027 File Offset: 0x001A9427
		private void _setJobImg(string path)
		{
			if (path == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.mJobImg, path, true);
			this.mJobImg.SetNativeSize();
		}

		// Token: 0x0600905B RID: 36955 RVA: 0x001AB04C File Offset: 0x001A944C
		private void _setAppointmentRoleDes(int id)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mDes.text = TR.Value("appointmentrole_description", tableItem.Name);
		}

		// Token: 0x040047B5 RID: 18357
		private int mApponintenRoleID;

		// Token: 0x040047B6 RID: 18358
		private Image mJobImg;

		// Token: 0x040047B7 RID: 18359
		private Text mName;

		// Token: 0x040047B8 RID: 18360
		private Text mDes;

		// Token: 0x040047B9 RID: 18361
		private GameObject mItem1Root;

		// Token: 0x040047BA RID: 18362
		private GameObject mItem2Root;

		// Token: 0x040047BB RID: 18363
		private GameObject mItem3Root;

		// Token: 0x040047BC RID: 18364
		private Button mClose;
	}
}
