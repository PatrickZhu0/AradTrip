using System;
using System.Collections;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019DA RID: 6618
	internal class OpenRedPacketFrame : ClientFrame
	{
		// Token: 0x06010370 RID: 66416 RVA: 0x00488E45 File Offset: 0x00487245
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RedPack/OpenRedPack";
		}

		// Token: 0x06010371 RID: 66417 RVA: 0x00488E4C File Offset: 0x0048724C
		protected override void _OnOpenFrame()
		{
			this.m_data = (this.userData as RedPacketDetail);
			if (this.m_data == null)
			{
				Logger.LogErrorFormat("open GuildOpenRedPacketFrame, userdata is invalid!", new object[0]);
				return;
			}
			string getMoneyIcon = DataManager<RedPackDataManager>.GetInstance().GetGetMoneyIcon((int)this.m_data.baseEntry.reason);
			string costMoneyIcon = DataManager<RedPackDataManager>.GetInstance().GetCostMoneyIcon((int)this.m_data.baseEntry.reason);
			ETCImageLoader.LoadSprite(ref this.m_imgOwnerHead, this._GetHeadByJobID((int)this.m_data.ownerIcon.occu), true);
			this.m_labOwnerLevel.text = this.m_data.ownerIcon.level.ToString();
			this.m_labOwnerName.text = TR.Value("WhoistheRedPack", this.m_data.ownerIcon.name);
			this.m_labRedPacketName.text = this.m_data.baseEntry.name;
			base.StartCoroutine(this._ShowDetail());
		}

		// Token: 0x06010372 RID: 66418 RVA: 0x00488F52 File Offset: 0x00487352
		protected override void _OnCloseFrame()
		{
			this.m_data = null;
		}

		// Token: 0x06010373 RID: 66419 RVA: 0x00488F5C File Offset: 0x0048735C
		private IEnumerator _ShowDetail()
		{
			float maxTime = 1f;
			float startTime = Time.time;
			float elapsed = 0f;
			while (elapsed < maxTime)
			{
				elapsed = Time.time - startTime;
				yield return Yielders.EndOfFrame;
			}
			this.frameMgr.OpenFrame<ShowOpenedRedPacketFrame>(FrameLayer.Middle, this.m_data, string.Empty);
			this.frameMgr.CloseFrame<OpenRedPacketFrame>(this, false);
			yield break;
		}

		// Token: 0x06010374 RID: 66420 RVA: 0x00488F78 File Offset: 0x00487378
		private string _GetHeadByJobID(int a_nJobID)
		{
			string result = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(a_nJobID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					result = tableItem2.IconPath;
				}
			}
			return result;
		}

		// Token: 0x06010375 RID: 66421 RVA: 0x00488FD0 File Offset: 0x004873D0
		[UIEventHandle("Content")]
		private void _OnOpenClicked()
		{
			this.frameMgr.OpenFrame<ShowOpenedRedPacketFrame>(FrameLayer.Middle, this.m_data, string.Empty);
			this.frameMgr.CloseFrame<OpenRedPacketFrame>(this, false);
		}

		// Token: 0x0400A3FE RID: 41982
		[UIControl("Content/Head/Viewport/Image", null, 0)]
		private Image m_imgOwnerHead;

		// Token: 0x0400A3FF RID: 41983
		[UIControl("Content/Head/Level", null, 0)]
		private Text m_labOwnerLevel;

		// Token: 0x0400A400 RID: 41984
		[UIControl("Content/Head/Name", null, 0)]
		private Text m_labOwnerName;

		// Token: 0x0400A401 RID: 41985
		[UIControl("Content/RedPackName", null, 0)]
		private Text m_labRedPacketName;

		// Token: 0x0400A402 RID: 41986
		private RedPacketDetail m_data;
	}
}
