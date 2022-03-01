using System;
using System.Collections;
using DG.Tweening;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010C2 RID: 4290
	public class AnniversaryFinishFrame : ClientFrame
	{
		// Token: 0x0600A22B RID: 41515 RVA: 0x00211551 File Offset: 0x0020F951
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/AnniversaryDungeonFinish";
		}

		// Token: 0x0600A22C RID: 41516 RVA: 0x00211558 File Offset: 0x0020F958
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x0600A22D RID: 41517 RVA: 0x0021155C File Offset: 0x0020F95C
		protected override void _bindExUI()
		{
			this.mScoreBind = this.mBind.GetCom<ComCommonBind>("Score");
			this.mScoreInfo[0] = this.mBind.GetCom<ComCommonBind>("Info0");
			this.mScoreInfo[1] = this.mBind.GetCom<ComCommonBind>("Info1");
			this.mScoreInfo[2] = this.mBind.GetCom<ComCommonBind>("Info2");
			this.mAudioProxy = this.mBind.GetCom<UIAudioProxy>("AudioProxy");
			this.mDt[0] = this.mBind.GetCom<DOTweenAnimation>("dt0");
			this.mDt[1] = this.mBind.GetCom<DOTweenAnimation>("dt1");
			this.mDt[2] = this.mBind.GetCom<DOTweenAnimation>("dt2");
			this.mDt[3] = this.mBind.GetCom<DOTweenAnimation>("dt3");
			this.mDt[4] = this.mBind.GetCom<DOTweenAnimation>("dt4");
			this.mDt[5] = this.mBind.GetCom<DOTweenAnimation>("dt5");
			this.mDt[6] = this.mBind.GetCom<DOTweenAnimation>("dt6");
			this.mDt[7] = this.mBind.GetCom<DOTweenAnimation>("dt7");
			this.mDt[8] = this.mBind.GetCom<DOTweenAnimation>("dt8");
			this.mDt[9] = this.mBind.GetCom<DOTweenAnimation>("dt9");
			this.mDt[10] = this.mBind.GetCom<DOTweenAnimation>("dt10");
			this.mDt[11] = this.mBind.GetCom<DOTweenAnimation>("dt11");
			this.mDt[12] = this.mBind.GetCom<DOTweenAnimation>("dt12");
			this.mDt[13] = this.mBind.GetCom<DOTweenAnimation>("dt13");
			this.mDt[14] = this.mBind.GetCom<DOTweenAnimation>("dt14");
			this.mDt[15] = this.mBind.GetCom<DOTweenAnimation>("dt15");
			this.mDt[16] = this.mBind.GetCom<DOTweenAnimation>("dt16");
			this.mDt[17] = this.mBind.GetCom<DOTweenAnimation>("dt17");
		}

		// Token: 0x0600A22E RID: 41518 RVA: 0x00211798 File Offset: 0x0020FB98
		protected override void _unbindExUI()
		{
			this.mAudioProxy = null;
			this.mDt[0] = null;
			this.mDt[1] = null;
			this.mDt[2] = null;
			this.mDt[3] = null;
			this.mDt[4] = null;
			this.mDt[5] = null;
			this.mDt[6] = null;
			this.mDt[7] = null;
			this.mDt[8] = null;
			this.mDt[9] = null;
			this.mDt[10] = null;
			this.mDt[11] = null;
			this.mDt[12] = null;
			this.mDt[13] = null;
			this.mDt[14] = null;
			this.mDt[15] = null;
			this.mDt[16] = null;
			this.mDt[17] = null;
			this.mScoreBind = null;
			for (int i = 0; i < this.mScoreInfo.Length; i++)
			{
				this.mScoreInfo[i] = null;
			}
		}

		// Token: 0x0600A22F RID: 41519 RVA: 0x00211880 File Offset: 0x0020FC80
		protected override void _OnOpenFrame()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._addCallback());
			this._playAnimate(this.mDt.Length);
			this._playBgm();
		}

		// Token: 0x0600A230 RID: 41520 RVA: 0x002118A8 File Offset: 0x0020FCA8
		private void _playAnimate(int dtLength)
		{
			for (int i = 0; i < dtLength; i++)
			{
				if (null != this.mDt[i] && this.mDt[i].isActive)
				{
					this.mDt[i].DOPlay();
				}
			}
		}

		// Token: 0x0600A231 RID: 41521 RVA: 0x002118F9 File Offset: 0x0020FCF9
		private void _playBgm()
		{
			if (null != this.mAudioProxy)
			{
				this.mAudioProxy.TriggerAudio(1);
			}
		}

		// Token: 0x0600A232 RID: 41522 RVA: 0x00211918 File Offset: 0x0020FD18
		protected override void _OnCloseFrame()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (BattleMain.instance.GetDungeonManager() == null)
			{
				return;
			}
			if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager() == null)
			{
				return;
			}
			Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.CLICK_RESULT, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().CurrentAreaID(), string.Empty);
		}

		// Token: 0x0600A233 RID: 41523 RVA: 0x00211994 File Offset: 0x0020FD94
		private IEnumerator _addCallback()
		{
			yield return Yielders.GetWaitForSeconds(5f);
			this.frameMgr.CloseFrame<AnniversaryFinishFrame>(this, false);
			yield break;
		}

		// Token: 0x0600A234 RID: 41524 RVA: 0x002119B0 File Offset: 0x0020FDB0
		private void _set1Image(Image image, bool isSucces, string spritename)
		{
			if (null != this.mScoreBind)
			{
				this.mScoreBind.GetSprite(spritename, ref image);
				if (isSucces)
				{
					GameObject prefabInstance = this.mScoreBind.GetPrefabInstance("effect");
					Utility.AttachTo(prefabInstance, image.gameObject, false);
				}
			}
		}

		// Token: 0x0600A235 RID: 41525 RVA: 0x00211A00 File Offset: 0x0020FE00
		private void _RefreshInfo(string[] caption, string[] content, int[] countLevel, int count, bool lessEqualComparor)
		{
			if (caption.Length != 3 || content.Length != 3 || countLevel.Length != 3)
			{
				return;
			}
			for (int i = 0; i < this.mScoreInfo.Length; i++)
			{
				ComCommonBind comCommonBind = this.mScoreInfo[i];
				if (!(comCommonBind == null))
				{
					Text com = comCommonBind.GetCom<Text>("Caption");
					Text com2 = comCommonBind.GetCom<Text>("Content");
					if (com != null)
					{
						com.text = caption[i];
					}
					if (com2 != null)
					{
						com2.text = content[i];
					}
					bool flag = false;
					if (lessEqualComparor)
					{
						if (countLevel[i] >= count)
						{
							flag = true;
						}
					}
					else if (countLevel[i] <= count)
					{
						flag = true;
					}
					GameObject gameObject = comCommonBind.GetGameObject("successRoot");
					GameObject gameObject2 = comCommonBind.GetGameObject("failRoot");
					Image com3 = comCommonBind.GetCom<Image>("ScoreImage");
					if (flag)
					{
						gameObject2.CustomActive(false);
						gameObject.CustomActive(true);
						this.mBind.GetSprite("success", ref com3);
					}
					else
					{
						gameObject2.CustomActive(true);
						gameObject.CustomActive(false);
						this.mBind.GetSprite("failed", ref com3);
					}
				}
			}
		}

		// Token: 0x0600A236 RID: 41526 RVA: 0x00211B40 File Offset: 0x0020FF40
		public void SetFrameData(DungeonScore finalScore, string[] caption, string[] content, int[] countLevel, int count, bool lessEqualComparor)
		{
			if (null != this.mScoreBind)
			{
				Image com = this.mScoreBind.GetCom<Image>("s0");
				Image com2 = this.mScoreBind.GetCom<Image>("s1");
				Image com3 = this.mScoreBind.GetCom<Image>("s2");
				GameObject gameObject = this.mScoreBind.GetGameObject("fail");
				GameObject gameObject2 = this.mScoreBind.GetGameObject("successroot");
				com.enabled = false;
				com2.enabled = false;
				com3.enabled = false;
				gameObject2.CustomActive(true);
				gameObject.CustomActive(false);
				switch (finalScore)
				{
				case DungeonScore.C:
					gameObject.CustomActive(true);
					gameObject2.CustomActive(false);
					Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "C");
					break;
				case DungeonScore.B:
				case DungeonScore.A:
					com2.enabled = true;
					this._set1Image(com2, true, "a");
					Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "A");
					break;
				case DungeonScore.S:
					com2.enabled = true;
					this._set1Image(com2, true, "s");
					Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "S");
					break;
				case DungeonScore.SS:
					com2.enabled = true;
					com3.enabled = true;
					this._set1Image(com2, true, "s");
					this._set1Image(com3, true, "s");
					Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "SS");
					break;
				case DungeonScore.SSS:
					com.enabled = true;
					com2.enabled = true;
					com3.enabled = true;
					this._set1Image(com, true, "s");
					this._set1Image(com2, true, "s");
					this._set1Image(com3, true, "s");
					Singleton<GameStatisticManager>.GetInstance().DoStartCheckPointsSettlement(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, "SSS");
					break;
				}
			}
			this._RefreshInfo(caption, content, countLevel, count, lessEqualComparor);
		}

		// Token: 0x04005A5D RID: 23133
		private const string kOpenFrameSoundPath = "Sound/SE/result_list";

		// Token: 0x04005A5E RID: 23134
		protected GameObject mEffect;

		// Token: 0x04005A5F RID: 23135
		private UIAudioProxy mAudioProxy;

		// Token: 0x04005A60 RID: 23136
		private DOTweenAnimation[] mDt = new DOTweenAnimation[18];

		// Token: 0x04005A61 RID: 23137
		public ComCommonBind mScoreBind;

		// Token: 0x04005A62 RID: 23138
		public ComCommonBind[] mScoreInfo = new ComCommonBind[3];
	}
}
