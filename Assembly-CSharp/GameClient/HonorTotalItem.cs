using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001673 RID: 5747
	public class HonorTotalItem : MonoBehaviour
	{
		// Token: 0x0600E1F6 RID: 57846 RVA: 0x003A1052 File Offset: 0x0039F452
		private void OnDestroy()
		{
			this._pvpNumberStatistics = null;
		}

		// Token: 0x0600E1F7 RID: 57847 RVA: 0x003A105B File Offset: 0x0039F45B
		public void InitItem(PvpNumberStatistics pvpNumberStatistics)
		{
			this._pvpNumberStatistics = pvpNumberStatistics;
			if (this._pvpNumberStatistics == null)
			{
				return;
			}
			this.InitActivityIcon();
			this.InitActivityText();
		}

		// Token: 0x0600E1F8 RID: 57848 RVA: 0x003A107C File Offset: 0x0039F47C
		private void InitActivityIcon()
		{
			CommonUtility.UpdateGameObjectVisible(this.newFlag, this._pvpNumberStatistics.IsNewFlag);
			if (this.activityItemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.activityItemIcon, this._pvpNumberStatistics.PvpIconPath, true);
			}
			bool flag = this._pvpNumberStatistics.PvpCount <= 0U;
			CommonUtility.UpdateGameObjectUiGray(this.activityItemUIGray, flag);
		}

		// Token: 0x0600E1F9 RID: 57849 RVA: 0x003A10E8 File Offset: 0x0039F4E8
		private void InitActivityText()
		{
			if (this._pvpNumberStatistics.PvpCount <= 0U)
			{
				CommonUtility.UpdateTextVisible(this.activityTotalNumberText, false);
				CommonUtility.UpdateTextVisible(this.notGetText, true);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.activityTotalNumberText, true);
				if (this.activityTotalNumberText != null)
				{
					this.activityTotalNumberText.text = this._pvpNumberStatistics.PvpCount.ToString();
				}
				CommonUtility.UpdateTextVisible(this.notGetText, false);
			}
		}

		// Token: 0x0400873B RID: 34619
		[Space(5f)]
		[Header("Text")]
		[SerializeField]
		private Text activityTotalNumberText;

		// Token: 0x0400873C RID: 34620
		[SerializeField]
		private Text notGetText;

		// Token: 0x0400873D RID: 34621
		[Space(10f)]
		[Header("Icon")]
		[Space(10f)]
		[SerializeField]
		private GameObject newFlag;

		// Token: 0x0400873E RID: 34622
		[SerializeField]
		private Image activityItemIcon;

		// Token: 0x0400873F RID: 34623
		[SerializeField]
		private UIGray activityItemUIGray;

		// Token: 0x04008740 RID: 34624
		private PvpNumberStatistics _pvpNumberStatistics;
	}
}
