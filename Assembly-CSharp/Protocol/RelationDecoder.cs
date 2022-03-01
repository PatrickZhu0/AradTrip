using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x0200063F RID: 1599
	public class RelationDecoder
	{
		// Token: 0x060055AA RID: 21930 RVA: 0x00105EE8 File Offset: 0x001042E8
		public static List<Relation> DecodeList(byte[] buffer, ref int pos, int length)
		{
			List<Relation> list = new List<Relation>();
			for (;;)
			{
				ulong num = 0UL;
				BaseDLL.decode_uint64(buffer, ref pos, ref num);
				if (num == 0UL)
				{
					break;
				}
				Relation relation = new Relation();
				BaseDLL.decode_int8(buffer, ref pos, ref relation.isOnline);
				StreamObjectDecoder<Relation>.DecodePropertys(ref relation, buffer, ref pos, length);
				relation.uid = num;
				list.Add(relation);
			}
			return list;
		}

		// Token: 0x060055AB RID: 21931 RVA: 0x00105F48 File Offset: 0x00104348
		public static Relation DecodeData(byte[] buffer, ref int pos, int length)
		{
			Relation relation = new Relation();
			BaseDLL.decode_uint64(buffer, ref pos, ref relation.uid);
			StreamObjectDecoder<Relation>.DecodePropertys(ref relation, buffer, ref pos, length);
			return relation;
		}

		// Token: 0x060055AC RID: 21932 RVA: 0x00105F78 File Offset: 0x00104378
		public static Relation DecodeNew(byte[] buffer, ref int pos, int length)
		{
			Relation relation = new Relation();
			BaseDLL.decode_uint64(buffer, ref pos, ref relation.uid);
			BaseDLL.decode_int8(buffer, ref pos, ref relation.isOnline);
			StreamObjectDecoder<Relation>.DecodePropertys(ref relation, buffer, ref pos, length);
			return relation;
		}
	}
}
