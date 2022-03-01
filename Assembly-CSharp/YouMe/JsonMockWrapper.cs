using System;
using System.Collections;
using System.Collections.Specialized;

namespace YouMe
{
	// Token: 0x02004AD2 RID: 19154
	public class JsonMockWrapper : IJsonWrapper, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x170025CF RID: 9679
		// (get) Token: 0x0601BD45 RID: 113989 RVA: 0x008860A5 File Offset: 0x008844A5
		public bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025D0 RID: 9680
		// (get) Token: 0x0601BD46 RID: 113990 RVA: 0x008860A8 File Offset: 0x008844A8
		public bool IsBoolean
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025D1 RID: 9681
		// (get) Token: 0x0601BD47 RID: 113991 RVA: 0x008860AB File Offset: 0x008844AB
		public bool IsDouble
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025D2 RID: 9682
		// (get) Token: 0x0601BD48 RID: 113992 RVA: 0x008860AE File Offset: 0x008844AE
		public bool IsInt
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025D3 RID: 9683
		// (get) Token: 0x0601BD49 RID: 113993 RVA: 0x008860B1 File Offset: 0x008844B1
		public bool IsLong
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025D4 RID: 9684
		// (get) Token: 0x0601BD4A RID: 113994 RVA: 0x008860B4 File Offset: 0x008844B4
		public bool IsObject
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025D5 RID: 9685
		// (get) Token: 0x0601BD4B RID: 113995 RVA: 0x008860B7 File Offset: 0x008844B7
		public bool IsString
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0601BD4C RID: 113996 RVA: 0x008860BA File Offset: 0x008844BA
		public bool GetBoolean()
		{
			return false;
		}

		// Token: 0x0601BD4D RID: 113997 RVA: 0x008860BD File Offset: 0x008844BD
		public double GetDouble()
		{
			return 0.0;
		}

		// Token: 0x0601BD4E RID: 113998 RVA: 0x008860C8 File Offset: 0x008844C8
		public int GetInt()
		{
			return 0;
		}

		// Token: 0x0601BD4F RID: 113999 RVA: 0x008860CB File Offset: 0x008844CB
		public JsonType GetJsonType()
		{
			return JsonType.None;
		}

		// Token: 0x0601BD50 RID: 114000 RVA: 0x008860CE File Offset: 0x008844CE
		public long GetLong()
		{
			return 0L;
		}

		// Token: 0x0601BD51 RID: 114001 RVA: 0x008860D2 File Offset: 0x008844D2
		public string GetString()
		{
			return string.Empty;
		}

		// Token: 0x0601BD52 RID: 114002 RVA: 0x008860D9 File Offset: 0x008844D9
		public void SetBoolean(bool val)
		{
		}

		// Token: 0x0601BD53 RID: 114003 RVA: 0x008860DB File Offset: 0x008844DB
		public void SetDouble(double val)
		{
		}

		// Token: 0x0601BD54 RID: 114004 RVA: 0x008860DD File Offset: 0x008844DD
		public void SetInt(int val)
		{
		}

		// Token: 0x0601BD55 RID: 114005 RVA: 0x008860DF File Offset: 0x008844DF
		public void SetJsonType(JsonType type)
		{
		}

		// Token: 0x0601BD56 RID: 114006 RVA: 0x008860E1 File Offset: 0x008844E1
		public void SetLong(long val)
		{
		}

		// Token: 0x0601BD57 RID: 114007 RVA: 0x008860E3 File Offset: 0x008844E3
		public void SetString(string val)
		{
		}

		// Token: 0x0601BD58 RID: 114008 RVA: 0x008860E5 File Offset: 0x008844E5
		public string ToJson()
		{
			return string.Empty;
		}

		// Token: 0x0601BD59 RID: 114009 RVA: 0x008860EC File Offset: 0x008844EC
		public void ToJson(JsonWriter writer)
		{
		}

		// Token: 0x170025C3 RID: 9667
		// (get) Token: 0x0601BD5A RID: 114010 RVA: 0x008860EE File Offset: 0x008844EE
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170025C4 RID: 9668
		// (get) Token: 0x0601BD5B RID: 114011 RVA: 0x008860F1 File Offset: 0x008844F1
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170025C5 RID: 9669
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

