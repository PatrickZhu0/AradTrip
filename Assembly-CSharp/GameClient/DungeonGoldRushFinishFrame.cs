using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010C8 RID: 4296
	public class DungeonGoldRushFinishFrame : ClientFrame, IDungeonFinish
	{
		// Token: 0x0600A275 RID: 41589 RVA: 0x002129DA File Offset: 0x00210DDA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonGoldRushFinish";
		}

		// Token: 0x0600A276 RID: 41590 RVA: 0x002129E4 File Offset: 0x00210DE4
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mComItems = this.mBind.GetCom<ComItemList>("ComItems");
			this.mExpBar = this.mBind.GetCom<ComExpBar>("ExpBar");
			this.mExpValue = this.mBind.GetCom<Text>("ExpValue");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.title = this.mBind.GetCom<Text>("title");
			this.text = this.mBind.GetCom<RectTransform>("text");
			this.finalTestContainer = this.mBind.GetGameObject("finalTest");
			this.b = this.mBind.GetGameObject("b");
			this.t = this.mBind.GetGameObject("t");
			this.info = this.mBind.GetCom<FinalTestPlayerInfo>("PlayerSelfHPBar");
		}

		// Token: 0x0600A277 RID: 41591 RVA: 0x00212B00 File Offset: 0x00210F00
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mComItems = null;
			this.mExpBar = null;
			this.mExpValue = null;
			this.mName = null;
		}

		// Token: 0x0600A278 RID: 41592 RVA: 0x00212B4C File Offset: 0x00210F4C
		private void _onCloseButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600A279 RID: 41593 RVA: 0x00212B54 File Offset: 0x00210F54
		private void _onExpUpdate(UIEvent ui)
		{
			this._setExp(DataManager<PlayerBaseData>.GetInstance().Exp, false);
		}

		// Token: 0x0600A27A RID: 41594 RVA: 0x00212B67 File Offset: 0x00210F67
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpUpdate));
			this._setExp(DataManager<BattleDataManager>.GetInstance().originExp, true);
			this.SetTitle();
			this.SetPlayerInfo();
		}

		// Token: 0x0600A27B RID: 41595 RVA: 0x00212BA0 File Offset: 0x00210FA0
		private void SetPlayerInfo()
		{
			if (this.b == null || this.t == null || this.finalTestContainer == null)
			{
				return;
			}
			if (BattleMain.instance != null)
			{
				FinalTestBattle finalTestBattle = BattleMain.instance.GetBattle() as FinalTestBattle;
				this.b.CustomActive(finalTestBattle == null);
				this.t.CustomActive(finalTestBattle == null);
				this.finalTestContainer.CustomActive(finalTestBattle != null);
				this.info.gameObject.CustomActive(finalTestBattle != null);
				if (finalTestBattle != null && finalTestBattle.playerInfo != null)
				{
					this.info.SetPlayerInfo(finalTestBattle.playerInfo);
				}
			}
		}

		// Token: 0x0600A27C RID: 41596 RVA: 0x00212C64 File Offset: 0x00211064
		private void SetTitle()
		{
			if (BattleMain.instance != null)
			{
				FinalTestBattle finalTestBattle = BattleMain.instance.GetBattle() as FinalTestBattle;
				if (finalTestBattle != null && this.title != null && finalTestBattle.tableData != null)
				{
					this.text.gameObject.SetActive(false);
					this.title.gameObject.SetActive(true);
					if (Singleton<TableManager>.instance.IsLastFloor(finalTestBattle.tableData.ID))
					{
						this.title.text = "通关成功";
						this.title.color = new Color(0f, 1f, 0f, 0f);
					}
					else
					{
						this.title.text = "挑战成功";
						this.title.color = new Color(1f, 1f, 1f, 0f);
					}
					Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(2000, delegate
					{
						if (this.title != null)
						{
							ShortcutExtensions46.DOFade(this.title, 1f, 0.2f);
						}
					}, 0, 0, false);
				}
			}
		}

		// Token: 0x0600A27D RID: 41597 RVA: 0x00212D7A File Offset: 0x0021117A
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpUpdate));
		}

		// Token: 0x0600A27E RID: 41598 RVA: 0x00212D94 File Offset: 0x00211194
		public void SetName(string name)
		{
			this.mName.text = name;
		}

		// Token: 0x0600A27F RID: 41599 RVA: 0x00212DA2 File Offset: 0x002111A2
		public void SetBestTime(int time)
		{
		}

		// Token: 0x0600A280 RID: 41600 RVA: 0x00212DA4 File Offset: 0x002111A4
		public void SetCurrentTime(int time)
		{
		}

		// Token: 0x0600A281 RID: 41601 RVA: 0x00212DA6 File Offset: 0x002111A6
		public void SetDiff(int diff)
		{
		}

		// Token: 0x0600A282 RID: 41602 RVA: 0x00212DA8 File Offset: 0x002111A8
		public void SetDrops(ComItemList.Items[] items)
		{
			if (this.mComItems != null)
			{
				this.mComItems.SetItems(items);
			}
		}

		// Token: 0x0600A283 RID: 41603 RVA: 0x00212DC7 File Offset: 0x002111C7
		private void _setExp(ulong val, bool force)
		{
			if (null != this.mExpBar)
			{
				this.mExpBar.SetExp(val, force, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
			}
		}

		// Token: 0x0600A284 RID: 41604 RVA: 0x00212E04 File Offset: 0x00211204
		public void SetExp(ulong exp)
		{
			if (this.mExpValue != null)
			{
				this.mExpValue.text = exp.ToString();
			}
			this._onExpUpdate(null);
		}

		// Token: 0x0600A285 RID: 41605 RVA: 0x00212E36 File Offset: 0x00211236
		public void SetFinish(bool isFinish)
		{
		}

		// Token: 0x0600A286 RID: 41606 RVA: 0x00212E38 File Offset: 0x00211238
		public void SetLevel(int lvl)
		{
		}

		// Token: 0x0600A287 RID: 41607 RVA: 0x00212E3A File Offset: 0x0021123A
		private void _onClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonGoldRushFinishFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x04005A93 RID: 23187
		private Button mClose;

		// Token: 0x04005A94 RID: 23188
		private ComItemList mComItems;

		// Token: 0x04005A95 RID: 23189
		private ComExpBar mExpBar;

		// Token: 0x04005A96 RID: 23190
		private Text mExpValue;

		// Token: 0x04005A97 RID: 23191
		private Text mName;

		// Token: 0x04005A98 RID: 23192
		private Text title;

		// Token: 0x04005A99 RID: 23193
		private RectTransform text;

		// Token: 0x04005A9A RID: 23194
		private GameObject finalTestContainer;

		// Token: 0x04005A9B RID: 23195
		private GameObject b;

		// Token: 0x04005A9C RID: 23196
		private GameObject t;

		// Token: 0x04005A9D RID: 23197
		private FinalTestPlayerInfo info;
	}
}
