using System;

namespace Network
{
	// Token: 0x020001C3 RID: 451
	public class MsgBuffer
	{
		// Token: 0x04000A07 RID: 2567
		public byte[] data = new byte[NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE];

		// Token: 0x04000A08 RID: 2568
		public int length;
	}
}
