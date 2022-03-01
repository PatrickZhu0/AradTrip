using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x02000632 RID: 1586
	internal class ItemDecoder
	{
		// Token: 0x06005598 RID: 21912 RVA: 0x00105B4C File Offset: 0x00103F4C
		public static List<Item> Decode(byte[] buffer, ref int pos, int length, bool isUpdate = false)
		{
			List<Item> list = new List<Item>();
			for (;;)
			{
				ulong num = 0UL;
				uint dataid = 0U;
				BaseDLL.decode_uint64(buffer, ref pos, ref num);
				if (num == 0UL)
				{
					break;
				}
				if (!isUpdate)
				{
					BaseDLL.decode_uint32(buffer, ref pos, ref dataid);
				}
				Item item = new Item();
				StreamObjectDecoder<Item>.DecodePropertys(ref item, buffer, ref pos, length);
				item.uid = num;
				item.dataid = dataid;
				list.Add(item);
			}
			return list;
		}
	}
}
