using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001021 RID: 4129
	public class NewbieGuideFinalShow : ClientFrame
	{
		// Token: 0x06009C6F RID: 40047 RVA: 0x001E9164 File Offset: 0x001E7564
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/GuideFinish";
		}

		// Token: 0x06009C70 RID: 40048 RVA: 0x001E916C File Offset: 0x001E756C
		private float _finalTime()
		{
			DOTweenAnimation[] componentsInChildren = this.frame.GetComponentsInChildren<DOTweenAnimation>(true);
			float num = 0f;
			foreach (DOTweenAnimation dotweenAnimation in componentsInChildren)
			{
				float num2 = dotweenAnimation.delay + dotweenAnimation.duration * (float)(dotweenAnimation.loops + 1);
				num = Mathf.Max(num, num2);
			}
			return num;
		}

		// Token: 0x06009C71 RID: 40049 RVA: 0x001E91C7 File Offset: 0x001E75C7
		protected override void _OnOpenFrame()
		{
			this.mLeftTime = this._finalTime();
			this.mState = NewbieGuideFinalShow.eState.Playing;
			this._loadButton();
		}

		// Token: 0x06009C72 RID: 40050 RVA: 0x001E91E2 File Offset: 0x001E75E2
		protected override void _OnCloseFrame()
		{
			this._unloadButton();
		}

		// Token: 0x06009C73 RID: 40051 RVA: 0x001E91EC File Offset: 0x001E75EC
		private void _loadButton()
		{
			if (null != this.mBind)
			{
				Button com = this.mBind.GetCom<Button>("button");
				if (com == null)
				{
					return;
				}
				com.onClick.AddListener(delegate()
				{
					this.mState = NewbieGuideFinalShow.eState.Stop;
					Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideFinalShow>(this, false);
				});
			}
		}

		// Token: 0x06009C74 RID: 40052 RVA: 0x001E9240 File Offset: 0x001E7640
		private void _unloadButton()
		{
			if (null != this.mBind)
			{
				Button com = this.mBind.GetCom<Button>("button");
				if (com != null)
				{
					com.onClick.RemoveAllListeners();
				}
			}
		}

		// Token: 0x06009C75 RID: 40053 RVA: 0x001E9286 File Offset: 0x001E7686
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06009C76 RID: 40054 RVA: 0x001E9289 File Offset: 0x001E7689
		protected override void _OnUpdate(float time)
		{
			if (this.mState == NewbieGuideFinalShow.eState.Playing)
			{
				this.mLeftTime -= time;
				if (this.mLeftTime < 0f)
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideFinalShow>(this, false);
					this.mState = NewbieGuideFinalShow.eState.Stop;
				}
			}
		}

		// Token: 0x040055E9 RID: 21993
		private NewbieGuideFinalShow.eState mState;

		// Token: 0x040055EA RID: 21994
		protected float mLeftTime;

		// Token: 0x02001022 RID: 4130
		private enum eState
		{
			// Token: 0x040055EC RID: 21996
			None,
			// Token: 0x040055ED RID: 21997
			Playing,
			// Token: 0x040055EE RID: 21998
			Stop
		}
	}
}
