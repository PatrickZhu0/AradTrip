using System;
using System.Collections;
using System.Collections.Specialized;

namespace YIMEngine
{
	// Token: 0x02004A83 RID: 19075
	public class JsonMockWrapper : IJsonWrapper, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x17002523 RID: 9507
		// (get) Token: 0x0601BA6F RID: 113263 RVA: 0x0087E2A9 File Offset: 0x0087C6A9
		public bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002524 RID: 9508
		// (get) Token: 0x0601BA70 RID: 113264 RVA: 0x0087E2AC File Offset: 0x0087C6AC
		public bool IsBoolean
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002525 RID: 9509
		// (get) Token: 0x0601BA71 RID: 113265 RVA: 0x0087E2AF File Offset: 0x0087C6AF
		public bool IsDouble
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002526 RID: 9510
		// (get) Token: 0x0601BA72 RID: 113266 RVA: 0x0087E2B2 File Offset: 0x0087C6B2
		public bool IsInt
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002527 RID: 9511
		// (get) Token: 0x0601BA73 RID: 113267 RVA: 0x0087E2B5 File Offset: 0x0087C6B5
		public bool IsLong
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002528 RID: 9512
		// (get) Token: 0x0601BA74 RID: 113268 RVA: 0x0087E2B8 File Offset: 0x0087C6B8
		public bool IsObject
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002529 RID: 9513
		// (get) Token: 0x0601BA75 RID: 113269 RVA: 0x0087E2BB File Offset: 0x0087C6BB
		public bool IsString
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0601BA76 RID: 113270 RVA: 0x0087E2BE File Offset: 0x0087C6BE
		public bool GetBoolean()
		{
			return false;
		}

		// Token: 0x0601BA77 RID: 113271 RVA: 0x0087E2C1 File Offset: 0x0087C6C1
		public double GetDouble()
		{
			return 0.0;
		}

		// Token: 0x0601BA78 RID: 113272 RVA: 0x0087E2CC File Offset: 0x0087C6CC
		public int GetInt()
		{
			return 0;
		}

		// Token: 0x0601BA79 RID: 113273 RVA: 0x0087E2CF File Offset: 0x0087C6CF
		public JsonType GetJsonType()
		{
			return JsonType.None;
		}

		// Token: 0x0601BA7A RID: 113274 RVA: 0x0087E2D2 File Offset: 0x0087C6D2
		public long GetLong()
		{
			return 0L;
		}

		// Token: 0x0601BA7B RID: 113275 RVA: 0x0087E2D6 File Offset: 0x0087C6D6
		public string GetString()
		{
			return string.Empty;
		}

		// Token: 0x0601BA7C RID: 113276 RVA: 0x0087E2DD File Offset: 0x0087C6DD
		public void SetBoolean(bool val)
		{
		}

		// Token: 0x0601BA7D RID: 113277 RVA: 0x0087E2DF File Offset: 0x0087C6DF
		public void SetDouble(double val)
		{
		}

		// Token: 0x0601BA7E RID: 113278 RVA: 0x0087E2E1 File Offset: 0x0087C6E1
		public void SetInt(int val)
		{
		}

		// Token: 0x0601BA7F RID: 113279 RVA: 0x0087E2E3 File Offset: 0x0087C6E3
		public void SetJsonType(JsonType type)
		{
		}

		// Token: 0x0601BA80 RID: 113280 RVA: 0x0087E2E5 File Offset: 0x0087C6E5
		public void SetLong(long val)
		{
		}

		// Token: 0x0601BA81 RID: 113281 RVA: 0x0087E2E7 File Offset: 0x0087C6E7
		public void SetString(string val)
		{
		}

		// Token: 0x0601BA82 RID: 113282 RVA: 0x0087E2E9 File Offset: 0x0087C6E9
		public string ToJson()
		{
			return string.Empty;
		}

		// Token: 0x0601BA83 RID: 113283 RVA: 0x0087E2F0 File Offset: 0x0087C6F0
		public void ToJson(JsonWriter writer)
		{
		}

		// Token: 0x17002517 RID: 9495
		// (get) Token: 0x0601BA84 RID: 113284 RVA: 0x0087E2F2 File Offset: 0x0087C6F2
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002518 RID: 9496
		// (get) Token: 0x0601BA85 RID: 113285 RVA: 0x0087E2F5 File Offset: 0x0087C6F5
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002519 RID: 9497
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

