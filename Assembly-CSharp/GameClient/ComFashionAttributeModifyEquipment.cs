using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B1C RID: 6940
	internal class ComFashionAttributeModifyEquipment : MonoBehaviour
	{
		// Token: 0x17001D8B RID: 7563
		// (get) Token: 0x06011086 RID: 69766 RVA: 0x004E01E9 File Offset: 0x004DE5E9
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06011087 RID: 69767 RVA: 0x004E020D File Offset: 0x004DE60D
		public static bool CheckCanSeal(ItemData x)
		{
			return x.iMaxPackTime > 0 && !x.Packing && x.RePackTime > 0;
		}

		// Token: 0x06011088 RID: 69768 RVA: 0x004E0232 File Offset: 0x004DE632
		public void OnCreate(ClientFrame frame)
		{
			this.clientFrame = (frame as FashionAttributesModifyFrame);
			if (frame != null)
			{
				this.comItem = frame.CreateComItem(this.goItemParent);
				this.comItem.imgBackGround.enabled = false;
			}
		}

		// Token: 0x06011089 RID: 69769 RVA: 0x004E026C File Offset: 0x004DE66C
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
			Scrollbar component = base.gameObject.transform.parent.parent.parent.parent.transform.Find("EquipAdjust/Root/middleback/Scroll View/Scrollbar Vertical").GetComponent<Scrollbar>();
			if (component != null)
			{
				component.value = 1f;
			}
		}

		// Token: 0x0601108A RID: 69770 RVA: 0x004E02D0 File Offset: 0x004DE6D0
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0601108B RID: 69771 RVA: 0x004E02E8 File Offset: 0x004DE6E8
		public void OnItemVisible(ItemData itemData)
		{
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			this.Name.text = itemData.GetColorName(string.Empty, false);
			this.checkName.text = itemData.GetColorName(string.Empty, false);
			this.equiptedMark.CustomActive(itemData.PackageType == EPackageType.WearFashion);
			base.gameObject.name = itemData.TableID.ToString();
		}

		// Token: 0x0601108C RID: 69772 RVA: 0x004E036E File Offset: 0x004DE76E
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem.imgBackGround.enabled = true;
				this.comItem = null;
			}
			this.clientFrame = null;
		}

		// Token: 0x0400AF53 RID: 44883
		public static ItemData ms_selected;

		// Token: 0x0400AF54 RID: 44884
		public Text Name;

		// Token: 0x0400AF55 RID: 44885
		public Text checkName;

		// Token: 0x0400AF56 RID: 44886
		public GameObject equiptedMark;

		// Token: 0x0400AF57 RID: 44887
		public GameObject goItemParent;

		// Token: 0x0400AF58 RID: 44888
		public GameObject goCheckMark;

		// Token: 0x0400AF59 RID: 44889
		public Text redPointHint;

		// Token: 0x0400AF5A RID: 44890
		public Image imageItemBack;

		// Token: 0x0400AF5B RID: 44891
		private ComItem comItem;

		// Token: 0x0400AF5C RID: 44892
		public SmithFunctionRedBinder comFunctionBinder;

		// Token: 0x0400AF5D RID: 44893
		private FashionAttributesModifyFrame clientFrame;
	}
}
