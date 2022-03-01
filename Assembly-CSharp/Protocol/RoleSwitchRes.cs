using System;

namespace Protocol
{
	// Token: 0x020009D0 RID: 2512
	[Protocol]
	public class RoleSwitchRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007078 RID: 28792 RVA: 0x00145480 File Offset: 0x00143880
		public uint GetMsgID()
		{
			return 300320U;
		}

		// Token: 0x06007079 RID: 28793 RVA: 0x00145487 File Offset: 0x00143887
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600707A RID: 28794 RVA: 0x0014548F File Offset: 0x0014388F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600707B RID: 28795 RVA: 0x00145498 File Offset: 0x00143898
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasrole);
			BaseDLL.encode_uint32(buffer, ref pos_, this.waitPlayerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.serverStartTime);
		}

		// Token: 0x0600707C RID: 28796 RVA: 0x001454D2 File Offset: 0x001438D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasrole);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waitPlayerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.serverStartTime);
		}

		// Token: 0x0600707D RID: 28797 RVA: 0x0014550C File Offset: 0x0014390C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.hasrole);
			BaseDLL.encode_uint32(buffer, ref pos_, this.waitPlayerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.serverStartTime);
		}

		// Token: 0x0600707E RID: 28798 RVA: 0x00145546 File Offset: 0x00143946
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasrole);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waitPlayerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.serverStartTime);
		}

		// Token: 0x0600707F RID: 28799 RVA: 0x00145580 File Offset: 0x00143980
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400333A RID: 13114
		public const uint MsgID = 300320U;

		// Token: 0x0400333B RID: 13115
		public uint Sequence;

		// Token: 0x0400333C RID: 13116
		public uint result;

		// Token: 0x0400333D RID: 13117
		public byte hasrole;

		// Token: 0x0400333E RID: 13118
		public uint waitPlayerNum;

		// Token: 0x0400333F RID: 13119
		public uint serverStartTime;
	}
}
