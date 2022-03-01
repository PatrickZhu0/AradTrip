using System;

namespace Protocol
{
	// Token: 0x02000832 RID: 2098
	[Protocol]
	public class WorldGuildRequesterRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006334 RID: 25396 RVA: 0x0012A1BC File Offset: 0x001285BC
		public uint GetMsgID()
		{
			return 601910U;
		}

		// Token: 0x06006335 RID: 25397 RVA: 0x0012A1C3 File Offset: 0x001285C3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006336 RID: 25398 RVA: 0x0012A1CB File Offset: 0x001285CB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006337 RID: 25399 RVA: 0x0012A1D4 File Offset: 0x001285D4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.requesters.Length);
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006338 RID: 25400 RVA: 0x0012A21C File Offset: 0x0012861C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.requesters = new GuildRequesterInfo[(int)num];
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i] = new GuildRequesterInfo();
				this.requesters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006339 RID: 25401 RVA: 0x0012A278 File Offset: 0x00128678
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.requesters.Length);
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600633A RID: 25402 RVA: 0x0012A2C0 File Offset: 0x001286C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.requesters = new GuildRequesterInfo[(int)num];
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i] = new GuildRequesterInfo();
				this.requesters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600633B RID: 25403 RVA: 0x0012A31C File Offset: 0x0012871C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.requesters.Length; i++)
			{
				num += this.requesters[i].getLen();
			}
			return num;
		}

		// Token: 0x04002C90 RID: 11408
		public const uint MsgID = 601910U;

		// Token: 0x04002C91 RID: 11409
		public uint Sequence;

		// Token: 0x04002C92 RID: 11410
		public GuildRequesterInfo[] requesters = new GuildRequesterInfo[0];
	}
}
