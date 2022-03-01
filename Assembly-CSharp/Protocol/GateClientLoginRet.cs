using System;

namespace Protocol
{
	// Token: 0x020009BF RID: 2495
	[Protocol]
	public class GateClientLoginRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FDF RID: 28639 RVA: 0x001440EB File Offset: 0x001424EB
		public uint GetMsgID()
		{
			return 300204U;
		}

		// Token: 0x06006FE0 RID: 28640 RVA: 0x001440F2 File Offset: 0x001424F2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FE1 RID: 28641 RVA: 0x001440FA File Offset: 0x001424FA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FE2 RID: 28642 RVA: 0x00144104 File Offset: 0x00142504
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasrole);
			BaseDLL.encode_uint32(buffer, ref pos_, this.waitPlayerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.serverStartTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.notifyVeteranReturn);
		}

		// Token: 0x06006FE3 RID: 28643 RVA: 0x00144158 File Offset: 0x00142558
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasrole);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waitPlayerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.serverStartTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.notifyVeteranReturn);
		}

		// Token: 0x06006FE4 RID: 28644 RVA: 0x001441AC File Offset: 0x001425AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasrole);
			BaseDLL.encode_uint32(buffer, ref pos_, this.waitPlayerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.serverStartTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.notifyVeteranReturn);
		}

		// Token: 0x06006FE5 RID: 28645 RVA: 0x00144200 File Offset: 0x00142600
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasrole);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waitPlayerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.serverStartTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.notifyVeteranReturn);
		}

		// Token: 0x06006FE6 RID: 28646 RVA: 0x00144254 File Offset: 0x00142654
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x040032F3 RID: 13043
		public const uint MsgID = 300204U;

		// Token: 0x040032F4 RID: 13044
		public uint Sequence;

		// Token: 0x040032F5 RID: 13045
		public uint result;

		// Token: 0x040032F6 RID: 13046
		public byte hasrole;

		// Token: 0x040032F7 RID: 13047
		public uint waitPlayerNum;

		// Token: 0x040032F8 RID: 13048
		public uint serverStartTime;

		// Token: 0x040032F9 RID: 13049
		public byte notifyVeteranReturn;
	}
}
