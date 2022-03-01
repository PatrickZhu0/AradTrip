using System;

namespace Protocol
{
	// Token: 0x02000B8B RID: 2955
	[Protocol]
	public class WorldTeamMasterOperSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D3E RID: 32062 RVA: 0x00164EE9 File Offset: 0x001632E9
		public uint GetMsgID()
		{
			return 601629U;
		}

		// Token: 0x06007D3F RID: 32063 RVA: 0x00164EF0 File Offset: 0x001632F0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D40 RID: 32064 RVA: 0x00164EF8 File Offset: 0x001632F8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D41 RID: 32065 RVA: 0x00164F01 File Offset: 0x00163301
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06007D42 RID: 32066 RVA: 0x00164F1F File Offset: 0x0016331F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007D43 RID: 32067 RVA: 0x00164F3D File Offset: 0x0016333D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06007D44 RID: 32068 RVA: 0x00164F5B File Offset: 0x0016335B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007D45 RID: 32069 RVA: 0x00164F7C File Offset: 0x0016337C
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04003B6A RID: 15210
		public const uint MsgID = 601629U;

		// Token: 0x04003B6B RID: 15211
		public uint Sequence;

		// Token: 0x04003B6C RID: 15212
		public byte type;

		// Token: 0x04003B6D RID: 15213
		public uint param;
	}
}
