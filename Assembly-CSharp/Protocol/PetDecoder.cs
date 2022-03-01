using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x02000638 RID: 1592
	internal class PetDecoder
	{
		// Token: 0x060055A0 RID: 21920 RVA: 0x00105CA4 File Offset: 0x001040A4
		public static Pet Decode(byte[] buffer, ref int pos, int length)
		{
			Pet pet = new Pet();
			ulong id = 0UL;
			uint dataId = 0U;
			BaseDLL.decode_uint64(buffer, ref pos, ref id);
			BaseDLL.decode_uint32(buffer, ref pos, ref dataId);
			pet.id = id;
			pet.dataId = dataId;
			StreamObjectDecoder<Pet>.DecodePropertys(ref pet, buffer, ref pos, length);
			return pet;
		}

		// Token: 0x060055A1 RID: 21921 RVA: 0x00105CEC File Offset: 0x001040EC
		public static List<Pet> DecodeList(byte[] buffer, ref int pos, int length, bool isUpdate = false)
		{
			List<Pet> list = new List<Pet>();
			for (;;)
			{
				ulong num = 0UL;
				uint dataId = 0U;
				BaseDLL.decode_uint64(buffer, ref pos, ref num);
				if (num == 0UL)
				{
					break;
				}
				if (!isUpdate)
				{
					BaseDLL.decode_uint32(buffer, ref pos, ref dataId);
				}
				Pet pet = new Pet();
				StreamObjectDecoder<Pet>.DecodePropertys(ref pet, buffer, ref pos, length);
				pet.id = num;
				pet.dataId = dataId;
				list.Add(pet);
			}
			return list;
		}
	}
}
