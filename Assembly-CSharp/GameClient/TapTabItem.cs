using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BF5 RID: 7157
	internal class TapTabItem : CachedSelectedObject<TAPTabData, TapTabItem>
	{
		// Token: 0x060118A2 RID: 71842 RVA: 0x0051A752 File Offset: 0x00518B52
		public override void Initialize()
		{
			this.name = Utility.FindComponent<Text>(this.goLocal, "Text", true);
			this.checkName = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
		}

		// Token: 0x060118A3 RID: 71843 RVA: 0x0051A782 File Offset: 0x00518B82
		public override void UnInitialize()
		{
			this.name = null;
			this.checkName = null;
		}

		// Token: 0x060118A4 RID: 71844 RVA: 0x0051A794 File Offset: 0x00518B94
		public override void OnUpdate()
		{
			if (base.Value != null)
			{
				if (null != this.name)
				{
					this.name.text = base.Value.name;
				}
				if (null != this.checkName)
				{
					this.checkName.text = base.Value.name;
				}
			}
		}

		// Token: 0x0400B679 RID: 46713
		private Text name;

		// Token: 0x0400B67A RID: 46714
		private Text checkName;
	}
}
