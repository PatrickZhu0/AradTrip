using System;

namespace Protocol
{
	// Token: 0x02000928 RID: 2344
	[Protocol]
	public class SceneEquipMakeRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AD5 RID: 27349 RVA: 0x001393B8 File Offset: 0x001377B8
		public uint GetMsgID()
		{
			return 500955U;
		}

		// Token: 0x06006AD6 RID: 27350 RVA: 0x001393BF File Offset: 0x001377BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AD7 RID: 27351 RVA: 0x001393C7 File Offset: 0x001377C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AD8 RID: 27352 RVA: 0x001393D0 File Offset: 0x001377D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006AD9 RID: 27353 RVA: 0x001393E0 File Offset: 0x001377E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006ADA RID: 27354 RVA: 0x001393F0 File Offset: 0x001377F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006ADB RID: 27355 RVA: 0x00139400 File Offset: 0x00137800
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006ADC RID: 27356 RVA: 0x00139410 File Offset: 0x00137810
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003074 RID: 12404
		public const uint MsgID = 500955U;

		// Token: 0x04003075 RID: 12405
		public uint Sequence;

		// Token: 0x04003076 RID: 12406
		public uint code;
	}
}
