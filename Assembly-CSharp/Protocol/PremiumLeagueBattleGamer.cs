using System;

namespace Protocol
{
	// Token: 0x02000A61 RID: 2657
	public class PremiumLeagueBattleGamer : IProtocolStream
	{
		// Token: 0x060074AA RID: 29866 RVA: 0x00151B74 File Offset: 0x0014FF74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ranking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLose);
		}

		// Token: 0x060074AB RID: 29867 RVA: 0x00151BE4 File Offset: 0x0014FFE4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ranking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLose);
		}

		// Token: 0x060074AC RID: 29868 RVA: 0x00151C78 File Offset: 0x00150078
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ranking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLose);
		}

		// Token: 0x060074AD RID: 29869 RVA: 0x00151CEC File Offset: 0x001500EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ranking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLose);
		}

		// Token: 0x060074AE RID: 29870 RVA: 0x00151D80 File Offset: 0x00150180
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400363A RID: 13882
		public ulong roleId;

		// Token: 0x0400363B RID: 13883
		public string name;

		// Token: 0x0400363C RID: 13884
		public byte occu;

		// Token: 0x0400363D RID: 13885
		public uint ranking;

		// Token: 0x0400363E RID: 13886
		public uint winNum;

		// Token: 0x0400363F RID: 13887
		public byte isLose;
	}
}
