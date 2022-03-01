using System;

namespace Protocol
{
	// Token: 0x02000C0E RID: 3086
	[Protocol]
	public class TeamCopyGridSquadNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008110 RID: 33040 RVA: 0x0016CC49 File Offset: 0x0016B049
		public uint GetMsgID()
		{
			return 1100080U;
		}

		// Token: 0x06008111 RID: 33041 RVA: 0x0016CC50 File Offset: 0x0016B050
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008112 RID: 33042 RVA: 0x0016CC58 File Offset: 0x0016B058
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008113 RID: 33043 RVA: 0x0016CC64 File Offset: 0x0016B064
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetObjId);
			this.squadData.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pathList.Length);
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pathList[i]);
			}
		}

		// Token: 0x06008114 RID: 33044 RVA: 0x0016CCF0 File Offset: 0x0016B0F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetObjId);
			this.squadData.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pathList = new uint[(int)num];
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pathList[i]);
			}
		}

		// Token: 0x06008115 RID: 33045 RVA: 0x0016CD88 File Offset: 0x0016B188
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetObjId);
			this.squadData.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pathList.Length);
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pathList[i]);
			}
		}

		// Token: 0x06008116 RID: 33046 RVA: 0x0016CE14 File Offset: 0x0016B214
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetObjId);
			this.squadData.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pathList = new uint[(int)num];
			for (int i = 0; i < this.pathList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pathList[i]);
			}
		}

		// Token: 0x06008117 RID: 33047 RVA: 0x0016CEAC File Offset: 0x0016B2AC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += this.squadData.getLen();
			return num + (2 + 4 * this.pathList.Length);
		}

		// Token: 0x04003D93 RID: 15763
		public const uint MsgID = 1100080U;

		// Token: 0x04003D94 RID: 15764
		public uint Sequence;

		// Token: 0x04003D95 RID: 15765
		public uint squadId;

		// Token: 0x04003D96 RID: 15766
		public uint squadStatus;

		// Token: 0x04003D97 RID: 15767
		public uint targetGridId;

		// Token: 0x04003D98 RID: 15768
		public uint targetObjId;

		// Token: 0x04003D99 RID: 15769
		public TCGridObjData squadData = new TCGridObjData();

		// Token: 0x04003D9A RID: 15770
		public uint[] pathList = new uint[0];
	}
}
