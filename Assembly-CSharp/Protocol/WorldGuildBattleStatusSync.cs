using System;

namespace Protocol
{
	// Token: 0x02000863 RID: 2147
	[Protocol]
	public class WorldGuildBattleStatusSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064ED RID: 25837 RVA: 0x0012C922 File Offset: 0x0012AD22
		public uint GetMsgID()
		{
			return 601958U;
		}

		// Token: 0x060064EE RID: 25838 RVA: 0x0012C929 File Offset: 0x0012AD29
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064EF RID: 25839 RVA: 0x0012C931 File Offset: 0x0012AD31
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064F0 RID: 25840 RVA: 0x0012C93C File Offset: 0x0012AD3C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.endInfo.Length);
			for (int i = 0; i < this.endInfo.Length; i++)
			{
				this.endInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060064F1 RID: 25841 RVA: 0x0012C9AC File Offset: 0x0012ADAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.endInfo = new GuildBattleEndInfo[(int)num];
			for (int i = 0; i < this.endInfo.Length; i++)
			{
				this.endInfo[i] = new GuildBattleEndInfo();
				this.endInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060064F2 RID: 25842 RVA: 0x0012CA30 File Offset: 0x0012AE30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.endInfo.Length);
			for (int i = 0; i < this.endInfo.Length; i++)
			{
				this.endInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060064F3 RID: 25843 RVA: 0x0012CAA0 File Offset: 0x0012AEA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.endInfo = new GuildBattleEndInfo[(int)num];
			for (int i = 0; i < this.endInfo.Length; i++)
			{
				this.endInfo[i] = new GuildBattleEndInfo();
				this.endInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060064F4 RID: 25844 RVA: 0x0012CB24 File Offset: 0x0012AF24
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 2;
			for (int i = 0; i < this.endInfo.Length; i++)
			{
				num += this.endInfo[i].getLen();
			}
			return num;
		}

		// Token: 0x04002D39 RID: 11577
		public const uint MsgID = 601958U;

		// Token: 0x04002D3A RID: 11578
		public uint Sequence;

		// Token: 0x04002D3B RID: 11579
		public byte type;

		// Token: 0x04002D3C RID: 11580
		public byte status;

		// Token: 0x04002D3D RID: 11581
		public uint time;

		// Token: 0x04002D3E RID: 11582
		public GuildBattleEndInfo[] endInfo = new GuildBattleEndInfo[0];
	}
}
