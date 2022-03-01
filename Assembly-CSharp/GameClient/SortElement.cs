using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000073 RID: 115
	internal class SortElement
	{
		// Token: 0x06000274 RID: 628 RVA: 0x00012D90 File Offset: 0x00011190
		public static SortElement Alloc()
		{
			if (SortElement.ms_sortelements.Count > 0)
			{
				SortElement result = SortElement.ms_sortelements[0];
				SortElement.ms_sortelements.RemoveAt(0);
				return result;
			}
			return new SortElement
			{
				rectTransform = null,
				iOrder = 0
			};
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00012DDB File Offset: 0x000111DB
		public static void Delloc(SortElement sortElement)
		{
			if (sortElement != null)
			{
				sortElement.rectTransform = null;
				sortElement.iOrder = 0;
				SortElement.ms_sortelements.Add(sortElement);
			}
		}

		// Token: 0x0400026A RID: 618
		public RectTransform rectTransform;

		// Token: 0x0400026B RID: 619
		public int iOrder;

		// Token: 0x0400026C RID: 620
		public static List<SortElement> ms_sortelements = new List<SortElement>();
	}
}
