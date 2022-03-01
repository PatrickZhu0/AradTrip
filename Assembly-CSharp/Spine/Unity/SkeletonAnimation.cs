using System;
using System.Diagnostics;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E9 RID: 18921
	[ExecuteInEditMode]
	[AddComponentMenu("Spine/SkeletonAnimation")]
	[HelpURL("http://esotericsoftware.com/spine-unity-documentation#Controlling-Animation")]
	public class SkeletonAnimation : SkeletonRenderer, ISkeletonAnimation, IAnimationStateComponent
	{
		// Token: 0x1700241E RID: 9246
		// (get) Token: 0x0601B4C9 RID: 111817 RVA: 0x00867B06 File Offset: 0x00865F06
		public AnimationState AnimationState
		{
			get
			{
				return this.state;
			}
		}

		// Token: 0x1400006F RID: 111
		// (add) Token: 0x0601B4CA RID: 111818 RVA: 0x00867B10 File Offset: 0x00865F10
		// (remove) Token: 0x0601B4CB RID: 111819 RVA: 0x00867B48 File Offset: 0x00865F48
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UpdateBonesDelegate _UpdateLocal;

		// Token: 0x14000070 RID: 112
		// (add) Token: 0x0601B4CC RID: 111820 RVA: 0x00867B80 File Offset: 0x00865F80
		// (remove) Token: 0x0601B4CD RID: 111821 RVA: 0x00867BB8 File Offset: 0x00865FB8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UpdateBonesDelegate _UpdateWorld;

		// Token: 0x14000071 RID: 113
		// (add) Token: 0x0601B4CE RID: 111822 RVA: 0x00867BF0 File Offset: 0x00865FF0
		// (remove) Token: 0x0601B4CF RID: 111823 RVA: 0x00867C28 File Offset: 0x00866028
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected event UpdateBonesDelegate _UpdateComplete;

		// Token: 0x14000072 RID: 114
		// (add) Token: 0x0601B4D0 RID: 111824 RVA: 0x00867C5E File Offset: 0x0086605E
		// (remove) Token: 0x0601B4D1 RID: 111825 RVA: 0x00867C67 File Offset: 0x00866067
		public event UpdateBonesDelegate UpdateLocal
		{
			add
			{
				this._UpdateLocal += value;
			}
			remove
			{
				this._UpdateLocal -= value;
			}
		}

		// Token: 0x14000073 RID: 115
		// (add) Token: 0x0601B4D2 RID: 111826 RVA: 0x00867C70 File Offset: 0x00866070
		// (remove) Token: 0x0601B4D3 RID: 111827 RVA: 0x00867C79 File Offset: 0x00866079
		public event UpdateBonesDelegate UpdateWorld
		{
			add
			{
				this._UpdateWorld += value;
			}
			remove
			{
				this._UpdateWorld -= value;
			}
		}

		// Token: 0x14000074 RID: 116
		// (add) Token: 0x0601B4D4 RID: 111828 RVA: 0x00867C82 File Offset: 0x00866082
		// (remove) Token: 0x0601B4D5 RID: 111829 RVA: 0x00867C8B File Offset: 0x0086608B
		public event UpdateBonesDelegate UpdateComplete
		{
			add
			{
				this._UpdateComplete += value;
			}
			remove
			{
				this._UpdateComplete -= value;
			}
		}

		// Token: 0x1700241F RID: 9247
		// (get) Token: 0x0601B4D6 RID: 111830 RVA: 0x00867C94 File Offset: 0x00866094
		// (set) Token: 0x0601B4D7 RID: 111831 RVA: 0x00867CD8 File Offset: 0x008660D8
		public string AnimationName
		{
			get
			{
				if (!this.valid)
				{
					return this._animationName;
				}
				TrackEntry current = this.state.GetCurrent(0);
				return (current != null) ? current.Animation.Name : null;
			}
			set
			{
				if (this._animationName == value)
				{
					return;
				}
				this._animationName = value;
				if (string.IsNullOrEmpty(value))
				{
					this.state.ClearTrack(0);
				}
				else
				{
					this.TrySetAnimation(value, this.loop);
				}
			}
		}

		// Token: 0x0601B4D8 RID: 111832 RVA: 0x00867D28 File Offset: 0x00866128
		private TrackEntry TrySetAnimation(string animationName, bool animationLoop)
		{
			Animation animation = this.skeletonDataAsset.GetSkeletonData(false).FindAnimation(animationName);
			if (animation != null)
			{
				return this.state.SetAnimation(0, animation, animationLoop);
			}
			return null;
		}

		// Token: 0x0601B4D9 RID: 111833 RVA: 0x00867D5E File Offset: 0x0086615E
		public void ReWind()
		{
			this.ClearState();
			if (this._animationName != null)
			{
				this.TrySetAnimation(this._animationName, this.loop);
			}
			this.Update(0f);
		}

		// Token: 0x0601B4DA RID: 111834 RVA: 0x00867D8F File Offset: 0x0086618F
		public static SkeletonAnimation AddToGameObject(GameObject gameObject, SkeletonDataAsset skeletonDataAsset)
		{
			return SkeletonRenderer.AddSpineComponent<SkeletonAnimation>(gameObject, skeletonDataAsset);
		}

		// Token: 0x0601B4DB RID: 111835 RVA: 0x00867D98 File Offset: 0x00866198
		public static SkeletonAnimation NewSkeletonAnimationGameObject(SkeletonDataAsset skeletonDataAsset)
		{
			return SkeletonRenderer.NewSpineGameObject<SkeletonAnimation>(skeletonDataAsset);
		}

		// Token: 0x0601B4DC RID: 111836 RVA: 0x00867DA0 File Offset: 0x008661A0
		public override void ClearState()
		{
			base.ClearState();
			if (this.state != null)
			{
				this.state.ClearTracks();
			}
		}

		// Token: 0x0601B4DD RID: 111837 RVA: 0x00867DC0 File Offset: 0x008661C0
		public override void Initialize(bool overwrite)
		{
			if (this.valid && !overwrite)
			{
				return;
			}
			base.Initialize(overwrite);
			if (!this.valid)
			{
				return;
			}
			this.state = new AnimationState(this.skeletonDataAsset.GetAnimationStateData());
			if (!string.IsNullOrEmpty(this._animationName))
			{
				TrackEntry trackEntry = this.TrySetAnimation(this._animationName, this.loop);
				if (trackEntry != null)
				{
					this.Update(0f);
				}
			}
		}

		// Token: 0x0601B4DE RID: 111838 RVA: 0x00867E3C File Offset: 0x0086623C
		private void Update()
		{
			this.Update(Time.deltaTime);
		}

		// Token: 0x0601B4DF RID: 111839 RVA: 0x00867E4C File Offset: 0x0086624C
		public void Update(float deltaTime)
		{
			if (!this.valid)
			{
				return;
			}
			deltaTime *= this.timeScale;
			this.skeleton.Update(deltaTime);
			this.state.Update(deltaTime);
			this.state.Apply(this.skeleton);
			if (this._UpdateLocal != null)
			{
				this._UpdateLocal(this);
			}
			this.skeleton.UpdateWorldTransform();
			if (this._UpdateWorld != null)
			{
				this._UpdateWorld(this);
				this.skeleton.UpdateWorldTransform();
			}
			if (this._UpdateComplete != null)
			{
				this._UpdateComplete(this);
			}
		}

		// Token: 0x0401303D RID: 77885
		public AnimationState state;

		// Token: 0x04013041 RID: 77889
		[SerializeField]
		[SpineAnimation("", "", true, false)]
		private string _animationName;

		// Token: 0x04013042 RID: 77890
		public bool loop;

		// Token: 0x04013043 RID: 77891
		public float timeScale = 1f;
	}
}
