using System;

namespace Protocol
{
	// Token: 0x020006A1 RID: 1697
	[Protocol]
	public class WorldQueryExpeditionMapRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057BC RID: 22460 RVA: 0x0010B2FC File Offset: 0x001096FC
		public uint GetMsgID()
		{
			return 608612U;
		}

		// Token: 0x060057BD RID: 22461 RVA: 0x0010B303 File Offset: 0x00109703
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057BE RID: 22462 RVA: 0x0010B30B File Offset: 0x0010970B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057BF RID: 22463 RVA: 0x0010B314 File Offset: 0x00109714
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.durationOfExpedition);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTimeOfExpedition);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060057C0 RID: 22464 RVA: 0x0010B3A0 File Offset: 0x001097A0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.durationOfExpedition);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTimeOfExpedition);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new ExpeditionMemberInfo[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i] = new ExpeditionMemberInfo();
				this.members[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060057C1 RID: 22465 RVA: 0x0010B440 File Offset: 0x00109840
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.durationOfExpedition);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTimeOfExpedition);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060057C2 RID: 22466 RVA: 0x0010B4CC File Offset: 0x001098CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.durationOfExpedition);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTimeOfExpedition);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new ExpeditionMemberInfo[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				this.members[i] = new ExpeditionMemberInfo();
				this.members[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060057C3 RID: 22467 RVA: 0x0010B56C File Offset: 0x0010996C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.members.Length; i++)
			{
				num += this.members[i].getLen();
			}
			return num;
		}

		// Token: 0x040022E1 RID: 8929
		public const uint MsgID = 608612U;

		// Token: 0x040022E2 RID: 8930
		public uint Sequence;

		// Token: 0x040022E3 RID: 8931
		public uint resCode;

		// Token: 0x040022E4 RID: 8932
		public byte mapId;

		// Token: 0x040022E5 RID: 8933
		public byte expeditionStatus;

		// Token: 0x040022E6 RID: 8934
		public uint durationOfExpedition;

		// Token: 0x040022E7 RID: 8935
		public uint endTimeOfExpedition;

		// Token: 0x040022E8 RID: 8936
		public ExpeditionMemberInfo[] members = new ExpeditionMemberInfo[0];
	}
}
