using System;

namespace Protocol
{
	// Token: 0x02000BDE RID: 3038
	public class TeamCopyFlop : IProtocolStream
	{
		// Token: 0x06007F6F RID: 32623 RVA: 0x00169778 File Offset: 0x00167B78
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.number);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldFlop);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isLimit);
		}

		// Token: 0x06007F70 RID: 32624 RVA: 0x001697F8 File Offset: 0x00167BF8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.number);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldFlop);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isLimit);
		}

		// Token: 0x06007F71 RID: 32625 RVA: 0x0016989C File Offset: 0x00167C9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.number);
			BaseDLL.encode_uint32(buffer, ref pos_, this.goldFlop);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isLimit);
		}

		// Token: 0x06007F72 RID: 32626 RVA: 0x0016991C File Offset: 0x00167D1C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.number);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.goldFlop);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isLimit);
		}

		// Token: 0x06007F73 RID: 32627 RVA: 0x001699C0 File Offset: 0x00167DC0
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003CD1 RID: 15569
		public string playerName;

		// Token: 0x04003CD2 RID: 15570
		public ulong playerId;

		// Token: 0x04003CD3 RID: 15571
		public uint rewardId;

		// Token: 0x04003CD4 RID: 15572
		public uint rewardNum;

		// Token: 0x04003CD5 RID: 15573
		public uint number;

		// Token: 0x04003CD6 RID: 15574
		public uint goldFlop;

		// Token: 0x04003CD7 RID: 15575
		public uint isLimit;
	}
}
