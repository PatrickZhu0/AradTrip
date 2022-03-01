using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DD5 RID: 3541
	internal class FunctionBinder<T> : IFunctionBinder where T : class, IClientFrame, new()
	{
		// Token: 0x06008F0C RID: 36620 RVA: 0x001A7380 File Offset: 0x001A5780
		public void install(IClientFrame clientFrame, GameObject frame)
		{
			this.clientFrame = (clientFrame as T);
			this.frame = frame;
			this.Initialize();
		}

		// Token: 0x06008F0D RID: 36621 RVA: 0x001A73A0 File Offset: 0x001A57A0
		public void refresh()
		{
			this.Refresh();
		}

		// Token: 0x06008F0E RID: 36622 RVA: 0x001A73A8 File Offset: 0x001A57A8
		public void uninstall()
		{
			this.UnInitialize();
			this.frame = null;
		}

		// Token: 0x06008F0F RID: 36623 RVA: 0x001A73B7 File Offset: 0x001A57B7
		protected virtual void Initialize()
		{
		}

		// Token: 0x06008F10 RID: 36624 RVA: 0x001A73B9 File Offset: 0x001A57B9
		protected virtual void Refresh()
		{
		}

		// Token: 0x06008F11 RID: 36625 RVA: 0x001A73BB File Offset: 0x001A57BB
		protected virtual void UnInitialize()
		{
		}

		// Token: 0x040046F0 RID: 18160
		protected T clientFrame;

		// Token: 0x040046F1 RID: 18161
		protected GameObject frame;
	}
}
