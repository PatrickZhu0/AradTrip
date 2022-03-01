using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000FA0 RID: 4000
	public class ComToggleItemWithExample : ComToggleItem
	{
		// Token: 0x06009A7B RID: 39547 RVA: 0x001DDB6E File Offset: 0x001DBF6E
		protected override void InitItemView()
		{
			base.InitItemView();
			this.InitItemWithExampleName();
		}

		// Token: 0x06009A7C RID: 39548 RVA: 0x001DDB7C File Offset: 0x001DBF7C
		private void InitItemWithExampleName()
		{
			if (this.toggleItemText == null)
			{
				return;
			}
			ComSecondLevelToggleDataWithExample comSecondLevelToggleDataWithExample = this._comToggleData as ComSecondLevelToggleDataWithExample;
			if (comSecondLevelToggleDataWithExample != null && !string.IsNullOrEmpty(comSecondLevelToggleDataWithExample.SecondLevelExampleName))
			{
				this.toggleItemText.text = comSecondLevelToggleDataWithExample.SecondLevelExampleName;
			}
			else
			{
				this.toggleItemText.text = string.Empty;
			}
		}

		// Token: 0x04005007 RID: 20487
		public Text toggleItemText;
	}
}
