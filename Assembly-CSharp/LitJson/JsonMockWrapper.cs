using System;
using System.Collections;
using System.Collections.Specialized;

namespace LitJson
{
	// Token: 0x020046A6 RID: 18086
	public class JsonMockWrapper : IJsonWrapper, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x17002119 RID: 8473
		// (get) Token: 0x0601999C RID: 104860 RVA: 0x00810591 File Offset: 0x0080E991
		public bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700211A RID: 8474
		// (get) Token: 0x0601999D RID: 104861 RVA: 0x00810594 File Offset: 0x0080E994
		public bool IsBoolean
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700211B RID: 8475
		// (get) Token: 0x0601999E RID: 104862 RVA: 0x00810597 File Offset: 0x0080E997
		public bool IsDouble
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700211C RID: 8476
		// (get) Token: 0x0601999F RID: 104863 RVA: 0x0081059A File Offset: 0x0080E99A
		public bool IsInt
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700211D RID: 8477
		// (get) Token: 0x060199A0 RID: 104864 RVA: 0x0081059D File Offset: 0x0080E99D
		public bool IsLong
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700211E RID: 8478
		// (get) Token: 0x060199A1 RID: 104865 RVA: 0x008105A0 File Offset: 0x0080E9A0
		public bool IsObject
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700211F RID: 8479
		// (get) Token: 0x060199A2 RID: 104866 RVA: 0x008105A3 File Offset: 0x0080E9A3
		public bool IsString
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060199A3 RID: 104867 RVA: 0x008105A6 File Offset: 0x0080E9A6
		public bool GetBoolean()
		{
			return false;
		}

		// Token: 0x060199A4 RID: 104868 RVA: 0x008105A9 File Offset: 0x0080E9A9
		public double GetDouble()
		{
			return 0.0;
		}

		// Token: 0x060199A5 RID: 104869 RVA: 0x008105B4 File Offset: 0x0080E9B4
		public int GetInt()
		{
			return 0;
		}

		// Token: 0x060199A6 RID: 104870 RVA: 0x008105B7 File Offset: 0x0080E9B7
		public JsonType GetJsonType()
		{
			return JsonType.None;
		}

		// Token: 0x060199A7 RID: 104871 RVA: 0x008105BA File Offset: 0x0080E9BA
		public long GetLong()
		{
			return 0L;
		}

		// Token: 0x060199A8 RID: 104872 RVA: 0x008105BE File Offset: 0x0080E9BE
		public string GetString()
		{
			return string.Empty;
		}

		// Token: 0x060199A9 RID: 104873 RVA: 0x008105C5 File Offset: 0x0080E9C5
		public void SetBoolean(bool val)
		{
		}

		// Token: 0x060199AA RID: 104874 RVA: 0x008105C7 File Offset: 0x0080E9C7
		public void SetDouble(double val)
		{
		}

		// Token: 0x060199AB RID: 104875 RVA: 0x008105C9 File Offset: 0x0080E9C9
		public void SetInt(int val)
		{
		}

		// Token: 0x060199AC RID: 104876 RVA: 0x008105CB File Offset: 0x0080E9CB
		public void SetJsonType(JsonType type)
		{
		}

		// Token: 0x060199AD RID: 104877 RVA: 0x008105CD File Offset: 0x0080E9CD
		public void SetLong(long val)
		{
		}

		// Token: 0x060199AE RID: 104878 RVA: 0x008105CF File Offset: 0x0080E9CF
		public void SetString(string val)
		{
		}

		// Token: 0x060199AF RID: 104879 RVA: 0x008105D1 File Offset: 0x0080E9D1
		public string ToJson()
		{
			return string.Empty;
		}

		// Token: 0x060199B0 RID: 104880 RVA: 0x008105D8 File Offset: 0x0080E9D8
		public void ToJson(JsonWriter writer)
		{
		}

		// Token: 0x1700210D RID: 8461
		// (get) Token: 0x060199B1 RID: 104881 RVA: 0x008105DA File Offset: 0x0080E9DA
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700210E RID: 8462
		// (get) Token: 0x060199B2 RID: 104882 RVA: 0x008105DD File Offset: 0x0080E9DD
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700210F RID: 8463
		object IList.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x060199B5 RID: 104885 RVA: 0x008105E5 File Offset: 0x0080E9E5
		int IList.Add(object value)
		{
			return 0;
		}

