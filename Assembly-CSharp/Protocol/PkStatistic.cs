using System;
using System.Collections.Generic;
using System.Reflection;

namespace Protocol
{
	// Token: 0x0200063B RID: 1595
	public class PkStatistic : StreamObject
	{
		// Token: 0x060055A3 RID: 21923 RVA: 0x00105D7C File Offset: 0x0010417C
		public override bool GetStructProperty(FieldInfo field, byte[] buffer, ref int pos, int length)
		{
			if (field.FieldType == typeof(Dictionary<byte, PkOccuRecord>))
			{
				while (length - pos > 1)
				{
					byte b = 0;
					BaseDLL.decode_int8(buffer, ref pos, ref b);
					if (b == 0)
					{
						break;
					}
					PkOccuRecord pkOccuRecord = new PkOccuRecord();
					pkOccuRecord.decode(buffer, ref pos);
					if (this.detailRecord.ContainsKey(pkOccuRecord.occu))
					{
						this.detailRecord.Remove(pkOccuRecord.occu);
					}
					this.detailRecord.Add(pkOccuRecord.occu, pkOccuRecord);
				}
				return true;
			}
			if (field.FieldType == typeof(byte[]))
			{
				for (int i = 0; i < this.recentRecord.Length; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref this.recentRecord[i]);
				}
				return true;
			}
			return false;
		}

		// Token: 0x04001FBB RID: 8123
		public static byte MAX_RECENT_RECORD_NUM = 10;

		// Token: 0x04001FBC RID: 8124
		public ulong id;

		// Token: 0x04001FBD RID: 8125
		[SProperty(1)]
		public byte type;

		// Token: 0x04001FBE RID: 8126
		[SProperty(2)]
		public uint totalWinNum;

		// Token: 0x04001FBF RID: 8127
		[SProperty(3)]
		public uint totalLoseNum;

		// Token: 0x04001FC0 RID: 8128
		[SProperty(4)]
		public uint totalNum;

		// Token: 0x04001FC1 RID: 8129
		[SProperty(5)]
		public Dictionary<byte, PkOccuRecord> detailRecord = new Dictionary<byte, PkOccuRecord>();

		// Token: 0x04001FC2 RID: 8130
		[SProperty(6)]
		public byte[] recentRecord = new byte[(int)PkStatistic.MAX_RECENT_RECORD_NUM];

		// Token: 0x04001FC3 RID: 8131
		[SProperty(7)]
		public uint maxWinSteak;

		// Token: 0x04001FC4 RID: 8132
		[SProperty(8)]
		public uint curWinSteak;
	}
}
