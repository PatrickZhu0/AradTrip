using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017C8 RID: 6088
	public class MiyaSendDoorFrame : ClientFrame
	{
		// Token: 0x0600F02B RID: 61483 RVA: 0x0040A4E2 File Offset: 0x004088E2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MiyaSendDoor/MiyaSendDoorFrame";
		}

		// Token: 0x0600F02C RID: 61484 RVA: 0x0040A4EC File Offset: 0x004088EC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.userData != null)
			{
				this._sendDoorModelData = (this.userData as SendDoorModelData);
			}
			this.defaultType = CityTeleportTable.eTabType.TabType_None;
			if (this._sendDoorModelData != null)
			{
				this.defaultType = this._sendDoorModelData.ModelType;
			}
			if (this.mModelControlRoot != null)
			{
				this.mModelControlRoot.InitMapModelControl(this.defaultType, new OnSendDoorMapToggleClick(this.OnSendDoorMapToggleClick));
			}
		}

		// Token: 0x0600F02D RID: 61485 RVA: 0x0040A56C File Offset: 0x0040896C
		private void OnSendDoorMapToggleClick(CityTeleportTable.eTabType modelType)
		{
			if (this.defaultType == CityTeleportTable.eTabType.TabType_None)
			{
				this.defaultType = CityTeleportTable.eTabType.AlardLand;
			}
			if (this.mContentControlRoot != null)
			{
				this.mContentControlRoot.ShowMapContent(modelType);
			}
		}

		// Token: 0x0600F02E RID: 61486 RVA: 0x0040A59D File Offset: 0x0040899D
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600F02F RID: 61487 RVA: 0x0040A5A5 File Offset: 0x004089A5
		private void ClearData()
		{
			this._sendDoorModelData = null;
			this.defaultType = CityTeleportTable.eTabType.TabType_None;
		}

		// Token: 0x0600F030 RID: 61488 RVA: 0x0040A5B8 File Offset: 0x004089B8
		protected override void _bindExUI()
		{
			this.mModelControlRoot = this.mBind.GetCom<SendDoorMapModelControl>("modelControlRoot");
			this.mContentControlRoot = this.mBind.GetCom<SendDoorMapContentControl>("contentControlRoot");
			this.mCloseButton = this.mBind.GetCom<Button>("closeButton");
			this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseButtonButtonClick));
		}

		// Token: 0x0600F031 RID: 61489 RVA: 0x0040A623 File Offset: 0x00408A23
		protected override void _unbindExUI()
		{
			this.mModelControlRoot = null;
			this.mContentControlRoot = null;
			this.mCloseButton.onClick.RemoveListener(new UnityAction(this._onCloseButtonButtonClick));
			this.mCloseButton = null;
		}

		// Token: 0x0600F032 RID: 61490 RVA: 0x0040A656 File Offset: 0x00408A56
		private void _onCloseButtonButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x04009337 RID: 37687
		private CityTeleportTable.eTabType defaultType;

		// Token: 0x04009338 RID: 37688
		private SendDoorModelData _sendDoorModelData;

		// Token: 0x04009339 RID: 37689
		private SendDoorMapModelControl mModelControlRoot;

		// Token: 0x0400933A RID: 37690
		private SendDoorMapContentControl mContentControlRoot;

		// Token: 0x0400933B RID: 37691
		private Button mCloseButton;
	}
}
