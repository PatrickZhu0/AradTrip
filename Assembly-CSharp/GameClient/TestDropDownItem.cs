using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F7C RID: 3964
	public class TestDropDownItem : ComDropDownItem
	{
		// Token: 0x0600994B RID: 39243 RVA: 0x001D7F90 File Offset: 0x001D6390
		public override void InitItem(ComControlData comControlData, OnComDropDownItemButtonClick onItemButtonClick = null)
		{
			base.InitItem(comControlData, onItemButtonClick);
			if (this.dropDownName != null)
			{
				TestDropDownData testDropDownData = this._comControlData as TestDropDownData;
				if (testDropDownData != null)
				{
					if (testDropDownData.Id % 3 == 0)
					{
						this.dropDownName.gameObject.CustomActive(true);
						this.dropDownName.text = testDropDownData.DropDownName;
					}
					else
					{
						this.dropDownName.gameObject.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x04004EED RID: 20205
		[Space(10f)]
		[Header("ComToggleItem")]
		[Space(5f)]
		[SerializeField]
		private Text dropDownName;
	}
}
