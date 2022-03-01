using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x02000635 RID: 1589
	public class MasterSectRelationDecoder
	{
		// Token: 0x0600559B RID: 21915 RVA: 0x00105BC8 File Offset: 0x00103FC8
		public static List<MasterSectRelation> DecodeList(byte[] buffer, ref int pos, int length)
		{
			List<MasterSectRelation> list = new List<MasterSectRelation>();
			for (;;)
			{
				ulong num = 0UL;
				BaseDLL.decode_uint64(buffer, ref pos, ref num);
				if (num == 0UL)
				{
					break;
				}
				MasterSectRelation masterSectRelation = new MasterSectRelation();
				BaseDLL.decode_int8(buffer, ref pos, ref masterSectRelation.isOnline);
				StreamObjectDecoder<MasterSectRelation>.DecodePropertys(ref masterSectRelation, buffer, ref pos, length);
				masterSectRelation.uid = num;
				list.Add(masterSectRelation);
			}
			return list;
		}

		// Token: 0x0600559C RID: 21916 RVA: 0x00105C28 File Offset: 0x00104028
		public static MasterSectRelation DecodeData(byte[] buffer, ref int pos, int length)
		{
			MasterSectRelation masterSectRelation = new MasterSectRelation();
			BaseDLL.decode_uint64(buffer, ref pos, ref masterSectRelation.uid);
			StreamObjectDecoder<MasterSectRelation>.DecodePropertys(ref masterSectRelation, buffer, ref pos, length);
			return masterSectRelation;
		}

		// Token: 0x0600559D RID: 21917 RVA: 0x00105C58 File Offset: 0x00104058
		public static MasterSectRelation DecodeNew(byte[] buffer, ref int pos, int length)
		{
			MasterSectRelation masterSectRelation = new MasterSectRelation();
			BaseDLL.decode_uint64(buffer, ref pos, ref masterSectRelation.uid);
			BaseDLL.decode_int8(buffer, ref pos, ref masterSectRelation.isOnline);
			StreamObjectDecoder<MasterSectRelation>.DecodePropertys(ref masterSectRelation, buffer, ref pos, length);
			return masterSectRelation;
		}
	}
}
