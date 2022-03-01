using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001488 RID: 5256
	public class AuctionNewMagicCardStrengthenLevelItem : MonoBehaviour
	{
		// Token: 0x0600CBC6 RID: 52166 RVA: 0x0031EE5E File Offset: 0x0031D25E
		private void Awake()
		{
			this._dataModel = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600CBC7 RID: 52167 RVA: 0x0031EE6D File Offset: 0x0031D26D
		private void BindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnItemButtonClick));
			}
		}

		// Token: 0x0600CBC8 RID: 52168 RVA: 0x0031EEAC File Offset: 0x0031D2AC
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600CBC9 RID: 52169 RVA: 0x0031EEB4 File Offset: 0x0031D2B4
		private void UnBindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CBCA RID: 52170 RVA: 0x0031EED7 File Offset: 0x0031D2D7
		public virtual void InitItem(AuctionNewMagicCardStrengthenLevelDataModel itemData, OnMagicCardStrengthenLevelItemClick onItemClick = null)
		{
			this._dataModel = itemData;
			if (this._dataModel == null)
			{
				return;
			}
			this._onItemButtonClick = onItemClick;
			this.InitView();
		}

		// Token: 0x0600CBCB RID: 52171 RVA: 0x0031EEF9 File Offset: 0x0031D2F9
		private void InitView()
		{
			this.UpdateMagicCardItem();
		}

		// Token: 0x0600CBCC RID: 52172 RVA: 0x0031EF01 File Offset: 0x0031D301
		private void ResetItemImage()
		{
			this.UpdateItemImageVisible(this.disableImage, false);
			this.UpdateItemImageVisible(this.normalBackgroundImage, false);
			this.UpdateItemImageVisible(this.selectedBackgroundImage, false);
		}

		// Token: 0x0600CBCD RID: 52173 RVA: 0x0031EF2A File Offset: 0x0031D32A
		private void UpdateItemImageVisible(Image image, bool flag)
		{
			if (image != null)
			{
				image.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CBCE RID: 52174 RVA: 0x0031EF44 File Offset: 0x0031D344
		public void UpdateMagicCardItem()
		{
			if (this._dataModel == null)
			{
				return;
			}
			this.ResetItemImage();
			if (this._dataModel.Number <= 0)
			{
				this.UpdateItemImageVisible(this.disableImage, true);
				this.UpdateItemImageVisible(this.normalBackgroundImage, false);
				this.UpdateItemImageVisible(this.selectedBackgroundImage, false);
				this.UpdateItemText(false, false);
			}
			else
			{
				this.UpdateItemImageVisible(this.disableImage, false);
				if (this._dataModel.IsSelected)
				{
					this.UpdateItemImageVisible(this.selectedBackgroundImage, true);
					this.UpdateItemText(true, true);
				}
				else
				{
					this.UpdateItemImageVisible(this.normalBackgroundImage, true);
					this.UpdateItemText(true, false);
				}
			}
		}

		// Token: 0x0600CBCF RID: 52175 RVA: 0x0031EFF4 File Offset: 0x0031D3F4
		private void UpdateItemText(bool isHaveNumber, bool isSelected = false)
		{
			if (this.levelText != null)
			{
				if (!isHaveNumber)
				{
					this.levelText.text = TR.Value("auction_new_magic_card_strengthen_level_less", this._dataModel.StrengthenLevel);
				}
				else if (isSelected)
				{
					this.levelText.text = TR.Value("auction_new_magic_card_strengthen_level_selected", this._dataModel.StrengthenLevel);
				}
				else
				{
					this.levelText.text = TR.Value("auction_new_magic_card_strengthen_level", this._dataModel.StrengthenLevel);
				}
			}
			if (this.numberText != null)
			{
				if (!isHaveNumber)
				{
					this.numberText.text = TR.Value("auction_new_magic_card_number_less", this._dataModel.Number);
				}
				else if (isSelected)
				{
					this.numberText.text = TR.Value("auction_new_magic_card_number_selected", this._dataModel.Number);
				}
				else
				{
					this.numberText.text = TR.Value("auction_new_magic_card_number", this._dataModel.Number);
				}
			}
		}

		// Token: 0x0600CBD0 RID: 52176 RVA: 0x0031F130 File Offset: 0x0031D530
		private void OnItemButtonClick()
		{
			if (this._dataModel.Number <= 0)
			{
				return;
			}
			this._dataModel.IsSelected = true;
			if (this._onItemButtonClick != null)
			{
				this._onItemButtonClick(this._dataModel.StrengthenLevel);
			}
			this.UpdateMagicCardItem();
		}

		// Token: 0x04007660 RID: 30304
		private OnMagicCardStrengthenLevelItemClick _onItemButtonClick;

		// Token: 0x04007661 RID: 30305
		protected AuctionNewMagicCardStrengthenLevelDataModel _dataModel;

		// Token: 0x04007662 RID: 30306
		[SerializeField]
		private Text levelText;

		// Token: 0x04007663 RID: 30307
		[SerializeField]
		private Text numberText;

		// Token: 0x04007664 RID: 30308
		[SerializeField]
		private Image normalBackgroundImage;

		// Token: 0x04007665 RID: 30309
		[SerializeField]
		private Image selectedBackgroundImage;

		// Token: 0x04007666 RID: 30310
		[SerializeField]
		private Image disableImage;

		// Token: 0x04007667 RID: 30311
		[SerializeField]
		private Button button;
	}
}
