using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02004600 RID: 17920
	public class UIFrameScript : MonoBehaviour
	{
		// Token: 0x06019301 RID: 103169 RVA: 0x007F7760 File Offset: 0x007F5B60
		public void Initialize()
		{
			this.akFunctions.Clear();
			this.akFunctions.Add(this.FadeIn);
			this.akFunctions.Add(this.FadeOut);
			this.akFunctions.Add(this.OpenFrameBack);
			this.akFunctions.Add(this.RemoveFrameBack);
			this.RemoveFrameBack.orgAddBack = this.OpenFrameBack;
			if (this.akFunctions != null)
			{
				for (int i = 0; i < this.akFunctions.Count; i++)
				{
					this.akFunctions[i].Initialize();
				}
			}
		}

		// Token: 0x06019302 RID: 103170 RVA: 0x007F7808 File Offset: 0x007F5C08
		public void DoPlay(UIFrameScript.FunctionType eFunctionType, UnityAction callback = null)
		{
			if (this.akFunctions != null)
			{
				for (int i = 0; i < this.akFunctions.Count; i++)
				{
					if (this.akFunctions[i] != null && this.akFunctions[i].Function == eFunctionType)
					{
						float fDelyTime = this.akFunctions[i].DoPlay(base.gameObject);
						if (callback != null)
						{
							InvokeMethod.Invoke(this, fDelyTime, callback);
						}
						return;
					}
				}
			}
		}

		// Token: 0x06019303 RID: 103171 RVA: 0x007F788B File Offset: 0x007F5C8B
		private void OnDestroy()
		{
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x040120B2 RID: 73906
		public static string ms_effect_root = "UIFlatten/Prefabs/CommEffect/";

		// Token: 0x040120B3 RID: 73907
		public UIFrameScript.FunctionBase FadeIn = new UIFrameScript.FunctionBase(UIFrameScript.FunctionType.FT_FADEIN);

		// Token: 0x040120B4 RID: 73908
		public UIFrameScript.FunctionBase FadeOut = new UIFrameScript.FunctionBase(UIFrameScript.FunctionType.FT_FADEOUT);

		// Token: 0x040120B5 RID: 73909
		public UIFrameScript.FunctionAddBack OpenFrameBack = new UIFrameScript.FunctionAddBack();

		// Token: 0x040120B6 RID: 73910
		private UIFrameScript.FunctionRemoveBack RemoveFrameBack = new UIFrameScript.FunctionRemoveBack();

		// Token: 0x040120B7 RID: 73911
		private List<UIFrameScript.FunctionBase> akFunctions = new List<UIFrameScript.FunctionBase>();

		// Token: 0x02004601 RID: 17921
		public enum FunctionType
		{
			// Token: 0x040120B9 RID: 73913
			FT_FADEIN,
			// Token: 0x040120BA RID: 73914
			FT_FADEOUT,
			// Token: 0x040120BB RID: 73915
			FT_ADDBACK,
			// Token: 0x040120BC RID: 73916
			FT_REMOVEBACK,
			// Token: 0x040120BD RID: 73917
			FT_COUNT
		}

		// Token: 0x02004602 RID: 17922
		[Serializable]
		public class FunctionBase
		{
			// Token: 0x06019305 RID: 103173 RVA: 0x007F789F File Offset: 0x007F5C9F
			public FunctionBase(UIFrameScript.FunctionType eFunctionType)
			{
				this.eFunctionType = eFunctionType;
			}

			// Token: 0x170020B0 RID: 8368
			// (get) Token: 0x06019306 RID: 103174 RVA: 0x007F78C4 File Offset: 0x007F5CC4
			public UIFrameScript.FunctionType Function
			{
				get
				{
					return this.eFunctionType;
				}
			}

			// Token: 0x06019307 RID: 103175 RVA: 0x007F78CC File Offset: 0x007F5CCC
			public void Initialize()
			{
				this.bHasCreate = false;
				this.goPrefab = null;
				this.comTweens.Clear();
				this.comAnimations.Clear();
				this.fTotalCompleteTime = 0f;
			}

			// Token: 0x06019308 RID: 103176 RVA: 0x007F7900 File Offset: 0x007F5D00
			public virtual float DoPlay(GameObject go)
			{
				if (!this.bHasCreate)
				{
					this.Create(go);
				}
				this.fTotalCompleteTime = 0f;
				for (int i = 0; i < this.comTweens.Count; i++)
				{
					if (this.comTweens[i].onComplete == null)
					{
						this.comTweens[i].onComplete = new UnityEvent();
					}
					this.comTweens[i].onComplete.RemoveAllListeners();
					this.comTweens[i].DOPlay();
					this.fTotalCompleteTime = Mathf.Max(this.comTweens[i].delay + this.comTweens[i].duration * (float)this.comTweens[i].loops, this.fTotalCompleteTime);
				}
				for (int j = 0; j < this.comAnimations.Count; j++)
				{
					if (this.comAnimations[j] != null)
					{
						this.comAnimations[j].DoPlay(null);
						this.fTotalCompleteTime = Mathf.Max(this.fTotalCompleteTime, this.comAnimations[j].GetTotalRunTime());
					}
				}
				return this.fTotalCompleteTime;
			}

			// Token: 0x06019309 RID: 103177 RVA: 0x007F7A50 File Offset: 0x007F5E50
			protected virtual void Create(GameObject go)
			{
				if (!this.bHasCreate)
				{
					this.comTweens.Clear();
					this.comAnimations.Clear();
					if (this.prefabs != null)
					{
						string[] array = this.prefabs.Split(new char[]
						{
							'/'
						});
						if (array.Length > 0)
						{
							this.goPrefab = ScriptPool.CreatePrefab(UIFrameScript.ms_effect_root + array[array.Length - 1], true);
						}
					}
					if (this.goPrefab != null && go != null)
					{
						Component[] components = this.goPrefab.GetComponents(typeof(DOTweenAnimation));
						if (components.Length > 0)
						{
							for (int i = 0; i < components.Length; i++)
							{
								DOTweenAnimation dotweenAnimation = Utility.CopyComponent<DOTweenAnimation>(components[i] as DOTweenAnimation, go, true);
								if (dotweenAnimation != null)
								{
									dotweenAnimation.target = go.transform;
									dotweenAnimation.CreateTween();
									this.comTweens.Add(dotweenAnimation);
								}
							}
						}
						components = this.goPrefab.GetComponents(typeof(AnimationController));
						if (components.Length > 0)
						{
							for (int j = 0; j < components.Length; j++)
							{
								AnimationController animationController = Utility.CopyComponent<AnimationController>(components[j] as AnimationController, go, true);
								if (animationController != null)
								{
									animationController.Initialize();
									this.comAnimations.Add(animationController);
								}
							}
						}
					}
					this.bHasCreate = true;
				}
			}

			// Token: 0x040120BE RID: 73918
			protected bool bHasCreate;

			// Token: 0x040120BF RID: 73919
			protected GameObject goPrefab;

			// Token: 0x040120C0 RID: 73920
			protected UIFrameScript.FunctionType eFunctionType;

			// Token: 0x040120C1 RID: 73921
			public string prefabs;

			// Token: 0x040120C2 RID: 73922
			private List<DOTweenAnimation> comTweens = new List<DOTweenAnimation>();

			// Token: 0x040120C3 RID: 73923
			private List<AnimationController> comAnimations = new List<AnimationController>();

			// Token: 0x040120C4 RID: 73924
			private float fTotalCompleteTime;
		}

		// Token: 0x02004603 RID: 17923
		[Serializable]
		public class FunctionAddBack : UIFrameScript.FunctionBase
		{
			// Token: 0x0601930A RID: 103178 RVA: 0x007F7BC1 File Offset: 0x007F5FC1
			public FunctionAddBack() : base(UIFrameScript.FunctionType.FT_ADDBACK)
			{
			}

			// Token: 0x0601930B RID: 103179 RVA: 0x007F7BCC File Offset: 0x007F5FCC
			protected override void Create(GameObject go)
			{
				if (!this.bHasCreate)
				{
					if (go != null && go.transform.parent != null && this.prefabs != null)
					{
						string[] array = this.prefabs.Split(new char[]
						{
							'/'
						});
						if (array.Length > 0)
						{
							this.goPrefab = ScriptPool.CreatePrefab(UIFrameScript.ms_effect_root + array[array.Length - 1], false);
						}
						if (this.goPrefab != null)
						{
							GameObject gameObject = go.transform.parent.gameObject;
							GameObject goPrefab = this.goPrefab;
							goPrefab.SetActive(true);
							goPrefab.name = go.name + "parent";
							Utility.AttachTo(goPrefab, gameObject, false);
							Utility.AttachTo(go, goPrefab, false);
							DoTweenTrigger component = goPrefab.GetComponent<DoTweenTrigger>();
							if (component != null)
							{
								component.Initialize();
							}
						}
					}
					this.bHasCreate = true;
				}
			}

			// Token: 0x0601930C RID: 103180 RVA: 0x007F7CC4 File Offset: 0x007F60C4
			public override float DoPlay(GameObject go)
			{
				if (!this.bHasCreate)
				{
					this.Create(go);
				}
				return 0f;
			}
		}

		// Token: 0x02004604 RID: 17924
		public class FunctionRemoveBack : UIFrameScript.FunctionBase
		{
			// Token: 0x0601930D RID: 103181 RVA: 0x007F7CDD File Offset: 0x007F60DD
			public FunctionRemoveBack() : base(UIFrameScript.FunctionType.FT_REMOVEBACK)
			{
				this.orgAddBack = null;
			}

			// Token: 0x0601930E RID: 103182 RVA: 0x007F7CF0 File Offset: 0x007F60F0
			protected override void Create(GameObject go)
			{
				if (!this.bHasCreate)
				{
					if (go != null && go.transform.parent != null && go.transform.parent.parent != null)
					{
						GameObject gameObject = go.transform.parent.gameObject;
						GameObject gameObject2 = gameObject.transform.parent.gameObject;
						if (gameObject.name == go.name + "parent" && gameObject != null && gameObject2 != null)
						{
							Utility.AttachTo(go, gameObject2, false);
							if (this.orgAddBack != null && this.orgAddBack.prefabs != null)
							{
								string[] array = this.orgAddBack.prefabs.Split(new char[]
								{
									'/'
								});
								if (array.Length > 0)
								{
									ScriptPool.RecyclePrefab(gameObject, UIFrameScript.ms_effect_root + array[array.Length - 1]);
								}
							}
							else
							{
								gameObject.SetActive(false);
								Object.Destroy(gameObject);
							}
						}
					}
					this.bHasCreate = true;
				}
			}

			// Token: 0x0601930F RID: 103183 RVA: 0x007F7E17 File Offset: 0x007F6217
			public override float DoPlay(GameObject go)
			{
				if (!this.bHasCreate)
				{
					this.Create(go);
				}
				return 0f;
			}

			// Token: 0x040120C5 RID: 73925
			public UIFrameScript.FunctionAddBack orgAddBack;
		}
	}
}
