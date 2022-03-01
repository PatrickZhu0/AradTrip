using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014EC RID: 5356
	public class ChampionshipFightBaseView : MonoBehaviour
	{
		// Token: 0x0600CFD4 RID: 53204 RVA: 0x00334B69 File Offset: 0x00332F69
		protected virtual void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CFD5 RID: 53205 RVA: 0x00334B71 File Offset: 0x00332F71
		protected virtual void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CFD6 RID: 53206 RVA: 0x00334B80 File Offset: 0x00332F80
		protected virtual void BindUiEvents()
		{
			if (this.betButton != null)
			{
				this.betButton.onClick.RemoveAllListeners();
				this.betButton.onClick.AddListener(new UnityAction(this.OnBetButtonClick));
			}
			if (this.shopButton != null)
			{
				this.shopButton.onClick.RemoveAllListeners();
				this.shopButton.onClick.AddListener(new UnityAction(this.OnShopButtonClick));
			}
		}

		// Token: 0x0600CFD7 RID: 53207 RVA: 0x00334C08 File Offset: 0x00333008
		protected virtual void UnBindUiEvents()
		{
			if (this.betButton != null)
			{
				this.betButton.onClick.RemoveAllListeners();
			}
			if (this.shopButton != null)
			{
				this.shopButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CFD8 RID: 53208 RVA: 0x00334C57 File Offset: 0x00333057
		protected virtual void ClearData()
		{
			this._championScheduleId = 0;
			this._championScheduleTable = null;
		}

		// Token: 0x0600CFD9 RID: 53209 RVA: 0x00334C68 File Offset: 0x00333068
		public virtual void UpdateView(ChampionshipScheduleTable scheduleTable)
		{
			this._championScheduleTable = scheduleTable;
			if (this._championScheduleTable == null)
			{
				return;
			}
			this._championScheduleId = this._championScheduleTable.ID;
			if (this.helpNewAssistant != null)
			{
				this.helpNewAssistant.HelpId = this._championScheduleTable.CommonHelpId;
			}
			if (this.scheduleIconImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.scheduleIconImage, this._championScheduleTable.ScheduleIconPath, true);
				this.scheduleIconImage.SetNativeSize();
			}
			if (this.scheduleTimeLabel != null)
			{
				string championshipScheduleTimeStr = ChampionshipUtility.GetChampionshipScheduleTimeStr();
				this.scheduleTimeLabel.text = championshipScheduleTimeStr;
			}
			if (this.bigRewardControl != null)
			{
				this.bigRewardControl.InitControl();
				this.bigRewardControl.SetScheduleId(this._championScheduleId);
			}
		}

		// Token: 0x0600CFDA RID: 53210 RVA: 0x00334D44 File Offset: 0x00333144
		private void OnBetButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipGuessFrame();
		}

		// Token: 0x0600CFDB RID: 53211 RVA: 0x00334D4B File Offset: 0x0033314B
		private void OnShopButtonClick()
		{
			ChampionshipUtility.OnOpenChampionshipGuessShop();
		}

		// Token: 0x0600CFDC RID: 53212 RVA: 0x00334D54 File Offset: 0x00333154
		protected void UpdateScheduleTimeInfo()
		{
			if (this._championScheduleTable == null)
			{
				return;
			}
			if (this._championScheduleTable.ID < DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId && this.scheduleTimeLabel != null)
			{
				string text = TR.Value("Championship_Fight_Against_Already_Finished");
				this.scheduleTimeLabel.text = text;
			}
		}

		// Token: 0x04007999 RID: 31129
		protected int _championScheduleId;

		// Token: 0x0400799A RID: 31130
		protected ChampionshipScheduleTable _championScheduleTable;

		// Token: 0x0400799B RID: 31131
		[Space(10f)]
		[Header("Base")]
		[Space(10f)]
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x0400799C RID: 31132
		[SerializeField]
		private Image scheduleIconImage;

		// Token: 0x0400799D RID: 31133
		[SerializeField]
		private Text scheduleTimeLabel;

		// Token: 0x0400799E RID: 31134
		[Space(10f)]
		[Header("BigRewardPreviewControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipBigRewardControl bigRewardControl;

		// Token: 0x0400799F RID: 31135
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button betButton;

		// Token: 0x040079A0 RID: 31136
		[SerializeField]
		private Button shopButton;
	}
}
