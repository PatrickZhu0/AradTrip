using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001515 RID: 5397
	public class ChampionshipScoreRankItem : MonoBehaviour
	{
		// Token: 0x0600D19E RID: 53662 RVA: 0x0033B40E File Offset: 0x0033980E
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D19F RID: 53663 RVA: 0x0033B416 File Offset: 0x00339816
		private void ClearData()
		{
		}

		// Token: 0x0600D1A0 RID: 53664 RVA: 0x0033B418 File Offset: 0x00339818
		public void Init(ChampionshipScoreRankDataModel pointRankDataModel, bool isMainScheduleScoreItem = false)
		{
			this._pointRankDataModel = pointRankDataModel;
			if (this._pointRankDataModel == null)
			{
				return;
			}
			if (!isMainScheduleScoreItem)
			{
				this.InitItem();
			}
			else
			{
				this.InitMainScheduleScoreItem();
			}
		}

		// Token: 0x0600D1A1 RID: 53665 RVA: 0x0033B444 File Offset: 0x00339844
		private void InitMainScheduleScoreItem()
		{
			string format = TR.Value("Championship_Main_Schedule_Score_Four_Color_Format");
			if (this._pointRankDataModel.RankIndex == 1)
			{
				format = TR.Value("Championship_Main_Schedule_Score_First_Color_Format");
			}
			else if (this._pointRankDataModel.RankIndex == 2)
			{
				format = TR.Value("Championship_Main_Schedule_Score_Second_Color_Format");
			}
			else if (this._pointRankDataModel.RankIndex == 3)
			{
				format = TR.Value("Championship_Main_Schedule_Score_Third_Color_Format");
			}
			if (this.rankIndexLabel != null)
			{
				string text = string.Format(format, this._pointRankDataModel.RankIndex.ToString());
				this.rankIndexLabel.text = text;
			}
			if (this.playerNameLabel != null)
			{
				string text2 = string.Format(format, this._pointRankDataModel.Name);
				this.playerNameLabel.text = text2;
			}
			if (this.pointValueLabel != null)
			{
				string text3 = string.Format(format, this._pointRankDataModel.Score);
				this.pointValueLabel.text = text3;
			}
			if (this.serverNameLabel != null)
			{
				string text4 = string.Format(format, this._pointRankDataModel.ServerName);
				this.serverNameLabel.text = text4;
			}
		}

		// Token: 0x0600D1A2 RID: 53666 RVA: 0x0033B588 File Offset: 0x00339988
		private void InitItem()
		{
			if (this.rankIndexLabel != null)
			{
				this.rankIndexLabel.text = this._pointRankDataModel.RankIndex.ToString();
			}
			if (this.playerNameLabel != null)
			{
				this.playerNameLabel.text = this._pointRankDataModel.Name;
			}
			if (this.pointValueLabel != null)
			{
				this.pointValueLabel.text = this._pointRankDataModel.Score.ToString();
			}
			if (this.serverNameLabel != null)
			{
				this.serverNameLabel.text = this._pointRankDataModel.ServerName;
			}
		}

		// Token: 0x0600D1A3 RID: 53667 RVA: 0x0033B647 File Offset: 0x00339A47
		public void Reset()
		{
			this._pointRankDataModel = null;
		}

		// Token: 0x0600D1A4 RID: 53668 RVA: 0x0033B650 File Offset: 0x00339A50
		public void UpdateSpecialContent(int topWinNumber = 0)
		{
			CommonUtility.UpdateGameObjectVisible(this.specialContentImage, false);
			CommonUtility.UpdateGameObjectVisible(this.specialBgFlag, false);
			if (this._pointRankDataModel == null)
			{
				return;
			}
			if (this.specialContentImage != null && this._pointRankDataModel.RankIndex <= topWinNumber)
			{
				CommonUtility.UpdateGameObjectVisible(this.specialContentImage, true);
			}
			if (this.specialBgFlag != null && this._pointRankDataModel.RankIndex % 2 == 0)
			{
				CommonUtility.UpdateGameObjectVisible(this.specialBgFlag, true);
			}
		}

		// Token: 0x04007AA6 RID: 31398
		private ChampionshipScoreRankDataModel _pointRankDataModel;

		// Token: 0x04007AA7 RID: 31399
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private Text rankIndexLabel;

		// Token: 0x04007AA8 RID: 31400
		[SerializeField]
		private Text playerNameLabel;

		// Token: 0x04007AA9 RID: 31401
		[SerializeField]
		private Text serverNameLabel;

		// Token: 0x04007AAA RID: 31402
		[SerializeField]
		private Text pointValueLabel;

		// Token: 0x04007AAB RID: 31403
		[Space(10f)]
		[Header("SpecialFlag")]
		[Space(10f)]
		[SerializeField]
		private GameObject specialBgFlag;

		// Token: 0x04007AAC RID: 31404
		[SerializeField]
		private GameObject specialContentImage;
	}
}
