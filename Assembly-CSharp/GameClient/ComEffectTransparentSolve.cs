using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020017DA RID: 6106
	public class ComEffectTransparentSolve : MonoBehaviour
	{
		// Token: 0x0600F0B3 RID: 61619 RVA: 0x0040CE1A File Offset: 0x0040B21A
		private void Awake()
		{
			GlobalEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FrameOpen, new ClientEventSystem.UIEventHandler(this._OnFrameOpen));
			GlobalEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FrameClose, new ClientEventSystem.UIEventHandler(this._OnFrameClose));
		}

		// Token: 0x0600F0B4 RID: 61620 RVA: 0x0040CE54 File Offset: 0x0040B254
		private void Start()
		{
			if (!this.bInited)
			{
				this.comBinder = base.GetComponentInParent<ClientFrameBinder>();
				if (null != this.comBinder)
				{
					this.mFrameType = this.comBinder.GetFrameType();
				}
				else
				{
					this.mFrameType = null;
				}
				this.bInited = true;
			}
			this._Check();
		}

		// Token: 0x0600F0B5 RID: 61621 RVA: 0x0040CEB3 File Offset: 0x0040B2B3
		private void OnDestroy()
		{
			GlobalEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FrameOpen, new ClientEventSystem.UIEventHandler(this._OnFrameOpen));
			GlobalEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FrameClose, new ClientEventSystem.UIEventHandler(this._OnFrameClose));
		}

		// Token: 0x0600F0B6 RID: 61622 RVA: 0x0040CEEC File Offset: 0x0040B2EC
		private int _FindIndex(Type type)
		{
			if (this.mFrameType == null)
			{
				return -1;
			}
			if (type.Name == ComEffectTransparentSolve.ms_invalid_type)
			{
				return -1;
			}
			if (type != null)
			{
				for (int i = 0; i < this.types.Length; i++)
				{
					if (this.types[i] == type.Name && this.types[i] != this.mFrameType.Name)
					{
						return i;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600F0B7 RID: 61623 RVA: 0x0040CF74 File Offset: 0x0040B374
		private void _OnFrameOpen(UIEvent uiEvent)
		{
			Type type = uiEvent.Param2 as Type;
			if (type != null)
			{
				int num = this._FindIndex(type);
				if (num != -1)
				{
					this._Check();
				}
			}
		}

		// Token: 0x0600F0B8 RID: 61624 RVA: 0x0040CFA8 File Offset: 0x0040B3A8
		private void _OnFrameClose(UIEvent uiEvent)
		{
			Type type = uiEvent.Param2 as Type;
			if (type != null)
			{
				int num = this._FindIndex(type);
				if (num != -1)
				{
					this._Check();
				}
			}
		}

		// Token: 0x0600F0B9 RID: 61625 RVA: 0x0040CFDC File Offset: 0x0040B3DC
		private void _Check()
		{
			bool flag = false;
			int num = 0;
			while (num < this.types.Length && !flag)
			{
				flag = (!string.IsNullOrEmpty(this.types[num]) && Singleton<ClientSystemManager>.GetInstance().HasActiveFrame(this.types[num]));
				num++;
			}
			UnityEvent unityEvent = flag ? this.onDisable : this.onEnable;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x040093B3 RID: 37811
		private static string ms_invalid_type = "WaitNetMessageFrame";

		// Token: 0x040093B4 RID: 37812
		public UnityEvent onEnable;

		// Token: 0x040093B5 RID: 37813
		public UnityEvent onDisable;

		// Token: 0x040093B6 RID: 37814
		[HideInInspector]
		public string[] types = new string[0];

		// Token: 0x040093B7 RID: 37815
		private ClientFrameBinder comBinder;

		// Token: 0x040093B8 RID: 37816
		private bool bInited;

		// Token: 0x040093B9 RID: 37817
		private Type mFrameType;
	}
}
