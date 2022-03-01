using System;

namespace Protocol
{
	// Token: 0x02000B8A RID: 2954
	[Protocol]
	public class WorldQueryTeamListRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D35 RID: 32053 RVA: 0x00164C53 File Offset: 0x00163053
		public uint GetMsgID()
		{
			return 601624U;
		}

		// Token: 0x06007D36 RID: 32054 RVA: 0x00164C5A File Offset: 0x0016305A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D37 RID: 32055 RVA: 0x00164C62 File Offset: 0x00163062
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D38 RID: 32056 RVA: 0x00164C6C File Offset: 0x0016306C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamList.Length);
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.pos);
			BaseDLL.encode_uint16(buffer, ref pos_, this.maxNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.param);
		}

		// Token: 0x06007D39 RID: 32057 RVA: 0x00164CEC File Offset: 0x001630EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamList = new TeamBaseInfo[(int)num];
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i] = new TeamBaseInfo();
				this.teamList[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.maxNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007D3A RID: 32058 RVA: 0x00164D80 File Offset: 0x00163180
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamList.Length);
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.pos);
			BaseDLL.encode_uint16(buffer, ref pos_, this.maxNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.param);
		}

		// Token: 0x06007D3B RID: 32059 RVA: 0x00164E00 File Offset: 0x00163200
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamList = new TeamBaseInfo[(int)num];
			for (int i = 0; i < this.teamList.Length; i++)
			{
				this.teamList[i] = new TeamBaseInfo();
				this.teamList[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.maxNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06007D3C RID: 32060 RVA: 0x00164E94 File Offset: 0x00163294
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.teamList.Length; i++)
			{
				num += this.teamList[i].getLen();
			}
			num += 2;
			num += 2;
			return num + 1;
		}

		// Token: 0x04003B63 RID: 15203
		public const uint MsgID = 601624U;

		// Token: 0x04003B64 RID: 15204
		public uint Sequence;

		// Token: 0x04003B65 RID: 15205
		public uint targetId;

		// Token: 0x04003B66 RID: 15206
		public TeamBaseInfo[] teamList = new TeamBaseInfo[0];

		// Token: 0x04003B67 RID: 15207
		public ushort pos;

		// Token: 0x04003B68 RID: 15208
		public ushort maxNum;

		// Token: 0x04003B69 RID: 15209
		public byte param;
	}
}
