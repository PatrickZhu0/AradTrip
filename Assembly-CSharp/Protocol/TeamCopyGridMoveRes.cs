using System;

namespace Protocol
{
	// Token: 0x02000C11 RID: 3089
	[Protocol]
	public class TeamCopyGridMoveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600812B RID: 33067 RVA: 0x0016D144 File Offset: 0x0016B544
		public uint GetMsgID()
		{
			return 1100083U;
		}

		// Token: 0x0600812C RID: 33068 RVA: 0x0016D14B File Offset: 0x0016B54B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600812D RID: 33069 RVA: 0x0016D153 File Offset: 0x0016B553
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600812E RID: 33070 RVA: 0x0016D15C File Offset: 0x0016B55C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetObjId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pathList.Length);
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pathList[i]);
			}
		}

		// Token: 0x0600812F RID: 33071 RVA: 0x0016D1EC File Offset: 0x0016B5EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetObjId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pathList = new uint[(int)num];
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pathList[i]);
			}
		}

		// Token: 0x06008130 RID: 33072 RVA: 0x0016D284 File Offset: 0x0016B684
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetObjId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pathList.Length);
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pathList[i]);
			}
		}

		// Token: 0x06008131 RID: 33073 RVA: 0x0016D314 File Offset: 0x0016B714
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetObjId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pathList = new uint[(int)num];
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pathList[i]);
			}
		}

		// Token: 0x06008132 RID: 33074 RVA: 0x0016D3AC File Offset: 0x0016B7AC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + (2 + 4 * this.pathList.Length);
		}

		// Token: 0x04003DA6 RID: 15782
		public const uint MsgID = 1100083U;

		// Token: 0x04003DA7 RID: 15783
		public uint Sequence;

		// Token: 0x04003DA8 RID: 15784
		public uint retCode;

		// Token: 0x04003DA9 RID: 15785
		public uint squadId;

		// Token: 0x04003DAA RID: 15786
		public uint squadStatus;

		// Token: 0x04003DAB RID: 15787
		public uint targetGridId;

		// Token: 0x04003DAC RID: 15788
		public uint targetObjId;

		// Token: 0x04003DAD RID: 15789
		public uint[] pathList = new uint[0];
	}
}
