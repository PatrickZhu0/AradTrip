using System;

namespace Protocol
{
	// Token: 0x02000900 RID: 2304
	[Protocol]
	public class SceneRandEquipQlvReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006970 RID: 26992 RVA: 0x00136BA8 File Offset: 0x00134FA8
		public uint GetMsgID()
		{
			return 500941U;
		}

		// Token: 0x06006971 RID: 26993 RVA: 0x00136BAF File Offset: 0x00134FAF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006972 RID: 26994 RVA: 0x00136BB7 File Offset: 0x00134FB7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006973 RID: 26995 RVA: 0x00136BC0 File Offset: 0x00134FC0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.bUsePoint);
			BaseDLL.encode_int8(buffer, ref pos_, this.usePerfect);
		}

		// Token: 0x06006974 RID: 26996 RVA: 0x00136BEC File Offset: 0x00134FEC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bUsePoint);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.usePerfect);
		}

		// Token: 0x06006975 RID: 26997 RVA: 0x00136C18 File Offset: 0x00135018
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.bUsePoint);
			BaseDLL.encode_int8(buffer, ref pos_, this.usePerfect);
		}

		// Token: 0x06006976 RID: 26998 RVA: 0x00136C44 File Offset: 0x00135044
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bUsePoint);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.usePerfect);
		}

		// Token: 0x06006977 RID: 26999 RVA: 0x00136C70 File Offset: 0x00135070
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 1;
		}

		// Token: 0x04002FC8 RID: 12232
		public const uint MsgID = 500941U;

		// Token: 0x04002FC9 RID: 12233
		public uint Sequence;

		// Token: 0x04002FCA RID: 12234
		public ulong uid;

		// Token: 0x04002FCB RID: 12235
		public byte bUsePoint;

		// Token: 0x04002FCC RID: 12236
		public byte usePerfect;
	}
}
