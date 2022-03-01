using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014AD RID: 5293
	internal class BudoResultFrame : ClientFrame
	{
		// Token: 0x0600CD23 RID: 52515 RVA: 0x00326BA5 File Offset: 0x00324FA5
		public static void Open(BudoResultFrameData data)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BudoResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<BudoResultFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BudoResultFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x0600CD24 RID: 52516 RVA: 0x00326BD8 File Offset: 0x00324FD8
		public override string GetPrefabPath()
		{
			this.m_kData = (this.userData as BudoResultFrameData);
			if (this.m_kData == null)
			{
				Logger.LogError("【BudoResultFrame】 must set a BudoResultFrameData!!");
				return string.Empty;
			}
			if (this.m_kData.bOver)
			{
				return "UIFlatten/Prefabs/Budo/BudoResult_over";
			}
			if (this.m_kData.eResult == PKResult.LOSE)
			{
				return "UIFlatten/Prefabs/Budo/BudoResult_lose_ing";
			}
			return "UIFlatten/Prefabs/Budo/BudoResult_Win_ing";
		}

		// Token: 0x0600CD25 RID: 52517 RVA: 0x00326C44 File Offset: 0x00325044
		private void _OnClickAward()
		{
			ItemData itemData = DataManager<BudoManager>.GetInstance().GetJarDataByTimes();
			if (this.m_kData.bDebug)
			{
				itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(330000006);
			}
			if (itemData != null)
			{
				DataManager<BudoManager>.GetInstance().SendSceneWudaoRewardReq();
				DataManager<BudoManager>.GetInstance().NeedOpenBudoInfoFrame = this.m_kData.bNeedOpenBudoInfo;
				this.frameMgr.CloseFrame<BudoResultFrame>(this, false);
			}
		}

		// Token: 0x0600CD26 RID: 52518 RVA: 0x00326CB0 File Offset: 0x003250B0
		private void ShowCurrentLoseStars(int count, bool bAnimation)
		{
			for (int i = 0; i < 3; i++)
			{
				this.m_LoseStar[i].CustomActive(i <= count);
			}
			if (bAnimation && count >= 0 && count < 3)
			{
				DOTweenAnimation[] components = this.m_LoseStar[count].GetComponents<DOTweenAnimation>();
				for (int j = 0; j < components.Length; j++)
				{
					components[j].autoPlay = true;
					components[j].CreateTween();
				}
			}
		}

		// Token: 0x0600CD27 RID: 52519 RVA: 0x00326D2C File Offset: 0x0032512C
		protected override void _OnOpenFrame()
		{
			this.m_kComBind = this.frame.GetComponent<ComCommonBind>();
			this.m_kJarName = this.m_kComBind.GetCom<Text>("JarName");
			this.m_LoseStar[0] = this.m_kComBind.GetGameObject("LoseStar1");
			this.m_LoseStar[1] = this.m_kComBind.GetGameObject("LoseStar2");
			this.m_LoseStar[2] = this.m_kComBind.GetGameObject("LoseStar3");
			this.m_kBudoWinTimes = this.m_kComBind.GetCom<Text>("WinText");
			this.m_Close = this.m_kComBind.GetCom<Button>("Close");
			if (this.m_Close != null)
			{
				this.m_Close.onClick.AddListener(new UnityAction(this._OnClickClose));
			}
			this.m_JarOpen = this.m_kComBind.GetCom<Button>("JarOpen");
			if (this.m_JarOpen != null)
			{
				this.m_JarOpen.onClick.AddListener(new UnityAction(this._OnClickAward));
			}
			this.m_OverText = this.m_kComBind.GetCom<Text>("OverText");
			this.m_kClickHint = this.mBind.GetCom<Text>("ClickHint");
			this.ShowCurrentLoseStars(DataManager<BudoManager>.GetInstance().LoseTimes - 1, this.m_kData.eResult == PKResult.LOSE);
			if (!this.m_kData.bOver)
			{
				if (this.m_kData.eResult == PKResult.LOSE)
				{
				}
			}
			this.m_bCanClose = false;
			InvokeMethod.Invoke(this, 1f, delegate()
			{
				this.m_bCanClose = true;
			});
			this._UpdateBudoInfo();
		}

		// Token: 0x0600CD28 RID: 52520 RVA: 0x00326EDC File Offset: 0x003252DC
		private void _UpdateBudoInfo()
		{
			if ((this.m_kData.bOver && this.m_kData.eResult == PKResult.WIN) || this.m_kData.bDebug)
			{
				this.m_kBudoWinTimes.text = string.Format(TR.Value("budo_win_times"), DataManager<BudoManager>.GetInstance().WinTimes - 1);
				ItemData itemData = DataManager<BudoManager>.GetInstance().GetPreJarDataByTimes();
				if (this.m_kData.bDebug)
				{
					itemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(330000002);
				}
				if (itemData != null)
				{
					this.m_kJarName.text = itemData.GetColorName(string.Empty, false);
				}
			}
			else
			{
				this.m_kBudoWinTimes.text = string.Format(TR.Value("budo_win_times"), DataManager<BudoManager>.GetInstance().WinTimes);
				ItemData jarDataByTimes = DataManager<BudoManager>.GetInstance().GetJarDataByTimes();
				if (jarDataByTimes != null)
				{
					this.m_kJarName.text = jarDataByTimes.GetColorName(string.Empty, false);
				}
			}
			bool canAcqured = DataManager<BudoManager>.GetInstance().CanAcqured;
			this.mCanAward = canAcqured;
			if (!canAcqured)
			{
				this.m_kClickHint.text = "点击屏幕任意位置关闭";
			}
			else
			{
				this.m_kClickHint.text = "请领取武道会奖励!";
			}
		}

		// Token: 0x0600CD29 RID: 52521 RVA: 0x00327020 File Offset: 0x00325420
		private void _OnClickClose()
		{
			if (!this.m_bCanClose)
			{
				return;
			}
			if (this.mCanAward)
			{
				return;
			}
			this.frameMgr.CloseFrame<BudoResultFrame>(this, false);
		}

		// Token: 0x0600CD2A RID: 52522 RVA: 0x00327047 File Offset: 0x00325447
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x04007787 RID: 30599
		private BudoResultFrameData m_kData;

		// Token: 0x04007788 RID: 30600
		private ComCommonBind m_kComBind;

		// Token: 0x04007789 RID: 30601
		private Text m_kJarName;

		// Token: 0x0400778A RID: 30602
		private const int mLoseStarCount = 3;

		// Token: 0x0400778B RID: 30603
		private GameObject[] m_LoseStar = new GameObject[3];

		// Token: 0x0400778C RID: 30604
		private Text m_kBudoWinTimes;

		// Token: 0x0400778D RID: 30605
		private Button m_Close;

		// Token: 0x0400778E RID: 30606
		private Button m_JarOpen;

		// Token: 0x0400778F RID: 30607
		private Text m_OverText;

		// Token: 0x04007790 RID: 30608
		private Text m_kClickHint;

		// Token: 0x04007791 RID: 30609
		private bool m_bCanClose;

		// Token: 0x04007792 RID: 30610
		private bool mCanAward;
	}
}
