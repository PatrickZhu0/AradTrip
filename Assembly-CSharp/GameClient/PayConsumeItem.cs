using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200194B RID: 6475
	public class PayConsumeItem
	{
		// Token: 0x0600FBCF RID: 64463 RVA: 0x00450718 File Offset: 0x0044EB18
		public PayConsumeItem(ActiveManager.ActivityData data, GameObject parent, ClientFrame THIS)
		{
			this.data = data;
			this.parent = parent;
			this.THIS = THIS;
			this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayConsumeItem", true, 0U);
			if (this.root != null)
			{
				this.txtMoney = Utility.FindComponent<Text>(this.root, "title/tmp/Money", false);
				this.rootItems = Utility.FindGameObject(this.root, "item", false);
				this.txtStatus = Utility.FindComponent<Text>(this.root, "status", false);
				this.goBtnGet = Utility.FindGameObject(this.root, "btnGet", false);
				this.goBtnGet.GetComponent<Button>().onClick.AddListener(new UnityAction(this.OnClickGet));
				this.goBtnGet.CustomActive(false);
				this.goBtnGet.CustomActive(true);
				this.txtStatus.CustomActive(false);
				Utility.AttachTo(this.root, parent, false);
			}
			this.SetData();
		}

		// Token: 0x0600FBD0 RID: 64464 RVA: 0x0045081C File Offset: 0x0044EC1C
		public void SetStat()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PayConsumeFrame>(null))
			{
				return;
			}
			bool flag = Singleton<PayManager>.GetInstance().CanGetRewards(this.data.ID);
			UIGray uigray = this.goBtnGet.GetComponent<UIGray>();
			if (uigray == null)
			{
				uigray = this.goBtnGet.AddComponent<UIGray>();
			}
			uigray.enabled = !flag;
			this.txtMoney.text = this.data.activeItem.Desc;
			if (this.data.status >= 4)
			{
				this.txtStatus.CustomActive(true);
				this.txtStatus.text = "已领取";
				this.goBtnGet.CustomActive(false);
			}
		}

		// Token: 0x0600FBD1 RID: 64465 RVA: 0x004508D6 File Offset: 0x0044ECD6
		private void OnClickGet()
		{
			Singleton<PayManager>.GetInstance().GetRewards(this.data.ID);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(300, delegate
			{
				this.SetStat();
			}, 0, 0, false);
		}

		// Token: 0x0600FBD2 RID: 64466 RVA: 0x00450914 File Offset: 0x0044ED14
		public void SetData()
		{
			if (this.data == null)
			{
				return;
			}
			this.SetStat();
			Dictionary<uint, int> awardItems = Singleton<PayManager>.GetInstance().GetAwardItems(this.data);
			foreach (KeyValuePair<uint, int> keyValuePair in awardItems)
			{
				uint key = keyValuePair.Key;
				Dictionary<uint, int>.Enumerator enumerator;
				KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
				int value = keyValuePair2.Value;
				ComItem comItem = this.THIS.CreateComItem(this.rootItems);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)key, 100, 0);
				itemData.Count = value;
				comItem.Setup(itemData, delegate(GameObject obj, ItemData item1)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item1, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x04009D57 RID: 40279
		private GameObject root;

		// Token: 0x04009D58 RID: 40280
		private GameObject parent;

		// Token: 0x04009D59 RID: 40281
		public const string res_consumeItem = "UIFlatten/Prefabs/Vip/PayConsumeItem";

		// Token: 0x04009D5A RID: 40282
		private ActiveManager.ActivityData data;

		// Token: 0x04009D5B RID: 40283
		private ClientFrame THIS;

		// Token: 0x04009D5C RID: 40284
		private Text txtMoney;

		// Token: 0x04009D5D RID: 40285
		private GameObject rootItems;

		// Token: 0x04009D5E RID: 40286
		private Text txtStatus;

		// Token: 0x04009D5F RID: 40287
		private GameObject goBtnGet;
	}
}
