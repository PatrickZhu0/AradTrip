using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x0200063C RID: 1596
	public class PkStatisticDecoder
	{
		// Token: 0x060055A6 RID: 21926 RVA: 0x00105E68 File Offset: 0x00104268
		public static Dictionary<byte, PkStatistic> DecodeSyncPkStatisticInfoMsg(byte[] buffer, ref int pos, int length)
		{
			Dictionary<byte, PkStatistic> dictionary = new Dictionary<byte, PkStatistic>();
			while (length - pos > 1)
			{
				ulong num = 0UL;
				BaseDLL.decode_uint64(buffer, ref pos, ref num);
				if (num == 0UL)
				{
					break;
				}
				PkStatistic pkStatistic = new PkStatistic();
				pkStatistic.id = num;
				StreamObjectDecoder<PkStatistic>.DecodePropertys(ref pkStatistic, buffer, ref pos, length);
				dictionary.Add(pkStatistic.type, pkStatistic);
			}
			return dictionary;
		}

		// Token: 0x060055A7 RID: 21927 RVA: 0x00105ECA File Offset: 0x001042CA
		public static void DecodeSyncPkStatisticPropertyMsg(ref PkStatistic info, byte[] buffer, ref int pos, int length)
		{
			StreamObjectDecoder<PkStatistic>.DecodePropertys(ref info, buffer, ref pos, length);
		}
	}
}
