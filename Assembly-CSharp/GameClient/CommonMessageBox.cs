using System;
using System.Text.RegularExpressions;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AEF RID: 6895
	public class CommonMessageBox : ClientFrame
	{
		// Token: 0x17001D7D RID: 7549
		// (get) Token: 0x06010EC8 RID: 69320 RVA: 0x004D55F6 File Offset: 0x004D39F6
		// (set) Token: 0x06010EC9 RID: 69321 RVA: 0x004D55FE File Offset: 0x004D39FE
		private MsgBoxData Value
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
			}
		}

		// Token: 0x17001D7E RID: 7550
		// (get) Token: 0x06010ECA RID: 69322 RVA: 0x004D5607 File Offset: 0x004D3A07
		private bool IsReverse
		{
			get
			{
				return this._HasFlag(MsgBoxDataType.MBDT_REVERSE);
			}
		}

		// Token: 0x06010ECB RID: 69323 RVA: 0x004D5610 File Offset: 0x004D3A10
		private bool _HasFlag(MsgBoxDataType eFlag)
		{
			return (eFlag & this.Value.flags) == eFlag;
		}

		// Token: 0x06010ECC RID: 69324 RVA: 0x004D5622 File Offset: 0x004D3A22
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/CrazyAdjustFinish";
		}

		// Token: 0x06010ECD RID: 69325 RVA: 0x004D562C File Offset: 0x004D3A2C
		protected override void _OnOpenFrame()
		{
			this.Value = (this.userData as MsgBoxData);
			this.title.text = this.Value.title;
			this.con.text = this.Value.content;
			if (this.IsReverse)
			{
				this.ok.text = this.Value.cancel;
				this.cancel.text = this.Value.ok;
			}
			else
			{
				this.ok.text = this.Value.ok;
				this.cancel.text = this.Value.cancel;
			}
			this.goTitle.CustomActive(this._HasFlag(MsgBoxDataType.MBDT_TITLE));
		}

		// Token: 0x06010ECE RID: 69326 RVA: 0x004D56F0 File Offset: 0x004D3AF0
		protected override void _OnCloseFrame()
		{
			this.Value = null;
		}

		// Token: 0x06010ECF RID: 69327 RVA: 0x004D56FC File Offset: 0x004D3AFC
		[UIEventHandle("OK")]
		private void OnClickOK()
		{
			if (this.IsReverse)
			{
				if (this.Value.OnCancel != null)
				{
					this.Value.OnCancel.Invoke();
				}
			}
			else if (this.Value.OnOK != null)
			{
				this.Value.OnOK.Invoke();
			}
			base.Close(false);
		}

		// Token: 0x06010ED0 RID: 69328 RVA: 0x004D5760 File Offset: 0x004D3B60
		[UIEventHandle("CANCEL")]
		private void OnClickCancel()
		{
			if (this.IsReverse)
			{
				if (this.Value.OnOK != null)
				{
					this.Value.OnOK.Invoke();
				}
			}
			else if (this.Value.OnCancel != null)
			{
				this.Value.OnCancel.Invoke();
			}
			base.Close(false);
		}

		// Token: 0x06010ED1 RID: 69329 RVA: 0x004D57C4 File Offset: 0x004D3BC4
		[UIEventHandle("Title/closeicon")]
		private void OnClickCancel2()
		{
			this.OnClickCancel();
		}

		// Token: 0x06010ED2 RID: 69330 RVA: 0x004D57CC File Offset: 0x004D3BCC
		private static string TranslateMsg(string des, params object[] args)
		{
			string text = des;
			if (args != null)
			{
				string format = Regex.Replace(text, "\\{[\\w]*\\:([\\d]*)\\}", "{$1}");
				text = string.Format(format, args);
			}
			return text.Replace("\\n", "\n");
		}

		// Token: 0x06010ED3 RID: 69331 RVA: 0x004D580C File Offset: 0x004D3C0C
		public static void Notify(int iID, string path, object[] arg0 = null, UnityAction ok = null, UnityAction cancel = null, object[] arg1 = null, object[] arg2 = null, object[] arg3 = null)
		{
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(iID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find common desc id = {0}", new object[]
				{
					iID
				});
				return;
			}
			if (string.IsNullOrEmpty(path))
			{
				Logger.LogErrorFormat("prefab path is error!", new object[0]);
				return;
			}
			MsgBoxDataType msgBoxDataType = MsgBoxDataType.MBDT_OK;
			if (tableItem.ShowType == CommonTipsDesc.eShowType.CT_MSG_BOX_OK)
			{
				msgBoxDataType = MsgBoxDataType.MBDT_OK;
			}
			else if (tableItem.ShowType == CommonTipsDesc.eShowType.CT_MSG_BOX_OK_CANCEL)
			{
				msgBoxDataType = (MsgBoxDataType)3;
			}
			else if (tableItem.ShowType == CommonTipsDesc.eShowType.CT_MSG_BOX_CANCEL_OK)
			{
				msgBoxDataType = (MsgBoxDataType)11;
			}
			if (!string.IsNullOrEmpty(tableItem.TitleText) && !string.Equals("-", tableItem.TitleText))
			{
				msgBoxDataType |= MsgBoxDataType.MBDT_TITLE;
			}
			CommonMessageBox.Notify(new MsgBoxData
			{
				prefab = path,
				content = CommonMessageBox.TranslateMsg(tableItem.Descs, arg0),
				title = CommonMessageBox.TranslateMsg(tableItem.TitleText, arg1),
				ok = CommonMessageBox.TranslateMsg(tableItem.ButtonText, arg2),
				cancel = CommonMessageBox.TranslateMsg(tableItem.CancelBtnText, arg3),
				OnOK = ok,
				OnCancel = cancel,
				flags = msgBoxDataType,
				iID = iID
			});
		}

		// Token: 0x06010ED4 RID: 69332 RVA: 0x004D5946 File Offset: 0x004D3D46
		public static void Notify(MsgBoxData data)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonMessageBox>(FrameLayer.Middle, data, "CommonMessageBox" + data.iID);
		}

		// Token: 0x0400ADEC RID: 44524
		[UIControl("Title/titletext", typeof(Text), 0)]
		private Text title;

		// Token: 0x0400ADED RID: 44525
		[UIControl("Content", typeof(Text), 0)]
		private Text con;

		// Token: 0x0400ADEE RID: 44526
		[UIControl("OK/Image", typeof(Text), 0)]
		private Text ok;

		// Token: 0x0400ADEF RID: 44527
		[UIControl("CANCEL/Image", typeof(Text), 0)]
		private Text cancel;

		// Token: 0x0400ADF0 RID: 44528
		[UIControl("OK", typeof(Button), 0)]
		private Button OK;

		// Token: 0x0400ADF1 RID: 44529
		[UIControl("CANCEL", typeof(Button), 0)]
		private Button CANCEL;

		// Token: 0x0400ADF2 RID: 44530
		[UIObject("Title")]
		private GameObject goTitle;

		// Token: 0x0400ADF3 RID: 44531
		private MsgBoxData data;
	}
}
