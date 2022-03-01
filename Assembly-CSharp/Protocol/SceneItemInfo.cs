using System;

namespace Protocol
{
	// Token: 0x02000B14 RID: 2836
	public class SceneItemInfo : IProtocolStream
	{
		// Token: 0x060079C6 RID: 31174 RVA: 0x0015E20C File Offset: 0x0015C60C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060079C7 RID: 31175 RVA: 0x0015E260 File Offset: 0x0015C660
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new SceneItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new SceneItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060079C8 RID: 31176 RVA: 0x0015E2C8 File Offset: 0x0015C6C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060079C9 RID: 31177 RVA: 0x0015E31C File Offset: 0x0015C71C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new SceneItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new SceneItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060079CA RID: 31178 RVA: 0x0015E384 File Offset: 0x0015C784
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x0400396E RID: 14702
		public uint sceneId;

		// Token: 0x0400396F RID: 14703
		public SceneItem[] items = new SceneItem[0];
	}
}
