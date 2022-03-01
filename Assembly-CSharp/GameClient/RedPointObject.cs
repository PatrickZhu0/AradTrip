using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001385 RID: 4997
	public class RedPointObject
	{
		// Token: 0x17001BB3 RID: 7091
		// (get) Token: 0x0600C1DA RID: 49626 RVA: 0x002E38D5 File Offset: 0x002E1CD5
		public List<string> Keys
		{
			get
			{
				return this.keys;
			}
		}

		// Token: 0x17001BB4 RID: 7092
		// (get) Token: 0x0600C1DB RID: 49627 RVA: 0x002E38DD File Offset: 0x002E1CDD
		public GameObject Current
		{
			get
			{
				return this.goCurrent;
			}
		}

		// Token: 0x0600C1DC RID: 49628 RVA: 0x002E38E8 File Offset: 0x002E1CE8
		public static List<RedPointObject> Create(string value, GameObject goLocal)
		{
			List<RedPointObject> list = null;
			IEnumerator enumerator = RedPointObject.ms_red_point.Matches(value).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Match match = (Match)obj;
					if (!string.IsNullOrEmpty(match.Groups[0].Value))
					{
						RedPointObject redPointObject = new RedPointObject();
						redPointObject.path = match.Groups[1].Value;
						redPointObject.goCurrent = Utility.FindChild(goLocal, redPointObject.path);
						if (redPointObject.goCurrent != null)
						{
							redPointObject.redBinder = redPointObject.goCurrent.GetComponent<ActiveSpecialRedBinder>();
						}
						if (redPointObject.goCurrent != null)
						{
							string[] array = match.Groups[2].Value.Split(new char[]
							{
								'|'
							});
							for (int i = 0; i < array.Length; i++)
							{
								if (!string.IsNullOrEmpty(array[i]))
								{
									redPointObject.keys.Add(array[i]);
								}
							}
							if (list == null)
							{
								list = new List<RedPointObject>();
							}
							list.Add(redPointObject);
						}
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			return list;
		}

		// Token: 0x04006DD5 RID: 28117
		public static Regex ms_red_point = new Regex("<path=([A-Za-z/]+) key=([A-Za-z\\|]+)");

		// Token: 0x04006DD6 RID: 28118
		public ActiveSpecialRedBinder redBinder;

		// Token: 0x04006DD7 RID: 28119
		private RedPointObject.RedPointType eRedPointType = RedPointObject.RedPointType.RPT_COUNT;

		// Token: 0x04006DD8 RID: 28120
		private int iMark;

		// Token: 0x04006DD9 RID: 28121
		private string path;

		// Token: 0x04006DDA RID: 28122
		private List<string> keys = new List<string>();

		// Token: 0x04006DDB RID: 28123
		private GameObject goCurrent;

		// Token: 0x02001386 RID: 4998
		public enum RedPointType
		{
			// Token: 0x04006DDD RID: 28125
			RPT_LOCAL,
			// Token: 0x04006DDE RID: 28126
			RPT_GLOBAL,
			// Token: 0x04006DDF RID: 28127
			RPT_COUNT
		}
	}
}
