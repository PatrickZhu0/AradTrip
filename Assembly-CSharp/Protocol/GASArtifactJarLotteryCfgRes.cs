using System;

namespace Protocol
{
	// Token: 0x0200096F RID: 2415
	[Protocol]
	public class GASArtifactJarLotteryCfgRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D42 RID: 27970 RVA: 0x0013D6F1 File Offset: 0x0013BAF1
		public uint GetMsgID()
		{
			return 700906U;
		}

		// Token: 0x06006D43 RID: 27971 RVA: 0x0013D6F8 File Offset: 0x0013BAF8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D44 RID: 27972 RVA: 0x0013D700 File Offset: 0x0013BB00
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D45 RID: 27973 RVA: 0x0013D70C File Offset: 0x0013BB0C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.artifactJarCfgList.Length);
			for (int i = 0; i < this.artifactJarCfgList.Length; i++)
			{
				this.artifactJarCfgList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D46 RID: 27974 RVA: 0x0013D754 File Offset: 0x0013BB54
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.artifactJarCfgList = new ArtifactJarLotteryCfg[(int)num];
			for (int i = 0; i < this.artifactJarCfgList.Length; i++)
			{
				this.artifactJarCfgList[i] = new ArtifactJarLotteryCfg();
				this.artifactJarCfgList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D47 RID: 27975 RVA: 0x0013D7B0 File Offset: 0x0013BBB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.artifactJarCfgList.Length);
			for (int i = 0; i < this.artifactJarCfgList.Length; i++)
			{
				this.artifactJarCfgList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D48 RID: 27976 RVA: 0x0013D7F8 File Offset: 0x0013BBF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.artifactJarCfgList = new ArtifactJarLotteryCfg[(int)num];
			for (int i = 0; i < this.artifactJarCfgList.Length; i++)
			{
				this.artifactJarCfgList[i] = new ArtifactJarLotteryCfg();
				this.artifactJarCfgList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D49 RID: 27977 RVA: 0x0013D854 File Offset: 0x0013BC54
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.artifactJarCfgList.Length; i++)
			{
				num += this.artifactJarCfgList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003175 RID: 12661
		public const uint MsgID = 700906U;

		// Token: 0x04003176 RID: 12662
		public uint Sequence;

		// Token: 0x04003177 RID: 12663
		public ArtifactJarLotteryCfg[] artifactJarCfgList = new ArtifactJarLotteryCfg[0];
	}
}