		// Token: 0x0601BD5E RID: 114014 RVA: 0x008860F9 File Offset: 0x008844F9
		int IList.Add(object value)
		{
			return 0;
		}

		// Token: 0x0601BD5F RID: 114015 RVA: 0x008860FC File Offset: 0x008844FC
		void IList.Clear()
		{
		}

		// Token: 0x0601BD60 RID: 114016 RVA: 0x008860FE File Offset: 0x008844FE
		bool IList.Contains(object value)
		{
			return false;
		}

		// Token: 0x0601BD61 RID: 114017 RVA: 0x00886101 File Offset: 0x00884501
		int IList.IndexOf(object value)
		{
			return -1;
		}

		// Token: 0x0601BD62 RID: 114018 RVA: 0x00886104 File Offset: 0x00884504
		void IList.Insert(int i, object v)
		{
		}

		// Token: 0x0601BD63 RID: 114019 RVA: 0x00886106 File Offset: 0x00884506
		void IList.Remove(object value)
		{
		}

		// Token: 0x0601BD64 RID: 114020 RVA: 0x00886108 File Offset: 0x00884508
		void IList.RemoveAt(int index)
		{
		}

		// Token: 0x170025C6 RID: 9670
		// (get) Token: 0x0601BD65 RID: 114021 RVA: 0x0088610A File Offset: 0x0088450A
		int ICollection.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170025C7 RID: 9671
		// (get) Token: 0x0601BD66 RID: 114022 RVA: 0x0088610D File Offset: 0x0088450D
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170025C8 RID: 9672
		// (get) Token: 0x0601BD67 RID: 114023 RVA: 0x00886110 File Offset: 0x00884510
		object ICollection.SyncRoot
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0601BD68 RID: 114024 RVA: 0x00886113 File Offset: 0x00884513
		void ICollection.CopyTo(Array array, int index)
		{
		}

		// Token: 0x0601BD69 RID: 114025 RVA: 0x00886115 File Offset: 0x00884515
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		// Token: 0x170025C9 RID: 9673
		// (get) Token: 0x0601BD6A RID: 114026 RVA: 0x00886118 File Offset: 0x00884518
		bool IDictionary.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170025CA RID: 9674
		// (get) Token: 0x0601BD6B RID: 114027 RVA: 0x0088611B File Offset: 0x0088451B
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170025CB RID: 9675
		// (get) Token: 0x0601BD6C RID: 114028 RVA: 0x0088611E File Offset: 0x0088451E
		ICollection IDictionary.Keys
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170025CC RID: 9676
		// (get) Token: 0x0601BD6D RID: 114029 RVA: 0x00886121 File Offset: 0x00884521
		ICollection IDictionary.Values
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170025CD RID: 9677
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

		// Token: 0x0601BD70 RID: 114032 RVA: 0x00886129 File Offset: 0x00884529
		void IDictionary.Add(object k, object v)
		{
		}

		// Token: 0x0601BD71 RID: 114033 RVA: 0x0088612B File Offset: 0x0088452B
		void IDictionary.Clear()
		{
		}

		// Token: 0x0601BD72 RID: 114034 RVA: 0x0088612D File Offset: 0x0088452D
		bool IDictionary.Contains(object key)
		{
			return false;
		}

		// Token: 0x0601BD73 RID: 114035 RVA: 0x00886130 File Offset: 0x00884530
		void IDictionary.Remove(object key)
		{
		}

		// Token: 0x0601BD74 RID: 114036 RVA: 0x00886132 File Offset: 0x00884532
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x170025CE RID: 9678
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

		// Token: 0x0601BD77 RID: 114039 RVA: 0x0088613A File Offset: 0x0088453A
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x0601BD78 RID: 114040 RVA: 0x0088613D File Offset: 0x0088453D
		void IOrderedDictionary.Insert(int i, object k, object v)
		{
		}

		// Token: 0x0601BD79 RID: 114041 RVA: 0x0088613F File Offset: 0x0088453F
		void IOrderedDictionary.RemoveAt(int i)
		{
		}
	}
}
