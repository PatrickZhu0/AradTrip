using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace YouMe
{
	// Token: 0x02004AC6 RID: 19142
	public class JsonData : IJsonWrapper, IEquatable<JsonData>, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x0601BC84 RID: 113796 RVA: 0x008837EA File Offset: 0x00881BEA
		public JsonData()
		{
		}

		// Token: 0x0601BC85 RID: 113797 RVA: 0x008837F2 File Offset: 0x00881BF2
		public JsonData(bool boolean)
		{
			this.type = JsonType.Boolean;
			this.inst_boolean = boolean;
		}

		// Token: 0x0601BC86 RID: 113798 RVA: 0x00883808 File Offset: 0x00881C08
		public JsonData(double number)
		{
			this.type = JsonType.Double;
			this.inst_double = number;
		}

		// Token: 0x0601BC87 RID: 113799 RVA: 0x0088381E File Offset: 0x00881C1E
		public JsonData(int number)
		{
			this.type = JsonType.Int;
			this.inst_int = number;
		}

		// Token: 0x0601BC88 RID: 113800 RVA: 0x00883834 File Offset: 0x00881C34
		public JsonData(long number)
		{
			this.type = JsonType.Long;
			this.inst_long = number;
		}

		// Token: 0x0601BC89 RID: 113801 RVA: 0x0088384C File Offset: 0x00881C4C
		public JsonData(object obj)
		{
			if (obj is bool)
			{
				this.type = JsonType.Boolean;
				this.inst_boolean = (bool)obj;
				return;
			}
			if (obj is double)
			{
				this.type = JsonType.Double;
				this.inst_double = (double)obj;
				return;
			}
			if (obj is int)
			{
				this.type = JsonType.Int;
				this.inst_int = (int)obj;
				return;
			}
			if (obj is long)
			{
				this.type = JsonType.Long;
				this.inst_long = (long)obj;
				return;
			}
			if (obj is string)
			{
				this.type = JsonType.String;
				this.inst_string = (string)obj;
				return;
			}
			throw new ArgumentException("Unable to wrap the given object with JsonData");
		}

		// Token: 0x0601BC8A RID: 113802 RVA: 0x00883904 File Offset: 0x00881D04
		public JsonData(string str)
		{
			this.type = JsonType.String;
			this.inst_string = str;
		}

		// Token: 0x170025AE RID: 9646
		// (get) Token: 0x0601BC8B RID: 113803 RVA: 0x0088391A File Offset: 0x00881D1A
		public int Count
		{
			get
			{
				return this.EnsureCollection().Count;
			}
		}

		// Token: 0x170025AF RID: 9647
		// (get) Token: 0x0601BC8C RID: 113804 RVA: 0x00883927 File Offset: 0x00881D27
		public bool IsArray
		{
			get
			{
				return this.type == JsonType.Array;
			}
		}

		// Token: 0x170025B0 RID: 9648
		// (get) Token: 0x0601BC8D RID: 113805 RVA: 0x00883932 File Offset: 0x00881D32
		public bool IsBoolean
		{
			get
			{
				return this.type == JsonType.Boolean;
			}
		}

		// Token: 0x170025B1 RID: 9649
		// (get) Token: 0x0601BC8E RID: 113806 RVA: 0x0088393D File Offset: 0x00881D3D
		public bool IsDouble
		{
			get
			{
				return this.type == JsonType.Double;
			}
		}

		// Token: 0x170025B2 RID: 9650
		// (get) Token: 0x0601BC8F RID: 113807 RVA: 0x00883948 File Offset: 0x00881D48
		public bool IsInt
		{
			get
			{
				return this.type == JsonType.Int;
			}
		}

		// Token: 0x170025B3 RID: 9651
		// (get) Token: 0x0601BC90 RID: 113808 RVA: 0x00883953 File Offset: 0x00881D53
		public bool IsLong
		{
			get
			{
				return this.type == JsonType.Long;
			}
		}

		// Token: 0x170025B4 RID: 9652
		// (get) Token: 0x0601BC91 RID: 113809 RVA: 0x0088395E File Offset: 0x00881D5E
		public bool IsObject
		{
			get
			{
				return this.type == JsonType.Object;
			}
		}

		// Token: 0x170025B5 RID: 9653
		// (get) Token: 0x0601BC92 RID: 113810 RVA: 0x00883969 File Offset: 0x00881D69
		public bool IsString
		{
			get
			{
				return this.type == JsonType.String;
			}
		}

		// Token: 0x170025B6 RID: 9654
		// (get) Token: 0x0601BC93 RID: 113811 RVA: 0x00883974 File Offset: 0x00881D74
		public ICollection<string> Keys
		{
			get
			{
				this.EnsureDictionary();
				return this.inst_object.Keys;
			}
		}

		// Token: 0x1700259B RID: 9627
		// (get) Token: 0x0601BC94 RID: 113812 RVA: 0x00883988 File Offset: 0x00881D88
		int ICollection.Count
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x1700259C RID: 9628
		// (get) Token: 0x0601BC95 RID: 113813 RVA: 0x00883990 File Offset: 0x00881D90
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.EnsureCollection().IsSynchronized;
			}
		}

		// Token: 0x1700259D RID: 9629
		// (get) Token: 0x0601BC96 RID: 113814 RVA: 0x0088399D File Offset: 0x00881D9D
		object ICollection.SyncRoot
		{
			get
			{
				return this.EnsureCollection().SyncRoot;
			}
		}

		// Token: 0x1700259E RID: 9630
		// (get) Token: 0x0601BC97 RID: 113815 RVA: 0x008839AA File Offset: 0x00881DAA
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.EnsureDictionary().IsFixedSize;
			}
		}

		// Token: 0x1700259F RID: 9631
		// (get) Token: 0x0601BC98 RID: 113816 RVA: 0x008839B7 File Offset: 0x00881DB7
		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.EnsureDictionary().IsReadOnly;
			}
		}

		// Token: 0x170025A0 RID: 9632
		// (get) Token: 0x0601BC99 RID: 113817 RVA: 0x008839C4 File Offset: 0x00881DC4
		ICollection IDictionary.Keys
		{
			get
			{
				this.EnsureDictionary();
				IList<string> list = new List<string>();
				foreach (KeyValuePair<string, JsonData> keyValuePair in this.object_list)
				{
					list.Add(keyValuePair.Key);
				}
				return (ICollection)list;
			}
		}

		// Token: 0x170025A1 RID: 9633
		// (get) Token: 0x0601BC9A RID: 113818 RVA: 0x00883A38 File Offset: 0x00881E38
		ICollection IDictionary.Values
		{
			get
			{
				this.EnsureDictionary();
				IList<JsonData> list = new List<JsonData>();
				foreach (KeyValuePair<string, JsonData> keyValuePair in this.object_list)
				{
					list.Add(keyValuePair.Value);
				}
				return (ICollection)list;
			}
		}

		// Token: 0x170025A2 RID: 9634
		// (get) Token: 0x0601BC9B RID: 113819 RVA: 0x00883AAC File Offset: 0x00881EAC
		bool IJsonWrapper.IsArray
		{
			get
			{
				return this.IsArray;
			}
		}

		// Token: 0x170025A3 RID: 9635
		// (get) Token: 0x0601BC9C RID: 113820 RVA: 0x00883AB4 File Offset: 0x00881EB4
		bool IJsonWrapper.IsBoolean
		{
			get
			{
				return this.IsBoolean;
			}
		}

		// Token: 0x170025A4 RID: 9636
		// (get) Token: 0x0601BC9D RID: 113821 RVA: 0x00883ABC File Offset: 0x00881EBC
		bool IJsonWrapper.IsDouble
		{
			get
			{
				return this.IsDouble;
			}
		}

		// Token: 0x170025A5 RID: 9637
		// (get) Token: 0x0601BC9E RID: 113822 RVA: 0x00883AC4 File Offset: 0x00881EC4
		bool IJsonWrapper.IsInt
		{
			get
			{
				return this.IsInt;
			}
		}

		// Token: 0x170025A6 RID: 9638
		// (get) Token: 0x0601BC9F RID: 113823 RVA: 0x00883ACC File Offset: 0x00881ECC
		bool IJsonWrapper.IsLong
		{
			get
			{
				return this.IsLong;
			}
		}

		// Token: 0x170025A7 RID: 9639
		// (get) Token: 0x0601BCA0 RID: 113824 RVA: 0x00883AD4 File Offset: 0x00881ED4
		bool IJsonWrapper.IsObject
		{
			get
			{
				return this.IsObject;
			}
		}

		// Token: 0x170025A8 RID: 9640
		// (get) Token: 0x0601BCA1 RID: 113825 RVA: 0x00883ADC File Offset: 0x00881EDC
		bool IJsonWrapper.IsString
		{
			get
			{
				return this.IsString;
			}
		}

		// Token: 0x170025A9 RID: 9641
		// (get) Token: 0x0601BCA2 RID: 113826 RVA: 0x00883AE4 File Offset: 0x00881EE4
		bool IList.IsFixedSize
		{
			get
			{
				return this.EnsureList().IsFixedSize;
			}
		}

		// Token: 0x170025AA RID: 9642
		// (get) Token: 0x0601BCA3 RID: 113827 RVA: 0x00883AF1 File Offset: 0x00881EF1
		bool IList.IsReadOnly
		{
			get
			{
				return this.EnsureList().IsReadOnly;
			}
		}

		// Token: 0x170025AB RID: 9643
		object IDictionary.this[object key]
		{
			get
			{
				return this.EnsureDictionary()[key];
			}
			set
			{
				if (!(key is string))
				{
					throw new ArgumentException("The key has to be a string");
				}
				JsonData value2 = this.ToJsonData(value);
				this[(string)key] = value2;
			}
		}

		// Token: 0x170025AC RID: 9644
		object IOrderedDictionary.this[int idx]
		{
			get
			{
				this.EnsureDictionary();
				return this.object_list[idx].Value;
			}
			set
			{
				this.EnsureDictionary();
				JsonData value2 = this.ToJsonData(value);
				KeyValuePair<string, JsonData> keyValuePair = this.object_list[idx];
				this.inst_object[keyValuePair.Key] = value2;
				KeyValuePair<string, JsonData> value3 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value2);
				this.object_list[idx] = value3;
			}
		}

		// Token: 0x170025AD RID: 9645
		object IList.this[int index]
		{
			get
			{
				return this.EnsureList()[index];
			}
			set
			{
				this.EnsureList();
				JsonData value2 = this.ToJsonData(value);
				this[index] = value2;
			}
		}

		// Token: 0x170025B7 RID: 9655
		public JsonData this[string prop_name]
		{
			get
			{
				this.EnsureDictionary();
				return this.inst_object[prop_name];
			}
			set
			{
				this.EnsureDictionary();
				KeyValuePair<string, JsonData> keyValuePair = new KeyValuePair<string, JsonData>(prop_name, value);
				if (this.inst_object.ContainsKey(prop_name))
				{
					for (int i = 0; i < this.object_list.Count; i++)
					{
						if (this.object_list[i].Key == prop_name)
						{
							this.object_list[i] = keyValuePair;
							break;
						}
					}
				}
				else
				{
					this.object_list.Add(keyValuePair);
				}
				this.inst_object[prop_name] = value;
				this.json = null;
			}
		}

		// Token: 0x170025B8 RID: 9656
		public JsonData this[int index]
		{
			get
			{
				this.EnsureCollection();
				if (this.type == JsonType.Array)
				{
					return this.inst_array[index];
				}
				return this.object_list[index].Value;
			}
			set
			{
				this.EnsureCollection();
				if (this.type == JsonType.Array)
				{
					this.inst_array[index] = value;
				}
				else
				{
					KeyValuePair<string, JsonData> keyValuePair = this.object_list[index];
					KeyValuePair<string, JsonData> value2 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value);
					this.object_list[index] = value2;
					this.inst_object[keyValuePair.Key] = value;
				}
				this.json = null;
			}
		}

		// Token: 0x0601BCAE RID: 113838 RVA: 0x00883D69 File Offset: 0x00882169
		public static implicit operator JsonData(bool data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601BCAF RID: 113839 RVA: 0x00883D71 File Offset: 0x00882171
		public static implicit operator JsonData(double data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601BCB0 RID: 113840 RVA: 0x00883D79 File Offset: 0x00882179
		public static implicit operator JsonData(int data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601BCB1 RID: 113841 RVA: 0x00883D81 File Offset: 0x00882181
		public static implicit operator JsonData(long data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601BCB2 RID: 113842 RVA: 0x00883D89 File Offset: 0x00882189
		public static implicit operator JsonData(string data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601BCB3 RID: 113843 RVA: 0x00883D91 File Offset: 0x00882191
		public static explicit operator bool(JsonData data)
		{
			if (data.type != JsonType.Boolean)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_boolean;
		}

		// Token: 0x0601BCB4 RID: 113844 RVA: 0x00883DB0 File Offset: 0x008821B0
		public static explicit operator double(JsonData data)
		{
			if (data.type != JsonType.Double)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_double;
		}

		// Token: 0x0601BCB5 RID: 113845 RVA: 0x00883DCF File Offset: 0x008821CF
		public static explicit operator int(JsonData data)
		{
			if (data.type != JsonType.Int)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.inst_int;
		}

		// Token: 0x0601BCB6 RID: 113846 RVA: 0x00883DEE File Offset: 0x008821EE
		public static explicit operator long(JsonData data)
		{
			if (data.type != JsonType.Long)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.inst_long;
		}

		// Token: 0x0601BCB7 RID: 113847 RVA: 0x00883E0D File Offset: 0x0088220D
		public static explicit operator string(JsonData data)
		{
			if (data.type != JsonType.String)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a string");
			}
			return data.inst_string;
		}

		// Token: 0x0601BCB8 RID: 113848 RVA: 0x00883E2C File Offset: 0x0088222C
		void ICollection.CopyTo(Array array, int index)
		{
			this.EnsureCollection().CopyTo(array, index);
		}

		// Token: 0x0601BCB9 RID: 113849 RVA: 0x00883E3C File Offset: 0x0088223C
		void IDictionary.Add(object key, object value)
		{
			JsonData value2 = this.ToJsonData(value);
			this.EnsureDictionary().Add(key, value2);
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>((string)key, value2);
			this.object_list.Add(item);
			this.json = null;
		}

		// Token: 0x0601BCBA RID: 113850 RVA: 0x00883E7F File Offset: 0x0088227F
		void IDictionary.Clear()
		{
			this.EnsureDictionary().Clear();
			this.object_list.Clear();
			this.json = null;
		}

		// Token: 0x0601BCBB RID: 113851 RVA: 0x00883E9E File Offset: 0x0088229E
		bool IDictionary.Contains(object key)
		{
			return this.EnsureDictionary().Contains(key);
		}

		// Token: 0x0601BCBC RID: 113852 RVA: 0x00883EAC File Offset: 0x008822AC
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IOrderedDictionary)this).GetEnumerator();
		}

		// Token: 0x0601BCBD RID: 113853 RVA: 0x00883EB4 File Offset: 0x008822B4
		void IDictionary.Remove(object key)
		{
			this.EnsureDictionary().Remove(key);
			for (int i = 0; i < this.object_list.Count; i++)
			{
				if (this.object_list[i].Key == (string)key)
				{
					this.object_list.RemoveAt(i);
					break;
				}
			}
			this.json = null;
		}

		// Token: 0x0601BCBE RID: 113854 RVA: 0x00883F25 File Offset: 0x00882325
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.EnsureCollection().GetEnumerator();
		}

		// Token: 0x0601BCBF RID: 113855 RVA: 0x00883F32 File Offset: 0x00882332
		bool IJsonWrapper.GetBoolean()
		{
			if (this.type != JsonType.Boolean)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a boolean");
			}
			return this.inst_boolean;
		}

		// Token: 0x0601BCC0 RID: 113856 RVA: 0x00883F51 File Offset: 0x00882351
		double IJsonWrapper.GetDouble()
		{
			if (this.type != JsonType.Double)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a double");
			}
			return this.inst_double;
		}

		// Token: 0x0601BCC1 RID: 113857 RVA: 0x00883F70 File Offset: 0x00882370
		int IJsonWrapper.GetInt()
		{
			if (this.type != JsonType.Int)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return this.inst_int;
		}

		// Token: 0x0601BCC2 RID: 113858 RVA: 0x00883F8F File Offset: 0x0088238F
		long IJsonWrapper.GetLong()
		{
			if (this.type != JsonType.Long)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return this.inst_long;
		}

		// Token: 0x0601BCC3 RID: 113859 RVA: 0x00883FAE File Offset: 0x008823AE
		string IJsonWrapper.GetString()
		{
			if (this.type != JsonType.String)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a string");
			}
			return this.inst_string;
		}

		// Token: 0x0601BCC4 RID: 113860 RVA: 0x00883FCD File Offset: 0x008823CD
		void IJsonWrapper.SetBoolean(bool val)
		{
			this.type = JsonType.Boolean;
			this.inst_boolean = val;
			this.json = null;
		}

		// Token: 0x0601BCC5 RID: 113861 RVA: 0x00883FE4 File Offset: 0x008823E4
		void IJsonWrapper.SetDouble(double val)
		{
			this.type = JsonType.Double;
			this.inst_double = val;
			this.json = null;
		}

		// Token: 0x0601BCC6 RID: 113862 RVA: 0x00883FFB File Offset: 0x008823FB
		void IJsonWrapper.SetInt(int val)
		{
			this.type = JsonType.Int;
			this.inst_int = val;
			this.json = null;
		}

		// Token: 0x0601BCC7 RID: 113863 RVA: 0x00884012 File Offset: 0x00882412
		void IJsonWrapper.SetLong(long val)
		{
			this.type = JsonType.Long;
			this.inst_long = val;
			this.json = null;
		}

		// Token: 0x0601BCC8 RID: 113864 RVA: 0x00884029 File Offset: 0x00882429
		void IJsonWrapper.SetString(string val)
		{
			this.type = JsonType.String;
			this.inst_string = val;
			this.json = null;
		}

		// Token: 0x0601BCC9 RID: 113865 RVA: 0x00884040 File Offset: 0x00882440
		string IJsonWrapper.ToJson()
		{
			return this.ToJson();
		}

		// Token: 0x0601BCCA RID: 113866 RVA: 0x00884048 File Offset: 0x00882448
		void IJsonWrapper.ToJson(JsonWriter writer)
		{
			this.ToJson(writer);
		}

		// Token: 0x0601BCCB RID: 113867 RVA: 0x00884051 File Offset: 0x00882451
		int IList.Add(object value)
		{
			return this.Add(value);
		}

		// Token: 0x0601BCCC RID: 113868 RVA: 0x0088405A File Offset: 0x0088245A
		void IList.Clear()
		{
			this.EnsureList().Clear();
			this.json = null;
		}

		// Token: 0x0601BCCD RID: 113869 RVA: 0x0088406E File Offset: 0x0088246E
		bool IList.Contains(object value)
		{
			return this.EnsureList().Contains(value);
		}

		// Token: 0x0601BCCE RID: 113870 RVA: 0x0088407C File Offset: 0x0088247C
		int IList.IndexOf(object value)
		{
			return this.EnsureList().IndexOf(value);
		}

		// Token: 0x0601BCCF RID: 113871 RVA: 0x0088408A File Offset: 0x0088248A
		void IList.Insert(int index, object value)
		{
			this.EnsureList().Insert(index, value);
			this.json = null;
		}

		// Token: 0x0601BCD0 RID: 113872 RVA: 0x008840A0 File Offset: 0x008824A0
		void IList.Remove(object value)
		{
			this.EnsureList().Remove(value);
			this.json = null;
		}

		// Token: 0x0601BCD1 RID: 113873 RVA: 0x008840B5 File Offset: 0x008824B5
		void IList.RemoveAt(int index)
		{
			this.EnsureList().RemoveAt(index);
			this.json = null;
		}

		// Token: 0x0601BCD2 RID: 113874 RVA: 0x008840CA File Offset: 0x008824CA
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			this.EnsureDictionary();
			return new OrderedDictionaryEnumerator(this.object_list.GetEnumerator());
		}

		// Token: 0x0601BCD3 RID: 113875 RVA: 0x008840E4 File Offset: 0x008824E4
		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
			string text = (string)key;
			JsonData value2 = this.ToJsonData(value);
			this[text] = value2;
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>(text, value2);
			this.object_list.Insert(idx, item);
		}

		// Token: 0x0601BCD4 RID: 113876 RVA: 0x00884120 File Offset: 0x00882520
		void IOrderedDictionary.RemoveAt(int idx)
		{
			this.EnsureDictionary();
			this.inst_object.Remove(this.object_list[idx].Key);
			this.object_list.RemoveAt(idx);
		}

		// Token: 0x0601BCD5 RID: 113877 RVA: 0x00884160 File Offset: 0x00882560
		private ICollection EnsureCollection()
		{
			if (this.type == JsonType.Array)
			{
				return (ICollection)this.inst_array;
			}
			if (this.type == JsonType.Object)
			{
				return (ICollection)this.inst_object;
			}
			throw new InvalidOperationException("The JsonData instance has to be initialized first");
		}

		// Token: 0x0601BCD6 RID: 113878 RVA: 0x0088419C File Offset: 0x0088259C
		private IDictionary EnsureDictionary()
		{
			if (this.type == JsonType.Object)
			{
				return (IDictionary)this.inst_object;
			}
			if (this.type != JsonType.None)
			{
				throw new InvalidOperationException("Instance of JsonData is not a dictionary");
			}
			this.type = JsonType.Object;
			this.inst_object = new Dictionary<string, JsonData>();
			this.object_list = new List<KeyValuePair<string, JsonData>>();
			return (IDictionary)this.inst_object;
		}

		// Token: 0x0601BCD7 RID: 113879 RVA: 0x00884200 File Offset: 0x00882600
		private IList EnsureList()
		{
			if (this.type == JsonType.Array)
			{
				return (IList)this.inst_array;
			}
			if (this.type != JsonType.None)
			{
				throw new InvalidOperationException("Instance of JsonData is not a list");
			}
			this.type = JsonType.Array;
			this.inst_array = new List<JsonData>();
			return (IList)this.inst_array;
		}

		// Token: 0x0601BCD8 RID: 113880 RVA: 0x00884258 File Offset: 0x00882658
		private JsonData ToJsonData(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			if (obj is JsonData)
			{
				return (JsonData)obj;
			}
			return new JsonData(obj);
		}

		// Token: 0x0601BCD9 RID: 113881 RVA: 0x0088427C File Offset: 0x0088267C
		private static void WriteJson(IJsonWrapper obj, JsonWriter writer)
		{
			if (obj == null)
			{
				writer.Write(null);
				return;
			}
			if (obj.IsString)
			{
				writer.Write(obj.GetString());
				return;
			}
			if (obj.IsBoolean)
			{
				writer.Write(obj.GetBoolean());
				return;
			}
			if (obj.IsDouble)
			{
				writer.Write(obj.GetDouble());
				return;
			}
			if (obj.IsInt)
			{
				writer.Write(obj.GetInt());
				return;
			}
			if (obj.IsLong)
			{
				writer.Write(obj.GetLong());
				return;
			}
			if (obj.IsArray)
			{
				writer.WriteArrayStart();
				IEnumerator enumerator = obj.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj2 = enumerator.Current;
						JsonData.WriteJson((JsonData)obj2, writer);
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
				writer.WriteArrayEnd();
				return;
			}
			if (obj.IsObject)
			{
				writer.WriteObjectStart();
				IDictionaryEnumerator enumerator2 = obj.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj3 = enumerator2.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj3;
						writer.WritePropertyName((string)dictionaryEntry.Key);
						JsonData.WriteJson((JsonData)dictionaryEntry.Value, writer);
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				writer.WriteObjectEnd();
				return;
			}
		}

		// Token: 0x0601BCDA RID: 113882 RVA: 0x00884404 File Offset: 0x00882804
		public int Add(object value)
		{
			JsonData value2 = this.ToJsonData(value);
			this.json = null;
			return this.EnsureList().Add(value2);
		}

		// Token: 0x0601BCDB RID: 113883 RVA: 0x0088442C File Offset: 0x0088282C
		public void Clear()
		{
			if (this.IsObject)
			{
				((IDictionary)this).Clear();
				return;
			}
			if (this.IsArray)
			{
				((IList)this).Clear();
				return;
			}
		}

		// Token: 0x0601BCDC RID: 113884 RVA: 0x00884454 File Offset: 0x00882854
		public bool Equals(JsonData x)
		{
			if (x == null)
			{
				return false;
			}
			if (x.type != this.type)
			{
				return false;
			}
			switch (this.type)
			{
			case JsonType.None:
				return true;
			case JsonType.Object:
				return this.inst_object.Equals(x.inst_object);
			case JsonType.Array:
				return this.inst_array.Equals(x.inst_array);
			case JsonType.String:
				return this.inst_string.Equals(x.inst_string);
			case JsonType.Int:
				return this.inst_int.Equals(x.inst_int);
			case JsonType.Long:
				return this.inst_long.Equals(x.inst_long);
			case JsonType.Double:
				return this.inst_double.Equals(x.inst_double);
			case JsonType.Boolean:
				return this.inst_boolean.Equals(x.inst_boolean);
			default:
				return false;
			}
		}

		// Token: 0x0601BCDD RID: 113885 RVA: 0x0088452F File Offset: 0x0088292F
		public JsonType GetJsonType()
		{
			return this.type;
		}

		// Token: 0x0601BCDE RID: 113886 RVA: 0x00884538 File Offset: 0x00882938
		public void SetJsonType(JsonType type)
		{
			if (this.type == type)
			{
				return;
			}
			switch (type)
			{
			case JsonType.Object:
				this.inst_object = new Dictionary<string, JsonData>();
				this.object_list = new List<KeyValuePair<string, JsonData>>();
				break;
			case JsonType.Array:
				this.inst_array = new List<JsonData>();
				break;
			case JsonType.String:
				this.inst_string = null;
				break;
			case JsonType.Int:
				this.inst_int = 0;
				break;
			case JsonType.Long:
				this.inst_long = 0L;
				break;
			case JsonType.Double:
				this.inst_double = 0.0;
				break;
			case JsonType.Boolean:
				this.inst_boolean = false;
				break;
			}
			this.type = type;
		}

		// Token: 0x0601BCDF RID: 113887 RVA: 0x008845FC File Offset: 0x008829FC
		public string ToJson()
		{
			if (this.json != null)
			{
				return this.json;
			}
			StringWriter stringWriter = new StringWriter();
			JsonData.WriteJson(this, new JsonWriter(stringWriter)
			{
				Validate = false
			});
			this.json = stringWriter.ToString();
			return this.json;
		}

		// Token: 0x0601BCE0 RID: 113888 RVA: 0x00884648 File Offset: 0x00882A48
		public void ToJson(JsonWriter writer)
		{
			bool validate = writer.Validate;
			writer.Validate = false;
			JsonData.WriteJson(this, writer);
			writer.Validate = validate;
		}

		// Token: 0x0601BCE1 RID: 113889 RVA: 0x00884674 File Offset: 0x00882A74
		public override string ToString()
		{
			switch (this.type)
			{
			case JsonType.Object:
				return "JsonData object";
			case JsonType.Array:
				return "JsonData array";
			case JsonType.String:
				return this.inst_string;
			case JsonType.Int:
				return this.inst_int.ToString();
			case JsonType.Long:
				return this.inst_long.ToString();
			case JsonType.Double:
				return this.inst_double.ToString();
			case JsonType.Boolean:
				return this.inst_boolean.ToString();
			default:
				return "Uninitialized JsonData";
			}
		}

		// Token: 0x040135DA RID: 79322
		private IList<JsonData> inst_array;

		// Token: 0x040135DB RID: 79323
		private bool inst_boolean;

		// Token: 0x040135DC RID: 79324
		private double inst_double;

		// Token: 0x040135DD RID: 79325
		private int inst_int;

		// Token: 0x040135DE RID: 79326
		private long inst_long;

		// Token: 0x040135DF RID: 79327
		private IDictionary<string, JsonData> inst_object;

		// Token: 0x040135E0 RID: 79328
		private string inst_string;

		// Token: 0x040135E1 RID: 79329
		private string json;

		// Token: 0x040135E2 RID: 79330
		private JsonType type;

		// Token: 0x040135E3 RID: 79331
		private IList<KeyValuePair<string, JsonData>> object_list;
	}
}
