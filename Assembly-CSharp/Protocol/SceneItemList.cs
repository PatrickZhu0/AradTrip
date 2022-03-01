using System;

namespace Protocol
{
	// Token: 0x02000B15 RID: 2837
	[Protocol]
	public class SceneItemList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079CC RID: 31180 RVA: 0x0015E3D9 File Offset: 0x0015C7D9
		public uint GetMsgID()
		{
			return 500625U;
		}

		// Token: 0x060079CD RID: 31181 RVA: 0x0015E3E0 File Offset: 0x0015C7E0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079CE RID: 31182 RVA: 0x0015E3E8 File Offset: 0x0015C7E8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079CF RID: 31183 RVA: 0x0015E3F4 File Offset: 0x0015C7F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060079D0 RID: 31184 RVA: 0x0015E448 File Offset: 0x0015C848
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new SceneItemInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new SceneItemInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060079D1 RID: 31185 RVA: 0x0015E4B0 File Offset: 0x0015C8B0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060079D2 RID: 31186 RVA: 0x0015E504 File Offset: 0x0015C904
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new SceneItemInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new SceneItemInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060079D3 RID: 31187 RVA: 0x0015E56C File Offset: 0x0015C96C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.infoes.Length; i++)
			{
				num += this.infoes[i].getLen();
			}
			return num;
		}

		// Token: 0x04003970 RID: 14704
		public const uint MsgID = 500625U;

		// Token: 0x04003971 RID: 14705
		public uint Sequence;

		// Token: 0x04003972 RID: 14706
		public uint battleID;

		// Token: 0x04003973 RID: 14707
		public SceneItemInfo[] infoes = new SceneItemInfo[0];
	}
}
