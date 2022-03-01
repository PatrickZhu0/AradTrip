using System;

namespace Protocol
{
	// Token: 0x02000842 RID: 2114
	[Protocol]
	public class WorldGuildOperRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063C4 RID: 25540 RVA: 0x0012AFA8 File Offset: 0x001293A8
		public uint GetMsgID()
		{
			return 601926U;
		}

		// Token: 0x060063C5 RID: 25541 RVA: 0x0012AFAF File Offset: 0x001293AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063C6 RID: 25542 RVA: 0x0012AFB7 File Offset: 0x001293B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063C7 RID: 25543 RVA: 0x0012AFC0 File Offset: 0x001293C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param2);
		}

		// Token: 0x060063C8 RID: 25544 RVA: 0x0012AFFA File Offset: 0x001293FA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x060063C9 RID: 25545 RVA: 0x0012B034 File Offset: 0x00129434
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param2);
		}

		// Token: 0x060063CA RID: 25546 RVA: 0x0012B06E File Offset: 0x0012946E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x060063CB RID: 25547 RVA: 0x0012B0A8 File Offset: 0x001294A8
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x04002CC4 RID: 11460
		public const uint MsgID = 601926U;

		// Token: 0x04002CC5 RID: 11461
		public uint Sequence;

		// Token: 0x04002CC6 RID: 11462
		public byte type;

		// Token: 0x04002CC7 RID: 11463
		public uint result;

		// Token: 0x04002CC8 RID: 11464
		public uint param;

		// Token: 0x04002CC9 RID: 11465
		public ulong param2;
	}
}
