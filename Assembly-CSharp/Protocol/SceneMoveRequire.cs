using System;

namespace Protocol
{
	// Token: 0x02000B02 RID: 2818
	[Protocol]
	public class SceneMoveRequire : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600792A RID: 31018 RVA: 0x0015D52E File Offset: 0x0015B92E
		public uint GetMsgID()
		{
			return 500501U;
		}

		// Token: 0x0600792B RID: 31019 RVA: 0x0015D535 File Offset: 0x0015B935
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600792C RID: 31020 RVA: 0x0015D53D File Offset: 0x0015B93D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600792D RID: 31021 RVA: 0x0015D546 File Offset: 0x0015B946
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.clientSceneId);
			this.pos.encode(buffer, ref pos_);
			this.dir.encode(buffer, ref pos_);
		}

		// Token: 0x0600792E RID: 31022 RVA: 0x0015D570 File Offset: 0x0015B970
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.clientSceneId);
			this.pos.decode(buffer, ref pos_);
			this.dir.decode(buffer, ref pos_);
		}

		// Token: 0x0600792F RID: 31023 RVA: 0x0015D59A File Offset: 0x0015B99A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.clientSceneId);
			this.pos.encode(buffer, ref pos_);
			this.dir.encode(buffer, ref pos_);
		}

		// Token: 0x06007930 RID: 31024 RVA: 0x0015D5C4 File Offset: 0x0015B9C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.clientSceneId);
			this.pos.decode(buffer, ref pos_);
			this.dir.decode(buffer, ref pos_);
		}

		// Token: 0x06007931 RID: 31025 RVA: 0x0015D5F0 File Offset: 0x0015B9F0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += this.pos.getLen();
			return num + this.dir.getLen();
		}

		// Token: 0x04003938 RID: 14648
		public const uint MsgID = 500501U;

		// Token: 0x04003939 RID: 14649
		public uint Sequence;

		// Token: 0x0400393A RID: 14650
		public uint clientSceneId;

		// Token: 0x0400393B RID: 14651
		public ScenePosition pos = new ScenePosition();

		// Token: 0x0400393C RID: 14652
		public SceneDir dir = new SceneDir();
	}
}
