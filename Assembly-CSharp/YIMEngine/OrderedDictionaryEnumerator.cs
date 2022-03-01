using System;
using System.Collections;
using System.Collections.Generic;

namespace YIMEngine
{
	// Token: 0x02004A78 RID: 19064
	internal class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x0601BA0C RID: 113164 RVA: 0x0087C915 File Offset: 0x0087AD15
		public OrderedDictionaryEnumerator(IEnumerator<KeyValuePair<string, JsonData>> enumerator)
		{
			this.list_enumerator = enumerator;
		}

		// Token: 0x1700250D RID: 9485
		// (get) Token: 0x0601BA0D RID: 113165 RVA: 0x0087C924 File Offset: 0x0087AD24
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x1700250E RID: 9486
		// (get) Token: 0x0601BA0E RID: 113166 RVA: 0x0087C934 File Offset: 0x0087AD34
		public DictionaryEntry Entry
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x1700250F RID: 9487
		// (get) Token: 0x0601BA0F RID: 113167 RVA: 0x0087C960 File Offset: 0x0087AD60
		public object Key
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x17002510 RID: 9488
		// (get) Token: 0x0601BA10 RID: 113168 RVA: 0x0087C980 File Offset: 0x0087AD80
		public object Value
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x0601BA11 RID: 113169 RVA: 0x0087C9A0 File Offset: 0x0087ADA0
		public bool MoveNext()
		{
			return this.list_enumerator.MoveNext();
		}

		// Token: 0x0601BA12 RID: 113170 RVA: 0x0087C9AD File Offset: 0x0087ADAD
		public void Reset()
		{
			this.list_enumerator.Reset();
		}

		// Token: 0x0401341E RID: 78878
		private IEnumerator<KeyValuePair<string, JsonData>> list_enumerator;
	}
}
