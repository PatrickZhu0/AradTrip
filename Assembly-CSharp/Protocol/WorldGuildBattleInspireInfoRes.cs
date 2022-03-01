using System;

namespace Protocol
{
	// Token: 0x02000869 RID: 2153
	[Protocol]
	public class WorldGuildBattleInspireInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006523 RID: 25891 RVA: 0x0012D0AC File Offset: 0x0012B4AC
		public uint GetMsgID()
		{
			return 601964U;
		}

		// Token: 0x06006524 RID: 25892 RVA: 0x0012D0B3 File Offset: 0x0012B4B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006525 RID: 25893 RVA: 0x0012D0BB File Offset: 0x0012B4BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006526 RID: 25894 RVA: 0x0012D0C4 File Offset: 0x0012B4C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inspireInfos.Length);
			for (int i = 0; i < this.inspireInfos.Length; i++)
			{
				this.inspireInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006527 RID: 25895 RVA: 0x0012D128 File Offset: 0x0012B528
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inspireInfos = new GuildBattleInspireInfo[(int)num];
			for (int i = 0; i < this.inspireInfos.Length; i++)
			{
				this.inspireInfos[i] = new GuildBattleInspireInfo();
				this.inspireInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006528 RID: 25896 RVA: 0x0012D1A0 File Offset: 0x0012B5A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inspireInfos.Length);
			for (int i = 0; i < this.inspireInfos.Length; i++)
			{
				this.inspireInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006529 RID: 25897 RVA: 0x0012D204 File Offset: 0x0012B604
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inspireInfos = new GuildBattleInspireInfo[(int)num];
			for (int i = 0; i < this.inspireInfos.Length; i++)
			{
				this.inspireInfos[i] = new GuildBattleInspireInfo();
				this.inspireInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600652A RID: 25898 RVA: 0x0012D27C File Offset: 0x0012B67C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 2;
			for (int i = 0; i < this.inspireInfos.Length; i++)
			{
				num += this.inspireInfos[i].getLen();
			}
			return num;
		}

		// Token: 0x04002D54 RID: 11604
		public const uint MsgID = 601964U;

		// Token: 0x04002D55 RID: 11605
		public uint Sequence;

		// Token: 0x04002D56 RID: 11606
		public uint result;

		// Token: 0x04002D57 RID: 11607
		public byte terrId;

		// Token: 0x04002D58 RID: 11608
		public GuildBattleInspireInfo[] inspireInfos = new GuildBattleInspireInfo[0];
	}
}
