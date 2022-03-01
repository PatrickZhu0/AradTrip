using System;

namespace Protocol
{
	// Token: 0x020008A8 RID: 2216
	[Protocol]
	public class SceneHeadFrameRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006742 RID: 26434 RVA: 0x00130D5C File Offset: 0x0012F15C
		public uint GetMsgID()
		{
			return 509102U;
		}

		// Token: 0x06006743 RID: 26435 RVA: 0x00130D63 File Offset: 0x0012F163
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006744 RID: 26436 RVA: 0x00130D6B File Offset: 0x0012F16B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006745 RID: 26437 RVA: 0x00130D74 File Offset: 0x0012F174
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.headFrameList.Length);
			for (int i = 0; i < this.headFrameList.Length; i++)
			{
				this.headFrameList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006746 RID: 26438 RVA: 0x00130DBC File Offset: 0x0012F1BC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.headFrameList = new HeadFrame[(int)num];
			for (int i = 0; i < this.headFrameList.Length; i++)
			{
				this.headFrameList[i] = new HeadFrame();
				this.headFrameList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006747 RID: 26439 RVA: 0x00130E18 File Offset: 0x0012F218
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.headFrameList.Length);
			for (int i = 0; i < this.headFrameList.Length; i++)
			{
				this.headFrameList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006748 RID: 26440 RVA: 0x00130E60 File Offset: 0x0012F260
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.headFrameList = new HeadFrame[(int)num];
			for (int i = 0; i < this.headFrameList.Length; i++)
			{
				this.headFrameList[i] = new HeadFrame();
				this.headFrameList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006749 RID: 26441 RVA: 0x00130EBC File Offset: 0x0012F2BC
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.headFrameList.Length; i++)
			{
				num += this.headFrameList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002E25 RID: 11813
		public const uint MsgID = 509102U;

		// Token: 0x04002E26 RID: 11814
		public uint Sequence;

		// Token: 0x04002E27 RID: 11815
		public HeadFrame[] headFrameList = new HeadFrame[0];
	}
}
