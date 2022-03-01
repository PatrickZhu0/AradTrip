using System;
using System.Collections;

namespace GameClient
{
	// Token: 0x02000E3F RID: 3647
	public class WaitClientFrameState : BaseCustomEnum<WaitClientFrameState.eResult>, IEnumerator
	{
		// Token: 0x06009172 RID: 37234 RVA: 0x001AEDBB File Offset: 0x001AD1BB
		public WaitClientFrameState(Type type, EFrameState state)
		{
			this.mFrame = Singleton<ClientSystemManager>.instance.GetFrame(type);
			this.mState = state;
			this.mResult = WaitClientFrameState.eResult.None;
		}

		// Token: 0x06009173 RID: 37235 RVA: 0x001AEDE2 File Offset: 0x001AD1E2
		public WaitClientFrameState(IClientFrame frame, EFrameState state)
		{
			this.mFrame = frame;
			this.mState = state;
			this.mResult = WaitClientFrameState.eResult.None;
		}

		// Token: 0x06009174 RID: 37236 RVA: 0x001AEDFF File Offset: 0x001AD1FF
		public bool MoveNext()
		{
			if (this.mFrame == null)
			{
				this.mResult = WaitClientFrameState.eResult.InvalidFrame;
				return false;
			}
			if (this.mFrame.GetState() != this.mState)
			{
				return true;
			}
			this.mResult = WaitClientFrameState.eResult.Success;
			this.mFrame = null;
			return false;
		}

		// Token: 0x06009175 RID: 37237 RVA: 0x001AEE3C File Offset: 0x001AD23C
		public void Reset()
		{
			this.mResult = WaitClientFrameState.eResult.None;
			this.mFrame = null;
		}

		// Token: 0x170018E9 RID: 6377
		// (get) Token: 0x06009176 RID: 37238 RVA: 0x001AEE4C File Offset: 0x001AD24C
		public object Current
		{
			get
			{
				return this.mResult;
			}
		}

		// Token: 0x040048A7 RID: 18599
		private IClientFrame mFrame;

		// Token: 0x040048A8 RID: 18600
		private EFrameState mState;

		// Token: 0x02000E40 RID: 3648
		public enum eResult
		{
			// Token: 0x040048AA RID: 18602
			None,
			// Token: 0x040048AB RID: 18603
			Success,
			// Token: 0x040048AC RID: 18604
			InvalidFrame
		}
	}
}
