using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200166E RID: 5742
	public class HonorCommonController : MonoBehaviour
	{
		// Token: 0x0600E1CE RID: 57806 RVA: 0x003A057E File Offset: 0x0039E97E
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E1CF RID: 57807 RVA: 0x003A0586 File Offset: 0x0039E986
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E1D0 RID: 57808 RVA: 0x003A0594 File Offset: 0x0039E994
		private void BindEvents()
		{
			if (this.honorSystemPreviewButton != null)
			{
				this.honorSystemPreviewButton.onClick.RemoveAllListeners();
				this.honorSystemPreviewButton.onClick.AddListener(new UnityAction(this.OnHonorSystemPreviewButtonClicked));
			}
			if (this.protectCardUseButton != null)
			{
				this.protectCardUseButton.onClick.RemoveAllListeners();
				this.protectCardUseButton.onClick.AddListener(new UnityAction(this.OnProtectCardUseButtonClicked));
			}
		}

		// Token: 0x0600E1D1 RID: 57809 RVA: 0x003A061C File Offset: 0x0039EA1C
		private void UnBindEvents()
		{
			if (this.honorSystemPreviewButton != null)
			{
				this.honorSystemPreviewButton.onClick.RemoveAllListeners();
			}
			if (this.protectCardUseButton != null)
			{
				this.protectCardUseButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600E1D2 RID: 57810 RVA: 0x003A066B File Offset: 0x0039EA6B
		private void ClearData()
		{
		}

		// Token: 0x0600E1D3 RID: 57811 RVA: 0x003A066D File Offset: 0x0039EA6D
		public void InitHonorCommonController()
		{
			this.InitHonorPlayerInfo();
			this.UpdateProtectCardUsedContent();
			this.InitHonorTodayActivityItemList();
		}

		// Token: 0x0600E1D4 RID: 57812 RVA: 0x003A0684 File Offset: 0x0039EA84
		private void InitHonorPlayerInfo()
		{
			int id = (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel;
			if (DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel == 0U)
			{
				id = 1000;
			}
			HonorLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<HonorLevelTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.InitHonorPlayerLevelInfo(tableItem);
			this.InitHonorPlayerExpInfo(tableItem);
			this.InitHonorPreWeekRankInfo();
			this.InitHonorHistoryRankInfo();
		}

		// Token: 0x0600E1D5 RID: 57813 RVA: 0x003A06E8 File Offset: 0x0039EAE8
		private void InitHonorPlayerLevelInfo(HonorLevelTable playerHonorLevelTable)
		{
			if (this.leftLevelIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.leftLevelIcon, playerHonorLevelTable.TitleFlag, true);
			}
			if (this.rightLevelIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.rightLevelIcon, playerHonorLevelTable.TitleFlag, true);
			}
			if (this.honorLevelNameText != null)
			{
				string titleNameByTitleId = HonorSystemUtility.GetTitleNameByTitleId(playerHonorLevelTable.Title);
				this.honorLevelNameText.text = titleNameByTitleId;
			}
			if (this.honorLevelValueText != null)
			{
				this.honorLevelValueText.text = DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel.ToString();
			}
		}

		// Token: 0x0600E1D6 RID: 57814 RVA: 0x003A0798 File Offset: 0x0039EB98
		private void InitHonorPlayerExpInfo(HonorLevelTable playerHonorLevelTable)
		{
			int needExp = playerHonorLevelTable.NeedExp;
			long num = (long)((ulong)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorExp - (ulong)((long)needExp));
			int id = (int)(DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel + 1U);
			HonorLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<HonorLevelTable>(id, string.Empty, string.Empty);
			int num2;
			if (tableItem != null)
			{
				num2 = tableItem.NeedExp - needExp;
			}
			else
			{
				num2 = 0;
				num = 0L;
			}
			if (this.honorExpSlider != null)
			{
				float num3 = 1f;
				if (num2 > 0)
				{
					num3 = (float)num / (float)num2;
				}
				if (num3 < 0f)
				{
					num3 = 0f;
				}
				else if (num3 > 1f)
				{
					num3 = 1f;
				}
				this.honorExpSlider.value = num3;
			}
		}

		// Token: 0x0600E1D7 RID: 57815 RVA: 0x003A085C File Offset: 0x0039EC5C
		private void InitHonorPreWeekRankInfo()
		{
			CommonUtility.UpdateGameObjectVisible(this.upIcon, false);
			CommonUtility.UpdateGameObjectVisible(this.flatIcon, false);
			CommonUtility.UpdateGameObjectVisible(this.downIcon, false);
			if (this.honorPreWeekRankText == null)
			{
				return;
			}
			uint playerLastWeekRank = DataManager<HonorSystemDataManager>.GetInstance().PlayerLastWeekRank;
			uint playerHistoryRank = DataManager<HonorSystemDataManager>.GetInstance().PlayerHistoryRank;
			if (playerLastWeekRank <= 0U)
			{
				this.honorPreWeekRankText.text = TR.Value("Honor_System_Rank_Last_Week_Empty_Flag");
				if (playerHistoryRank > 0U)
				{
					CommonUtility.UpdateGameObjectVisible(this.downIcon, true);
				}
				return;
			}
			this.honorPreWeekRankText.text = DataManager<HonorSystemDataManager>.GetInstance().PlayerLastWeekRank.ToString();
			if (playerHistoryRank <= 0U)
			{
				CommonUtility.UpdateGameObjectVisible(this.upIcon, true);
				return;
			}
			if (playerLastWeekRank < playerHistoryRank)
			{
				CommonUtility.UpdateGameObjectVisible(this.upIcon, true);
			}
			else if (playerLastWeekRank != playerHistoryRank)
			{
				CommonUtility.UpdateGameObjectVisible(this.downIcon, true);
			}
		}

		// Token: 0x0600E1D8 RID: 57816 RVA: 0x003A094C File Offset: 0x0039ED4C
		private void InitHonorHistoryRankInfo()
		{
			int num = (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHighestHonorLevel;
			if (num == 0)
			{
				num = 1000;
			}
			HonorLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<HonorLevelTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.historyRankText != null)
			{
				string titleNameByTitleId = HonorSystemUtility.GetTitleNameByTitleId(tableItem.Title);
				this.historyRankText.text = titleNameByTitleId;
			}
		}

		// Token: 0x0600E1D9 RID: 57817 RVA: 0x003A09B6 File Offset: 0x0039EDB6
		private void InitHonorTodayActivityItemList()
		{
		}

		// Token: 0x0600E1DA RID: 57818 RVA: 0x003A09B8 File Offset: 0x0039EDB8
		public void UpdateProtectCardUsedContent()
		{
			CommonUtility.UpdateGameObjectVisible(this.protectCardFunctionOpenRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.protectCardFunctionUnOpenRoot, false);
			if (DataManager<HonorSystemDataManager>.GetInstance().IsAlreadyUseProtectCard)
			{
				CommonUtility.UpdateGameObjectVisible(this.protectCardFunctionOpenRoot, true);
				if (this.protectCardOpenTipLabel != null)
				{
					this.protectCardOpenTipLabel.text = TR.Value("Honor_System_Protect_Card_Already_Open");
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.protectCardFunctionUnOpenRoot, true);
				if (this.protectCardUnUsedTipLabel != null)
				{
					this.protectCardUnUsedTipLabel.text = TR.Value("Honor_System_Protect_Card_To_Use");
				}
			}
		}

		// Token: 0x0600E1DB RID: 57819 RVA: 0x003A0A55 File Offset: 0x0039EE55
		private void OnProtectCardUseButtonClicked()
		{
			HonorSystemUtility.OnOpenHonorSystemProtectCardFrame();
		}

		// Token: 0x0600E1DC RID: 57820 RVA: 0x003A0A5C File Offset: 0x0039EE5C
		private void OnHonorSystemPreviewButtonClicked()
		{
			HonorSystemUtility.OnOpenHonorSystemPreviewFrame();
		}

		// Token: 0x0400871A RID: 34586
		[Space(5f)]
		[Header("HonorLevelIcon")]
		[Space(5f)]
		[SerializeField]
		private Image leftLevelIcon;

		// Token: 0x0400871B RID: 34587
		[SerializeField]
		private Image rightLevelIcon;

		// Token: 0x0400871C RID: 34588
		[Space(5f)]
		[Header("HonorLevelName")]
		[Space(5f)]
		[SerializeField]
		private Text honorLevelValueText;

		// Token: 0x0400871D RID: 34589
		[SerializeField]
		private Text honorLevelNameText;

		// Token: 0x0400871E RID: 34590
		[Space(5f)]
		[Header("HonorExp")]
		[Space(5f)]
		[SerializeField]
		private Slider honorExpSlider;

		// Token: 0x0400871F RID: 34591
		[SerializeField]
		private Text honorExpText;

		// Token: 0x04008720 RID: 34592
		[Space(5f)]
		[Header("ProtectCard")]
		[Space(5f)]
		[SerializeField]
		private GameObject protectCardFunctionOpenRoot;

		// Token: 0x04008721 RID: 34593
		[SerializeField]
		private Text protectCardOpenTipLabel;

		// Token: 0x04008722 RID: 34594
		[SerializeField]
		private GameObject protectCardFunctionUnOpenRoot;

		// Token: 0x04008723 RID: 34595
		[SerializeField]
		private Text protectCardUnUsedTipLabel;

		// Token: 0x04008724 RID: 34596
		[SerializeField]
		private Button protectCardUseButton;

		// Token: 0x04008725 RID: 34597
		[Space(5f)]
		[Header("HonorPreWeekRank")]
		[Space(5f)]
		[SerializeField]
		private Text honorPreWeekRankText;

		// Token: 0x04008726 RID: 34598
		[SerializeField]
		private GameObject upIcon;

		// Token: 0x04008727 RID: 34599
		[SerializeField]
		private GameObject flatIcon;

		// Token: 0x04008728 RID: 34600
		[SerializeField]
		private GameObject downIcon;

		// Token: 0x04008729 RID: 34601
		[Space(5f)]
		[Header("HonorHistoryRank")]
		[Space(5f)]
		[SerializeField]
		private Text historyRankText;

		// Token: 0x0400872A RID: 34602
		[SerializeField]
		private Button honorSystemPreviewButton;

		// Token: 0x0400872B RID: 34603
		private List<PvpNumberStatistics> todayActivityDataModelList;
	}
}
