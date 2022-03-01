using System;
using System.Collections;
using System.Collections.Generic;

namespace YouMe
{
	// Token: 0x02004AC7 RID: 19143
	internal class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x0601BCE2 RID: 113890 RVA: 0x00884711 File Offset: 0x00882B11
		public OrderedDictionaryEnumerator(IEnumerator<KeyValuePair<string, JsonData>> enumerator)
		{
			this.list_enumerator = enumerator;
		}

		// Token: 0x170025B9 RID: 9657
		// (get) Token: 0x0601BCE3 RID: 113891 RVA: 0x00884720 File Offset: 0x00882B20
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x170025BA RID: 9658
		// (get) Token: 0x0601BCE4 RID: 113892 RVA: 0x00884730 File Offset: 0x00882B30
		public DictionaryEntry Entry
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x170025BB RID: 9659
		// (get) Token: 0x0601BCE5 RID: 113893 RVA: 0x0088475C File Offset: 0x00882B5C
		public object Key
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x170025BC RID: 9660
		// (get) Token: 0x0601BCE6 RID: 113894 RVA: 0x0088477C File Offset: 0x00882B7C
		public object Value
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x0601BCE7 RID: 113895 RVA: 0x0088479C File Offset: 0x00882B9C
		public bool MoveNext()
		{
			return this.list_enumerator.MoveNext();
		}

		// Token: 0x0601BCE8 RID: 113896 RVA: 0x008847A9 File Offset: 0x00882BA9
		public void Reset()
		{
			this.list_enumerator.Reset();
		}

		// Token: 0x040135E4 RID: 79332
		private IEnumerator<KeyValuePair<string, JsonData>> list_enumerator;
	}
}
