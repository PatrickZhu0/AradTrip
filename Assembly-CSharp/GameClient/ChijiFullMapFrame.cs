using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001108 RID: 4360
	public class ChijiFullMapFrame : ClientFrame
	{
		// Token: 0x0600A541 RID: 42305 RVA: 0x002218CB File Offset: 0x0021FCCB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiFullMapFrame";
		}

		// Token: 0x170019C6 RID: 6598
		// (get) Token: 0x0600A542 RID: 42306 RVA: 0x002218D2 File Offset: 0x0021FCD2
		public ChijiMapFrame MapFrame
		{
			get
			{
				return this.m_mapFrame;
			}
		}

		// Token: 0x0600A543 RID: 42307 RVA: 0x002218DA File Offset: 0x0021FCDA
		protected override void _OnOpenFrame()
		{
			this.m_mapFrame = (this.frameMgr.OpenFrame<ChijiMapFrame>(this.mContent, ChijiMapState.Full_Map, "chiji_full_map") as ChijiMapFrame);
		}

		// Token: 0x0600A544 RID: 42308 RVA: 0x00221903 File Offset: 0x0021FD03
		protected override void _OnCloseFrame()
		{
			this.frameMgr.CloseFrame<ChijiMapFrame>(this.m_mapFrame, false);
		}

		// Token: 0x0600A545 RID: 42309 RVA: 0x00221918 File Offset: 0x0021FD18
		protected override void _bindExUI()
		{
			this.mContent = this.mBind.GetGameObject("content");
			this.mClose = this.mBind.GetCom<Button>("close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0600A546 RID: 42310 RVA: 0x0022197E File Offset: 0x0021FD7E
		protected override void _unbindExUI()
		{
			this.mContent = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x0600A547 RID: 42311 RVA: 0x002219BB File Offset: 0x0021FDBB
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiFullMapFrame>(this, false);
		}

		// Token: 0x04005C39 RID: 23609
		private ChijiMapFrame m_mapFrame;

		// Token: 0x04005C3A RID: 23610
		private GameObject mContent;

		// Token: 0x04005C3B RID: 23611
		private Button mClose;
	}
}
