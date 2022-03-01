using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014DF RID: 5343
	public class ChampionshipAvatarView : MonoBehaviour
	{
		// Token: 0x0600CF4A RID: 53066 RVA: 0x0033270C File Offset: 0x00330B0C
		public void Init(ChampionshipTopPlayerDataModel leftPlayerDataModel, ChampionshipTopPlayerDataModel rightPlayerDataModel)
		{
			if (this.leftPlayerItem != null)
			{
				if (leftPlayerDataModel == null)
				{
					CommonUtility.UpdateGameObjectVisible(this.leftPlayerItem.gameObject, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.leftPlayerItem.gameObject, true);
					this.leftPlayerItem.Init(leftPlayerDataModel);
				}
			}
			if (this.rightPlayerItem != null)
			{
				if (rightPlayerDataModel == null)
				{
					CommonUtility.UpdateGameObjectVisible(this.rightPlayerItem.gameObject, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.rightPlayerItem.gameObject, true);
					this.rightPlayerItem.Init(rightPlayerDataModel);
				}
			}
		}

		// Token: 0x0600CF4B RID: 53067 RVA: 0x003327AD File Offset: 0x00330BAD
		public void ResetAvatarView()
		{
			if (this.leftPlayerItem != null)
			{
				this.leftPlayerItem.ResetPlayerRenderEx();
			}
			if (this.rightPlayerItem != null)
			{
				this.rightPlayerItem.ResetPlayerRenderEx();
			}
		}

		// Token: 0x0400792B RID: 31019
		[Space(10f)]
		[Header("PlayerItem")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipPlayerItem leftPlayerItem;

		// Token: 0x0400792C RID: 31020
		[SerializeField]
		private ChampionshipPlayerItem rightPlayerItem;
	}
}
