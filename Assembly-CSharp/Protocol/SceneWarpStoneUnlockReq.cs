using System;

namespace Protocol
{
	// Token: 0x02000C1D RID: 3101
	[Protocol]
	public class SceneWarpStoneUnlockReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008185 RID: 33157 RVA: 0x0016DA08 File Offset: 0x0016BE08
		public uint GetMsgID()
		{
			return 506901U;
		}

		// Token: 0x06008186 RID: 33158 RVA: 0x0016DA0F File Offset: 0x0016BE0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008187 RID: 33159 RVA: 0x0016DA17 File Offset: 0x0016BE17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008188 RID: 33160 RVA: 0x0016DA20 File Offset: 0x0016BE20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06008189 RID: 33161 RVA: 0x0016DA30 File Offset: 0x0016BE30
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600818A RID: 33162 RVA: 0x0016DA40 File Offset: 0x0016BE40
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x0600818B RID: 33163 RVA: 0x0016DA50 File Offset: 0x0016BE50
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600818C RID: 33164 RVA: 0x0016DA60 File Offset: 0x0016BE60
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DD3 RID: 15827
		public const uint MsgID = 506901U;

		// Token: 0x04003DD4 RID: 15828
		public uint Sequence;

		// Token: 0x04003DD5 RID: 15829
		public uint id;
	}
}
