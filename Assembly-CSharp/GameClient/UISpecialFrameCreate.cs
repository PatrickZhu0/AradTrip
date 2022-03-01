using System;
using System.Reflection;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004BE4 RID: 19428
	internal class UISpecialFrameCreate : MonoBehaviour
	{
		// Token: 0x0601C7AB RID: 116651 RVA: 0x0089FA80 File Offset: 0x0089DE80
		private void Create<T>(string path) where T : ClientFrame, new()
		{
			IClientFrame clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<T>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x170027E1 RID: 10209
		// (set) Token: 0x0601C7AC RID: 116652 RVA: 0x0089FA9F File Offset: 0x0089DE9F
		public string Param0
		{
			set
			{
				this.param0 = value;
			}
		}

		// Token: 0x170027E2 RID: 10210
		// (get) Token: 0x0601C7AD RID: 116653 RVA: 0x0089FAA8 File Offset: 0x0089DEA8
		// (set) Token: 0x0601C7AE RID: 116654 RVA: 0x0089FAB0 File Offset: 0x0089DEB0
		public string ClsName
		{
			get
			{
				return this.ClsName;
			}
			set
			{
				this.className = value;
				this.m_bDirty = true;
				this.MarkDirty();
			}
		}

		// Token: 0x0601C7AF RID: 116655 RVA: 0x0089FAC8 File Offset: 0x0089DEC8
		private void MarkDirty()
		{
			this._CloseFrame();
			if (!string.IsNullOrEmpty(this.className) && this.m_bDirty)
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (executingAssembly != null)
				{
					Type type = executingAssembly.GetType(this.className);
					if (type != null)
					{
						this.m_clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame(base.gameObject, type, this.param0, string.Empty);
					}
				}
				this.m_bDirty = false;
			}
		}

		// Token: 0x0601C7B0 RID: 116656 RVA: 0x0089FB3E File Offset: 0x0089DF3E
		private void _CloseFrame()
		{
			if (this.m_clientFrame != null)
			{
				this.m_clientFrame.Close(this);
				this.m_clientFrame = null;
			}
		}

		// Token: 0x0601C7B1 RID: 116657 RVA: 0x0089FB63 File Offset: 0x0089DF63
		public void OnClose()
		{
			this._CloseFrame();
		}

		// Token: 0x0601C7B2 RID: 116658 RVA: 0x0089FB6B File Offset: 0x0089DF6B
		private void OnDestroy()
		{
			this._CloseFrame();
		}

		// Token: 0x04013B1B RID: 80667
		private string className;

		// Token: 0x04013B1C RID: 80668
		private string param0;

		// Token: 0x04013B1D RID: 80669
		private bool m_bDirty;

		// Token: 0x04013B1E RID: 80670
		private IClientFrame m_clientFrame;
	}
}
