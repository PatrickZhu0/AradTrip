using System;

namespace Protocol
{
	// Token: 0x02000B89 RID: 2953
	[Protocol]
	public class WorldQueryTeamList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D2C RID: 32044 RVA: 0x001649A4 File Offset: 0x00162DA4
		public uint GetMsgID()
		{
			return 601623U;
		}

		// Token: 0x06007D2D RID: 32045 RVA: 0x001649AB File Offset: 0x00162DAB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D2E RID: 32046 RVA: 0x001649B3 File Offset: 0x00162DB3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D2F RID: 32047 RVA: 0x001649BC File Offset: 0x00162DBC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.targetList.Length);
			for (int i = 0; i < this.targetList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.targetList[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.startPos);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.param);
		}

		// Token: 0x06007D30 RID: 32048 RVA: 0x00164A4C File Offset: 0x00162E4C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.targetList = new uint[(int)num];
			for (int i = 0; i < this.targetList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetList[i]);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.startPos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007D31 RID: 32049 RVA: 0x00164AE4 File Offset: 0x00162EE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.targetList.Length);
			for (int i = 0; i < this.targetList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.targetList[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.startPos);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.param);
		}

		// Token: 0x06007D32 RID: 32050 RVA: 0x00164B74 File Offset: 0x00162F74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.targetList = new uint[(int)num];
			for (int i = 0; i < this.targetList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetList[i]);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.startPos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007D33 RID: 32051 RVA: 0x00164C0C File Offset: 0x0016300C
		public int getLen()
		{
			int num = 0;
			num += 2;
			num += 4;
			num += 2 + 4 * this.targetList.Length;
			num += 2;
			num++;
			return num + 1;
		}

		// Token: 0x04003B5B RID: 15195
		public const uint MsgID = 601623U;

		// Token: 0x04003B5C RID: 15196
		public uint Sequence;

		// Token: 0x04003B5D RID: 15197
		public ushort teamId;

		// Token: 0x04003B5E RID: 15198
		public uint targetId;

		// Token: 0x04003B5F RID: 15199
		public uint[] targetList = new uint[0];

		// Token: 0x04003B60 RID: 15200
		public ushort startPos;

		// Token: 0x04003B61 RID: 15201
		public byte num;

		// Token: 0x04003B62 RID: 15202
		public byte param;
	}
}
