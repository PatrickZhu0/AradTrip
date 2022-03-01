using System;
using Parser;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200194F RID: 6479
	public class PayAwardItem
	{
		// Token: 0x0600FBED RID: 64493 RVA: 0x00451E94 File Offset: 0x00450294
		public PayAwardItem(ComItem comItem, GameObject parent)
		{
			this.parent = parent;
			this.comItem = comItem;
			this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayAwardItem", true, 0U);
			if (this.root)
			{
				Utility.AttachTo(this.root, parent, false);
				this.awardItemGo = Utility.FindGameObject(this.root, "Image", false);
				this.awardEle = this.awardItemGo.GetComponent<LayoutElement>();
				this.awardName = Utility.FindComponent<Text>(this.root, "Text", false);
			}
			this.SetData();
		}

		// Token: 0x0600FBEE RID: 64494 RVA: 0x00451F30 File Offset: 0x00450330
		public void SetData()
		{
			if (this.comItem == null)
			{
				return;
			}
			if (this.awardItemGo)
			{
				Utility.AttachTo(this.comItem.gameObject, this.awardItemGo, false);
			}
			if (this.awardName && this.comItem.ItemData != null)
			{
				string text = this.comItem.ItemData.Name + " x" + this.comItem.ItemData.Count;
				text = text.Replace("（", "(");
				text = text.Replace("）", ")");
				this.awardName.text = text;
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.comItem.ItemData.TableID, string.Empty, string.Empty);
				this.SetNameColorByQuality(tableItem, this.awardName);
			}
		}

		// Token: 0x0600FBEF RID: 64495 RVA: 0x00452028 File Offset: 0x00450428
		private void SetNameColorByQuality(ItemTable item, Text text)
		{
			if (text == null)
			{
				return;
			}
			string arg = "white";
			if (item != null)
			{
				arg = ItemParser.GetItemColor(item);
			}
			string text2 = text.text;
			text.text = string.Format("<color={0}>", arg) + text2 + "</color>";
		}

		// Token: 0x0600FBF0 RID: 64496 RVA: 0x00452078 File Offset: 0x00450478
		public LayoutElement GetCurrAwardItemEle()
		{
			return this.awardEle;
		}

		// Token: 0x04009D94 RID: 40340
		public const string res_awardItem = "UIFlatten/Prefabs/Vip/PayAwardItem";

		// Token: 0x04009D95 RID: 40341
		private GameObject root;

		// Token: 0x04009D96 RID: 40342
		private GameObject parent;

		// Token: 0x04009D97 RID: 40343
		private ComItem comItem;

		// Token: 0x04009D98 RID: 40344
		private GameObject awardItemGo;

		// Token: 0x04009D99 RID: 40345
		private LayoutElement awardEle;

		// Token: 0x04009D9A RID: 40346
		private Text awardName;
	}
}
