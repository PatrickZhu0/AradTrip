using System;

namespace Protocol
{
	// Token: 0x02000B66 RID: 2918
	[Protocol]
	public class SceneSetSkillPageRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C39 RID: 31801 RVA: 0x00162FD4 File Offset: 0x001613D4
		public uint GetMsgID()
		{
			return 500719U;
		}

		// Token: 0x06007C3A RID: 31802 RVA: 0x00162FDB File Offset: 0x001613DB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C3B RID: 31803 RVA: 0x00162FE3 File Offset: 0x001613E3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C3C RID: 31804 RVA: 0x00162FEC File Offset: 0x001613EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
			BaseDLL.encode_int8(buffer, ref pos_, this.page);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C3D RID: 31805 RVA: 0x00163018 File Offset: 0x00161418
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.page);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C3E RID: 31806 RVA: 0x00163044 File Offset: 0x00161444
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.configType);
			BaseDLL.encode_int8(buffer, ref pos_, this.page);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007C3F RID: 31807 RVA: 0x00163070 File Offset: 0x00161470
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.configType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.page);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007C40 RID: 31808 RVA: 0x0016309C File Offset: 0x0016149C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04003AD6 RID: 15062
		public const uint MsgID = 500719U;

		// Token: 0x04003AD7 RID: 15063
		public uint Sequence;

		// Token: 0x04003AD8 RID: 15064
		public uint configType;

		// Token: 0x04003AD9 RID: 15065
		public byte page;

		// Token: 0x04003ADA RID: 15066
		public uint result;
	}
}
