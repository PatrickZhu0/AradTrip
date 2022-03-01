using System;

namespace Protocol
{
	// Token: 0x020008FE RID: 2302
	[Protocol]
	public class SceneCheckSealEquipReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600695E RID: 26974 RVA: 0x00136A47 File Offset: 0x00134E47
		public uint GetMsgID()
		{
			return 500939U;
		}

		// Token: 0x0600695F RID: 26975 RVA: 0x00136A4E File Offset: 0x00134E4E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006960 RID: 26976 RVA: 0x00136A56 File Offset: 0x00134E56
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006961 RID: 26977 RVA: 0x00136A5F File Offset: 0x00134E5F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006962 RID: 26978 RVA: 0x00136A6F File Offset: 0x00134E6F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006963 RID: 26979 RVA: 0x00136A7F File Offset: 0x00134E7F
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006964 RID: 26980 RVA: 0x00136A8F File Offset: 0x00134E8F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006965 RID: 26981 RVA: 0x00136AA0 File Offset: 0x00134EA0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002FC0 RID: 12224
		public const uint MsgID = 500939U;

		// Token: 0x04002FC1 RID: 12225
		public uint Sequence;

		// Token: 0x04002FC2 RID: 12226
		public ulong uid;
	}
}
