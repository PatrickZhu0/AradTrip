using System;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A1A RID: 6682
	public class CDKRewardSettings : SettingsBindUI
	{
		// Token: 0x060106AC RID: 67244 RVA: 0x0049E7F5 File Offset: 0x0049CBF5
		public CDKRewardSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x060106AD RID: 67245 RVA: 0x0049E7FF File Offset: 0x0049CBFF
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/cdkCharge";
		}

		// Token: 0x060106AE RID: 67246 RVA: 0x0049E808 File Offset: 0x0049CC08
		protected override void InitBind()
		{
			this.pasteBtn = this.mBind.GetCom<Button>("PasteBtn");
			this.pasteBtn.onClick.AddListener(new UnityAction(this.OnPasteBtnClick));
			this.inputBtn = this.mBind.GetCom<Button>("InputBtn");
			this.inputBtn.onClick.AddListener(new UnityAction(this.OnInputBtnClick));
			this.inputText = this.mBind.GetCom<InputField>("InputField");
		}

		// Token: 0x060106AF RID: 67247 RVA: 0x0049E890 File Offset: 0x0049CC90
		protected override void UnInitBind()
		{
			if (this.pasteBtn)
			{
				this.pasteBtn.onClick.RemoveListener(new UnityAction(this.OnPasteBtnClick));
			}
			this.pasteBtn = null;
			if (this.inputBtn)
			{
				this.inputBtn.onClick.RemoveListener(new UnityAction(this.OnInputBtnClick));
			}
			this.inputBtn = null;
			this.inputText = null;
		}

		// Token: 0x060106B0 RID: 67248 RVA: 0x0049E90A File Offset: 0x0049CD0A
		protected override void OnShowOut()
		{
		}

		// Token: 0x060106B1 RID: 67249 RVA: 0x0049E90C File Offset: 0x0049CD0C
		protected override void OnHideIn()
		{
			if (this.inputText)
			{
				this.inputText.text = string.Empty;
			}
		}

		// Token: 0x060106B2 RID: 67250 RVA: 0x0049E92E File Offset: 0x0049CD2E
		private void OnPasteBtnClick()
		{
			this.inputText.text = SDKInterface.instance.GetClipboardText();
		}

		// Token: 0x060106B3 RID: 67251 RVA: 0x0049E948 File Offset: 0x0049CD48
		private void OnInputBtnClick()
		{
			if (!string.IsNullOrEmpty(this.inputText.text))
			{
				string text = this.inputText.text;
				text = text.Replace("\r", string.Empty);
				text = text.Replace("\n", string.Empty);
				text = text.Replace("\t", string.Empty);
				text = text.Replace(" ", string.Empty);
				Singleton<CDKManager>.GetInstance().SendCDKcode(text.Trim());
			}
		}

		// Token: 0x060106B4 RID: 67252 RVA: 0x0049E9CC File Offset: 0x0049CDCC
		private void OnCDKReturn(CDKData cdkData)
		{
			switch (cdkData.CDKReturnCode)
			{
			case 0U:
				SystemNotifyManager.SysNotifyTextAnimation("已兑换奖励，请在邮箱查收", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 1U:
				SystemNotifyManager.SysNotifyTextAnimation("礼包卡不正确，请重新输入", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 2U:
				SystemNotifyManager.SysNotifyTextAnimation("您的礼包卡已超出使用有效期", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 3U:
				SystemNotifyManager.SysNotifyTextAnimation("您的礼包卡已被使用，无法再次使用", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case 4U:
				SystemNotifyManager.SysNotifyTextAnimation("您输入的礼包卡无效，请核实礼包卡兑换条件", CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			}
		}

		// Token: 0x0400A6CF RID: 42703
		private Button pasteBtn;

		// Token: 0x0400A6D0 RID: 42704
		private Button inputBtn;

		// Token: 0x0400A6D1 RID: 42705
		private InputField inputText;

		// Token: 0x02001A1B RID: 6683
		private enum CDKCodeMsgType
		{
			// Token: 0x0400A6D3 RID: 42707
			Succ,
			// Token: 0x0400A6D4 RID: 42708
			Wrong,
			// Token: 0x0400A6D5 RID: 42709
			OutDate,
			// Token: 0x0400A6D6 RID: 42710
			Used,
			// Token: 0x0400A6D7 RID: 42711
			Invalid
		}
	}
}
