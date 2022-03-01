using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010D2 RID: 4306
	public class GuildPVEBattleFrame : ClientFrame
	{
		// Token: 0x0600A2DC RID: 41692 RVA: 0x00214C08 File Offset: 0x00213008
		protected override void _bindExUI()
		{
			this.m_hpbarRoot = this.mBind.GetGameObject("GuildBossTips");
			if (this.m_hpbarRoot.IsNull())
			{
				return;
			}
			this.m_HpBarStartPosX = this.m_hpbarRoot.transform.localPosition.x;
			ComCommonBind component = this.m_hpbarRoot.GetComponent<ComCommonBind>();
			if (component.IsNull())
			{
				return;
			}
			this.m_HpBar = component.GetCom<Image>("HP");
			this.m_bossIcon = component.GetCom<Image>("bossIcon");
			this.m_hpPercent = component.GetCom<Text>("HPPercent");
			this.m_bossName = component.GetCom<Text>("BossName");
			this.m_dragButton = component.GetCom<Button>("DraghandleButton");
			this.m_dragRt = component.GetCom<RectTransform>("DraghandleRect");
			if (this.m_dragButton != null)
			{
				this.m_dragButton.onClick.AddListener(new UnityAction(this._onDrag));
			}
		}

		// Token: 0x0600A2DD RID: 41693 RVA: 0x00214D08 File Offset: 0x00213108
		protected override void _unbindExUI()
		{
			this.m_HpBar = null;
			this.m_bossIcon = null;
			this.m_hpPercent = null;
			this.m_bossName = null;
			this.m_dragButton = null;
			this.m_dragRt = null;
			if (this.m_dragButton.IsNull())
			{
				return;
			}
			this.m_dragButton.onClick.RemoveListener(new UnityAction(this._onDrag));
			this.m_dragButton = null;
			this.m_hpbarRoot = null;
		}

		// Token: 0x0600A2DE RID: 41694 RVA: 0x00214D7A File Offset: 0x0021317A
		protected sealed override void _OnLoadPrefabFinish()
		{
			if (this.mComClienFrame == null)
			{
				this.mComClienFrame = this.frame.AddComponent<ComClientFrame>();
			}
			this.mComClienFrame.SetGroupTag("system");
		}

		// Token: 0x0600A2DF RID: 41695 RVA: 0x00214DA8 File Offset: 0x002131A8
		private void _onDrag()
		{
			if (this.m_hpbarRoot != null)
			{
				if (this.m_isMoveIn)
				{
					Tweener tweener = ShortcutExtensions.DOLocalMoveX(this.m_hpbarRoot.transform, this.m_HpBarStartPosX + 330f, 0.5f, false);
					if (tweener != null)
					{
						TweenSettingsExtensions.OnComplete<Tweener>(tweener, new TweenCallback(this.OnMoveInAnimationComplete));
					}
				}
				else
				{
					Tweener tweener2 = ShortcutExtensions.DOLocalMoveX(this.m_hpbarRoot.transform, this.m_HpBarStartPosX, 0.5f, false);
					if (tweener2 != null)
					{
						TweenSettingsExtensions.OnComplete<Tweener>(tweener2, new TweenCallback(this.OnMoveOutAnimationComplete));
					}
				}
			}
			this.m_isMoveIn = !this.m_isMoveIn;
		}

		// Token: 0x0600A2E0 RID: 41696 RVA: 0x00214E57 File Offset: 0x00213257
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/GuildPVEBattleFrame";
		}

		// Token: 0x0600A2E1 RID: 41697 RVA: 0x00214E60 File Offset: 0x00213260
		protected override void _OnOpenFrame()
		{
			this._bindUIEvent();
			GuildPVEBattle.BossInfo bossInfo = this.userData as GuildPVEBattle.BossInfo;
			if (bossInfo == null)
			{
				return;
			}
			if (!this.m_bossName.IsNull())
			{
				this.m_bossName.text = bossInfo.bossName;
			}
			if (!this.m_bossIcon.IsNull())
			{
				ETCImageLoader.LoadSprite(ref this.m_bossIcon, bossInfo.iconPath, true);
			}
			this._RefreshHP(bossInfo);
		}

		// Token: 0x0600A2E2 RID: 41698 RVA: 0x00214ED1 File Offset: 0x002132D1
		protected override void _OnCloseFrame()
		{
			this._unBindUIEvent();
		}

		// Token: 0x0600A2E3 RID: 41699 RVA: 0x00214ED9 File Offset: 0x002132D9
		private void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBossHPRefresh, new ClientEventSystem.UIEventHandler(this._OnGuildBossHPRefresh));
		}

		// Token: 0x0600A2E4 RID: 41700 RVA: 0x00214EF6 File Offset: 0x002132F6
		private void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBossHPRefresh, new ClientEventSystem.UIEventHandler(this._OnGuildBossHPRefresh));
		}

		// Token: 0x0600A2E5 RID: 41701 RVA: 0x00214F14 File Offset: 0x00213314
		private void _RefreshHP(GuildPVEBattle.BossInfo bossInfo)
		{
			float num = 0f;
			if (bossInfo.maxHP > 0UL)
			{
				num = bossInfo.curHP * 1f / bossInfo.maxHP;
			}
			if (!this.m_HpBar.IsNull())
			{
				this.m_HpBar.fillAmount = num;
			}
			if (!this.m_hpPercent.IsNull())
			{
				this.m_hpPercent.text = BeUtility.Format("{0}%", (int)(num * 100f));
			}
		}

		// Token: 0x0600A2E6 RID: 41702 RVA: 0x00214F9C File Offset: 0x0021339C
		private void _OnGuildBossHPRefresh(UIEvent uiEvent)
		{
			GuildPVEBattle.BossInfo bossInfo = uiEvent.Param1 as GuildPVEBattle.BossInfo;
			if (bossInfo == null)
			{
				return;
			}
			this._RefreshHP(bossInfo);
		}

		// Token: 0x0600A2E7 RID: 41703 RVA: 0x00214FC4 File Offset: 0x002133C4
		private void OnMoveInAnimationComplete()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildPVEBattleFrame>(null) && this.m_dragRt != null)
			{
				this.m_dragRt.localRotation = Quaternion.Euler(0f, 0f, -180f);
				Vector3 localPosition = this.m_dragRt.transform.localPosition;
				localPosition.x = -120f;
				this.m_dragRt.transform.localPosition = localPosition;
			}
		}

		// Token: 0x0600A2E8 RID: 41704 RVA: 0x00215040 File Offset: 0x00213440
		private void OnMoveOutAnimationComplete()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildPVEBattleFrame>(null) && this.m_dragRt != null)
			{
				this.m_dragRt.localRotation = Quaternion.Euler(0f, 0f, 0f);
				Vector3 localPosition = this.m_dragRt.transform.localPosition;
				localPosition.x = -100f;
				this.m_dragRt.transform.localPosition = localPosition;
			}
		}

		// Token: 0x04005AC5 RID: 23237
		private Image m_HpBar;

		// Token: 0x04005AC6 RID: 23238
		private Text m_bossName;

		// Token: 0x04005AC7 RID: 23239
		private Image m_bossIcon;

		// Token: 0x04005AC8 RID: 23240
		private Text m_hpPercent;

		// Token: 0x04005AC9 RID: 23241
		private Button m_dragButton;

		// Token: 0x04005ACA RID: 23242
		private RectTransform m_dragRt;

		// Token: 0x04005ACB RID: 23243
		private GameObject m_hpbarRoot;

		// Token: 0x04005ACC RID: 23244
		private bool m_isMoveIn = true;

		// Token: 0x04005ACD RID: 23245
		private float m_HpBarStartPosX;
	}
}
