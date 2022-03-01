using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EE1 RID: 3809
	public class ComEffectController : MonoBehaviour
	{
		// Token: 0x0600956D RID: 38253 RVA: 0x001C3194 File Offset: 0x001C1594
		private void OnValidate()
		{
			if (this.test)
			{
				this.Stop();
				this.Play();
				this.test = false;
			}
		}

		// Token: 0x0600956E RID: 38254 RVA: 0x001C31B4 File Offset: 0x001C15B4
		private void Update()
		{
			if (this.m_bPlaying)
			{
				for (int i = 0; i < this.m_arrEffectRuntimes.Count; i++)
				{
					if (!this.m_arrEffectRuntimes[i].bStarted)
					{
						this.m_arrEffectRuntimes[i].fRemainTime -= Time.deltaTime;
						if (this.m_arrEffectRuntimes[i].fRemainTime <= 0f)
						{
							GameObject objEffect = this.m_arrEffectRuntimes[i].objEffect;
							objEffect.SetActive(true);
							GeUIEffectParticle[] componentsInChildren = objEffect.GetComponentsInChildren<GeUIEffectParticle>();
							for (int j = 0; j < componentsInChildren.Length; j++)
							{
								componentsInChildren[j].StartEmit();
							}
							ParticleSystem[] componentsInChildren2 = objEffect.GetComponentsInChildren<ParticleSystem>();
							for (int k = 0; k < componentsInChildren2.Length; k++)
							{
								componentsInChildren2[k].Play();
							}
							DOTweenAnimation[] componentsInChildren3 = objEffect.GetComponentsInChildren<DOTweenAnimation>();
							for (int l = 0; l < componentsInChildren3.Length; l++)
							{
								if (componentsInChildren3[l].id == this.m_arrEffectRuntimes[i].strTag)
								{
									componentsInChildren3[l].isActive = true;
									if (componentsInChildren3[l].tween == null)
									{
										componentsInChildren3[l].CreateTween();
									}
									TweenExtensions.Restart(componentsInChildren3[l].tween, true);
								}
							}
							this.m_arrEffectRuntimes[i].bStarted = true;
						}
					}
				}
				for (int m = 0; m < this.m_arrEventRuntimes.Count; m++)
				{
					if (!this.m_arrEventRuntimes[m].bStarted)
					{
						this.m_arrEventRuntimes[m].fRemainTime -= Time.deltaTime;
						if (this.m_arrEventRuntimes[m].fRemainTime <= 0f)
						{
							try
							{
								List<Action> list;
								this.m_eventProcessors.TryGetValue(this.m_arrEventRuntimes[m].eEventID, out list);
								if (list != null)
								{
									List<Action> list2 = new List<Action>(list);
									for (int n = 0; n < list.Count; n++)
									{
										list2[n]();
									}
								}
							}
							catch (Exception ex)
							{
								Logger.LogError(ex.ToString());
							}
							this.m_arrEffectRuntimes[m].bStarted = true;
						}
					}
				}
				if (!this.loop)
				{
					this.m_fRemainTime -= Time.deltaTime;
					if (this.m_fRemainTime <= 0f)
					{
						this.Stop();
					}
				}
			}
		}

		// Token: 0x0600956F RID: 38255 RVA: 0x001C3464 File Offset: 0x001C1864
		public void RegisterEvent(EEffectEvent a_event, Action a_callback)
		{
			if (!this.m_eventProcessors.ContainsKey(a_event))
			{
				this.m_eventProcessors.Add(a_event, new List<Action>());
			}
			List<Action> list = this.m_eventProcessors[a_event];
			if (!list.Contains(a_callback))
			{
				list.Add(a_callback);
			}
		}

		// Token: 0x06009570 RID: 38256 RVA: 0x001C34B4 File Offset: 0x001C18B4
		public void UnRegisterEvent(EEffectEvent a_event, Action a_callback)
		{
			List<Action> list;
			this.m_eventProcessors.TryGetValue(a_event, out list);
			if (list != null)
			{
				list.Remove(a_callback);
			}
		}

		// Token: 0x06009571 RID: 38257 RVA: 0x001C34E0 File Offset: 0x001C18E0
		public void Play()
		{
			this.m_bPlaying = true;
			this.m_fRemainTime = this.duration;
			this.m_arrEffectRuntimes.Clear();
			for (int i = 0; i < this.arrEffectInfos.Length; i++)
			{
				ComEffectController.EffectRuntime effectRuntime = new ComEffectController.EffectRuntime();
				effectRuntime.objEffect = this.arrEffectInfos[i].effect;
				effectRuntime.fRemainTime = this.arrEffectInfos[i].startTime;
				effectRuntime.strTag = this.arrEffectInfos[i].tag;
				effectRuntime.bStarted = false;
				effectRuntime.bOldActive = effectRuntime.objEffect.activeSelf;
				this.m_arrEffectRuntimes.Add(effectRuntime);
			}
			this.m_arrEventRuntimes.Clear();
			for (int j = 0; j < this.arrEventInfos.Length; j++)
			{
				ComEffectController.EventRuntime eventRuntime = new ComEffectController.EventRuntime();
				eventRuntime.eEventID = this.arrEventInfos[j].effectEvent;
				eventRuntime.fRemainTime = this.arrEventInfos[j].startTime;
				eventRuntime.bStarted = false;
				this.m_arrEventRuntimes.Add(eventRuntime);
			}
		}

		// Token: 0x06009572 RID: 38258 RVA: 0x001C35EC File Offset: 0x001C19EC
		public void Stop()
		{
			this.m_bPlaying = false;
			this.m_fRemainTime = 0f;
			for (int i = 0; i < this.m_arrEffectRuntimes.Count; i++)
			{
				ComEffectController.EffectRuntime effectRuntime = this.m_arrEffectRuntimes[i];
				if (effectRuntime.bStarted)
				{
					GameObject objEffect = this.m_arrEffectRuntimes[i].objEffect;
					GeUIEffectParticle[] componentsInChildren = objEffect.GetComponentsInChildren<GeUIEffectParticle>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						componentsInChildren[j].StopEmit();
					}
					ParticleSystem[] componentsInChildren2 = objEffect.GetComponentsInChildren<ParticleSystem>();
					for (int k = 0; k < componentsInChildren2.Length; k++)
					{
						componentsInChildren2[k].Stop();
					}
					DOTweenAnimation[] componentsInChildren3 = objEffect.GetComponentsInChildren<DOTweenAnimation>();
					for (int l = 0; l < componentsInChildren3.Length; l++)
					{
						if (componentsInChildren3[l].id == this.m_arrEffectRuntimes[i].strTag)
						{
							componentsInChildren3[l].DORewind();
							componentsInChildren3[l].isActive = false;
						}
					}
					objEffect.SetActive(effectRuntime.bOldActive);
				}
			}
			this.m_arrEffectRuntimes.Clear();
			this.m_arrEventRuntimes.Clear();
		}

		// Token: 0x06009573 RID: 38259 RVA: 0x001C3721 File Offset: 0x001C1B21
		public float Duration()
		{
			return this.duration;
		}

		// Token: 0x06009574 RID: 38260 RVA: 0x001C3729 File Offset: 0x001C1B29
		public void Clear()
		{
			this.Stop();
			this.m_eventProcessors.Clear();
		}

		// Token: 0x04004C61 RID: 19553
		public bool test;

		// Token: 0x04004C62 RID: 19554
		public EffectInfo[] arrEffectInfos = new EffectInfo[0];

		// Token: 0x04004C63 RID: 19555
		public EventInfo[] arrEventInfos = new EventInfo[0];

		// Token: 0x04004C64 RID: 19556
		public float duration;

		// Token: 0x04004C65 RID: 19557
		public bool loop;

		// Token: 0x04004C66 RID: 19558
		private bool m_bPlaying;

		// Token: 0x04004C67 RID: 19559
		private float m_fRemainTime;

		// Token: 0x04004C68 RID: 19560
		private List<ComEffectController.EffectRuntime> m_arrEffectRuntimes = new List<ComEffectController.EffectRuntime>();

		// Token: 0x04004C69 RID: 19561
		private List<ComEffectController.EventRuntime> m_arrEventRuntimes = new List<ComEffectController.EventRuntime>();

		// Token: 0x04004C6A RID: 19562
		private Dictionary<EEffectEvent, List<Action>> m_eventProcessors = new Dictionary<EEffectEvent, List<Action>>();

		// Token: 0x02000EE2 RID: 3810
		private class EffectRuntime
		{
			// Token: 0x04004C6B RID: 19563
			public GameObject objEffect;

			// Token: 0x04004C6C RID: 19564
			public float fRemainTime;

			// Token: 0x04004C6D RID: 19565
			public string strTag = string.Empty;

			// Token: 0x04004C6E RID: 19566
			public bool bStarted;

			// Token: 0x04004C6F RID: 19567
			public bool bOldActive;
		}

		// Token: 0x02000EE3 RID: 3811
		private class EventRuntime
		{
			// Token: 0x04004C70 RID: 19568
			public EEffectEvent eEventID = EEffectEvent.Invalid;

			// Token: 0x04004C71 RID: 19569
			public float fRemainTime;

			// Token: 0x04004C72 RID: 19570
			public bool bStarted;
		}
	}
}
