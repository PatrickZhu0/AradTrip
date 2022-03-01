using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010C1 RID: 4289
	public class EasyChatItem : MonoBehaviour
	{
		// Token: 0x0600A226 RID: 41510 RVA: 0x00211456 File Offset: 0x0020F856
		public void Init(int index)
		{
			this.easyChatIndex = index;
			this.InitUI();
		}

		// Token: 0x0600A227 RID: 41511 RVA: 0x00211465 File Offset: 0x0020F865
		public void Recycle()
		{
			this.easyChatIndex = -1;
			if (this.mEasyChatBtn != null)
			{
				this.mEasyChatBtn.onClick.RemoveListener(new UnityAction(this.SendEasyChatMsg));
			}
		}

		// Token: 0x0600A228 RID: 41512 RVA: 0x0021149C File Offset: 0x0020F89C
		private void InitUI()
		{
			if (this.mEasyChatBtn != null)
			{
				this.mEasyChatBtn.onClick.AddListener(new UnityAction(this.SendEasyChatMsg));
			}
			if (this.mEasyChatText != null)
			{
				this.mEasyChatText.text = DataManager<BattleEasyChatDataManager>.GetInstance().GetEasyChatStringByIndex(this.easyChatIndex);
			}
		}

		// Token: 0x0600A229 RID: 41513 RVA: 0x00211502 File Offset: 0x0020F902
		private void SendEasyChatMsg()
		{
			DataManager<BattleEasyChatDataManager>.GetInstance().SendEasyChatTipsByIndex(this.easyChatIndex);
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonTeamChatFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonTeamChatFrame>(null, false);
			}
		}

		// Token: 0x04005A5A RID: 23130
		[SerializeField]
		private Button mEasyChatBtn;

		// Token: 0x04005A5B RID: 23131
		[SerializeField]
		private Text mEasyChatText;

		// Token: 0x04005A5C RID: 23132
		private int easyChatIndex;
	}
}
