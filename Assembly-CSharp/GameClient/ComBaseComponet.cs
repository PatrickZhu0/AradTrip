using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DA5 RID: 3493
	[RequireComponent(typeof(ComCommonBind))]
	public class ComBaseComponet : MonoBehaviour
	{
		// Token: 0x170018C8 RID: 6344
		// (get) Token: 0x06008D7A RID: 36218 RVA: 0x001A56E5 File Offset: 0x001A3AE5
		public bool isInited
		{
			get
			{
				return this.mIsInited;
			}
		}

		// Token: 0x06008D7B RID: 36219 RVA: 0x001A56F0 File Offset: 0x001A3AF0
		private void _bindUI()
		{
			if (null == this.mBind)
			{
				this.mBind = base.GetComponent<ComCommonBind>();
			}
			if (!this.mIsInited)
			{
				this.mIsInited = true;
				this._bindExUI();
				this._bindEvents();
				this.Init();
			}
		}

		// Token: 0x06008D7C RID: 36220 RVA: 0x001A573E File Offset: 0x001A3B3E
		private void _unbindUI()
		{
			if (this.mIsInited)
			{
				this.UnInit();
				this._unbindEvents();
				this._unbindExUI();
			}
			this.mIsInited = false;
		}

		// Token: 0x06008D7D RID: 36221 RVA: 0x001A5764 File Offset: 0x001A3B64
		private void _bindEvents()
		{
			ClientEventNode[] listenEvents = this.GetListenEvents();
			for (int i = 0; i < listenEvents.Length; i++)
			{
				if (listenEvents[i] != null && listenEvents[i].handle != null)
				{
					UIEventSystem.GetInstance().RegisterEventHandler(listenEvents[i].id, listenEvents[i].handle);
				}
			}
		}

		// Token: 0x06008D7E RID: 36222 RVA: 0x001A57BC File Offset: 0x001A3BBC
		private void _unbindEvents()
		{
			ClientEventNode[] listenEvents = this.GetListenEvents();
			for (int i = 0; i < listenEvents.Length; i++)
			{
				if (listenEvents[i] != null && listenEvents[i].handle != null)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(listenEvents[i].id, listenEvents[i].handle);
				}
			}
		}

		// Token: 0x06008D7F RID: 36223 RVA: 0x001A5813 File Offset: 0x001A3C13
		protected virtual void Awake()
		{
			this.mIsInited = false;
			this._bindUI();
		}

		// Token: 0x06008D80 RID: 36224 RVA: 0x001A5822 File Offset: 0x001A3C22
		protected virtual void OnDestroy()
		{
			this._unbindUI();
		}

		// Token: 0x06008D81 RID: 36225 RVA: 0x001A582A File Offset: 0x001A3C2A
		protected virtual void OnEnable()
		{
			this._bindUI();
		}

		// Token: 0x06008D82 RID: 36226 RVA: 0x001A5832 File Offset: 0x001A3C32
		protected virtual void OnDisable()
		{
			this._unbindUI();
		}

		// Token: 0x06008D83 RID: 36227 RVA: 0x001A583A File Offset: 0x001A3C3A
		protected virtual void Init()
		{
		}

		// Token: 0x06008D84 RID: 36228 RVA: 0x001A583C File Offset: 0x001A3C3C
		protected virtual void UnInit()
		{
		}

		// Token: 0x06008D85 RID: 36229 RVA: 0x001A583E File Offset: 0x001A3C3E
		protected virtual ClientEventNode[] GetListenEvents()
		{
			return new ClientEventNode[0];
		}

		// Token: 0x06008D86 RID: 36230 RVA: 0x001A5846 File Offset: 0x001A3C46
		protected virtual void _bindExUI()
		{
		}

		// Token: 0x06008D87 RID: 36231 RVA: 0x001A5848 File Offset: 0x001A3C48
		protected virtual void _unbindExUI()
		{
		}

		// Token: 0x04004636 RID: 17974
		public ComCommonBind mBind;

		// Token: 0x04004637 RID: 17975
		private bool mIsInited;
	}
}
