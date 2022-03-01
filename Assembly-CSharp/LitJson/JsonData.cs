using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace LitJson
{
	// Token: 0x0200469A RID: 18074
	public class JsonData : IJsonWrapper, IEquatable<JsonData>, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x060198DA RID: 104666 RVA: 0x0080DCBC File Offset: 0x0080C0BC
		public JsonData()
		{
		}

		// Token: 0x060198DB RID: 104667 RVA: 0x0080DCC4 File Offset: 0x0080C0C4
		public JsonData(bool boolean)
		{
			this.type = JsonType.Boolean;
			this.inst_boolean = boolean;
		}

		// Token: 0x060198DC RID: 104668 RVA: 0x0080DCDA File Offset: 0x0080C0DA
		public JsonData(double number)
		{
			this.type = JsonType.Double;
			this.inst_double = number;
		}

		// Token: 0x060198DD RID: 104669 RVA: 0x0080DCF0 File Offset: 0x0080C0F0
		public JsonData(int number)
		{
			this.type = JsonType.Int;
			this.inst_int = number;
		}

		// Token: 0x060198DE RID: 104670 RVA: 0x0080DD06 File Offset: 0x0080C106
		public JsonData(long number)
		{
			this.type = JsonType.Long;
			this.inst_long = number;
		}

		// Token: 0x060198DF RID: 104671 RVA: 0x0080DD1C File Offset: 0x0080C11C
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

		// Token: 0x060198E0 RID: 104672 RVA: 0x0080DDD4 File Offset: 0x0080C1D4
		public JsonData(string str)
		{
			this.type = JsonType.String;
			this.inst_string = str;
		}

		// Token: 0x170020F8 RID: 8440
		// (get) Token: 0x060198E1 RID: 104673 RVA: 0x0080DDEA File Offset: 0x0080C1EA
		public int Count
		{
			get
			{
				return this.EnsureCollection().Count;
			}
		}

		// Token: 0x170020F9 RID: 8441
		// (get) Token: 0x060198E2 RID: 104674 RVA: 0x0080DDF7 File Offset: 0x0080C1F7
		public bool IsArray
		{
			get
			{
				return this.type == JsonType.Array;
			}
		}

		// Token: 0x170020FA RID: 8442
		// (get) Token: 0x060198E3 RID: 104675 RVA: 0x0080DE02 File Offset: 0x0080C202
		public bool IsBoolean
		{
			get
			{
				return this.type == JsonType.Boolean;
			}
		}

		// Token: 0x170020FB RID: 8443
		// (get) Token: 0x060198E4 RID: 104676 RVA: 0x0080DE0D File Offset: 0x0080C20D
		public bool IsDouble
		{
			get
			{
				return this.type == JsonType.Double;
			}
		}

		// Token: 0x170020FC RID: 8444
		// (get) Token: 0x060198E5 RID: 104677 RVA: 0x0080DE18 File Offset: 0x0080C218
		public bool IsInt
		{
			get
			{
				return this.type == JsonType.Int;
			}
		}

		// Token: 0x170020FD RID: 8445
		// (get) Token: 0x060198E6 RID: 104678 RVA: 0x0080DE23 File Offset: 0x0080C223
		public bool IsLong
		{
			get
			{
				return this.type == JsonType.Long;
			}
		}

		// Token: 0x170020FE RID: 8446
		// (get) Token: 0x060198E7 RID: 104679 RVA: 0x0080DE2E File Offset: 0x0080C22E
		public bool IsObject
		{
			get
			{
				return this.type == JsonType.Object;
			}
		}

		// Token: 0x170020FF RID: 8447
		// (get) Token: 0x060198E8 RID: 104680 RVA: 0x0080DE39 File Offset: 0x0080C239
		public bool IsString
		{
			get
			{
				return this.type == JsonType.String;
			}
		}

		// Token: 0x17002100 RID: 8448
		// (get) Token: 0x060198E9 RID: 104681 RVA: 0x0080DE44 File Offset: 0x0080C244
		public ICollection<string> Keys
		{
			get
			{
				this.EnsureDictionary();
				return this.inst_object.Keys;
			}
		}

		// Token: 0x060198EA RID: 104682 RVA: 0x0080DE58 File Offset: 0x0080C258
		public bool ContainsKey(string key)
		{
			this.EnsureDictionary();
			return this.inst_object.Keys.Contains(key);
		}

		// Token: 0x170020E5 RID: 8421
		// (get) Token: 0x060198EB RID: 104683 RVA: 0x0080DE72 File Offset: 0x0080C272
		int ICollection.Count
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x170020E6 RID: 8422
		// (get) Token: 0x060198EC RID: 104684 RVA: 0x0080DE7A File Offset: 0x0080C27A
		bool ICollection.IsSynchronized
		{
			get
			{
				return this.EnsureCollection().IsSynchronized;
			}
		}

		// Token: 0x170020E7 RID: 8423
		// (get) Token: 0x060198ED RID: 104685 RVA: 0x0080DE87 File Offset: 0x0080C287
		object ICollection.SyncRoot
		{
			get
			{
				return this.EnsureCollection().SyncRoot;
			}
		}

		// Token: 0x170020E8 RID: 8424
		// (get) Token: 0x060198EE RID: 104686 RVA: 0x0080DE94 File Offset: 0x0080C294
		bool IDictionary.IsFixedSize
		{
			get
			{
				return this.EnsureDictionary().IsFixedSize;
			}
		}

		// Token: 0x170020E9 RID: 8425
		// (get) Token: 0x060198EF RID: 104687 RVA: 0x0080DEA1 File Offset: 0x0080C2A1
		bool IDictionary.IsReadOnly
		{
			get
			{
				return this.EnsureDictionary().IsReadOnly;
			}
		}

		// Token: 0x170020EA RID: 8426
		// (get) Token: 0x060198F0 RID: 104688 RVA: 0x0080DEB0 File Offset: 0x0080C2B0
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

		// Token: 0x170020EB RID: 8427
		// (get) Token: 0x060198F1 RID: 104689 RVA: 0x0080DF24 File Offset: 0x0080C324
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

		// Token: 0x170020EC RID: 8428
		// (get) Token: 0x060198F2 RID: 104690 RVA: 0x0080DF98 File Offset: 0x0080C398
		bool IJsonWrapper.IsArray
		{
			get
			{
				return this.IsArray;
			}
		}

		// Token: 0x170020ED RID: 8429
		// (get) Token: 0x060198F3 RID: 104691 RVA: 0x0080DFA0 File Offset: 0x0080C3A0
		bool IJsonWrapper.IsBoolean
		{
			get
			{
				return this.IsBoolean;
			}
		}

		// Token: 0x170020EE RID: 8430
		// (get) Token: 0x060198F4 RID: 104692 RVA: 0x0080DFA8 File Offset: 0x0080C3A8
		bool IJsonWrapper.IsDouble
		{
			get
			{
				return this.IsDouble;
			}
		}

		// Token: 0x170020EF RID: 8431
		// (get) Token: 0x060198F5 RID: 104693 RVA: 0x0080DFB0 File Offset: 0x0080C3B0
		bool IJsonWrapper.IsInt
		{
			get
			{
				return this.IsInt;
			}
		}

		// Token: 0x170020F0 RID: 8432
		// (get) Token: 0x060198F6 RID: 104694 RVA: 0x0080DFB8 File Offset: 0x0080C3B8
		bool IJsonWrapper.IsLong
		{
			get
			{
				return this.IsLong;
			}
		}

		// Token: 0x170020F1 RID: 8433
		// (get) Token: 0x060198F7 RID: 104695 RVA: 0x0080DFC0 File Offset: 0x0080C3C0
		bool IJsonWrapper.IsObject
		{
			get
			{
				return this.IsObject;
			}
		}

		// Token: 0x170020F2 RID: 8434
		// (get) Token: 0x060198F8 RID: 104696 RVA: 0x0080DFC8 File Offset: 0x0080C3C8
		bool IJsonWrapper.IsString
		{
			get
			{
				return this.IsString;
			}
		}

		// Token: 0x170020F3 RID: 8435
		// (get) Token: 0x060198F9 RID: 104697 RVA: 0x0080DFD0 File Offset: 0x0080C3D0
		bool IList.IsFixedSize
		{
			get
			{
				return this.EnsureList().IsFixedSize;
			}
		}

		// Token: 0x170020F4 RID: 8436
		// (get) Token: 0x060198FA RID: 104698 RVA: 0x0080DFDD File Offset: 0x0080C3DD
		bool IList.IsReadOnly
		{
			get
			{
				return this.EnsureList().IsReadOnly;
			}
		}

		// Token: 0x170020F5 RID: 8437
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

		// Token: 0x170020F6 RID: 8438
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

		// Token: 0x170020F7 RID: 8439
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

		// Token: 0x17002101 RID: 8449
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

		// Token: 0x17002102 RID: 8450
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

		// Token: 0x06019905 RID: 104709 RVA: 0x0080E255 File Offset: 0x0080C655
		public static implicit operator JsonData(bool data)
		{
			return new JsonData(data);
		}

		// Token: 0x06019906 RID: 104710 RVA: 0x0080E25D File Offset: 0x0080C65D
		public static implicit operator JsonData(double data)
		{
			return new JsonData(data);
		}

		// Token: 0x06019907 RID: 104711 RVA: 0x0080E265 File Offset: 0x0080C665
		public static implicit operator JsonData(int data)
		{
			return new JsonData(data);
		}

		// Token: 0x06019908 RID: 104712 RVA: 0x0080E26D File Offset: 0x0080C66D
		public static implicit operator JsonData(long data)
		{
			return new JsonData(data);
		}

		// Token: 0x06019909 RID: 104713 RVA: 0x0080E275 File Offset: 0x0080C675
		public static implicit operator JsonData(string data)
		{
			return new JsonData(data);
		}

		// Token: 0x0601990A RID: 104714 RVA: 0x0080E27D File Offset: 0x0080C67D
		public static explicit operator bool(JsonData data)
		{
			if (data.type != JsonType.Boolean)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_boolean;
		}

		// Token: 0x0601990B RID: 104715 RVA: 0x0080E29C File Offset: 0x0080C69C
		public static explicit operator double(JsonData data)
		{
			if (data.type != JsonType.Double)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_double;
		}

		// Token: 0x0601990C RID: 104716 RVA: 0x0080E2BB File Offset: 0x0080C6BB
		public static explicit operator int(JsonData data)
		{
			if (data.type != JsonType.Int)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.inst_int;
		}

		// Token: 0x0601990D RID: 104717 RVA: 0x0080E2DA File Offset: 0x0080C6DA
		public static explicit operator long(JsonData data)
		{
			if (data.type != JsonType.Long)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return data.inst_long;
		}

		// Token: 0x0601990E RID: 104718 RVA: 0x0080E2F9 File Offset: 0x0080C6F9
		public static explicit operator string(JsonData data)
		{
			if (data.type != JsonType.String)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a string");
			}
			return data.inst_string;
		}

		// Token: 0x0601990F RID: 104719 RVA: 0x0080E318 File Offset: 0x0080C718
		void ICollection.CopyTo(Array array, int index)
		{
			this.EnsureCollection().CopyTo(array, index);
		}

		// Token: 0x06019910 RID: 104720 RVA: 0x0080E328 File Offset: 0x0080C728
		void IDictionary.Add(object key, object value)
		{
			JsonData value2 = this.ToJsonData(value);
			this.EnsureDictionary().Add(key, value2);
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>((string)key, value2);
			this.object_list.Add(item);
			this.json = null;
		}

		// Token: 0x06019911 RID: 104721 RVA: 0x0080E36B File Offset: 0x0080C76B
		void IDictionary.Clear()
		{
			this.EnsureDictionary().Clear();
			this.object_list.Clear();
			this.json = null;
		}

		// Token: 0x06019912 RID: 104722 RVA: 0x0080E38A File Offset: 0x0080C78A
		bool IDictionary.Contains(object key)
		{
			return this.EnsureDictionary().Contains(key);
		}

		// Token: 0x06019913 RID: 104723 RVA: 0x0080E398 File Offset: 0x0080C798
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IOrderedDictionary)this).GetEnumerator();
		}

		// Token: 0x06019914 RID: 104724 RVA: 0x0080E3A0 File Offset: 0x0080C7A0
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

		// Token: 0x06019915 RID: 104725 RVA: 0x0080E411 File Offset: 0x0080C811
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.EnsureCollection().GetEnumerator();
		}

		// Token: 0x06019916 RID: 104726 RVA: 0x0080E41E File Offset: 0x0080C81E
		bool IJsonWrapper.GetBoolean()
		{
			if (this.type != JsonType.Boolean)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a boolean");
			}
			return this.inst_boolean;
		}

		// Token: 0x06019917 RID: 104727 RVA: 0x0080E43D File Offset: 0x0080C83D
		double IJsonWrapper.GetDouble()
		{
			if (this.type != JsonType.Double)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a double");
			}
			return this.inst_double;
		}

		// Token: 0x06019918 RID: 104728 RVA: 0x0080E45C File Offset: 0x0080C85C
		int IJsonWrapper.GetInt()
		{
			if (this.type != JsonType.Int)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return this.inst_int;
		}

		// Token: 0x06019919 RID: 104729 RVA: 0x0080E47B File Offset: 0x0080C87B
		long IJsonWrapper.GetLong()
		{
			if (this.type != JsonType.Long)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return this.inst_long;
		}

		// Token: 0x0601991A RID: 104730 RVA: 0x0080E49A File Offset: 0x0080C89A
		string IJsonWrapper.GetString()
		{
			if (this.type != JsonType.String)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a string");
			}
			return this.inst_string;
		}

		// Token: 0x0601991B RID: 104731 RVA: 0x0080E4B9 File Offset: 0x0080C8B9
		void IJsonWrapper.SetBoolean(bool val)
		{
			this.type = JsonType.Boolean;
			this.inst_boolean = val;
			this.json = null;
		}

		// Token: 0x0601991C RID: 104732 RVA: 0x0080E4D0 File Offset: 0x0080C8D0
		void IJsonWrapper.SetDouble(double val)
		{
			this.type = JsonType.Double;
			this.inst_double = val;
			this.json = null;
		}

		// Token: 0x0601991D RID: 104733 RVA: 0x0080E4E7 File Offset: 0x0080C8E7
		void IJsonWrapper.SetInt(int val)
		{
			this.type = JsonType.Int;
			this.inst_int = val;
			this.json = null;
		}

		// Token: 0x0601991E RID: 104734 RVA: 0x0080E4FE File Offset: 0x0080C8FE
		void IJsonWrapper.SetLong(long val)
		{
			this.type = JsonType.Long;
			this.inst_long = val;
			this.json = null;
		}

		// Token: 0x0601991F RID: 104735 RVA: 0x0080E515 File Offset: 0x0080C915
		void IJsonWrapper.SetString(string val)
		{
			this.type = JsonType.String;
			this.inst_string = val;
			this.json = null;
		}

		// Token: 0x06019920 RID: 104736 RVA: 0x0080E52C File Offset: 0x0080C92C
		string IJsonWrapper.ToJson()
		{
			return this.ToJson();
		}

		// Token: 0x06019921 RID: 104737 RVA: 0x0080E534 File Offset: 0x0080C934
		void IJsonWrapper.ToJson(JsonWriter writer)
		{
			this.ToJson(writer);
		}

		// Token: 0x06019922 RID: 104738 RVA: 0x0080E53D File Offset: 0x0080C93D
		int IList.Add(object value)
		{
			return this.Add(value);
		}

		// Token: 0x06019923 RID: 104739 RVA: 0x0080E546 File Offset: 0x0080C946
		void IList.Clear()
		{
			this.EnsureList().Clear();
			this.json = null;
		}

		// Token: 0x06019924 RID: 104740 RVA: 0x0080E55A File Offset: 0x0080C95A
		bool IList.Contains(object value)
		{
			return this.EnsureList().Contains(value);
		}

		// Token: 0x06019925 RID: 104741 RVA: 0x0080E568 File Offset: 0x0080C968
		int IList.IndexOf(object value)
		{
			return this.EnsureList().IndexOf(value);
		}

		// Token: 0x06019926 RID: 104742 RVA: 0x0080E576 File Offset: 0x0080C976
		void IList.Insert(int index, object value)
		{
			this.EnsureList().Insert(index, value);
			this.json = null;
		}

		// Token: 0x06019927 RID: 104743 RVA: 0x0080E58C File Offset: 0x0080C98C
		void IList.Remove(object value)
		{
			this.EnsureList().Remove(value);
			this.json = null;
		}

		// Token: 0x06019928 RID: 104744 RVA: 0x0080E5A1 File Offset: 0x0080C9A1
		void IList.RemoveAt(int index)
		{
			this.EnsureList().RemoveAt(index);
			this.json = null;
		}

		// Token: 0x06019929 RID: 104745 RVA: 0x0080E5B6 File Offset: 0x0080C9B6
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			this.EnsureDictionary();
			return new OrderedDictionaryEnumerator(this.object_list.GetEnumerator());
		}

		// Token: 0x0601992A RID: 104746 RVA: 0x0080E5D0 File Offset: 0x0080C9D0
		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
			string text = (string)key;
			JsonData value2 = this.ToJsonData(value);
			this[text] = value2;
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>(text, value2);
			this.object_list.Insert(idx, item);
		}

		// Token: 0x0601992B RID: 104747 RVA: 0x0080E60C File Offset: 0x0080CA0C
		void IOrderedDictionary.RemoveAt(int idx)
		{
			this.EnsureDictionary();
			this.inst_object.Remove(this.object_list[idx].Key);
			this.object_list.RemoveAt(idx);
		}

		// Token: 0x0601992C RID: 104748 RVA: 0x0080E64C File Offset: 0x0080CA4C
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

		// Token: 0x0601992D RID: 104749 RVA: 0x0080E688 File Offset: 0x0080CA88
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

		// Token: 0x0601992E RID: 104750 RVA: 0x0080E6EC File Offset: 0x0080CAEC
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

		// Token: 0x0601992F RID: 104751 RVA: 0x0080E744 File Offset: 0x0080CB44
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

		// Token: 0x06019930 RID: 104752 RVA: 0x0080E768 File Offset: 0x0080CB68
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

		// Token: 0x06019931 RID: 104753 RVA: 0x0080E8F0 File Offset: 0x0080CCF0
		public int Add(object value)
		{
			JsonData value2 = this.ToJsonData(value);
			this.json = null;
			return this.EnsureList().Add(value2);
		}

		// Token: 0x06019932 RID: 104754 RVA: 0x0080E918 File Offset: 0x0080CD18
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

		// Token: 0x06019933 RID: 104755 RVA: 0x0080E940 File Offset: 0x0080CD40
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

		// Token: 0x06019934 RID: 104756 RVA: 0x0080EA1B File Offset: 0x0080CE1B
		public JsonType GetJsonType()
		{
			return this.type;
		}

		// Token: 0x06019935 RID: 104757 RVA: 0x0080EA24 File Offset: 0x0080CE24
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

		// Token: 0x06019936 RID: 104758 RVA: 0x0080EAE8 File Offset: 0x0080CEE8
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

		// Token: 0x06019937 RID: 104759 RVA: 0x0080EB34 File Offset: 0x0080CF34
		public void ToJson(JsonWriter writer)
		{
			bool validate = writer.Validate;
			writer.Validate = false;
			JsonData.WriteJson(this, writer);
			writer.Validate = validate;
		}

		// Token: 0x06019938 RID: 104760 RVA: 0x0080EB60 File Offset: 0x0080CF60
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

		// Token: 0x040123AE RID: 74670
		private IList<JsonData> inst_array;

		// Token: 0x040123AF RID: 74671
		private bool inst_boolean;

		// Token: 0x040123B0 RID: 74672
		private double inst_double;

		// Token: 0x040123B1 RID: 74673
		private int inst_int;

		// Token: 0x040123B2 RID: 74674
		private long inst_long;

		// Token: 0x040123B3 RID: 74675
		private IDictionary<string, JsonData> inst_object;

		// Token: 0x040123B4 RID: 74676
		private string inst_string;

		// Token: 0x040123B5 RID: 74677
		private string json;

		// Token: 0x040123B6 RID: 74678
		private JsonType type;

		// Token: 0x040123B7 RID: 74679
		private IList<KeyValuePair<string, JsonData>> object_list;
	}
}
