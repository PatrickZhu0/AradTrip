using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001605 RID: 5637
	internal class GuildCreateFrame : ClientFrame
	{
		// Token: 0x0600DCC6 RID: 56518 RVA: 0x0037CCE6 File Offset: 0x0037B0E6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildCreate";
		}

		// Token: 0x0600DCC7 RID: 56519 RVA: 0x0037CCF0 File Offset: 0x0037B0F0
		protected override void _OnOpenFrame()
		{
			this.m_labName.text = string.Empty;
			this.m_labDeclaration.text = string.Empty;
			this.m_costInfo = new CostItemManager.CostInfo();
			this.m_costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
			this.m_costInfo.nCount = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(117, string.Empty, string.Empty).Value;
			if (DataManager<CostItemManager>.GetInstance().IsEnough2Cost(this.m_costInfo))
			{
				this.m_labCostCount.text = this.m_costInfo.nCount.ToString();
			}
			else
			{
				this.m_labCostCount.text = TR.Value("color_red", this.m_costInfo.nCount);
			}
			ItemData moneyTableDataByType = DataManager<ItemDataManager>.GetInstance().GetMoneyTableDataByType(ItemTable.eSubType.GOLD);
			ETCImageLoader.LoadSprite(ref this.m_imgCostIcon, moneyTableDataByType.Icon, true);
			this.m_labTipCreateCost.text = TR.Value("guild_tip_create_cost", this.m_costInfo.nCount);
			this.m_nNameMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(120, string.Empty, string.Empty).Value;
			this.m_nDeclarationMaxWords = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(119, string.Empty, string.Empty).Value;
			this.m_labNameCount.text = string.Format("{0}/{1}", 0, this.m_nNameMaxWords);
			this.m_nameInput.onValueChanged.RemoveAllListeners();
			this.m_nameInput.onValueChanged.AddListener(delegate(string a_strValue)
			{
				this.m_labNameCount.text = string.Format("{0}/{1}", a_strValue.Length, this.m_nNameMaxWords);
			});
			this.m_labWordsCount.text = string.Format("{0}/{1}", 0, this.m_nDeclarationMaxWords);
			this.m_editLabDeclaration.onValueChanged.RemoveAllListeners();
			this.m_editLabDeclaration.onValueChanged.AddListener(delegate(string a_strValue)
			{
				this.m_labWordsCount.text = string.Format("{0}/{1}", a_strValue.Length, this.m_nDeclarationMaxWords);
			});
			this.m_objHelpContent.SetActive(false);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataBaseUpdated));
		}

		// Token: 0x0600DCC8 RID: 56520 RVA: 0x0037CF2F File Offset: 0x0037B32F
		protected override void _OnCloseFrame()
		{
			this.m_costInfo = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataBaseUpdated));
		}

		// Token: 0x0600DCC9 RID: 56521 RVA: 0x0037CF6B File Offset: 0x0037B36B
		private void _OnCreateSuccess(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildCreateFrame>(this, false);
			this.frameMgr.CloseFrame<GuildListFrame>(null, false);
			this.frameMgr.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DCCA RID: 56522 RVA: 0x0037CF9C File Offset: 0x0037B39C
		private void _OnPlayerDataBaseUpdated(UIEvent a_event)
		{
			if (DataManager<CostItemManager>.GetInstance().IsEnough2Cost(this.m_costInfo))
			{
				this.m_labCostCount.text = this.m_costInfo.nCount.ToString();
			}
			else
			{
				this.m_labCostCount.text = TR.Value("color_red", this.m_costInfo.nCount);
			}
		}

		// Token: 0x0600DCCB RID: 56523 RVA: 0x0037D00C File Offset: 0x0037B40C
		[UIEventHandle("Content/Ok")]
		private void _OnCreateGuildOKClicked()
		{
			if (string.IsNullOrEmpty(this.m_labName.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_create_need_name"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (string.IsNullOrEmpty(this.m_labDeclaration.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_create_need_declaration"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_labName.text.Length > this.m_nNameMaxWords)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_create_name_length_invalid", this.m_nNameMaxWords), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_labDeclaration.text.Length > this.m_nDeclarationMaxWords)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_create_declaration_length_invalid", this.m_nDeclarationMaxWords), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(this.m_costInfo, delegate
			{
				DataManager<GuildDataManager>.GetInstance().CreateGuild(this.m_labName.text, this.m_labDeclaration.text);
			}, "common_money_cost", null);
		}

		// Token: 0x0600DCCC RID: 56524 RVA: 0x0037D0F5 File Offset: 0x0037B4F5
		[UIEventHandle("Title/Close")]
		private void _OnCreateGuildCancelClicked()
		{
			this.frameMgr.CloseFrame<GuildCreateFrame>(this, false);
		}

		// Token: 0x04008259 RID: 33369
		[UIControl("Content/Name/InputField", null, 0)]
		private InputField m_nameInput;

		// Token: 0x0400825A RID: 33370
		[UIControl("Content/Name/InputField/Text", null, 0)]
		private Text m_labName;

		// Token: 0x0400825B RID: 33371
		[UIControl("Content/Name/Count", null, 0)]
		private Text m_labNameCount;

		// Token: 0x0400825C RID: 33372
		[UIControl("Content/Declaration/InputField/Text", null, 0)]
		private Text m_labDeclaration;

		// Token: 0x0400825D RID: 33373
		[UIControl("Content/Declaration/Count", null, 0)]
		private Text m_labWordsCount;

		// Token: 0x0400825E RID: 33374
		[UIControl("Content/Declaration/InputField", typeof(InputField), 0)]
		private InputField m_editLabDeclaration;

		// Token: 0x0400825F RID: 33375
		[UIControl("Content/Ok/Count", null, 0)]
		private Text m_labCostCount;

		// Token: 0x04008260 RID: 33376
		[UIControl("Content/Ok/Icon", null, 0)]
		private Image m_imgCostIcon;

		// Token: 0x04008261 RID: 33377
		[UIObject("HelpDesc")]
		private GameObject m_objHelpContent;

		// Token: 0x04008262 RID: 33378
		[UIControl("HelpDesc/Text", null, 0)]
		private Text m_labTipCreateCost;

		// Token: 0x04008263 RID: 33379
		private CostItemManager.CostInfo m_costInfo;

		// Token: 0x04008264 RID: 33380
		private int m_nNameMaxWords;

		// Token: 0x04008265 RID: 33381
		private int m_nDeclarationMaxWords;
	}
}
