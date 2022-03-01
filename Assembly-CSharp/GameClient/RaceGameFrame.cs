using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010D6 RID: 4310
	public sealed class RaceGameFrame : ClientFrame
	{
		// Token: 0x0600A323 RID: 41763 RVA: 0x00215DD6 File Offset: 0x002141D6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/RaceGameFrame";
		}

		// Token: 0x0600A324 RID: 41764 RVA: 0x00215DE0 File Offset: 0x002141E0
		protected override void _bindExUI()
		{
			this.m_root = this.mBind.GetCom<RectTransform>("sceneRoot");
			this.m_boss = this.mBind.GetCom<RectTransform>("boss");
			this.m_self = this.mBind.GetCom<RectTransform>("self");
			this.m_race = this.mBind.GetCom<RectTransform>("race");
			this.m_speedUpEff = this.mBind.GetGameObject("BossSpeedUp");
		}

		// Token: 0x0600A325 RID: 41765 RVA: 0x00215E5B File Offset: 0x0021425B
		protected override void _unbindExUI()
		{
			this.m_root = null;
			this.m_boss = null;
			this.m_self = null;
			this.m_race = null;
			this.m_speedUpEff = null;
		}

		// Token: 0x0600A326 RID: 41766 RVA: 0x00215E80 File Offset: 0x00214280
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600A327 RID: 41767 RVA: 0x00215E82 File Offset: 0x00214282
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600A328 RID: 41768 RVA: 0x00215E84 File Offset: 0x00214284
		public void Start(float time)
		{
			if (time <= 0f)
			{
				return;
			}
			this.m_isStart = true;
			this.m_raceTime = time;
			this.m_speed = this.m_race.sizeDelta.x / this.m_raceTime;
		}

		// Token: 0x0600A329 RID: 41769 RVA: 0x00215ECB File Offset: 0x002142CB
		public void Stop()
		{
			this.m_isStart = false;
		}

		// Token: 0x0600A32A RID: 41770 RVA: 0x00215ED4 File Offset: 0x002142D4
		public void UpdateRoot(float deltaTime)
		{
			if (!this.m_isStart)
			{
				return;
			}
			this.m_durTime += deltaTime;
			if (this.m_root == null)
			{
				return;
			}
			if (this.m_durTime < this.m_raceTime)
			{
				this.m_rootPos = this.m_root.anchoredPosition;
				this.m_rootPos.x = this.m_rootPos.x + this.m_speed * deltaTime;
				this.m_root.anchoredPosition = this.m_rootPos;
			}
		}

		// Token: 0x0600A32B RID: 41771 RVA: 0x00215F5C File Offset: 0x0021435C
		public void UpdateBoss(float percent)
		{
			if (!this.m_isStart)
			{
				return;
			}
			if (this.m_boss == null)
			{
				return;
			}
			this.m_bossPos.y = this.m_boss.anchoredPosition.y;
			this.m_bossPos.x = this.m_root.sizeDelta.x * percent;
			this.m_boss.anchoredPosition = this.m_bossPos;
		}

		// Token: 0x0600A32C RID: 41772 RVA: 0x00215FD8 File Offset: 0x002143D8
		public void UpdateSelf(float percent)
		{
			if (!this.m_isStart)
			{
				return;
			}
			if (this.m_self == null)
			{
				return;
			}
			this.m_playerPos.y = this.m_self.anchoredPosition.y;
			this.m_playerPos.x = this.m_root.sizeDelta.x * percent;
			this.m_self.anchoredPosition = this.m_playerPos;
		}

		// Token: 0x0600A32D RID: 41773 RVA: 0x00216052 File Offset: 0x00214452
		public void OnSpeedUpStart()
		{
			if (this.m_speedUpEff != null)
			{
				this.m_speedUpEff.CustomActive(true);
			}
		}

		// Token: 0x0600A32E RID: 41774 RVA: 0x00216071 File Offset: 0x00214471
		public void OnSpeedUpEnd()
		{
			if (this.m_speedUpEff != null)
			{
				this.m_speedUpEff.CustomActive(false);
			}
		}

		// Token: 0x04005AEF RID: 23279
		private RectTransform m_root;

		// Token: 0x04005AF0 RID: 23280
		private RectTransform m_boss;

		// Token: 0x04005AF1 RID: 23281
		private RectTransform m_self;

		// Token: 0x04005AF2 RID: 23282
		private RectTransform m_race;

		// Token: 0x04005AF3 RID: 23283
		private float m_speed;

		// Token: 0x04005AF4 RID: 23284
		private float m_durTime;

		// Token: 0x04005AF5 RID: 23285
		private Vector2 m_rootPos = Vector2.zero;

		// Token: 0x04005AF6 RID: 23286
		private Vector2 m_playerPos = Vector2.zero;

		// Token: 0x04005AF7 RID: 23287
		private Vector2 m_bossPos = Vector2.zero;

		// Token: 0x04005AF8 RID: 23288
		private GameObject m_speedUpEff;

		// Token: 0x04005AF9 RID: 23289
		private float m_raceTime = 10f;

		// Token: 0x04005AFA RID: 23290
		private bool m_isStart;
	}
}
