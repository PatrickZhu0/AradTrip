using System;
using System.Collections;
using System.Collections.Generic;

namespace LitJson
{
	// Token: 0x0200469B RID: 18075
	internal class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x06019939 RID: 104761 RVA: 0x0080EBFD File Offset: 0x0080CFFD
		public OrderedDictionaryEnumerator(IEnumerator<KeyValuePair<string, JsonData>> enumerator)
		{
			this.list_enumerator = enumerator;
		}

		// Token: 0x17002103 RID: 8451
		// (get) Token: 0x0601993A RID: 104762 RVA: 0x0080EC0C File Offset: 0x0080D00C
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x17002104 RID: 8452
		// (get) Token: 0x0601993B RID: 104763 RVA: 0x0080EC1C File Offset: 0x0080D01C
		public DictionaryEntry Entry
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x17002105 RID: 8453
		// (get) Token: 0x0601993C RID: 104764 RVA: 0x0080EC48 File Offset: 0x0080D048
		public object Key
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x17002106 RID: 8454
		// (get) Token: 0x0601993D RID: 104765 RVA: 0x0080EC68 File Offset: 0x0080D068
		public object Value
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x0601993E RID: 104766 RVA: 0x0080EC88 File Offset: 0x0080D088
		public bool MoveNext()
		{
			return this.list_enumerator.MoveNext();
		}

		// Token: 0x0601993F RID: 104767 RVA: 0x0080EC95 File Offset: 0x0080D095
		public void Reset()
		{
			this.list_enumerator.Reset();
		}

		// Token: 0x040123B8 RID: 74680
		private IEnumerator<KeyValuePair<string, JsonData>> list_enumerator;
	}
}
