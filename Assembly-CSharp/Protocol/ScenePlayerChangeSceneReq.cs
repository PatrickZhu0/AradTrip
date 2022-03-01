using System;

namespace Protocol
{
	// Token: 0x02000B09 RID: 2825
	[Protocol]
	public class ScenePlayerChangeSceneReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007969 RID: 31081 RVA: 0x0015D850 File Offset: 0x0015BC50
		public uint GetMsgID()
		{
			return 500503U;
		}

		// Token: 0x0600796A RID: 31082 RVA: 0x0015D857 File Offset: 0x0015BC57
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600796B RID: 31083 RVA: 0x0015D85F File Offset: 0x0015BC5F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600796C RID: 31084 RVA: 0x0015D868 File Offset: 0x0015BC68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.curDoorId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dstSceneId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dstDoorId);
		}

		// Token: 0x0600796D RID: 31085 RVA: 0x0015D894 File Offset: 0x0015BC94
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curDoorId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dstSceneId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dstDoorId);
		}

		// Token: 0x0600796E RID: 31086 RVA: 0x0015D8C0 File Offset: 0x0015BCC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.curDoorId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dstSceneId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dstDoorId);
		}

		// Token: 0x0600796F RID: 31087 RVA: 0x0015D8EC File Offset: 0x0015BCEC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curDoorId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dstSceneId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dstDoorId);
		}

		// Token: 0x06007970 RID: 31088 RVA: 0x0015D918 File Offset: 0x0015BD18
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400394C RID: 14668
		public const uint MsgID = 500503U;

		// Token: 0x0400394D RID: 14669
		public uint Sequence;

		// Token: 0x0400394E RID: 14670
		public uint curDoorId;

		// Token: 0x0400394F RID: 14671
		public uint dstSceneId;

		// Token: 0x04003950 RID: 14672
		public uint dstDoorId;
	}
}
