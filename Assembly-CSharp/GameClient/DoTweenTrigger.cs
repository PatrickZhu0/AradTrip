using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020045E7 RID: 17895
	public class DoTweenTrigger : MonoBehaviour
	{
		// Token: 0x060192B0 RID: 103088 RVA: 0x007F4E1A File Offset: 0x007F321A
		private void Start()
		{
		}

		// Token: 0x060192B1 RID: 103089 RVA: 0x007F4E1C File Offset: 0x007F321C
		private void OnDestroy()
		{
			this.doTweenTriggers.Clear();
			int i = 0;
			int count = this.akDoTweenComponents.Count;
			while (i < count)
			{
				DOTweenAnimation dotweenAnimation = this.akDoTweenComponents[i];
				if (!(null == dotweenAnimation))
				{
					dotweenAnimation.DOKill();
				}
				i++;
			}
			int j = 0;
			int count2 = this.akDoTweenComponentsOut.Count;
			while (j < count2)
			{
				DOTweenAnimation dotweenAnimation2 = this.akDoTweenComponentsOut[j];
				if (!(null == dotweenAnimation2))
				{
					dotweenAnimation2.DOKill();
				}
				j++;
			}
			this.akDoTweenComponents.Clear();
			this.akDoTweenComponentsOut.Clear();
			this.callbackFadeIn.RemoveAllListeners();
			this.callbackFadeOut.RemoveAllListeners();
		}

		// Token: 0x060192B2 RID: 103090 RVA: 0x007F4EE9 File Offset: 0x007F32E9
		public void AddTriggerObject(GameObject go)
		{
			if (go != null)
			{
				if (this.doTweenTriggers == null)
				{
					this.doTweenTriggers = new List<GameObject>();
				}
				this.doTweenTriggers.Add(go);
			}
		}

		// Token: 0x060192B3 RID: 103091 RVA: 0x007F4F1C File Offset: 0x007F331C
		public void Initialize()
		{
			if (!this.bInitialize)
			{
				this.bInitialize = true;
				this.iEndCount = 0;
				this.akDoTweenComponents.Clear();
				this.akDoTweenComponentsOut.Clear();
				if (this.doTweenTriggers != null)
				{
					for (int i = 0; i < this.doTweenTriggers.Count; i++)
					{
						if (!(this.doTweenTriggers[i] == null))
						{
							Component[] components = this.doTweenTriggers[i].GetComponents(typeof(DOTweenAnimation));
							if (components != null && components.Length > 0)
							{
								for (int j = 0; j < components.Length; j++)
								{
									DOTweenAnimation dotweenAnimation = components[j] as DOTweenAnimation;
									if (dotweenAnimation != null)
									{
										dotweenAnimation.id = DoTweenTrigger.FadeType.FT_In.ToString();
										dotweenAnimation.isFrom = true;
										dotweenAnimation.CreateTween();
										this.akDoTweenComponents.Add(dotweenAnimation);
										DOTweenAnimation dotweenAnimation2 = Utility.CopyComponent<DOTweenAnimation>(dotweenAnimation, dotweenAnimation.target.gameObject, true);
										if (dotweenAnimation2 != null)
										{
											dotweenAnimation2.isFrom = false;
											dotweenAnimation2.id = DoTweenTrigger.FadeType.FT_Out.ToString();
											dotweenAnimation2.CreateTween();
											this.akDoTweenComponentsOut.Add(dotweenAnimation2);
										}
									}
								}
							}
						}
					}
				}
				return;
			}
		}

		// Token: 0x060192B4 RID: 103092 RVA: 0x007F5078 File Offset: 0x007F3478
		public void CopyFrom(DoTweenTrigger target)
		{
			if (target != null)
			{
				this.iEndCount = 0;
				this.doTweenTriggers = null;
				this.akDoTweenComponents.Clear();
				for (int i = 0; i < target.akDoTweenComponents.Count; i++)
				{
					DOTweenAnimation dotweenAnimation = Utility.CopyComponent<DOTweenAnimation>(target.akDoTweenComponents[i], base.gameObject, true);
					if (dotweenAnimation != null)
					{
						dotweenAnimation.target = base.transform;
						dotweenAnimation.CreateTween();
						this.akDoTweenComponents.Add(dotweenAnimation);
					}
				}
				this.callbackFadeIn.RemoveAllListeners();
				this.callbackFadeOut.RemoveAllListeners();
			}
		}

		// Token: 0x060192B5 RID: 103093 RVA: 0x007F5120 File Offset: 0x007F3520
		public void FadeIn(UnityAction callback = null)
		{
			if (callback != null)
			{
				this.callbackFadeIn.RemoveAllListeners();
				this.callbackFadeIn.AddListener(callback);
			}
			if (!base.transform.gameObject.activeSelf)
			{
				base.transform.gameObject.SetActive(true);
			}
			this.iEndCount = 0;
			float num = 0f;
			for (int i = 0; i < this.akDoTweenComponents.Count; i++)
			{
				this.akDoTweenComponents[i].DORewind();
				this.akDoTweenComponents[i].DOPlayById(DoTweenTrigger.FadeType.FT_In.ToString());
				num = Mathf.Max(this.akDoTweenComponents[i].delay + this.akDoTweenComponents[i].duration, num);
			}
			this.eFadeType = DoTweenTrigger.FadeType.FT_In;
			InvokeMethod.Invoke(num, new UnityAction(this.OnFadeInOver));
		}

		// Token: 0x060192B6 RID: 103094 RVA: 0x007F5210 File Offset: 0x007F3610
		public void FadeOut(UnityAction callback = null)
		{
			if (callback != null)
			{
				this.callbackFadeOut.RemoveAllListeners();
				this.callbackFadeOut.AddListener(callback);
			}
			this.iEndCount = 0;
			float num = 0f;
			for (int i = 0; i < this.akDoTweenComponentsOut.Count; i++)
			{
				this.akDoTweenComponentsOut[i].DOPlayById(DoTweenTrigger.FadeType.FT_Out.ToString());
				num = Mathf.Max(this.akDoTweenComponentsOut[i].delay + this.akDoTweenComponentsOut[i].duration, num);
			}
			this.eFadeType = DoTweenTrigger.FadeType.FT_Out;
			InvokeMethod.Invoke(num, new UnityAction(this.OnFadeOutOver));
		}

		// Token: 0x060192B7 RID: 103095 RVA: 0x007F52C6 File Offset: 0x007F36C6
		private void OnFadeOutOver()
		{
			if (this.callbackFadeOut != null)
			{
				this.callbackFadeOut.Invoke();
			}
		}

		// Token: 0x060192B8 RID: 103096 RVA: 0x007F52DE File Offset: 0x007F36DE
		private void OnFadeInOver()
		{
			if (this.callbackFadeIn != null)
			{
				this.callbackFadeIn.Invoke();
			}
		}

		// Token: 0x0401206D RID: 73837
		public List<GameObject> doTweenTriggers;

		// Token: 0x0401206E RID: 73838
		private List<DOTweenAnimation> akDoTweenComponents = new List<DOTweenAnimation>();

		// Token: 0x0401206F RID: 73839
		private List<DOTweenAnimation> akDoTweenComponentsOut = new List<DOTweenAnimation>();

		// Token: 0x04012070 RID: 73840
		private UnityEvent callbackFadeIn = new UnityEvent();

		// Token: 0x04012071 RID: 73841
		private UnityEvent callbackFadeOut = new UnityEvent();

		// Token: 0x04012072 RID: 73842
		private int iEndCount;

		// Token: 0x04012073 RID: 73843
		private bool bInitialize;

		// Token: 0x04012074 RID: 73844
		private DoTweenTrigger.FadeType eFadeType;

		// Token: 0x020045E8 RID: 17896
		private enum FadeType
		{
			// Token: 0x04012076 RID: 73846
			FT_In,
			// Token: 0x04012077 RID: 73847
			FT_Out
		}
	}
}
