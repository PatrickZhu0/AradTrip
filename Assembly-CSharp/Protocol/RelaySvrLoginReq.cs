using System;

namespace Protocol
{
	// Token: 0x02000A8C RID: 2700
	[Protocol]
	public class RelaySvrLoginReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075E8 RID: 30184 RVA: 0x00154FA5 File Offset: 0x001533A5
		public uint GetMsgID()
		{
			return 1300001U;
		}

		// Token: 0x060075E9 RID: 30185 RVA: 0x00154FAC File Offset: 0x001533AC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075EA RID: 30186 RVA: 0x00154FB4 File Offset: 0x001533B4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075EB RID: 30187 RVA: 0x00154FBD File Offset: 0x001533BD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
		}

		// Token: 0x060075EC RID: 30188 RVA: 0x00154FF7 File Offset: 0x001533F7
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
		}

		// Token: 0x060075ED RID: 30189 RVA: 0x00155031 File Offset: 0x00153431
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
		}

		// Token: 0x060075EE RID: 30190 RVA: 0x0015506B File Offset: 0x0015346B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
		}

		// Token: 0x060075EF RID: 30191 RVA: 0x001550A8 File Offset: 0x001534A8
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x0400370B RID: 14091
		public const uint MsgID = 1300001U;

		// Token: 0x0400370C RID: 14092
		public uint Sequence;

		// Token: 0x0400370D RID: 14093
		public byte seat;

		// Token: 0x0400370E RID: 14094
		public uint accid;

		// Token: 0x0400370F RID: 14095
		public ulong roleid;

		// Token: 0x04003710 RID: 14096
		public ulong session;
	}
}
