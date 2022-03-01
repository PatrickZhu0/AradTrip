using System;

namespace Protocol
{
	// Token: 0x020007C3 RID: 1987
	[Protocol]
	public class SceneDungeonRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600604C RID: 24652 RVA: 0x0012144E File Offset: 0x0011F84E
		public uint GetMsgID()
		{
			return 506810U;
		}

		// Token: 0x0600604D RID: 24653 RVA: 0x00121455 File Offset: 0x0011F855
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600604E RID: 24654 RVA: 0x0012145D File Offset: 0x0011F85D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600604F RID: 24655 RVA: 0x00121468 File Offset: 0x0011F868
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pickedItems.Length);
			for (int i = 0; i < this.pickedItems.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pickedItems[i]);
			}
		}

		// Token: 0x06006050 RID: 24656 RVA: 0x001214B0 File Offset: 0x0011F8B0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pickedItems = new uint[(int)num];
			for (int i = 0; i < this.pickedItems.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pickedItems[i]);
			}
		}

		// Token: 0x06006051 RID: 24657 RVA: 0x00121504 File Offset: 0x0011F904
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pickedItems.Length);
			for (int i = 0; i < this.pickedItems.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.pickedItems[i]);
			}
		}

		// Token: 0x06006052 RID: 24658 RVA: 0x0012154C File Offset: 0x0011F94C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.pickedItems = new uint[(int)num];
			for (int i = 0; i < this.pickedItems.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.pickedItems[i]);
			}
		}

		// Token: 0x06006053 RID: 24659 RVA: 0x001215A0 File Offset: 0x0011F9A0
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.pickedItems.Length);
		}

		// Token: 0x04002807 RID: 10247
		public const uint MsgID = 506810U;

		// Token: 0x04002808 RID: 10248
		public uint Sequence;

		// Token: 0x04002809 RID: 10249
		public uint[] pickedItems = new uint[0];
	}
}
