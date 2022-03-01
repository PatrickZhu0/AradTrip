using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D3D RID: 3389
	public class GeUIEffectDataBlockSerializer
	{
		// Token: 0x06008A12 RID: 35346 RVA: 0x0019407C File Offset: 0x0019247C
		public static string[] ToString(GeUIEffectDataBlock[] data)
		{
			string[] array = new string[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				array[i] = string.Format("{0}|{1}", data[i].m_Name, data[i].m_Value);
			}
			return array;
		}

		// Token: 0x06008A13 RID: 35347 RVA: 0x001940C4 File Offset: 0x001924C4
		public static GeUIEffectDataBlock[] FromString(string[] str)
		{
			GeUIEffectDataBlock[] array = new GeUIEffectDataBlock[str.Length];
			for (int i = 0; i < str.Length; i++)
			{
				string[] array2 = str[i].Split(new char[]
				{
					'|'
				});
				if (array2.Length == 2)
				{
					array[i] = new GeUIEffectDataBlock(array2[0], array2[1]);
				}
			}
			return array;
		}
	}
}
