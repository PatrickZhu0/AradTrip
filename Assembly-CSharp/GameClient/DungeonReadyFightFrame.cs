using System;
using System.Collections;
using DG.Tweening;

namespace GameClient
{
	// Token: 0x020010AF RID: 4271
	public class DungeonReadyFightFrame : Dungeon3V3BaseLoadFrame
	{
		// Token: 0x0600A119 RID: 41241 RVA: 0x0020A1B0 File Offset: 0x002085B0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Loading/PVPLoading/DungeonPVPLoadingFrame";
		}

		// Token: 0x0600A11A RID: 41242 RVA: 0x0020A1B8 File Offset: 0x002085B8
		protected override void _OnOpenFrame()
		{
			this._updateCurrentFighters();
			base._initBoards();
			base._initPlayers();
			this.mApplyBtn.gameObject.CustomActive(false);
			this.mCountDownRoot.CustomActive(false);
			this.mLeftTimeRoot.CustomActive(false);
			this.mFightTips.CustomActive(false);
			this.mPvp3v3MicRoomBtn.gameObject.CustomActive(false);
			this.mPvp3v3PlayerBtn.gameObject.CustomActive(false);
			this._hiddenOther();
			if (null != this.mBind)
			{
				this.mBind.StartCoroutine(this._delay1sCall());
			}
		}

		// Token: 0x0600A11B RID: 41243 RVA: 0x0020A258 File Offset: 0x00208658
		private void _hiddenOther()
		{
			if (this.mCurrentFighters == null)
			{
				return;
			}
			for (int i = 0; i < this.mBoards.Length; i++)
			{
				if (this.mBoards[i].playerSeat != 255)
				{
					if (this.mBoards[i].playerSeat != this.mCurrentFighters.redTeamSeat)
					{
						if (this.mBoards[i].playerSeat != this.mCurrentFighters.blueTeamSeat)
						{
							if (null != this.mBoards[i].root)
							{
								this.mBoards[i].root.CustomActive(false);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A11C RID: 41244 RVA: 0x0020A315 File Offset: 0x00208715
		protected override void _OnCloseFrame()
		{
			base._uninitBoards();
		}

		// Token: 0x0600A11D RID: 41245 RVA: 0x0020A320 File Offset: 0x00208720
		protected IEnumerator _delay1sCall()
		{
			yield return Yielders.GetWaitForSeconds(1f);
			this._init2MatchPlayers();
			yield break;
		}

		// Token: 0x0600A11E RID: 41246 RVA: 0x0020A33B File Offset: 0x0020873B
		private void _updateCurrentFighters()
		{
			this.mCurrentFighters = (this.userData as DungeonReadyFightFrame.MatchedFighters);
			if (this.mCurrentFighters == null)
			{
				Logger.LogErrorFormat("[战斗] 获取 userdata 失败", new object[0]);
			}
		}

		// Token: 0x0600A11F RID: 41247 RVA: 0x0020A36C File Offset: 0x0020876C
		protected bool _init2MatchPlayers()
		{
			if (null == this.mBind)
			{
				return false;
			}
			this.mNextRoundRoot.CustomActive(true);
			this.mFightVS.gameObject.CustomActive(true);
			DOTween.Play(this.mPerpareRoot);
			if (this.mCurrentFighters == null)
			{
				Logger.LogErrorFormat("[战斗] [loading] mCurrentFighters 为空", new object[0]);
				return false;
			}
			this.mBind.GetSprite(string.Format("rnum{0}", this.mCurrentFighters.roundIndex), ref this.mNextRoundImage);
			this.mNextRoundImage.SetNativeSize();
			base._playProcessAnimateByType(Dungeon3V3BaseLoadFrame.eAnimateType.eSelected, this.mCurrentFighters.redTeamSeat);
			base._playProcessAnimateByType(Dungeon3V3BaseLoadFrame.eAnimateType.eSelected, this.mCurrentFighters.blueTeamSeat);
			return true;
		}

		// Token: 0x0600A120 RID: 41248 RVA: 0x0020A430 File Offset: 0x00208830
		private bool _playAnimationWith(byte seat)
		{
			Dungeon3V3BaseLoadFrame.MatchUnit matchUnit = base._findBoardBySeat(seat);
			if (matchUnit == null)
			{
				Logger.LogErrorFormat("[战斗] [loading] unit 为空 {0}", new object[]
				{
					seat
				});
				return false;
			}
			if (null == matchUnit.root)
			{
				Logger.LogErrorFormat("[战斗] [loading] root 为空 {0}", new object[]
				{
					seat
				});
				return false;
			}
			return true;
		}

		// Token: 0x0400599D RID: 22941
		private DungeonReadyFightFrame.MatchedFighters mCurrentFighters;

		// Token: 0x020010B0 RID: 4272
		public class MatchedFighters
		{
			// Token: 0x0400599E RID: 22942
			public byte redTeamSeat = byte.MaxValue;

			// Token: 0x0400599F RID: 22943
			public byte blueTeamSeat = byte.MaxValue;

			// Token: 0x040059A0 RID: 22944
			public int roundIndex = -1;
		}
	}
}
