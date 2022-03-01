using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000FA1 RID: 4001
	public class ComTwoLevelToggleItemWithExample : ComTwoLevelToggleItem
	{
		// Token: 0x06009A7E RID: 39550 RVA: 0x001DDBEB File Offset: 0x001DBFEB
		protected override void InitItemView()
		{
			base.InitItemView();
			this.InitItemWithExample();
		}

		// Token: 0x06009A7F RID: 39551 RVA: 0x001DDBFC File Offset: 0x001DBFFC
		private void InitItemWithExample()
		{
			if (this.twoLevelExampleNameText == null)
			{
				return;
			}
			ComFirstLevelToggleDataWithExample comFirstLevelToggleDataWithExample = this._comFirstLevelToggleData as ComFirstLevelToggleDataWithExample;
			if (comFirstLevelToggleDataWithExample != null && !string.IsNullOrEmpty(comFirstLevelToggleDataWithExample.FirstLevelExampleName))
			{
				this.twoLevelExampleNameText.text = comFirstLevelToggleDataWithExample.FirstLevelExampleName;
			}
			else
			{
				this.twoLevelExampleNameText.text = string.Empty;
			}
		}

		// Token: 0x04005008 RID: 20488
		public Text twoLevelExampleNameText;
	}
}
