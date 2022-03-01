using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x020046FA RID: 18170
	[Serializable]
	public class LinearMap<K, V> where K : IComparable<K>, IComparable, IEquatable<K>
	{
		// Token: 0x0601A0F1 RID: 106737 RVA: 0x0081E3C3 File Offset: 0x0081C7C3
		public LinearMap(bool ordered) : this(0, ordered)
		{
		}

		// Token: 0x0601A0F2 RID: 106738 RVA: 0x0081E3CD File Offset: 0x0081C7CD
		public LinearMap(int capacity, bool ordered)
		{
			this.m_ObjectMap = new List<LinearMap<K, V>.KeyValuePair<K, V>>(capacity);
			this.m_FixOrder = ordered;
		}

		// Token: 0x170021D3 RID: 8659
		// (get) Token: 0x0601A0F3 RID: 106739 RVA: 0x0081E3FE File Offset: 0x0081C7FE
		public int Count
		{
			get
			{
				return this.m_ObjectMap.Count;
			}
		}

		// Token: 0x0601A0F4 RID: 106740 RVA: 0x0081E40B File Offset: 0x0081C80B
		public void Fill(List<LinearMap<K, V>.KeyValuePair<K, V>> content, bool fixOrder)
		{
			this.m_ObjectMap = content;
			this.m_FixOrder = fixOrder;
		}

		// Token: 0x0601A0F5 RID: 106741 RVA: 0x0081E41B File Offset: 0x0081C81B
		public void Add(K key, V value)
		{
			if (this._CheckExist(key))
			{
				TMDebug.LogErrorFormat("There is already exist item with same key '{0}'!", new object[]
				{
					key
				});
				return;
			}
			this.m_ObjectMap.Add(new LinearMap<K, V>.KeyValuePair<K, V>(key, value));
			this._MarkDirty();
		}

		// Token: 0x0601A0F6 RID: 106742 RVA: 0x0081E45C File Offset: 0x0081C85C
		public bool TryGetValueAt(int index, out V value)
		{
			if (0 <= index && index < this.m_ObjectMap.Count)
			{
				value = this.m_ObjectMap[index].Value;
				return true;
			}
			value = default(V);
			return false;
		}

		// Token: 0x0601A0F7 RID: 106743 RVA: 0x0081E4AC File Offset: 0x0081C8AC
		public bool TryGetValue(K key, out V value)
		{
			this._EnsureOrder();
			this.m_TargetItem.Key = key;
			int num = this.m_ObjectMap.BinarySearch(this.m_TargetItem, this.m_Comparer);
			if (0 <= num && num < this.m_ObjectMap.Count)
			{
				value = this.m_ObjectMap[num].Value;
				return true;
			}
			value = default(V);
			return false;
		}

		// Token: 0x0601A0F8 RID: 106744 RVA: 0x0081E524 File Offset: 0x0081C924
		public bool ContainsKey(K key)
		{
			this._EnsureOrder();
			this.m_TargetItem.Key = key;
			int num = this.m_ObjectMap.BinarySearch(this.m_TargetItem, this.m_Comparer);
			return 0 <= num && num < this.m_ObjectMap.Count;
		}

		// Token: 0x0601A0F9 RID: 106745 RVA: 0x0081E574 File Offset: 0x0081C974
		public bool Remove(K key)
		{
			this._EnsureOrder();
			this.m_TargetItem.Key = key;
			int num = this.m_ObjectMap.BinarySearch(this.m_TargetItem, this.m_Comparer);
			if (0 <= num && num < this.m_ObjectMap.Count)
			{
				this.m_ObjectMap.RemoveAt(num);
				this._MarkDirty();
				return true;
			}
			return false;
		}

		// Token: 0x170021D4 RID: 8660
		public V this[int index]
		{
			get
			{
				return this.m_ObjectMap[index].Value;
			}
			set
			{
				this.m_ObjectMap[index].Value = value;
			}
		}

		// Token: 0x0601A0FC RID: 106748 RVA: 0x0081E5FF File Offset: 0x0081C9FF
		public void Clear()
		{
			this.m_ObjectMap.Clear();
			this.m_IsDirty = false;
		}

		// Token: 0x0601A0FD RID: 106749 RVA: 0x0081E613 File Offset: 0x0081CA13
		protected void _EnsureOrder()
		{
			if (this.m_IsDirty)
			{
				if (!this.m_FixOrder)
				{
					this.m_ObjectMap.Sort(this.m_Comparer);
				}
				this.m_IsDirty = false;
			}
		}

		// Token: 0x0601A0FE RID: 106750 RVA: 0x0081E643 File Offset: 0x0081CA43
		private void _MarkDirty()
		{
			this.m_IsDirty = true;
		}

		// Token: 0x0601A0FF RID: 106751 RVA: 0x0081E64C File Offset: 0x0081CA4C
		private bool _CheckExist(K key)
		{
			int hashCode = key.GetHashCode();
			int i = 0;
			int count = this.m_ObjectMap.Count;
			while (i < count)
			{
				LinearMap<K, V>.KeyValuePair<K, V> keyValuePair = this.m_ObjectMap[i];
				if (keyValuePair.HashKey == hashCode)
				{
					K key2 = keyValuePair.Key;
					if (key2.Equals(key))
					{
						return true;
					}
				}
				i++;
			}
			return false;
		}

		// Token: 0x040125A7 RID: 75175
		protected readonly LinearMap<K, V>.LinearMapComparer m_Comparer = new LinearMap<K, V>.LinearMapComparer();

		// Token: 0x040125A8 RID: 75176
		protected LinearMap<K, V>.KeyValuePair<K, V> m_TargetItem = new LinearMap<K, V>.KeyValuePair<K, V>();

		// Token: 0x040125A9 RID: 75177
		protected List<LinearMap<K, V>.KeyValuePair<K, V>> m_ObjectMap;

		// Token: 0x040125AA RID: 75178
		protected bool m_FixOrder;

		// Token: 0x040125AB RID: 75179
		private bool m_IsDirty;

		// Token: 0x020046FB RID: 18171
		[Serializable]
		public class KeyValuePair<TKey, TValue> where TKey : IComparable<TKey>, IComparable, IEquatable<TKey>
		{
			// Token: 0x0601A100 RID: 106752 RVA: 0x0081E6BC File Offset: 0x0081CABC
			public KeyValuePair()
			{
				this.m_HashKey = -1;
			}

			// Token: 0x0601A101 RID: 106753 RVA: 0x0081E6CB File Offset: 0x0081CACB
			public KeyValuePair(TKey key, TValue value)
			{
				this.m_Key = key;
				this.m_HashKey = key.GetHashCode();
				this.m_Value = value;
			}

			// Token: 0x170021D5 RID: 8661
			// (get) Token: 0x0601A102 RID: 106754 RVA: 0x0081E6F4 File Offset: 0x0081CAF4
			// (set) Token: 0x0601A103 RID: 106755 RVA: 0x0081E6FC File Offset: 0x0081CAFC
			public TKey Key
			{
				get
				{
					return this.m_Key;
				}
				set
				{
					this.m_Key = value;
					this.m_HashKey = value.GetHashCode();
				}
			}

			// Token: 0x170021D6 RID: 8662
			// (get) Token: 0x0601A104 RID: 106756 RVA: 0x0081E718 File Offset: 0x0081CB18
			public int HashKey
			{
				get
				{
					return this.m_HashKey;
				}
			}

			// Token: 0x170021D7 RID: 8663
			// (get) Token: 0x0601A105 RID: 106757 RVA: 0x0081E720 File Offset: 0x0081CB20
			// (set) Token: 0x0601A106 RID: 106758 RVA: 0x0081E728 File Offset: 0x0081CB28
			public TValue Value
			{
				get
				{
					return this.m_Value;
				}
				set
				{
					this.m_Value = value;
				}
			}

			// Token: 0x040125AC RID: 75180
			private TKey m_Key;

			// Token: 0x040125AD RID: 75181
			private TValue m_Value;

			// Token: 0x040125AE RID: 75182
			private int m_HashKey;
		}

		// Token: 0x020046FC RID: 18172
		protected class LinearMapComparer : IComparer<LinearMap<K, V>.KeyValuePair<K, V>>
		{
			// Token: 0x0601A108 RID: 106760 RVA: 0x0081E73C File Offset: 0x0081CB3C
			public int Compare(LinearMap<K, V>.KeyValuePair<K, V> x, LinearMap<K, V>.KeyValuePair<K, V> y)
			{
				K key = x.Key;
				return key.CompareTo(y.Key);
			}
		}
	}
}
