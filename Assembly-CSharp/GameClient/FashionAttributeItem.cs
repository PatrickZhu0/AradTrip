using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B27 RID: 6951
	internal class FashionAttributeItem : CachedSelectedObject<FashionAttributeItemData, FashionAttributeItem>
	{
		// Token: 0x17001D97 RID: 7575
		// (get) Token: 0x0601112B RID: 69931 RVA: 0x004E4EF2 File Offset: 0x004E32F2
		public bool IsAssigned
		{
			get
			{
				return base.Value.item == base.Value.selected;
			}
		}

		// Token: 0x0601112C RID: 69932 RVA: 0x004E4F0C File Offset: 0x004E330C
		public override void Initialize()
		{
			this.name = Utility.FindComponent<Text>(this.goLocal, "Name", true);
			this.goGraphic = Utility.FindChild(this.goLocal, "Mark");
			this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
			this.goCurAttribute = Utility.FindChild(this.goLocal, "CurAttribute");
			this.goLines = Utility.FindChild(this.goLocal, "Lines");
		}

		// Token: 0x0601112D RID: 69933 RVA: 0x004E4F88 File Offset: 0x004E3388
		public override void UnInitialize()
		{
		}

		// Token: 0x0601112E RID: 69934 RVA: 0x004E4F8C File Offset: 0x004E338C
		public override void OnUpdate()
		{
			if (this.IsAssigned)
			{
				this.goGraphic.CustomActive(false);
				this.goCurAttribute.CustomActive(true);
			}
			else
			{
				this.goGraphic.CustomActive(true);
				this.goCurAttribute.CustomActive(false);
			}
			this.name.text = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(base.Value.item.ID, "fashion_attribute_color_white", " ");
			this.goLines.CustomActive(!base.Value.bLast);
		}

		// Token: 0x0601112F RID: 69935 RVA: 0x004E5021 File Offset: 0x004E3421
		public override void OnDisplayChanged(bool bShow)
		{
			this.goCheckMark.CustomActive(bShow);
		}

		// Token: 0x0400AFEB RID: 45035
		private Text name;

		// Token: 0x0400AFEC RID: 45036
		private GameObject goGraphic;

		// Token: 0x0400AFED RID: 45037
		private GameObject goCheckMark;

		// Token: 0x0400AFEE RID: 45038
		private GameObject goCurAttribute;

		// Token: 0x0400AFEF RID: 45039
		private GameObject goLines;
	}
}
