using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AB8 RID: 6840
	internal class BeadItem : MonoBehaviour
	{
		// Token: 0x17001D5C RID: 7516
		// (get) Token: 0x06010CD3 RID: 68819 RVA: 0x004C9DDD File Offset: 0x004C81DD
		public BeadItemModel Model
		{
			get
			{
				return (this.model != null) ? this.model : null;
			}
		}

		// Token: 0x06010CD4 RID: 68820 RVA: 0x004C9DF6 File Offset: 0x004C81F6
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x06010CD5 RID: 68821 RVA: 0x004C9E04 File Offset: 0x004C8204
		public void OnItemVisible(BeadItemModel model)
		{
			this.model = model;
			string prefabPath = this.mBind.GetPrefabPath("nomalHole");
			this.mBind.ClearCacheBinds(prefabPath);
			ItemData mItemData = this.model.beadItemData;
			if (this.model.mountedType != 0)
			{
				ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
				if (comCommonBind != null)
				{
					Utility.AttachTo(comCommonBind.gameObject, this.mBind.GetGameObject("BeadHoleRoot"), false);
				}
				ItemData equipItemData = this.model.equipItemData;
				if (equipItemData != null)
				{
					GameObject gameObject = comCommonBind.GetGameObject("ItemPos");
					ComItem comItem = ComItemManager.Create(gameObject);
					ComItem comItem2 = comItem;
					ItemData item2 = equipItemData;
					if (BeadItem.<>f__mg$cache0 == null)
					{
						BeadItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item2, BeadItem.<>f__mg$cache0);
				}
			}
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.comItem.Setup(mItemData, delegate(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					mItemData.BeadAdditiveAttributeBuffID = model.buffID;
					mItemData.BeadPickNumber = model.beadPickNumber;
					mItemData.BeadReplaceNumber = model.replaceNumber;
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				}
			});
			Text text = this.mName;
			string text2 = mItemData.GetColorName(string.Empty, false);
			this.mCheckName.text = text2;
			text.text = text2;
			if (this.model.buffID > 0)
			{
				Text text3 = this.mBeadAttr;
				text2 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(mItemData.TableID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(this.model.buffID));
				this.mCheckBeadAttr.text = text2;
				text3.text = text2;
			}
			else
			{
				Text text4 = this.mBeadAttr;
				text2 = DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(mItemData.TableID, false);
				this.mCheckBeadAttr.text = text2;
				text4.text = text2;
			}
			this.ShowBeadReplaceRemainNumber();
			this.mScrollRect.verticalNormalizedPosition = 1f;
			this.mCheckScrollRect.verticalNormalizedPosition = 1f;
		}

		// Token: 0x06010CD6 RID: 68822 RVA: 0x004CA024 File Offset: 0x004C8424
		public void ShowBeadReplaceRemainNumber()
		{
			if (this.mIsShowBeadReplaceNumber)
			{
				string beadReplaceRemainNumber = DataManager<BeadCardManager>.GetInstance().GetBeadReplaceRemainNumber(this.model.beadItemData.TableID, this.model.replaceNumber);
				if (beadReplaceRemainNumber != string.Empty)
				{
					Text text = this.mBeadAttr;
					text.text = text.text + "\n" + beadReplaceRemainNumber;
				}
			}
		}

		// Token: 0x0400AC38 RID: 44088
		public static BeadItemModel ms_select;

		// Token: 0x0400AC39 RID: 44089
		[SerializeField]
		private ComCommonBind mBind;

		// Token: 0x0400AC3A RID: 44090
		[SerializeField]
		private Text mName;

		// Token: 0x0400AC3B RID: 44091
		[SerializeField]
		private Text mBeadAttr;

		// Token: 0x0400AC3C RID: 44092
		[SerializeField]
		private Text mCheckName;

		// Token: 0x0400AC3D RID: 44093
		[SerializeField]
		private Text mCheckBeadAttr;

		// Token: 0x0400AC3E RID: 44094
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x0400AC3F RID: 44095
		[SerializeField]
		private GameObject goCheckMark;

		// Token: 0x0400AC40 RID: 44096
		[SerializeField]
		private ScrollRect mScrollRect;

		// Token: 0x0400AC41 RID: 44097
		[SerializeField]
		private ScrollRect mCheckScrollRect;

		// Token: 0x0400AC42 RID: 44098
		[Header("是否显示宝珠置换次数")]
		[SerializeField]
		private bool mIsShowBeadReplaceNumber;

		// Token: 0x0400AC43 RID: 44099
		private ComItem comItem;

		// Token: 0x0400AC44 RID: 44100
		private BeadItemModel model;

		// Token: 0x0400AC45 RID: 44101
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
