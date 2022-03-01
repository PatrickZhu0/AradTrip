using System;

namespace Protocol
{
	// Token: 0x0200073E RID: 1854
	[Protocol]
	public class StakeRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C74 RID: 23668 RVA: 0x00116FB8 File Offset: 0x001153B8
		public uint GetMsgID()
		{
			return 708311U;
		}

		// Token: 0x06005C75 RID: 23669 RVA: 0x00116FBF File Offset: 0x001153BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C76 RID: 23670 RVA: 0x00116FC7 File Offset: 0x001153C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C77 RID: 23671 RVA: 0x00116FD0 File Offset: 0x001153D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.StakeRecordList.Length);
			for (int i = 0; i < this.StakeRecordList.Length; i++)
			{
				this.StakeRecordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C78 RID: 23672 RVA: 0x00117018 File Offset: 0x00115418
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.StakeRecordList = new StakeRecord[(int)num];
			for (int i = 0; i < this.StakeRecordList.Length; i++)
			{
				this.StakeRecordList[i] = new StakeRecord();
				this.StakeRecordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C79 RID: 23673 RVA: 0x00117074 File Offset: 0x00115474
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.StakeRecordList.Length);
			for (int i = 0; i < this.StakeRecordList.Length; i++)
			{
				this.StakeRecordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C7A RID: 23674 RVA: 0x001170BC File Offset: 0x001154BC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.StakeRecordList = new StakeRecord[(int)num];
			for (int i = 0; i < this.StakeRecordList.Length; i++)
			{
				this.StakeRecordList[i] = new StakeRecord();
				this.StakeRecordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C7B RID: 23675 RVA: 0x00117118 File Offset: 0x00115518
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.StakeRecordList.Length; i++)
			{
				num += this.StakeRecordList[i].getLen();
			}
			return num;
		}

		// Token: 0x040025C1 RID: 9665
		public const uint MsgID = 708311U;

		// Token: 0x040025C2 RID: 9666
		public uint Sequence;

		// Token: 0x040025C3 RID: 9667
		public StakeRecord[] StakeRecordList = new StakeRecord[0];
	}
}
