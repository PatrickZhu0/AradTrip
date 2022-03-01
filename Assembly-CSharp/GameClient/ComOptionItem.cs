using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000049 RID: 73
	internal class ComOptionItem : MonoBehaviour
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000F605 File Offset: 0x0000DA05
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x0000F60D File Offset: 0x0000DA0D
		public OptionItemData Value
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000F616 File Offset: 0x0000DA16
		public void OnClickRemove()
		{
			this.Value.onItemRemove(this.Value.itemData);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000F633 File Offset: 0x0000DA33
		public void OnClickAdd()
		{
			this.Value.onOpenEquipList(this.Value.isLeft);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000F650 File Offset: 0x0000DA50
		public void OnClickBG()
		{
			this.Value.onOpenEquipList(this.Value.isLeft);
		}

		// Token: 0x040001A1 RID: 417
		public Image itemBG;

		// Token: 0x040001A2 RID: 418
		public Text itemRealName;

		// Token: 0x040001A3 RID: 419
		public Text itemRealAttribute;

		// Token: 0x040001A4 RID: 420
		public GameObject itemParent;

		// Token: 0x040001A5 RID: 421
		public Text itemCount;

		// Token: 0x040001A6 RID: 422
		public Text itemName;

		// Token: 0x040001A7 RID: 423
		public Text itemHint;

		// Token: 0x040001A8 RID: 424
		public StateController stateController;

		// Token: 0x040001A9 RID: 425
		public Button buttonAdd;

		// Token: 0x040001AA RID: 426
		public Text acquiredHint;

		// Token: 0x040001AB RID: 427
		private OptionItemData data;
	}
}
