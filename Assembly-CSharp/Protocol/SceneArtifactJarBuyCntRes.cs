using System;

namespace Protocol
{
	// Token: 0x02000968 RID: 2408
	[Protocol]
	public class SceneArtifactJarBuyCntRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D09 RID: 27913 RVA: 0x0013CE28 File Offset: 0x0013B228
		public uint GetMsgID()
		{
			return 501047U;
		}

		// Token: 0x06006D0A RID: 27914 RVA: 0x0013CE2F File Offset: 0x0013B22F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D0B RID: 27915 RVA: 0x0013CE37 File Offset: 0x0013B237
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D0C RID: 27916 RVA: 0x0013CE40 File Offset: 0x0013B240
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.artifactJarBuyList.Length);
			for (int i = 0; i < this.artifactJarBuyList.Length; i++)
			{
				this.artifactJarBuyList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D0D RID: 27917 RVA: 0x0013CE88 File Offset: 0x0013B288
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.artifactJarBuyList = new ArtifactJarBuy[(int)num];
			for (int i = 0; i < this.artifactJarBuyList.Length; i++)
			{
				this.artifactJarBuyList[i] = new ArtifactJarBuy();
				this.artifactJarBuyList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D0E RID: 27918 RVA: 0x0013CEE4 File Offset: 0x0013B2E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.artifactJarBuyList.Length);
			for (int i = 0; i < this.artifactJarBuyList.Length; i++)
			{
				this.artifactJarBuyList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D0F RID: 27919 RVA: 0x0013CF2C File Offset: 0x0013B32C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.artifactJarBuyList = new ArtifactJarBuy[(int)num];
			for (int i = 0; i < this.artifactJarBuyList.Length; i++)
			{
				this.artifactJarBuyList[i] = new ArtifactJarBuy();
				this.artifactJarBuyList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D10 RID: 27920 RVA: 0x0013CF88 File Offset: 0x0013B388
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.artifactJarBuyList.Length; i++)
			{
				num += this.artifactJarBuyList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003161 RID: 12641
		public const uint MsgID = 501047U;

		// Token: 0x04003162 RID: 12642
		public uint Sequence;

		// Token: 0x04003163 RID: 12643
		public ArtifactJarBuy[] artifactJarBuyList = new ArtifactJarBuy[0];
	}
}
