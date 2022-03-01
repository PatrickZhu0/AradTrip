using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001387 RID: 4999
	public class SliderObject
	{
		// Token: 0x04006DE0 RID: 28128
		public static Regex kvRegex = new Regex("<slider=([A-Za-z0-9/]+) k=(\\w+) v=([A-Za-z0-9]*) mode=(\\d+)>", RegexOptions.Singleline);

		// Token: 0x04006DE1 RID: 28129
		public Slider slider;

		// Token: 0x04006DE2 RID: 28130
		public KeyValuePairObject.KVMode eKVMode;

		// Token: 0x04006DE3 RID: 28131
		public string key;

		// Token: 0x04006DE4 RID: 28132
		public string v;
	}
}
