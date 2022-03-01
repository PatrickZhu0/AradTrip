using System;

namespace Protocol
{
	// Token: 0x020006A5 RID: 1701
	[Protocol]
	public class WorldDispatchExpeditionTeamRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057E0 RID: 22496 RVA: 0x0010B9EF File Offset: 0x00109DEF
		public uint GetMsgID()
		{
			return 608616U;
		}

		// Token: 0x060057E1 RID: 22497 RVA: 0x0010B9F6 File Offset: 0x00109DF6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057E2 RID: 22498 RVA: 0x0010B9FE File Offset: 0x00109DFE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057E3 RID: 22499 RVA: 0x0010BA08 File Offset: 0x00109E08
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

		// Token: 0x060057E4 RID: 22500 RVA: 0x0010BA94 File Offset: 0x00109E94
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

		// Token: 0x060057E5 RID: 22501 RVA: 0x0010BB34 File Offset: 0x00109F34
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

		// Token: 0x060057E6 RID: 22502 RVA: 0x0010BBC0 File Offset: 0x00109FC0
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

		// Token: 0x060057E7 RID: 22503 RVA: 0x0010BC60 File Offset: 0x0010A060
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

		// Token: 0x040022F4 RID: 8948
		public const uint MsgID = 608616U;

		// Token: 0x040022F5 RID: 8949
		public uint Sequence;

		// Token: 0x040022F6 RID: 8950
		public uint resCode;

		// Token: 0x040022F7 RID: 8951
		public byte mapId;

		// Token: 0x040022F8 RID: 8952
		public byte expeditionStatus;

		// Token: 0x040022F9 RID: 8953
		public uint durationOfExpedition;

		// Token: 0x040022FA RID: 8954
		public uint endTimeOfExpedition;

		// Token: 0x040022FB RID: 8955
		public ExpeditionMemberInfo[] members = new ExpeditionMemberInfo[0];
	}
}