		// Token: 0x060199B6 RID: 104886 RVA: 0x008105E8 File Offset: 0x0080E9E8
		void IList.Clear()
		{
		}

		// Token: 0x060199B7 RID: 104887 RVA: 0x008105EA File Offset: 0x0080E9EA
		bool IList.Contains(object value)
		{
			return false;
		}

		// Token: 0x060199B8 RID: 104888 RVA: 0x008105ED File Offset: 0x0080E9ED
		int IList.IndexOf(object value)
		{
			return -1;
		}

		// Token: 0x060199B9 RID: 104889 RVA: 0x008105F0 File Offset: 0x0080E9F0
		void IList.Insert(int i, object v)
		{
		}

		// Token: 0x060199BA RID: 104890 RVA: 0x008105F2 File Offset: 0x0080E9F2
		void IList.Remove(object value)
		{
		}

		// Token: 0x060199BB RID: 104891 RVA: 0x008105F4 File Offset: 0x0080E9F4
		void IList.RemoveAt(int index)
		{
		}

		// Token: 0x17002110 RID: 8464
		// (get) Token: 0x060199BC RID: 104892 RVA: 0x008105F6 File Offset: 0x0080E9F6
		int ICollection.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17002111 RID: 8465
		// (get) Token: 0x060199BD RID: 104893 RVA: 0x008105F9 File Offset: 0x0080E9F9
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002112 RID: 8466
		// (get) Token: 0x060199BE RID: 104894 RVA: 0x008105FC File Offset: 0x0080E9FC
		object ICollection.SyncRoot
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060199BF RID: 104895 RVA: 0x008105FF File Offset: 0x0080E9FF
		void ICollection.CopyTo(Array array, int index)
		{
		}

		// Token: 0x060199C0 RID: 104896 RVA: 0x00810601 File Offset: 0x0080EA01
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		// Token: 0x17002113 RID: 8467
		// (get) Token: 0x060199C1 RID: 104897 RVA: 0x00810604 File Offset: 0x0080EA04
		bool IDictionary.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002114 RID: 8468
		// (get) Token: 0x060199C2 RID: 104898 RVA: 0x00810607 File Offset: 0x0080EA07
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002115 RID: 8469
		// (get) Token: 0x060199C3 RID: 104899 RVA: 0x0081060A File Offset: 0x0080EA0A
		ICollection IDictionary.Keys
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17002116 RID: 8470
		// (get) Token: 0x060199C4 RID: 104900 RVA: 0x0081060D File Offset: 0x0080EA0D
		ICollection IDictionary.Values
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17002117 RID: 8471
		object IDictionary.this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x060199C7 RID: 104903 RVA: 0x00810615 File Offset: 0x0080EA15
		void IDictionary.Add(object k, object v)
		{
		}

		// Token: 0x060199C8 RID: 104904 RVA: 0x00810617 File Offset: 0x0080EA17
		void IDictionary.Clear()
		{
		}

		// Token: 0x060199C9 RID: 104905 RVA: 0x00810619 File Offset: 0x0080EA19
		bool IDictionary.Contains(object key)
		{
			return false;
		}

		// Token: 0x060199CA RID: 104906 RVA: 0x0081061C File Offset: 0x0080EA1C
		void IDictionary.Remove(object key)
		{
		}

		// Token: 0x060199CB RID: 104907 RVA: 0x0081061E File Offset: 0x0080EA1E
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x17002118 RID: 8472
		object IOrderedDictionary.this[int idx]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x060199CE RID: 104910 RVA: 0x00810626 File Offset: 0x0080EA26
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x060199CF RID: 104911 RVA: 0x00810629 File Offset: 0x0080EA29
		void IOrderedDictionary.Insert(int i, object k, object v)
		{
		}

		// Token: 0x060199D0 RID: 104912 RVA: 0x0081062B File Offset: 0x0080EA2B
		void IOrderedDictionary.RemoveAt(int i)
		{
		}
	}
}
