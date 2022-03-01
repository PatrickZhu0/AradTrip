using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B42 RID: 6978
	public class InscriptionEquipmentItem : MonoBehaviour
	{
		// Token: 0x17001D99 RID: 7577
		// (get) Token: 0x06011202 RID: 70146 RVA: 0x004EA1A1 File Offset: 0x004E85A1
		// (set) Token: 0x06011203 RID: 70147 RVA: 0x004EA1A9 File Offset: 0x004E85A9
		public ItemData CurrentItemData
		{
			get
			{
				return this.mItemData;
			}
			set
			{
				this.mItemData = value;
			}
		}

		// Token: 0x06011204 RID: 70148 RVA: 0x004EA1B4 File Offset: 0x004E85B4
		public void OnitemVisiable(ItemData itemData)
		{
			this.mItemData = itemData;
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			ItemData item = this.mItemData;
			if (InscriptionEquipmentItem.<>f__mg$cache0 == null)
			{
				InscriptionEquipmentItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, InscriptionEquipmentItem.<>f__mg$cache0);
			if (this.mName != null)
			{
				this.mName.text = this.mItemData.GetColorName(string.Empty, false);
			}
			if (this.mEquipMark != null)
			{
				this.mEquipMark.CustomActive(this.mItemData.PackageType == EPackageType.WearEquip);
			}
			if (this.mGoInscriptionHoles != null && this.mGoInscriptionHoles.Count > 0)
			{
				for (int i = 0; i < this.mGoInscriptionHoles.Count; i++)
				{
					this.mGoInscriptionHoles[i].CustomActive(false);
				}
			}
			if (itemData.InscriptionHoles.Count > 0)
			{
				for (int j = 0; j < itemData.InscriptionHoles.Count; j++)
				{
					if (j < this.mGoInscriptionHoles.Count)
					{
						this.mGoInscriptionHoles[j].CustomActive(true);
						EquipmentInscriptionHole component = this.mGoInscriptionHoles[j].GetComponent<EquipmentInscriptionHole>();
						if (component != null)
						{
							component.OnItemVisiable(itemData.InscriptionHoles[j]);
						}
					}
					else
					{
						GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mEquipmentInscriptionHolePath, true, 0U);
						if (gameObject != null)
						{
							Utility.AttachTo(gameObject, this.mHoleRoot, false);
							EquipmentInscriptionHole component2 = gameObject.GetComponent<EquipmentInscriptionHole>();
							if (component2 != null)
							{
								component2.OnItemVisiable(itemData.InscriptionHoles[j]);
							}
							this.mGoInscriptionHoles.Add(gameObject);
						}
					}
				}
			}
		}

		// Token: 0x06011205 RID: 70149 RVA: 0x004EA39E File Offset: 0x004E879E
		public void OnItemChangeDisplay(bool bSelected)
		{
			if (this.mCheckMark != null)
			{
				this.mCheckMark.CustomActive(bSelected);
			}
		}

		// Token: 0x06011206 RID: 70150 RVA: 0x004EA3BD File Offset: 0x004E87BD
		private void OnDestroy()
		{
			this.mItemData = null;
			this.mComItem = null;
			this.mGoInscriptionHoles.Clear();
		}

		// Token: 0x0400B088 RID: 45192
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B089 RID: 45193
		[SerializeField]
		private Text mName;

		// Token: 0x0400B08A RID: 45194
		[SerializeField]
		private GameObject mHoleRoot;

		// Token: 0x0400B08B RID: 45195
		[SerializeField]
		private GameObject mCheckMark;

		// Token: 0x0400B08C RID: 45196
		[SerializeField]
		private GameObject mEquipMark;

		// Token: 0x0400B08D RID: 45197
		[SerializeField]
		private string mEquipmentInscriptionHolePath = "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionHole";

		// Token: 0x0400B08E RID: 45198
		public static ItemData mSelectItemData;

		// Token: 0x0400B08F RID: 45199
		private ItemData mItemData;

		// Token: 0x0400B090 RID: 45200
		private List<GameObject> mGoInscriptionHoles = new List<GameObject>();

		// Token: 0x0400B091 RID: 45201
		private ComItem mComItem;

		// Token: 0x0400B092 RID: 45202
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
