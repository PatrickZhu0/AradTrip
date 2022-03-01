using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017E6 RID: 6118
	public class ComMoneyRewardsTimePanel : MonoBehaviour
	{
		// Token: 0x17001CF5 RID: 7413
		// (get) Token: 0x0600F0F4 RID: 61684 RVA: 0x0040E229 File Offset: 0x0040C629
		public int Length
		{
			get
			{
				return IntMath.Min(this.mHints1.Length, this.mHints2.Length);
			}
		}

		// Token: 0x0600F0F5 RID: 61685 RVA: 0x0040E240 File Offset: 0x0040C640
		private void Start()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PremiumLeagueTimeTable>();
			if (table != null)
			{
				int num = 0;
				int num2 = 2;
				int num3 = 7;
				for (int i = num2; i <= num3; i++)
				{
					PremiumLeagueTimeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PremiumLeagueTimeTable>(i, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (num >= 0 && num < this.mHints1.Length)
						{
							Text text = this.mHints1[num];
							if (null != text)
							{
								text.text = tableItem.Time;
							}
						}
						if (num >= 0 && num < this.mHints2.Length)
						{
							Text text2 = this.mHints2[num];
							if (null != text2)
							{
								text2.text = tableItem.Desc;
							}
						}
						num++;
					}
				}
			}
		}

		// Token: 0x0400940A RID: 37898
		public Text[] mHints1 = new Text[6];

		// Token: 0x0400940B RID: 37899
		public Text[] mHints2 = new Text[6];
	}
}
