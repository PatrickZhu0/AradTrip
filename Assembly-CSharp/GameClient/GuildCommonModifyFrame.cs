using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001604 RID: 5636
	internal class GuildCommonModifyFrame : ClientFrame
	{
		// Token: 0x0600DCBE RID: 56510 RVA: 0x0037C906 File Offset: 0x0037AD06
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildCommonModify";
		}

		// Token: 0x0600DCBF RID: 56511 RVA: 0x0037C910 File Offset: 0x0037AD10
		protected override void _OnOpenFrame()
		{
			this.m_data = (this.userData as GuildCommonModifyData);
			if (this.m_data == null)
			{
				return;
			}
			RectTransform component = this.frame.GetComponent<RectTransform>();
			Vector2 sizeDelta = component.sizeDelta;
			if (this.m_data.eMode == EGuildCommonModifyMode.Short)
			{
				sizeDelta.y = 500f;
				component.sizeDelta = sizeDelta;
				this.m_labEdit.alignment = 4;
			}
			else
			{
				sizeDelta.y = 600f;
				component.sizeDelta = sizeDelta;
				this.m_labEdit.alignment = 0;
			}
			if (this.m_labTitle != null)
			{
				this.m_labTitle.SafeSetText(this.m_data.strTitle);
			}
			if (this.m_data.bHasCost)
			{
				this.m_objCost.CustomActive(true);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.m_data.nCostID, 100, 0);
				if (itemData != null)
				{
					ETCImageLoader.LoadSprite(ref this.m_imgCostIcon, itemData.Icon, true);
				}
				if (this.m_labCostCount != null)
				{
					this.m_labCostCount.SafeSetText(this.m_data.nCostCount.ToString());
				}
			}
			else
			{
				this.m_objCost.CustomActive(false);
			}
			if (this.m_labWordsCount != null)
			{
				this.m_labWordsCount.SafeSetText(string.Format("{0}/{1}", 0, this.m_data.nMaxWords));
			}
			if (this.m_labPlaceholder != null)
			{
				this.m_labPlaceholder.SafeSetText(this.m_data.strEmptyDesc);
			}
			if (this.m_btnOK != null)
			{
				this.m_btnOK.onClick.RemoveAllListeners();
				this.m_btnOK.onClick.AddListener(delegate()
				{
					if (this.m_editLabDeclaration != null)
					{
						if (this.m_editLabDeclaration.text.Length <= 0)
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_modify_words_none"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
						else if (this.m_editLabDeclaration.text.Length > this.m_data.nMaxWords)
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_modify_words_more"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
						else if (this.m_data.onOkClicked != null)
						{
							this.m_data.onOkClicked.Invoke(this.m_editLabDeclaration.text);
						}
					}
				});
			}
			if (this.m_btnCancel != null)
			{
				this.m_btnCancel.onClick.RemoveAllListeners();
				this.m_btnCancel.onClick.AddListener(delegate()
				{
					if (this.m_data.onCancelClicked != null)
					{
						this.m_data.onCancelClicked.Invoke();
					}
					this.frameMgr.CloseFrame<GuildCommonModifyFrame>(this, false);
				});
			}
			if (this.m_editLabDeclaration != null)
			{
				this.m_editLabDeclaration.onValueChanged.RemoveAllListeners();
				this.m_editLabDeclaration.onValueChanged.AddListener(delegate(string a_strValue)
				{
					this.m_labWordsCount.SafeSetText(string.Format("{0}/{1}", a_strValue.Length, this.m_data.nMaxWords));
				});
				this.m_editLabDeclaration.text = this.m_data.strDefultContent;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600DCC0 RID: 56512 RVA: 0x0037CB9E File Offset: 0x0037AF9E
		protected override void _OnCloseFrame()
		{
			this.m_data = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600DCC1 RID: 56513 RVA: 0x0037CBC2 File Offset: 0x0037AFC2
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildCommonModifyFrame>(this, false);
		}

		// Token: 0x0400824E RID: 33358
		[UIControl("Content/BG/Count", null, 0)]
		private Text m_labWordsCount;

		// Token: 0x0400824F RID: 33359
		[UIControl("Bottom/Ok/Cost/Icon", null, 0)]
		private Image m_imgCostIcon;

		// Token: 0x04008250 RID: 33360
		[UIControl("Bottom/Ok/Cost/Count", null, 0)]
		private Text m_labCostCount;

		// Token: 0x04008251 RID: 33361
		[UIObject("Bottom/Ok/Cost")]
		private GameObject m_objCost;

		// Token: 0x04008252 RID: 33362
		[UIControl("Title/Name", null, 0)]
		private Text m_labTitle;

		// Token: 0x04008253 RID: 33363
		[UIControl("Content/BG/InputField/Placeholder", null, 0)]
		private Text m_labPlaceholder;

		// Token: 0x04008254 RID: 33364
		[UIControl("Bottom/Ok", null, 0)]
		private Button m_btnOK;

		// Token: 0x04008255 RID: 33365
		[UIControl("Title/Close", null, 0)]
		private Button m_btnCancel;

		// Token: 0x04008256 RID: 33366
		[UIControl("Content/BG/InputField", typeof(InputField), 0)]
		private InputField m_editLabDeclaration;

		// Token: 0x04008257 RID: 33367
		[UIControl("Content/BG/InputField/Text", null, 0)]
		private Text m_labEdit;

		// Token: 0x04008258 RID: 33368
		private GuildCommonModifyData m_data;
	}
}
