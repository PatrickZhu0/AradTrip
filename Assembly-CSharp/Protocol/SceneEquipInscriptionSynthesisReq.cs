using System;

namespace Protocol
{
	// Token: 0x0200099B RID: 2459
	[Protocol]
	public class SceneEquipInscriptionSynthesisReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EC5 RID: 28357 RVA: 0x0014040C File Offset: 0x0013E80C
		public uint GetMsgID()
		{
			return 501081U;
		}

		// Token: 0x06006EC6 RID: 28358 RVA: 0x00140413 File Offset: 0x0013E813
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EC7 RID: 28359 RVA: 0x0014041B File Offset: 0x0013E81B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EC8 RID: 28360 RVA: 0x00140424 File Offset: 0x0013E824
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemIDVec.Length);
			for (int i = 0; i < this.itemIDVec.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.itemIDVec[i]);
			}
		}

		// Token: 0x06006EC9 RID: 28361 RVA: 0x0014046C File Offset: 0x0013E86C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemIDVec = new uint[(int)num];
			for (int i = 0; i < this.itemIDVec.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemIDVec[i]);
			}
		}

		// Token: 0x06006ECA RID: 28362 RVA: 0x001404C0 File Offset: 0x0013E8C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemIDVec.Length);
			for (int i = 0; i < this.itemIDVec.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.itemIDVec[i]);
			}
		}

		// Token: 0x06006ECB RID: 28363 RVA: 0x00140508 File Offset: 0x0013E908
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemIDVec = new uint[(int)num];
			for (int i = 0; i < this.itemIDVec.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemIDVec[i]);
			}
		}

		// Token: 0x06006ECC RID: 28364 RVA: 0x0014055C File Offset: 0x0013E95C
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.itemIDVec.Length);
		}

		// Token: 0x04003234 RID: 12852
		public const uint MsgID = 501081U;

		// Token: 0x04003235 RID: 12853
		public uint Sequence;

		// Token: 0x04003236 RID: 12854
		public uint[] itemIDVec = new uint[0];
	}
}
