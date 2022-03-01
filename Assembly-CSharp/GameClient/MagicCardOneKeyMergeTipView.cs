using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001748 RID: 5960
	public class MagicCardOneKeyMergeTipView : MonoBehaviour
	{
		// Token: 0x0600EA04 RID: 59908 RVA: 0x003DF909 File Offset: 0x003DDD09
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600EA05 RID: 59909 RVA: 0x003DF911 File Offset: 0x003DDD11
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600EA06 RID: 59910 RVA: 0x003DF920 File Offset: 0x003DDD20
		private void BindEvents()
		{
			if (this.whiteButton != null)
			{
				this.whiteButton.onClick.RemoveAllListeners();
				this.whiteButton.onClick.AddListener(new UnityAction(this.OnWhiteButtonClick));
			}
			if (this.blueButton != null)
			{
				this.blueButton.onClick.RemoveAllListeners();
				this.blueButton.onClick.AddListener(new UnityAction(this.OnBlueButtonClick));
			}
			if (this.goldButton != null)
			{
				this.goldButton.onClick.RemoveAllListeners();
				this.goldButton.onClick.AddListener(new UnityAction(this.OnGoldButtonClick));
			}
			if (this.noBindItemButton != null)
			{
				this.noBindItemButton.onClick.RemoveAllListeners();
				this.noBindItemButton.onClick.AddListener(new UnityAction(this.OnNoBindItemButtonClick));
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
				this.cancelButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.mergeButton != null)
			{
				this.mergeButton.onClick.RemoveAllListeners();
				this.mergeButton.onClick.AddListener(new UnityAction(this.OnMergeClick));
			}
		}

		// Token: 0x0600EA07 RID: 59911 RVA: 0x003DFA9C File Offset: 0x003DDE9C
		private void UnBindEvents()
		{
			if (this.whiteButton != null)
			{
				this.whiteButton.onClick.RemoveAllListeners();
			}
			if (this.blueButton != null)
			{
				this.blueButton.onClick.RemoveAllListeners();
			}
			if (this.goldButton != null)
			{
				this.goldButton.onClick.RemoveAllListeners();
			}
			if (this.noBindItemButton != null)
			{
				this.noBindItemButton.onClick.RemoveAllListeners();
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
			}
			if (this.mergeButton != null)
			{
				this.mergeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600EA08 RID: 59912 RVA: 0x003DFB6F File Offset: 0x003DDF6F
		private void ClearData()
		{
			this._magicCardMergeAction = null;
			this._magicCardMergeData = null;
		}

		// Token: 0x0600EA09 RID: 59913 RVA: 0x003DFB7F File Offset: 0x003DDF7F
		public void InitData(MagicCardMergeData magicCardMergeData)
		{
			this._magicCardMergeData = magicCardMergeData;
			this._magicCardMergeAction = magicCardMergeData.MagicCardMergeAction;
			DataManager<MagicCardMergeDataManager>.GetInstance().ResetOneKeyMergeSetting();
			this.InitView();
		}

		// Token: 0x0600EA0A RID: 59914 RVA: 0x003DFBA4 File Offset: 0x003DDFA4
		private void InitView()
		{
			this.UpdateWhiteFlag();
			this.UpdateBlueFlag();
			this.UpdateGoldFlag();
			this.UpdateNoBindItemFlag();
		}

		// Token: 0x0600EA0B RID: 59915 RVA: 0x003DFBBE File Offset: 0x003DDFBE
		private void UpdateWhiteFlag()
		{
			if (this.whiteFlag != null)
			{
				this.whiteFlag.CustomActive(DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseWhiteCard);
			}
		}

		// Token: 0x0600EA0C RID: 59916 RVA: 0x003DFBE6 File Offset: 0x003DDFE6
		private void UpdateBlueFlag()
		{
			if (this.blueFlag != null)
			{
				this.blueFlag.CustomActive(DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseBlueCard);
			}
		}

		// Token: 0x0600EA0D RID: 59917 RVA: 0x003DFC0E File Offset: 0x003DE00E
		private void UpdateGoldFlag()
		{
			if (this.goldFlag != null)
			{
				this.goldFlag.CustomActive(DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold);
			}
		}

		// Token: 0x0600EA0E RID: 59918 RVA: 0x003DFC36 File Offset: 0x003DE036
		private void UpdateNoBindItemFlag()
		{
			if (this.noBindItemFlag != null)
			{
				this.noBindItemFlag.CustomActive(DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseNoBindItem);
			}
		}

		// Token: 0x0600EA0F RID: 59919 RVA: 0x003DFC5E File Offset: 0x003DE05E
		private void OnWhiteButtonClick()
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseWhiteCard = !DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseWhiteCard;
			this.UpdateWhiteFlag();
		}

		// Token: 0x0600EA10 RID: 59920 RVA: 0x003DFC7D File Offset: 0x003DE07D
		private void OnBlueButtonClick()
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseBlueCard = !DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseBlueCard;
			this.UpdateBlueFlag();
		}

		// Token: 0x0600EA11 RID: 59921 RVA: 0x003DFC9C File Offset: 0x003DE09C
		private void OnGoldButtonClick()
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold = !DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold;
			this.UpdateGoldFlag();
		}

		// Token: 0x0600EA12 RID: 59922 RVA: 0x003DFCBB File Offset: 0x003DE0BB
		private void OnNoBindItemButtonClick()
		{
			DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseNoBindItem = !DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseNoBindItem;
			this.UpdateNoBindItemFlag();
		}

		// Token: 0x0600EA13 RID: 59923 RVA: 0x003DFCDA File Offset: 0x003DE0DA
		private void OnCloseFrame()
		{
			MagicCardMergeUtility.OnCloseMagicCardOneKeyMergeTipFrame();
		}

		// Token: 0x0600EA14 RID: 59924 RVA: 0x003DFCE1 File Offset: 0x003DE0E1
		private void OnMergeClick()
		{
			if (this._magicCardMergeAction != null)
			{
				this._magicCardMergeAction();
			}
			this.OnCloseFrame();
		}

		// Token: 0x04008DE7 RID: 36327
		private MagicCardMergeData _magicCardMergeData;

		// Token: 0x04008DE8 RID: 36328
		private Action _magicCardMergeAction;

		// Token: 0x04008DE9 RID: 36329
		[Space(15f)]
		[Header("WhiteFlag")]
		[Space(5f)]
		[SerializeField]
		private Image whiteFlag;

		// Token: 0x04008DEA RID: 36330
		[SerializeField]
		private Button whiteButton;

		// Token: 0x04008DEB RID: 36331
		[Space(15f)]
		[Header("BlueFlag")]
		[Space(5f)]
		[SerializeField]
		private Image blueFlag;

		// Token: 0x04008DEC RID: 36332
		[SerializeField]
		private Button blueButton;

		// Token: 0x04008DED RID: 36333
		[Space(15f)]
		[Header("GoldFlag")]
		[Space(5f)]
		[SerializeField]
		private Image goldFlag;

		// Token: 0x04008DEE RID: 36334
		[SerializeField]
		private Button goldButton;

		// Token: 0x04008DEF RID: 36335
		[Space(15f)]
		[Header("BindItemFlag")]
		[Space(5f)]
		[SerializeField]
		private Image noBindItemFlag;

		// Token: 0x04008DF0 RID: 36336
		[SerializeField]
		private Button noBindItemButton;

		// Token: 0x04008DF1 RID: 36337
		[Space(10f)]
		[Header("Button")]
		[SerializeField]
		private Button cancelButton;

		// Token: 0x04008DF2 RID: 36338
		[SerializeField]
		private Button mergeButton;
	}
}
