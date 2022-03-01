using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001380 RID: 4992
	public class KeyValuePairObject
	{
		// Token: 0x0600C1B2 RID: 49586 RVA: 0x002E2CF6 File Offset: 0x002E10F6
		public KeyValuePairObject()
		{
			this.kPreContent = null;
			this.kAftContent = null;
			this.text = null;
			this.key = null;
			this.v = null;
			this.eKVMode = KeyValuePairObject.KVMode.KVM_KV;
			this.bHasColor = false;
		}

		// Token: 0x04006DB1 RID: 28081
		public static Regex kvRegex = new Regex("<path=([A-Za-z0-9/]+) value=(.+)>", RegexOptions.Singleline);

		// Token: 0x04006DB2 RID: 28082
		public static Regex kvContent = new Regex("replace=<k=(\\w+) v=([A-Za-z0-9]*) mode=(\\d+) ec=(#[A-Fa-f0-9]*) dc=(#[A-Fa-f0-9]*)>", RegexOptions.Singleline);

		// Token: 0x04006DB3 RID: 28083
		public string kPreContent;

		// Token: 0x04006DB4 RID: 28084
		public string kAftContent;

		// Token: 0x04006DB5 RID: 28085
		public Text text;

		// Token: 0x04006DB6 RID: 28086
		public string key;

		// Token: 0x04006DB7 RID: 28087
		public string v;

		// Token: 0x04006DB8 RID: 28088
		public KeyValuePairObject.KVMode eKVMode;

		// Token: 0x04006DB9 RID: 28089
		public string enableColor;

		// Token: 0x04006DBA RID: 28090
		public string disableColor;

		// Token: 0x04006DBB RID: 28091
		public bool bHasColor;

		// Token: 0x02001381 RID: 4993
		public enum KVMode
		{
			// Token: 0x04006DBD RID: 28093
			KVM_KV,
			// Token: 0x04006DBE RID: 28094
			KVM_KK,
			// Token: 0x04006DBF RID: 28095
			KVM_REPLACE
		}
	}
}
