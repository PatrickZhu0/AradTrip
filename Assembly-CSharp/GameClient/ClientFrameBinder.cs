using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200001A RID: 26
	public class ClientFrameBinder : MonoBehaviour
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00007E6C File Offset: 0x0000626C
		public Type GetFrameType()
		{
			if (this.clientFrame != null)
			{
				return this.clientFrame.GetType();
			}
			return null;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007E86 File Offset: 0x00006286
		public void CloseFrame(bool bImmediately = false)
		{
			if (this.clientFrame != null)
			{
				this.clientFrame.Close(bImmediately);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007E9F File Offset: 0x0000629F
		public void OnCloseFrame()
		{
			this.clientFrame = null;
			this.frame = null;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00007EAF File Offset: 0x000062AF
		private void OnDestroy()
		{
			this.clientFrame = null;
			this.frame = null;
		}

		// Token: 0x0400006B RID: 107
		public IClientFrame clientFrame;

		// Token: 0x0400006C RID: 108
		public GameObject frame;
	}
}
