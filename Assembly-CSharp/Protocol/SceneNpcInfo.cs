using System;

namespace Protocol
{
	// Token: 0x02000B00 RID: 2816
	public class SceneNpcInfo : IProtocolStream
	{
		// Token: 0x0600791B RID: 31003 RVA: 0x0015D10C File Offset: 0x0015B50C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.npcs.Length);
			for (int i = 0; i < this.npcs.Length; i++)
			{
				this.npcs[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600791C RID: 31004 RVA: 0x0015D160 File Offset: 0x0015B560
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.npcs = new SceneNpc[(int)num];
			for (int i = 0; i < this.npcs.Length; i++)
			{
				this.npcs[i] = new SceneNpc();
				this.npcs[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600791D RID: 31005 RVA: 0x0015D1C8 File Offset: 0x0015B5C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.npcs.Length);
			for (int i = 0; i < this.npcs.Length; i++)
			{
				this.npcs[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600791E RID: 31006 RVA: 0x0015D21C File Offset: 0x0015B61C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.npcs = new SceneNpc[(int)num];
			for (int i = 0; i < this.npcs.Length; i++)
			{
				this.npcs[i] = new SceneNpc();
				this.npcs[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600791F RID: 31007 RVA: 0x0015D284 File Offset: 0x0015B684
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.npcs.Length; i++)
			{
				num += this.npcs[i].getLen();
			}
			return num;
		}

		// Token: 0x0400392F RID: 14639
		public uint sceneId;

		// Token: 0x04003930 RID: 14640
		public SceneNpc[] npcs = new SceneNpc[0];
	}
}
