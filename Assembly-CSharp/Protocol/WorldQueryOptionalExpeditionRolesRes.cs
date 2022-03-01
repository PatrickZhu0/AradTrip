using System;

namespace Protocol
{
	// Token: 0x020006A3 RID: 1699
	[Protocol]
	public class WorldQueryOptionalExpeditionRolesRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057CE RID: 22478 RVA: 0x0010B60C File Offset: 0x00109A0C
		public uint GetMsgID()
		{
			return 608614U;
		}

		// Token: 0x060057CF RID: 22479 RVA: 0x0010B613 File Offset: 0x00109A13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057D0 RID: 22480 RVA: 0x0010B61B File Offset: 0x00109A1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057D1 RID: 22481 RVA: 0x0010B624 File Offset: 0x00109A24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roles.Length);
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060057D2 RID: 22482 RVA: 0x0010B678 File Offset: 0x00109A78
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roles = new ExpeditionMemberInfo[(int)num];
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i] = new ExpeditionMemberInfo();
				this.roles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060057D3 RID: 22483 RVA: 0x0010B6E0 File Offset: 0x00109AE0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roles.Length);
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060057D4 RID: 22484 RVA: 0x0010B734 File Offset: 0x00109B34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roles = new ExpeditionMemberInfo[(int)num];
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i] = new ExpeditionMemberInfo();
				this.roles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060057D5 RID: 22485 RVA: 0x0010B79C File Offset: 0x00109B9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.roles.Length; i++)
			{
				num += this.roles[i].getLen();
			}
			return num;
		}

		// Token: 0x040022EB RID: 8939
		public const uint MsgID = 608614U;

		// Token: 0x040022EC RID: 8940
		public uint Sequence;

		// Token: 0x040022ED RID: 8941
		public uint resCode;

		// Token: 0x040022EE RID: 8942
		public ExpeditionMemberInfo[] roles = new ExpeditionMemberInfo[0];
	}
}
