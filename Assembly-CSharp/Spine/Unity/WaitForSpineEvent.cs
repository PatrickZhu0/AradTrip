using System;
using System.Collections;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A21 RID: 18977
	public class WaitForSpineEvent : IEnumerator
	{
		// Token: 0x0601B676 RID: 112246 RVA: 0x00873B3A File Offset: 0x00871F3A
		public WaitForSpineEvent(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			this.Subscribe(state, eventDataReference, unsubscribeAfterFiring);
		}

		// Token: 0x0601B677 RID: 112247 RVA: 0x00873B4B File Offset: 0x00871F4B
		public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			this.Subscribe(skeletonAnimation.state, eventDataReference, unsubscribeAfterFiring);
		}

		// Token: 0x0601B678 RID: 112248 RVA: 0x00873B61 File Offset: 0x00871F61
		public WaitForSpineEvent(AnimationState state, string eventName, bool unsubscribeAfterFiring = true)
		{
			this.SubscribeByName(state, eventName, unsubscribeAfterFiring);
		}

		// Token: 0x0601B679 RID: 112249 RVA: 0x00873B72 File Offset: 0x00871F72
		public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, string eventName, bool unsubscribeAfterFiring = true)
		{
			this.SubscribeByName(skeletonAnimation.state, eventName, unsubscribeAfterFiring);
		}

		// Token: 0x0601B67A RID: 112250 RVA: 0x00873B88 File Offset: 0x00871F88
		private void Subscribe(AnimationState state, EventData eventDataReference, bool unsubscribe)
		{
			if (state == null)
			{
				Debug.LogWarning("AnimationState argument was null. Coroutine will continue immediately.");
				this.m_WasFired = true;
				return;
			}
			if (eventDataReference == null)
			{
				Debug.LogWarning("eventDataReference argument was null. Coroutine will continue immediately.");
				this.m_WasFired = true;
				return;
			}
			this.m_AnimationState = state;
			this.m_TargetEvent = eventDataReference;
			state.Event += this.HandleAnimationStateEvent;
			this.m_unsubscribeAfterFiring = unsubscribe;
		}

		// Token: 0x0601B67B RID: 112251 RVA: 0x00873BEC File Offset: 0x00871FEC
		private void SubscribeByName(AnimationState state, string eventName, bool unsubscribe)
		{
			if (state == null)
			{
				Debug.LogWarning("AnimationState argument was null. Coroutine will continue immediately.");
				this.m_WasFired = true;
				return;
			}
			if (string.IsNullOrEmpty(eventName))
			{
				Debug.LogWarning("eventName argument was null. Coroutine will continue immediately.");
				this.m_WasFired = true;
				return;
			}
			this.m_AnimationState = state;
			this.m_EventName = eventName;
			state.Event += this.HandleAnimationStateEventByName;
			this.m_unsubscribeAfterFiring = unsubscribe;
		}

		// Token: 0x0601B67C RID: 112252 RVA: 0x00873C58 File Offset: 0x00872058
		private void HandleAnimationStateEventByName(TrackEntry trackEntry, Event e)
		{
			this.m_WasFired |= (e.Data.Name == this.m_EventName);
			if (this.m_WasFired && this.m_unsubscribeAfterFiring)
			{
				this.m_AnimationState.Event -= this.HandleAnimationStateEventByName;
			}
		}

		// Token: 0x0601B67D RID: 112253 RVA: 0x00873CB8 File Offset: 0x008720B8
		private void HandleAnimationStateEvent(TrackEntry trackEntry, Event e)
		{
			this.m_WasFired |= (e.Data == this.m_TargetEvent);
			if (this.m_WasFired && this.m_unsubscribeAfterFiring)
			{
				this.m_AnimationState.Event -= this.HandleAnimationStateEvent;
			}
		}

		// Token: 0x17002457 RID: 9303
		// (get) Token: 0x0601B67E RID: 112254 RVA: 0x00873D0D File Offset: 0x0087210D
		// (set) Token: 0x0601B67F RID: 112255 RVA: 0x00873D15 File Offset: 0x00872115
		public bool WillUnsubscribeAfterFiring
		{
			get
			{
				return this.m_unsubscribeAfterFiring;
			}
			set
			{
				this.m_unsubscribeAfterFiring = value;
			}
		}

		// Token: 0x0601B680 RID: 112256 RVA: 0x00873D1E File Offset: 0x0087211E
		public WaitForSpineEvent NowWaitFor(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			((IEnumerator)this).Reset();
			this.Clear(state);
			this.Subscribe(state, eventDataReference, unsubscribeAfterFiring);
			return this;
		}

		// Token: 0x0601B681 RID: 112257 RVA: 0x00873D37 File Offset: 0x00872137
		public WaitForSpineEvent NowWaitFor(AnimationState state, string eventName, bool unsubscribeAfterFiring = true)
		{
			((IEnumerator)this).Reset();
			this.Clear(state);
			this.SubscribeByName(state, eventName, unsubscribeAfterFiring);
			return this;
		}

		// Token: 0x0601B682 RID: 112258 RVA: 0x00873D50 File Offset: 0x00872150
		private void Clear(AnimationState state)
		{
			state.Event -= this.HandleAnimationStateEvent;
			state.Event -= this.HandleAnimationStateEventByName;
		}

		// Token: 0x0601B683 RID: 112259 RVA: 0x00873D76 File Offset: 0x00872176
		bool IEnumerator.MoveNext()
		{
			if (this.m_WasFired)
			{
				((IEnumerator)this).Reset();
				return false;
			}
			return true;
		}

		// Token: 0x0601B684 RID: 112260 RVA: 0x00873D8C File Offset: 0x0087218C
		void IEnumerator.Reset()
		{
			this.m_WasFired = false;
		}

		// Token: 0x17002456 RID: 9302
		// (get) Token: 0x0601B685 RID: 112261 RVA: 0x00873D95 File Offset: 0x00872195
		object IEnumerator.Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x04013167 RID: 78183
		private EventData m_TargetEvent;

		// Token: 0x04013168 RID: 78184
		private string m_EventName;

		// Token: 0x04013169 RID: 78185
		private AnimationState m_AnimationState;

		// Token: 0x0401316A RID: 78186
		private bool m_WasFired;

		// Token: 0x0401316B RID: 78187
		private bool m_unsubscribeAfterFiring;
	}
}
