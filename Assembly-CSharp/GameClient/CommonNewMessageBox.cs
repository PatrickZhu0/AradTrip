using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001AF2 RID: 6898
	public class CommonNewMessageBox : ClientFrame
	{
		// Token: 0x06010ED8 RID: 69336 RVA: 0x004D5997 File Offset: 0x004D3D97
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/CrazyAdjustConfirmFrame";
		}

		// Token: 0x06010ED9 RID: 69337 RVA: 0x004D59A0 File Offset: 0x004D3DA0
		protected override void _OnOpenFrame()
		{
			MsgBoxNewdata data = this.userData as MsgBoxNewdata;
			if (this.mCrazyAdjustConfirmView != null)
			{
				this.mCrazyAdjustConfirmView.InitData(data);
			}
		}

		// Token: 0x06010EDA RID: 69338 RVA: 0x004D59D6 File Offset: 0x004D3DD6
		protected override void _OnCloseFrame()
		{
			if (this.mCrazyAdjustConfirmView != null)
			{
				this.mCrazyAdjustConfirmView.Clear();
			}
		}

		// Token: 0x06010EDB RID: 69339 RVA: 0x004D59F4 File Offset: 0x004D3DF4
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

		// Token: 0x06010EDC RID: 69340 RVA: 0x004D5A34 File Offset: 0x004D3E34
		protected override void _bindExUI()
		{
			this.mCrazyAdjustConfirmView = this.mBind.GetCom<CommonNewMessageBoxView>("CommonNewMessageBoxView");
		}

		// Token: 0x06010EDD RID: 69341 RVA: 0x004D5A4C File Offset: 0x004D3E4C
		protected override void _unbindExUI()
		{
			this.mCrazyAdjustConfirmView = null;
		}

		// Token: 0x06010EDE RID: 69342 RVA: 0x004D5A58 File Offset: 0x004D3E58
		public static void Notify(string path, int iID, UnityAction ok = null, UnityAction cancel = null, List<ToggleEvent> toggleAction = null, object[] arg0 = null, object[] arg1 = null, object[] arg2 = null, object[] arg3 = null, FrameLayer eLayer = FrameLayer.Middle)
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
			CommonNewMessageBox.Notify(new MsgBoxNewdata
			{
				prefab = path,
				content = CommonNewMessageBox.TranslateMsg(tableItem.Descs, arg0),
				title = CommonNewMessageBox.TranslateMsg(tableItem.TitleText, arg1),
				ok = CommonNewMessageBox.TranslateMsg(tableItem.ButtonText, arg2),
				cancel = CommonNewMessageBox.TranslateMsg(tableItem.CancelBtnText, arg3),
				OnOK = ok,
				OnCancel = cancel,
				ToggleListEvent = toggleAction,
				flags = msgBoxDataType,
				iID = iID,
				eLayer = eLayer
			});
		}

		// Token: 0x06010EDF RID: 69343 RVA: 0x004D5BA2 File Offset: 0x004D3FA2
		public static void Notify(MsgBoxNewdata data)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonNewMessageBox>(data.eLayer, data, "CommonNewMessageBox" + data.iID);
		}

		// Token: 0x0400AE01 RID: 44545
		private CommonNewMessageBoxView mCrazyAdjustConfirmView;
	}
}
