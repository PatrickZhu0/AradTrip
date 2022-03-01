using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F38 RID: 3896
	public class TestLevelItem : ComToggleItem
	{
		// Token: 0x060097C0 RID: 38848 RVA: 0x001D11DC File Offset: 0x001CF5DC
		public override void InitItem(ComControlData comToggleData, OnComToggleClick onComToggleClick = null)
		{
			base.InitItem(comToggleData, onComToggleClick);
			if (this.levelName != null)
			{
				TestLevelData testLevelData = this._comToggleData as TestLevelData;
				if (testLevelData != null)
				{
					if (testLevelData.Id % 2 == 0)
					{
						this.levelName.gameObject.CustomActive(true);
						this.levelName.text = testLevelData.LevelName;
					}
					else
					{
						this.levelName.gameObject.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x04004E49 RID: 20041
		[Space(10f)]
		[Header("ComToggleItem")]
		[Space(5f)]
		[SerializeField]
		private Text levelName;
	}
}
