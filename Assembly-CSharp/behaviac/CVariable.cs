using System;
using System.Collections;

namespace behaviac
{
	// Token: 0x0200477B RID: 18299
	public class CVariable<T> : IInstantiatedVariable
	{
		// Token: 0x0601A4CA RID: 107722 RVA: 0x00826B6F File Offset: 0x00824F6F
		public CVariable(string name, T value)
		{
			Utils.Clone<T>(ref this._value, value);
			this._name = name;
		}

		// Token: 0x0601A4CB RID: 107723 RVA: 0x00826B8A File Offset: 0x00824F8A
		public CVariable(string name, string valueStr)
		{
			ValueConverter<T>.Convert(valueStr, out this._value);
			this._name = name;
		}

		// Token: 0x0601A4CC RID: 107724 RVA: 0x00826BA6 File Offset: 0x00824FA6
		public T GetValue(Agent self)
		{
			return this._value;
		}

		// Token: 0x0601A4CD RID: 107725 RVA: 0x00826BAE File Offset: 0x00824FAE
		public object GetValueObject(Agent self)
		{
			return this._value;
		}

		// Token: 0x0601A4CE RID: 107726 RVA: 0x00826BBC File Offset: 0x00824FBC
		public object GetValueObject(Agent self, int index)
		{
			IList list = this._value as IList;
			return (list == null) ? this._value : list[index];
		}

		// Token: 0x0601A4CF RID: 107727 RVA: 0x00826BF7 File Offset: 0x00824FF7
		public void SetValueFromString(Agent self, string valueStr)
		{
			ValueConverter<T>.Convert(valueStr, out this._value);
		}

		// Token: 0x0601A4D0 RID: 107728 RVA: 0x00826C06 File Offset: 0x00825006
		public void SetValue(Agent self, T value)
		{
			this._value = value;
		}

		// Token: 0x0601A4D1 RID: 107729 RVA: 0x00826C0F File Offset: 0x0082500F
		public void SetValue(Agent self, object value)
		{
			this.SetValue(self, (T)((object)value));
		}

		// Token: 0x0601A4D2 RID: 107730 RVA: 0x00826C1E File Offset: 0x0082501E
		public void SetValue(Agent self, object value, int index)
		{
		}

		// Token: 0x17002270 RID: 8816
		// (get) Token: 0x0601A4D3 RID: 107731 RVA: 0x00826C20 File Offset: 0x00825020
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x0601A4D4 RID: 107732 RVA: 0x00826C28 File Offset: 0x00825028
		public void Log(Agent self)
		{
		}

		// Token: 0x0601A4D5 RID: 107733 RVA: 0x00826C2A File Offset: 0x0082502A
		public void CopyTo(Agent pAgent)
		{
		}

		// Token: 0x0601A4D6 RID: 107734 RVA: 0x00826C2C File Offset: 0x0082502C
		public void Save(ISerializableNode node)
		{
			CSerializationID chidlId = new CSerializationID("var");
			ISerializableNode serializableNode = node.newChild(chidlId);
			CSerializationID attrId = new CSerializationID("name");
			serializableNode.setAttr(attrId, this._name);
			CSerializationID attrId2 = new CSerializationID("value");
			serializableNode.setAttr<T>(attrId2, this._value);
		}

		// Token: 0x0601A4D7 RID: 107735 RVA: 0x00826C80 File Offset: 0x00825080
		public IInstantiatedVariable clone()
		{
			return new CVariable<T>(this._name, this._value);
		}

		// Token: 0x0401271C RID: 75548
		private T _value;

		// Token: 0x0401271D RID: 75549
		private string _name;
	}
}
