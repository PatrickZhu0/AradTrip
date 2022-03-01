using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CE4 RID: 3300
[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
	// Token: 0x06008754 RID: 34644 RVA: 0x0017DB64 File Offset: 0x0017BF64
	public void OnBeforeSerialize()
	{
		this.keys.Clear();
		this.values.Clear();
		foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
		{
			this.keys.Add(keyValuePair.Key);
			this.values.Add(keyValuePair.Value);
		}
	}

	// Token: 0x06008755 RID: 34645 RVA: 0x0017DBF0 File Offset: 0x0017BFF0
	public void OnAfterDeserialize()
	{
		base.Clear();
		if (this.keys.Count != this.values.Count)
		{
			throw new Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable.", this.keys.Count, this.values.Count));
		}
		for (int i = 0; i < this.keys.Count; i++)
		{
			base.Add(this.keys[i], this.values[i]);
		}
	}

	// Token: 0x06008756 RID: 34646 RVA: 0x0017DC88 File Offset: 0x0017C088
	public TKey GetKey(int index)
	{
		return this.keys[index];
	}

	// Token: 0x06008757 RID: 34647 RVA: 0x0017DC96 File Offset: 0x0017C096
	public TValue GetValue(int index)
	{
		return this.values[index];
	}

	// Token: 0x04004119 RID: 16665
	[SerializeField]
	[HideInInspector]
	private List<TKey> keys = new List<TKey>();

	// Token: 0x0400411A RID: 16666
	[SerializeField]
	[HideInInspector]
	private List<TValue> values = new List<TValue>();
}
