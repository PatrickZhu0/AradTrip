using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace YIMEngine
{
	// Token: 0x02004A77 RID: 19063
	public class JsonData : IJsonWrapper, IEquatable<JsonData>, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x0601B9AE RID: 113070 RVA: 0x0087B9F0 File Offset: 0x00879DF0
		public JsonData()
		{
		}

		// Token: 0x0601B9AF RID: 113071 RVA: 0x0087B9F8 File Offset: 0x00879DF8
		public JsonData(bool boolean)
		{
			this.type = JsonType.Boolean;
			this.inst_boolean = boolean;
		}

		// Token: 0x0601B9B0 RID: 113072 RVA: 0x0087BA0E File Offset: 0x00879E0E
		public JsonData(double number)
		{
			this.type = JsonType.Double;
			this.inst_double = number;
		}

		// Token: 0x0601B9B1 RID: 113073 RVA: 0x0087BA24 File Offset: 0x00879E24
		public JsonData(int number)
		{
			this.type = JsonType.Int;
			this.inst_int = number;
		}

		// Token: 0x0601B9B2 RID: 113074 RVA: 0x0087BA3A File Offset: 0x00879E3A
		public JsonData(long number)
		{
			this.type = JsonType.Long;
			this.inst_long = number;
		}

		// Token: 0x0601B9B3 RID: 113075 RVA: 0x0087BA50 File Offset: 0x00879E50
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

		// Token: 0x0601B9B4 RID: 113076 RVA: 0x0087BB08 File Offset: 0x00879F08
		public JsonData(string str)
		{
			this.type = JsonType.String;
			this.inst_string = str;
		}

		// Token: 0x17002502 RID: 9474
		// (get) Token: 0x0601B9B5 RID: 113077 RVA: 0x0087BB1E File Offset: 0x00879F1E
		public int Count
		{
			get
			{
				return this.EnsureCollection().Count;
			}
		}

		// Token: 0x17002503 RID: 9475
		// (get) Token: 0x0601B9B6 RID: 113078 RVA: 0x0087BB2B File Offset: 0x00879F2B
		public bool IsArray
		{
			get
			{
				return this.type == JsonType.Array;
			}
		}

		// Token: 0x17002504 RID: 9476
		// (get) Token: 0x0601B9B7 RID: 113079 RVA: 0x0087BB36 File Offset: 0x00879F36
		public bool IsBoolean
		{
			get
			{
				return this.type == JsonType.Boolean;
			}
		}

		// Token: 0x17002505 RID: 9477
		// (get) Token: 0x0601B9B8 RID: 113080 RVA: 0x0087BB41 File Offset: 0x00879F41
		public bool IsDouble
		{
			get
			{
				return this.type == JsonType.Double;
			}
		}

		// Token: 0x17002506 RID: 9478
		// (get) Token: 0x0601B9B9 RID: 113081 RVA: 0x0087BB4C File Offset: 0x00879F4C
		public bool IsInt
		{
			get
			{
				return this.type == JsonType.Int;
			}
		}

		// Token: 0x17002507 RID: 9479
		// (get) Token: 0x0601B9BA RID: 113082 RVA: 0x0087BB57 File Offset: 0x00879F57
		public bool IsLong
		{
			get
			{
				return this.type == JsonType.Long;
			}
		}

		// Token: 0x17002508 RID: 9480
		// (get) Token: 0x0601B9BB RID: 113083 RVA: 0x0087BB62 File Offset: 0x00879F62
		public bool IsObject
		{
			get
			{
				return this.type == JsonType.Object;
			}
		}

		// Token: 0x17002509 RID: 9481
		// (get) Token: 0x0601B9BC RID: 113084 RVA: 0x0087BB6D File Offset: 0x00879F6D
		public bool IsString
		{
			get
			{
				return this.type == JsonType.String;
			}
		}

		// Token: 0x1700250A RID: 9482
		// (get) Token: 0x0601B9BD RID: 113085 RVA: 0x0087BB78 File Offset: 0x00879F78
		public ICollection<string> Keys
		{
			get
			{
				this.EnsureDictionary();
				return this.inst_object.Keys;
			}
		}

		// Token: 0x170024EF RID: 9455
		// (get) Token: 0x0601B9BE RID: 113086 RVA: 0x0087BB8C File Offset: 0x00879F8C
		int ICollection.Count
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x170024F0 RID: 9456
		// (get) Token: 0x0601B9BF RID: 113087 RVA: 0x0087BB94 File Offset: 0x00879F94
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.EnsureCollection().IsSynchronized;
			}
		}

		// Token: 0x170024F1 RID: 9457
		// (get) Token: 0x0601B9C0 RID: 113088 RVA: 0x0087BBA1 File Offset: 0x00879FA1
		object ICollection.SyncRoot
		{
			get
			{
				return this.EnsureCollection().SyncRoot;
			}
		}

		// Token: 0x170024F2 RID: 9458
		// (get) Token: 0x0601B9C1 RID: 113089 RVA: 0x0087BBAE File Offset: 0x00879FAE
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.EnsureDictionary().IsFixedSize;
			}
		}

		// Token: 0x170024F3 RID: 9459
		// (get) Token: 0x0601B9C2 RID: 113090 RVA: 0x0087BBBB File Offset: 0x00879FBB
		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.EnsureDictionary().IsReadOnly;
			}
		}

		// Token: 0x170024F4 RID: 9460
		// (get) Token: 0x0601B9C3 RID: 113091 RVA: 0x0087BBC8 File Offset: 0x00879FC8
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

		// Token: 0x170024F5 RID: 9461
		// (get) Token: 0x0601B9C4 RID: 113092 RVA: 0x0087BC3C File Offset: 0x0087A03C
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

		// Token: 0x170024F6 RID: 9462
		// (get) Token: 0x0601B9C5 RID: 113093 RVA: 0x0087BCB0 File Offset: 0x0087A0B0
		bool IJsonWrapper.IsArray
		{
			get
			{
				return this.IsArray;
			}
		}

		// Token: 0x170024F7 RID: 9463
		// (get) Token: 0x0601B9C6 RID: 113094 RVA: 0x0087BCB8 File Offset: 0x0087A0B8
		bool IJsonWrapper.IsBoolean
		{
			get
			{
				return this.IsBoolean;
			}
		}

		// Token: 0x170024F8 RID: 9464
		// (get) Token: 0x0601B9C7 RID: 113095 RVA: 0x0087BCC0 File Offset: 0x0087A0C0
		bool IJsonWrapper.IsDouble
		{
			get
			{
				return this.IsDouble;
			}
		}

		// Token: 0x170024F9 RID: 9465
		// (get) Token: 0x0601B9C8 RID: 113096 RVA: 0x0087BCC8 File Offset: 0x0087A0C8
		bool IJsonWrapper.IsInt
		{
			get
			{
				return this.IsInt;
			}
		}

		// Token: 0x170024FA RID: 9466
		// (get) Token: 0x0601B9C9 RID: 113097 RVA: 0x0087BCD0 File Offset: 0x0087A0D0
		bool IJsonWrapper.IsLong
		{
			get
			{
				return this.IsLong;
			}
		}

		// Token: 0x170024FB RID: 9467
		// (get) Token: 0x0601B9CA RID: 113098 RVA: 0x0087BCD8 File Offset: 0x0087A0D8
		bool IJsonWrapper.IsObject
		{
			get
			{
				return this.IsObject;
			}
		}

		// Token: 0x170024FC RID: 9468
		// (get) Token: 0x0601B9CB RID: 113099 RVA: 0x0087BCE0 File Offset: 0x0087A0E0
		bool IJsonWrapper.IsString
		{
			get
			{
				return this.IsString;
			}
		}

		// Token: 0x170024FD RID: 9469
		// (get) Token: 0x0601B9CC RID: 113100 RVA: 0x0087BCE8 File Offset: 0x0087A0E8
		bool IList.IsFixedSize
		{
			get
			{
				return this.EnsureList().IsFixedSize;
			}
		}

		// Token: 0x170024FE RID: 9470
		// (get) Token: 0x0601B9CD RID: 113101 RVA: 0x0087BCF5 File Offset: 0x0087A0F5
		bool IList.IsReadOnly
		{
			get
			{
				return this.EnsureList().IsReadOnly;
			}
		}

		// Token: 0x170024FF RID: 9471
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

		// Token: 0x17002500 RID: 9472
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

		// Token: 0x17002501 RID: 9473
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

		// Token: 0x1700250B RID: 9483
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

		// Token: 0x1700250C RID: 9484
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

		// Token: 0x0601B9D8 RID: 113112 RVA: 0x0087BF6D File Offset: 0x0087A36D
		public static implicit operator JsonData(bool data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601B9D9 RID: 113113 RVA: 0x0087BF75 File Offset: 0x0087A375
		public static implicit operator JsonData(double data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601B9DA RID: 113114 RVA: 0x0087BF7D File Offset: 0x0087A37D
		public static implicit operator JsonData(int data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601B9DB RID: 113115 RVA: 0x0087BF85 File Offset: 0x0087A385
		public static implicit operator JsonData(long data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601B9DC RID: 113116 RVA: 0x0087BF8D File Offset: 0x0087A38D
		public static implicit operator JsonData(string data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601B9DD RID: 113117 RVA: 0x0087BF95 File Offset: 0x0087A395
		public static explicit operator bool(JsonData data)
		{
			if (data.type != JsonType.Boolean)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_boolean;
		}

		// Token: 0x0601B9DE RID: 113118 RVA: 0x0087BFB4 File Offset: 0x0087A3B4
		public static explicit operator double(JsonData data)
		{
			if (data.type != JsonType.Double)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_double;
		}

		// Token: 0x0601B9DF RID: 113119 RVA: 0x0087BFD3 File Offset: 0x0087A3D3
		public static explicit operator int(JsonData data)
		{
			if (data.type != JsonType.Int)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.inst_int;
		}

		// Token: 0x0601B9E0 RID: 113120 RVA: 0x0087BFF2 File Offset: 0x0087A3F2
		public static explicit operator long(JsonData data)
		{
			if (data.type != JsonType.Long)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.inst_long;
		}

		// Token: 0x0601B9E1 RID: 113121 RVA: 0x0087C011 File Offset: 0x0087A411
		public static explicit operator string(JsonData data)
		{
			if (data.type != JsonType.String)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a string");
			}
			return data.inst_string;
		}

		// Token: 0x0601B9E2 RID: 113122 RVA: 0x0087C030 File Offset: 0x0087A430
		void ICollection.CopyTo(Array array, int index)
		{
			this.EnsureCollection().CopyTo(array, index);
		}

		// Token: 0x0601B9E3 RID: 113123 RVA: 0x0087C040 File Offset: 0x0087A440
		void IDictionary.Add(object key, object value)
		{
			JsonData value2 = this.ToJsonData(value);
			this.EnsureDictionary().Add(key, value2);
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>((string)key, value2);
			this.object_list.Add(item);
			this.json = null;
		}

		// Token: 0x0601B9E4 RID: 113124 RVA: 0x0087C083 File Offset: 0x0087A483
		void IDictionary.Clear()
		{
			this.EnsureDictionary().Clear();
			this.object_list.Clear();
			this.json = null;
		}

		// Token: 0x0601B9E5 RID: 113125 RVA: 0x0087C0A2 File Offset: 0x0087A4A2
		bool IDictionary.Contains(object key)
		{
			return this.EnsureDictionary().Contains(key);
		}

		// Token: 0x0601B9E6 RID: 113126 RVA: 0x0087C0B0 File Offset: 0x0087A4B0
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IOrderedDictionary)this).GetEnumerator();
		}

		// Token: 0x0601B9E7 RID: 113127 RVA: 0x0087C0B8 File Offset: 0x0087A4B8
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

		// Token: 0x0601B9E8 RID: 113128 RVA: 0x0087C129 File Offset: 0x0087A529
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.EnsureCollection().GetEnumerator();
		}

		// Token: 0x0601B9E9 RID: 113129 RVA: 0x0087C136 File Offset: 0x0087A536
		bool IJsonWrapper.GetBoolean()
		{
			if (this.type != JsonType.Boolean)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a boolean");
			}
			return this.inst_boolean;
		}

		// Token: 0x0601B9EA RID: 113130 RVA: 0x0087C155 File Offset: 0x0087A555
		double IJsonWrapper.GetDouble()
		{
			if (this.type != JsonType.Double)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a double");
			}
			return this.inst_double;
		}

		// Token: 0x0601B9EB RID: 113131 RVA: 0x0087C174 File Offset: 0x0087A574
		int IJsonWrapper.GetInt()
		{
			if (this.type != JsonType.Int)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return this.inst_int;
		}

		// Token: 0x0601B9EC RID: 113132 RVA: 0x0087C193 File Offset: 0x0087A593
		long IJsonWrapper.GetLong()
		{
			if (this.type != JsonType.Long)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return this.inst_long;
		}

		// Token: 0x0601B9ED RID: 113133 RVA: 0x0087C1B2 File Offset: 0x0087A5B2
		string IJsonWrapper.GetString()
		{
			if (this.type != JsonType.String)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a string");
			}
			return this.inst_string;
		}

		// Token: 0x0601B9EE RID: 113134 RVA: 0x0087C1D1 File Offset: 0x0087A5D1
		void IJsonWrapper.SetBoolean(bool val)
		{
			this.type = JsonType.Boolean;
			this.inst_boolean = val;
			this.json = null;
		}

		// Token: 0x0601B9EF RID: 113135 RVA: 0x0087C1E8 File Offset: 0x0087A5E8
		void IJsonWrapper.SetDouble(double val)
		{
			this.type = JsonType.Double;
			this.inst_double = val;
			this.json = null;
		}

		// Token: 0x0601B9F0 RID: 113136 RVA: 0x0087C1FF File Offset: 0x0087A5FF
		void IJsonWrapper.SetInt(int val)
		{
			this.type = JsonType.Int;
			this.inst_int = val;
			this.json = null;
		}

		// Token: 0x0601B9F1 RID: 113137 RVA: 0x0087C216 File Offset: 0x0087A616
		void IJsonWrapper.SetLong(long val)
		{
			this.type = JsonType.Long;
			this.inst_long = val;
			this.json = null;
		}

		// Token: 0x0601B9F2 RID: 113138 RVA: 0x0087C22D File Offset: 0x0087A62D
		void IJsonWrapper.SetString(string val)
		{
			this.type = JsonType.String;
			this.inst_string = val;
			this.json = null;
		}

		// Token: 0x0601B9F3 RID: 113139 RVA: 0x0087C244 File Offset: 0x0087A644
		string IJsonWrapper.ToJson()
		{
			return this.ToJson();
		}

		// Token: 0x0601B9F4 RID: 113140 RVA: 0x0087C24C File Offset: 0x0087A64C
		void IJsonWrapper.ToJson(JsonWriter writer)
		{
			this.ToJson(writer);
		}

		// Token: 0x0601B9F5 RID: 113141 RVA: 0x0087C255 File Offset: 0x0087A655
		int IList.Add(object value)
		{
			return this.Add(value);
		}

		// Token: 0x0601B9F6 RID: 113142 RVA: 0x0087C25E File Offset: 0x0087A65E
		void IList.Clear()
		{
			this.EnsureList().Clear();
			this.json = null;
		}

		// Token: 0x0601B9F7 RID: 113143 RVA: 0x0087C272 File Offset: 0x0087A672
		bool IList.Contains(object value)
		{
			return this.EnsureList().Contains(value);
		}

		// Token: 0x0601B9F8 RID: 113144 RVA: 0x0087C280 File Offset: 0x0087A680
		int IList.IndexOf(object value)
		{
			return this.EnsureList().IndexOf(value);
		}

		// Token: 0x0601B9F9 RID: 113145 RVA: 0x0087C28E File Offset: 0x0087A68E
		void IList.Insert(int index, object value)
		{
			this.EnsureList().Insert(index, value);
			this.json = null;
		}

		// Token: 0x0601B9FA RID: 113146 RVA: 0x0087C2A4 File Offset: 0x0087A6A4
		void IList.Remove(object value)
		{
			this.EnsureList().Remove(value);
			this.json = null;
		}

		// Token: 0x0601B9FB RID: 113147 RVA: 0x0087C2B9 File Offset: 0x0087A6B9
		void IList.RemoveAt(int index)
		{
			this.EnsureList().RemoveAt(index);
			this.json = null;
		}

		// Token: 0x0601B9FC RID: 113148 RVA: 0x0087C2CE File Offset: 0x0087A6CE
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			this.EnsureDictionary();
			return new OrderedDictionaryEnumerator(this.object_list.GetEnumerator());
		}

		// Token: 0x0601B9FD RID: 113149 RVA: 0x0087C2E8 File Offset: 0x0087A6E8
		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
			string text = (string)key;
			JsonData value2 = this.ToJsonData(value);
			this[text] = value2;
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>(text, value2);
			this.object_list.Insert(idx, item);
		}

		// Token: 0x0601B9FE RID: 113150 RVA: 0x0087C324 File Offset: 0x0087A724
		void IOrderedDictionary.RemoveAt(int idx)
		{
			this.EnsureDictionary();
			this.inst_object.Remove(this.object_list[idx].Key);
			this.object_list.RemoveAt(idx);
		}

		// Token: 0x0601B9FF RID: 113151 RVA: 0x0087C364 File Offset: 0x0087A764
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

		// Token: 0x0601BA00 RID: 113152 RVA: 0x0087C3A0 File Offset: 0x0087A7A0
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

		// Token: 0x0601BA01 RID: 113153 RVA: 0x0087C404 File Offset: 0x0087A804
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

		// Token: 0x0601BA02 RID: 113154 RVA: 0x0087C45C File Offset: 0x0087A85C
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

		// Token: 0x0601BA03 RID: 113155 RVA: 0x0087C480 File Offset: 0x0087A880
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

		// Token: 0x0601BA04 RID: 113156 RVA: 0x0087C608 File Offset: 0x0087AA08
		public int Add(object value)
		{
			JsonData value2 = this.ToJsonData(value);
			this.json = null;
			return this.EnsureList().Add(value2);
		}

		// Token: 0x0601BA05 RID: 113157 RVA: 0x0087C630 File Offset: 0x0087AA30
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

		// Token: 0x0601BA06 RID: 113158 RVA: 0x0087C658 File Offset: 0x0087AA58
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

		// Token: 0x0601BA07 RID: 113159 RVA: 0x0087C733 File Offset: 0x0087AB33
		public JsonType GetJsonType()
		{
			return this.type;
		}

		// Token: 0x0601BA08 RID: 113160 RVA: 0x0087C73C File Offset: 0x0087AB3C
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

		// Token: 0x0601BA09 RID: 113161 RVA: 0x0087C800 File Offset: 0x0087AC00
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

		// Token: 0x0601BA0A RID: 113162 RVA: 0x0087C84C File Offset: 0x0087AC4C
		public void ToJson(JsonWriter writer)
		{
			bool validate = writer.Validate;
			writer.Validate = false;
			JsonData.WriteJson(this, writer);
			writer.Validate = validate;
		}

		// Token: 0x0601BA0B RID: 113163 RVA: 0x0087C878 File Offset: 0x0087AC78
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

		// Token: 0x04013414 RID: 78868
		private IList<JsonData> inst_array;

		// Token: 0x04013415 RID: 78869
		private bool inst_boolean;

		// Token: 0x04013416 RID: 78870
		private double inst_double;

		// Token: 0x04013417 RID: 78871
		private int inst_int;

		// Token: 0x04013418 RID: 78872
		private long inst_long;

		// Token: 0x04013419 RID: 78873
		private IDictionary<string, JsonData> inst_object;

		// Token: 0x0401341A RID: 78874
		private string inst_string;

		// Token: 0x0401341B RID: 78875
		private string json;

		// Token: 0x0401341C RID: 78876
		private JsonType type;

		// Token: 0x0401341D RID: 78877
		private IList<KeyValuePair<string, JsonData>> object_list;
	}
}
