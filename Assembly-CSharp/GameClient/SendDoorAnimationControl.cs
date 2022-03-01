using System;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017C9 RID: 6089
	public class SendDoorAnimationControl : MonoBehaviour
	{
		// Token: 0x0600F034 RID: 61492 RVA: 0x0040A667 File Offset: 0x00408A67
		private void Awake()
		{
			this.sAnimation = base.transform.GetComponent<SkeletonAnimation>();
			this.comState = base.transform.GetComponent<StateController>();
			this.curAniState = SendDoorAnimationControl.AnimationState.eNil;
		}

		// Token: 0x0600F035 RID: 61493 RVA: 0x0040A692 File Offset: 0x00408A92
		public void SetAnimation(SendDoorAnimationControl.AnimationState state)
		{
			if (this.sAnimation == null)
			{
				return;
			}
			if (state == SendDoorAnimationControl.AnimationState.eOpen)
			{
				this.ShowOpenAnimation();
			}
			if (state == SendDoorAnimationControl.AnimationState.eClose)
			{
				this.ShowCloseAnimation();
			}
		}

		// Token: 0x0600F036 RID: 61494 RVA: 0x0040A6C0 File Offset: 0x00408AC0
		private void ShowOpenAnimation()
		{
			if (this.curAniState == SendDoorAnimationControl.AnimationState.eOpen || this.curAniState == SendDoorAnimationControl.AnimationState.eIn)
			{
				return;
			}
			this.curAniState = SendDoorAnimationControl.AnimationState.eOpen;
			Spine.AnimationState state = this.sAnimation.state;
			state.Complete += this.ShowInAnimation;
			state.SetAnimation(0, "open", false);
			state.AddAnimation(0, "in", true, 0f);
			this.UpdateEffectState();
		}

		// Token: 0x0600F037 RID: 61495 RVA: 0x0040A734 File Offset: 0x00408B34
		private void ShowCloseAnimation()
		{
			if (this.curAniState == SendDoorAnimationControl.AnimationState.eClose || this.curAniState == SendDoorAnimationControl.AnimationState.eStart)
			{
				return;
			}
			this.curAniState = SendDoorAnimationControl.AnimationState.eClose;
			Spine.AnimationState state = this.sAnimation.state;
			state.Complete += this.ShowStartAnimation;
			state.SetAnimation(0, "close", false);
			state.AddAnimation(0, "star", true, 0f);
			this.UpdateEffectState();
		}

		// Token: 0x0600F038 RID: 61496 RVA: 0x0040A7A8 File Offset: 0x00408BA8
		private void ShowStartAnimation(TrackEntry trackEntry)
		{
			if (this.curAniState == SendDoorAnimationControl.AnimationState.eStart)
			{
				return;
			}
			if (this.sAnimation == null)
			{
				return;
			}
			this.curAniState = SendDoorAnimationControl.AnimationState.eStart;
			Spine.AnimationState state = this.sAnimation.state;
			state.Complete -= this.ShowStartAnimation;
			this.UpdateEffectState();
		}

		// Token: 0x0600F039 RID: 61497 RVA: 0x0040A800 File Offset: 0x00408C00
		private void ShowInAnimation(TrackEntry trackEntry)
		{
			if (this.curAniState == SendDoorAnimationControl.AnimationState.eIn)
			{
				return;
			}
			if (this.sAnimation == null)
			{
				return;
			}
			this.curAniState = SendDoorAnimationControl.AnimationState.eIn;
			Spine.AnimationState state = this.sAnimation.state;
			state.Complete -= this.ShowInAnimation;
			this.UpdateEffectState();
		}

		// Token: 0x0600F03A RID: 61498 RVA: 0x0040A858 File Offset: 0x00408C58
		private void UpdateEffectState()
		{
			if (this.comState == null)
			{
				return;
			}
			switch (this.curAniState)
			{
			case SendDoorAnimationControl.AnimationState.eStart:
				this.comState.Key = "start";
				break;
			case SendDoorAnimationControl.AnimationState.eOpen:
				this.comState.Key = "open";
				break;
			case SendDoorAnimationControl.AnimationState.eIn:
				this.comState.Key = "in";
				break;
			case SendDoorAnimationControl.AnimationState.eClose:
				this.comState.Key = "close";
				break;
			default:
				this.comState.Key = "start";
				break;
			}
		}

		// Token: 0x0600F03B RID: 61499 RVA: 0x0040A904 File Offset: 0x00408D04
		private void OnDestroy()
		{
			this.curAniState = SendDoorAnimationControl.AnimationState.eNil;
			if (this.sAnimation != null)
			{
				this.sAnimation.ClearState();
			}
			this.sAnimation = null;
		}

		// Token: 0x0400933C RID: 37692
		private StateController comState;

		// Token: 0x0400933D RID: 37693
		private SendDoorAnimationControl.AnimationState curAniState;

		// Token: 0x0400933E RID: 37694
		private SkeletonAnimation sAnimation;

		// Token: 0x020017CA RID: 6090
		public enum AnimationState
		{
			// Token: 0x04009340 RID: 37696
			eNil,
			// Token: 0x04009341 RID: 37697
			eStart,
			// Token: 0x04009342 RID: 37698
			eOpen,
			// Token: 0x04009343 RID: 37699
			eIn,
			// Token: 0x04009344 RID: 37700
			eClose
		}
	}
}
