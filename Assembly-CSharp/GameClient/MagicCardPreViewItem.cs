using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B6B RID: 7019
	public class MagicCardPreViewItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0601133B RID: 70459 RVA: 0x004F2F34 File Offset: 0x004F1334
		public void InitItem(ItemData item)
		{
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ComItem comItem = this.mComItem;
			if (MagicCardPreViewItem.<>f__mg$cache0 == null)
			{
				MagicCardPreViewItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem.Setup(item, MagicCardPreViewItem.<>f__mg$cache0);
			this.mName.text = item.GetColorName(string.Empty, false);
		}

		// Token: 0x0601133C RID: 70460 RVA: 0x004F2FA3 File Offset: 0x004F13A3
		public void Dispose()
		{
			if (this.mComItem != null)
			{
				this.mComItem.Setup(null, null);
				this.mComItem = null;
			}
		}

		// Token: 0x0400B18E RID: 45454
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B18F RID: 45455
		[SerializeField]
		private Text mName;

		// Token: 0x0400B190 RID: 45456
		private ComItem mComItem;

		// Token: 0x0400B191 RID: 45457
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
