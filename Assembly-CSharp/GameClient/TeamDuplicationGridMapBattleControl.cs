using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C5E RID: 7262
	public class TeamDuplicationGridMapBattleControl : MonoBehaviour
	{
		// Token: 0x06011D67 RID: 73063 RVA: 0x00538240 File Offset: 0x00536640
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011D68 RID: 73064 RVA: 0x00538248 File Offset: 0x00536648
		private void ClearData()
		{
			this._captainOneBattleEffectPrefab = null;
			this._captainTwoBattleEffectPrefab = null;
		}

		// Token: 0x06011D69 RID: 73065 RVA: 0x00538258 File Offset: 0x00536658
		public void UpdateBattleControl(TeamDuplicationGridBattleDataModel gridBattleDataModel, TeamDuplicationGridPathPosition gridPathPosition, uint captainId = 1U)
		{
			if (captainId == 1U)
			{
				this.UpdateCaptainOneBattleControl(gridBattleDataModel, gridPathPosition);
			}
			else
			{
				this.UpdateCaptainTwoBattleControl(gridBattleDataModel, gridPathPosition);
			}
		}

		// Token: 0x06011D6A RID: 73066 RVA: 0x00538278 File Offset: 0x00536678
		public void UpdateCaptainOneBattleControl(TeamDuplicationGridBattleDataModel gridBattleDataModel, TeamDuplicationGridPathPosition gridPathPosition)
		{
			if (gridPathPosition == null || gridBattleDataModel == null || !gridBattleDataModel.IsInBattle)
			{
				CommonUtility.UpdateGameObjectVisible(this.captainOneBattleItemRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.captainOneBattleItemRoot, true);
			if (this.captainOneBattleItemRtf != null)
			{
				Vector3 middlePosition = CommonUtility.GetMiddlePosition(gridPathPosition.StartPointPosition, gridPathPosition.EndPointPosition);
				this.captainOneBattleItemRtf.localPosition = middlePosition;
			}
			if (this._captainOneBattleEffectPrefab == null)
			{
				this._captainOneBattleEffectPrefab = CommonUtility.LoadGameObject(this.captainOneBattleItemRoot);
			}
		}

		// Token: 0x06011D6B RID: 73067 RVA: 0x00538308 File Offset: 0x00536708
		public void UpdateCaptainTwoBattleControl(TeamDuplicationGridBattleDataModel gridBattleDataModel, TeamDuplicationGridPathPosition gridPathPosition)
		{
			if (gridPathPosition == null || gridBattleDataModel == null || !gridBattleDataModel.IsInBattle)
			{
				CommonUtility.UpdateGameObjectVisible(this.captainTwoBattleItemRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.captainTwoBattleItemRoot, true);
			if (this.captainTwoBattleItemRtf != null)
			{
				Vector3 middlePosition = CommonUtility.GetMiddlePosition(gridPathPosition.StartPointPosition, gridPathPosition.EndPointPosition);
				this.captainTwoBattleItemRtf.localPosition = middlePosition;
			}
			if (this._captainTwoBattleEffectPrefab == null)
			{
				this._captainTwoBattleEffectPrefab = CommonUtility.LoadGameObject(this.captainTwoBattleItemRoot);
			}
		}

		// Token: 0x0400B9C6 RID: 47558
		private GameObject _captainOneBattleEffectPrefab;

		// Token: 0x0400B9C7 RID: 47559
		private GameObject _captainTwoBattleEffectPrefab;

		// Token: 0x0400B9C8 RID: 47560
		[Space(10f)]
		[Header("CaptainOne")]
		[Space(10f)]
		[SerializeField]
		private GameObject captainOneBattleItemRoot;

		// Token: 0x0400B9C9 RID: 47561
		[SerializeField]
		private RectTransform captainOneBattleItemRtf;

		// Token: 0x0400B9CA RID: 47562
		[Space(10f)]
		[Header("CaptainTwo")]
		[Space(10f)]
		[SerializeField]
		private GameObject captainTwoBattleItemRoot;

		// Token: 0x0400B9CB RID: 47563
		[SerializeField]
		private RectTransform captainTwoBattleItemRtf;
	}
}
