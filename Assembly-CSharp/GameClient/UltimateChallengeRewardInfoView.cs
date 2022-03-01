using System;
using DG.Tweening;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013BA RID: 5050
	public class UltimateChallengeRewardInfoView : MonoBehaviour
	{
		// Token: 0x0600C401 RID: 50177 RVA: 0x002F0514 File Offset: 0x002EE914
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
			if (this.boxBtn != null)
			{
				this.boxBtn.onClick.RemoveAllListeners();
				this.boxBtn.onClick.AddListener(new UnityAction(this.OnBoxBtnClick));
			}
		}

		// Token: 0x0600C402 RID: 50178 RVA: 0x002F057C File Offset: 0x002EE97C
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
			if (this.boxBtn != null)
			{
				this.boxBtn.onClick.RemoveListener(new UnityAction(this.OnBoxBtnClick));
			}
		}

		// Token: 0x0600C403 RID: 50179 RVA: 0x002F05D4 File Offset: 0x002EE9D4
		public void RefreshView()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("zjsl_challenge_days");
			if (this.day != null)
			{
				this.day.text = string.Format(this.dayDesc, count);
			}
			UltimateChallengeCustomsClearanceRewardItemData ultimateChallengeCustomsClearanceRewardItemData = null;
			if (count > 0)
			{
				for (int i = 0; i < ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas.Count; i++)
				{
					UltimateChallengeCustomsClearanceRewardItemData ultimateChallengeCustomsClearanceRewardItemData2 = ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas[i];
					if (ultimateChallengeCustomsClearanceRewardItemData2 != null)
					{
						if (count >= ultimateChallengeCustomsClearanceRewardItemData2.minDays)
						{
							if (count <= ultimateChallengeCustomsClearanceRewardItemData2.maxDays)
							{
								ultimateChallengeCustomsClearanceRewardItemData = ultimateChallengeCustomsClearanceRewardItemData2;
								break;
							}
						}
					}
				}
			}
			else if (ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas.Count > 0)
			{
				ultimateChallengeCustomsClearanceRewardItemData = ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas[0];
			}
			if (ultimateChallengeCustomsClearanceRewardItemData != null)
			{
				ETCImageLoader.LoadSprite(ref this.icon, ultimateChallengeCustomsClearanceRewardItemData.iconPath, true);
			}
			this.UpdateBoxState();
		}

		// Token: 0x0600C404 RID: 50180 RVA: 0x002F06C4 File Offset: 0x002EEAC4
		private void UpdateBoxState()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("zjsl_clear_award");
			if (count != 0)
			{
				this.anim.DOPause();
				this.effectRoot.CustomActive(false);
				this.boxBtn.enabled = false;
				this.haveReceiveGo.CustomActive(true);
			}
			else
			{
				this.boxBtn.enabled = true;
				if (DataManager<ActivityDataManager>.GetInstance().IsCustomsClearance())
				{
					this.anim.DORestart(false);
					this.effectRoot.CustomActive(true);
				}
				else
				{
					this.anim.DOPause();
					this.effectRoot.CustomActive(false);
				}
				this.haveReceiveGo.CustomActive(false);
			}
		}

		// Token: 0x0600C405 RID: 50181 RVA: 0x002F0778 File Offset: 0x002EEB78
		private void OnBoxBtnClick()
		{
			if (DataManager<ActivityDataManager>.GetInstance().IsCustomsClearance())
			{
				SceneDungeonZjslClearGetAwardReq cmd = new SceneDungeonZjslClearGetAwardReq();
				NetManager.Instance().SendCommand<SceneDungeonZjslClearGetAwardReq>(ServerType.GATE_SERVER, cmd);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<UltimateChallengeCustomsClearanceRewardFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600C406 RID: 50182 RVA: 0x002F07BE File Offset: 0x002EEBBE
		private void OnCounterChanged(UIEvent uIEvent)
		{
			this.RefreshView();
		}

		// Token: 0x04006F88 RID: 28552
		[SerializeField]
		private Text day;

		// Token: 0x04006F89 RID: 28553
		[SerializeField]
		private Button boxBtn;

		// Token: 0x04006F8A RID: 28554
		[SerializeField]
		private Image icon;

		// Token: 0x04006F8B RID: 28555
		[SerializeField]
		private DOTweenAnimation anim;

		// Token: 0x04006F8C RID: 28556
		[SerializeField]
		private GameObject haveReceiveGo;

		// Token: 0x04006F8D RID: 28557
		[SerializeField]
		private GameObject effectRoot;

		// Token: 0x04006F8E RID: 28558
		[SerializeField]
		private string dayDesc = "已挑战天数：{0}天";
	}
}
