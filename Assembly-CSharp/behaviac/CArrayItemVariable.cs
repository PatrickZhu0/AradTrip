using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200477C RID: 18300
	public class CArrayItemVariable<T> : IInstantiatedVariable
	{
		// Token: 0x0601A4D8 RID: 107736 RVA: 0x00826CA0 File Offset: 0x008250A0
		public CArrayItemVariable(uint parentId, string name)
		{
			this._parentId = parentId;
			this._name = name;
		}

		// Token: 0x0601A4D9 RID: 107737 RVA: 0x00826CB8 File Offset: 0x008250B8
		public T GetValue(Agent self, int index)
		{
			IInstantiatedVariable instantiatedVariable = self.GetInstantiatedVariable(this._parentId);
			if (instantiatedVariable != null)
			{
				if (typeof(T).IsValueType)
				{
					CVariable<List<T>> cvariable = (CVariable<List<T>>)instantiatedVariable;
					if (cvariable != null)
					{
						return cvariable.GetValue(self)[index];
					}
				}
				return (T)((object)instantiatedVariable.GetValueObject(self, index));
			}
			return default(T);
		}

		// Token: 0x0601A4DA RID: 107738 RVA: 0x00826D1E File Offset: 0x0082511E
		public void SetValueFromString(Agent self, string valueStr)
		{
		}

		// Token: 0x0601A4DB RID: 107739 RVA: 0x00826D20 File Offset: 0x00825120
		public void SetValue(Agent self, T value, int index)
		{
			IInstantiatedVariable instantiatedVariable = self.GetInstantiatedVariable(this._parentId);
			CVariable<List<T>> cvariable = (CVariable<List<T>>)instantiatedVariable;
			if (cvariable != null)
			{
				cvariable.GetValue(self)[index] = value;
			}
		}

		// Token: 0x0601A4DC RID: 107740 RVA: 0x00826D55 File Offset: 0x00825155
		public object GetValueObject(Agent self)
		{
			return null;
		}

		// Token: 0x0601A4DD RID: 107741 RVA: 0x00826D58 File Offset: 0x00825158
		public object GetValueObject(Agent self, int index)
		{
			return this.GetValue(self, index);
		}

		// Token: 0x0601A4DE RID: 107742 RVA: 0x00826D67 File Offset: 0x00825167
		public void SetValue(Agent self, object value)
		{
		}

		// Token: 0x0601A4DF RID: 107743 RVA: 0x00826D69 File Offset: 0x00825169
		public void SetValue(Agent self, object value, int index)
		{
			this.SetValue(self, (T)((object)value), index);
		}

		// Token: 0x17002271 RID: 8817
		// (get) Token: 0x0601A4E0 RID: 107744 RVA: 0x00826D79 File Offset: 0x00825179
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x0601A4E1 RID: 107745 RVA: 0x00826D81 File Offset: 0x00825181
		public void Log(Agent self)
		{
		}

		// Token: 0x0601A4E2 RID: 107746 RVA: 0x00826D83 File Offset: 0x00825183
		public void CopyTo(Agent pAgent)
		{
		}

		// Token: 0x0601A4E3 RID: 107747 RVA: 0x00826D85 File Offset: 0x00825185
		public void Save(ISerializableNode node)
		{
		}

		// Token: 0x0601A4E4 RID: 107748 RVA: 0x00826D88 File Offset: 0x00825188
		public IInstantiatedVariable clone()
		{
			return new CArrayItemVariable<T>(this._parentId, this._name);
		}

		// Token: 0x0401271E RID: 75550
		private string _name;

		// Token: 0x0401271F RID: 75551
		private uint _parentId;
	}
}
