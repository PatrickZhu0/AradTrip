using System;

namespace Protocol
{
	// Token: 0x020008FD RID: 2301
	[Protocol]
	public class SceneSealEquipRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006955 RID: 26965 RVA: 0x00136894 File Offset: 0x00134C94
		public uint GetMsgID()
		{
			return 500938U;
		}

		// Token: 0x06006956 RID: 26966 RVA: 0x0013689B File Offset: 0x00134C9B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006957 RID: 26967 RVA: 0x001368A3 File Offset: 0x00134CA3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006958 RID: 26968 RVA: 0x001368AC File Offset: 0x00134CAC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inscriptionIds.Length);
			for (int i = 0; i < this.inscriptionIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionIds[i]);
			}
		}

		// Token: 0x06006959 RID: 26969 RVA: 0x00136904 File Offset: 0x00134D04
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inscriptionIds = new uint[(int)num];
			for (int i = 0; i < this.inscriptionIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionIds[i]);
			}
		}

		// Token: 0x0600695A RID: 26970 RVA: 0x00136964 File Offset: 0x00134D64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inscriptionIds.Length);
			for (int i = 0; i < this.inscriptionIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionIds[i]);
			}
		}

		// Token: 0x0600695B RID: 26971 RVA: 0x001369BC File Offset: 0x00134DBC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inscriptionIds = new uint[(int)num];
			for (int i = 0; i < this.inscriptionIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionIds[i]);
			}
		}

		// Token: 0x0600695C RID: 26972 RVA: 0x00136A1C File Offset: 0x00134E1C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 4 * this.inscriptionIds.Length);
		}

		// Token: 0x04002FBC RID: 12220
		public const uint MsgID = 500938U;

		// Token: 0x04002FBD RID: 12221
		public uint Sequence;

		// Token: 0x04002FBE RID: 12222
		public uint code;

		// Token: 0x04002FBF RID: 12223
		public uint[] inscriptionIds = new uint[0];
	}
}