		// Token: 0x0601BA88 RID: 113288 RVA: 0x0087E2FD File Offset: 0x0087C6FD
		int IList.Add(object value)
		{
			return 0;
		}

		// Token: 0x0601BA89 RID: 113289 RVA: 0x0087E300 File Offset: 0x0087C700
		void IList.Clear()
		{
		}

		// Token: 0x0601BA8A RID: 113290 RVA: 0x0087E302 File Offset: 0x0087C702
		bool IList.Contains(object value)
		{
			return false;
		}

		// Token: 0x0601BA8B RID: 113291 RVA: 0x0087E305 File Offset: 0x0087C705
		int IList.IndexOf(object value)
		{
			return -1;
		}

		// Token: 0x0601BA8C RID: 113292 RVA: 0x0087E308 File Offset: 0x0087C708
		void IList.Insert(int i, object v)
		{
		}

		// Token: 0x0601BA8D RID: 113293 RVA: 0x0087E30A File Offset: 0x0087C70A
		void IList.Remove(object value)
		{
		}

		// Token: 0x0601BA8E RID: 113294 RVA: 0x0087E30C File Offset: 0x0087C70C
		void IList.RemoveAt(int index)
		{
		}

		// Token: 0x1700251A RID: 9498
		// (get) Token: 0x0601BA8F RID: 113295 RVA: 0x0087E30E File Offset: 0x0087C70E
		int ICollection.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700251B RID: 9499
		// (get) Token: 0x0601BA90 RID: 113296 RVA: 0x0087E311 File Offset: 0x0087C711
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700251C RID: 9500
		// (get) Token: 0x0601BA91 RID: 113297 RVA: 0x0087E314 File Offset: 0x0087C714
		object ICollection.SyncRoot
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0601BA92 RID: 113298 RVA: 0x0087E317 File Offset: 0x0087C717
		void ICollection.CopyTo(Array array, int index)
		{
		}

		// Token: 0x0601BA93 RID: 113299 RVA: 0x0087E319 File Offset: 0x0087C719
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		// Token: 0x1700251D RID: 9501
		// (get) Token: 0x0601BA94 RID: 113300 RVA: 0x0087E31C File Offset: 0x0087C71C
		bool IDictionary.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700251E RID: 9502
		// (get) Token: 0x0601BA95 RID: 113301 RVA: 0x0087E31F File Offset: 0x0087C71F
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700251F RID: 9503
		// (get) Token: 0x0601BA96 RID: 113302 RVA: 0x0087E322 File Offset: 0x0087C722
		ICollection IDictionary.Keys
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17002520 RID: 9504
		// (get) Token: 0x0601BA97 RID: 113303 RVA: 0x0087E325 File Offset: 0x0087C725
		ICollection IDictionary.Values
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17002521 RID: 9505
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

		// Token: 0x0601BA9A RID: 113306 RVA: 0x0087E32D File Offset: 0x0087C72D
		void IDictionary.Add(object k, object v)
		{
		}

		// Token: 0x0601BA9B RID: 113307 RVA: 0x0087E32F File Offset: 0x0087C72F
		void IDictionary.Clear()
		{
		}

		// Token: 0x0601BA9C RID: 113308 RVA: 0x0087E331 File Offset: 0x0087C731
		bool IDictionary.Contains(object key)
		{
			return false;
		}

		// Token: 0x0601BA9D RID: 113309 RVA: 0x0087E334 File Offset: 0x0087C734
		void IDictionary.Remove(object key)
		{
		}

		// Token: 0x0601BA9E RID: 113310 RVA: 0x0087E336 File Offset: 0x0087C736
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x17002522 RID: 9506
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

		// Token: 0x0601BAA1 RID: 113313 RVA: 0x0087E33E File Offset: 0x0087C73E
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x0601BAA2 RID: 113314 RVA: 0x0087E341 File Offset: 0x0087C741
		void IOrderedDictionary.Insert(int i, object k, object v)
		{
		}

		// Token: 0x0601BAA3 RID: 113315 RVA: 0x0087E343 File Offset: 0x0087C743
		void IOrderedDictionary.RemoveAt(int i)
		{
		}
	}
}
