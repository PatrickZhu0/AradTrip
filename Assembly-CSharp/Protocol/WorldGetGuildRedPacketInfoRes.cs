using System;

namespace Protocol
{
	// Token: 0x02000A89 RID: 2697
	[Protocol]
	public class WorldGetGuildRedPacketInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075DF RID: 30175 RVA: 0x00154DCC File Offset: 0x001531CC
		public uint GetMsgID()
		{
			return 607314U;
		}

		// Token: 0x060075E0 RID: 30176 RVA: 0x00154DD3 File Offset: 0x001531D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075E1 RID: 30177 RVA: 0x00154DDB File Offset: 0x001531DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075E2 RID: 30178 RVA: 0x00154DE4 File Offset: 0x001531E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060075E3 RID: 30179 RVA: 0x00154E38 File Offset: 0x00153238
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new GuildRedPacketSpecInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new GuildRedPacketSpecInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060075E4 RID: 30180 RVA: 0x00154EA0 File Offset: 0x001532A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060075E5 RID: 30181 RVA: 0x00154EF4 File Offset: 0x001532F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new GuildRedPacketSpecInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new GuildRedPacketSpecInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060075E6 RID: 30182 RVA: 0x00154F5C File Offset: 0x0015335C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x040036DF RID: 14047
		public const uint MsgID = 607314U;

		// Token: 0x040036E0 RID: 14048
		public uint Sequence;

		// Token: 0x040036E1 RID: 14049
		public uint code;

		// Token: 0x040036E2 RID: 14050
		public GuildRedPacketSpecInfo[] infos = new GuildRedPacketSpecInfo[0];
	}
}
