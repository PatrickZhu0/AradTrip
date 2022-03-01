using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000032 RID: 50
	internal class ComGuidanceMainItem : MonoBehaviour
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0000CF18 File Offset: 0x0000B318
		public void OnClickLink()
		{
			if (this.value != null)
			{
				string text = this.value.LinkInfo;
				if (text.Contains("888888"))
				{
					int lastedDungeonIDByDiff = ChapterUtility.GetLastedDungeonIDByDiff(3);
					if (lastedDungeonIDByDiff == -1)
					{
						text = "<type=sceneid value=6002>";
					}
					else
					{
						text.Replace("888888", string.Empty + lastedDungeonIDByDiff);
					}
				}
				else if (text.Contains("999999"))
				{
					ChapterSelectFrame.SetDungeonID(999999);
					text = "<type=sceneid value=6002>";
				}
				if (this.value.bCloseFrame == 1 && this.frame != null)
				{
					this.frame.Close(true);
					this.frame = null;
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(text, null, false);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000159 RID: 345 RVA: 0x0000CFE2 File Offset: 0x0000B3E2
		public GuidanceMainItemTable Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000CFEA File Offset: 0x0000B3EA
		private void OnDestroy()
		{
			this.kIcon = null;
			this.kDesc = null;
			this.value = null;
			this.frame = null;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000D008 File Offset: 0x0000B408
		public void OnVisible(GuidanceMainItemTable data, ClientFrame clientFrame)
		{
			this.value = data;
			this.frame = (clientFrame as DevelopGuidanceMainFrame);
			if (this.value != null)
			{
				ETCImageLoader.LoadSprite(ref this.kIcon, this.value.Icon, true);
				this.kDesc.text = this.value.Desc;
			}
		}

		// Token: 0x0400012C RID: 300
		public Image kIcon;

		// Token: 0x0400012D RID: 301
		public Text kDesc;

		// Token: 0x0400012E RID: 302
		public const string TO_CHAPTER = "<type=sceneid value=6002>";

		// Token: 0x0400012F RID: 303
		public const string LINK_KING_LEVEL = "888888";

		// Token: 0x04000130 RID: 304
		public const string LINK_BOX = "999999";

		// Token: 0x04000131 RID: 305
		public const int LINK_BOX_INT = 999999;

		// Token: 0x04000132 RID: 306
		private GuidanceMainItemTable value;

		// Token: 0x04000133 RID: 307
		private DevelopGuidanceMainFrame frame;
	}
}
