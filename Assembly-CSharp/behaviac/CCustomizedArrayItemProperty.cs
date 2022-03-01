using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200477A RID: 18298
	public class CCustomizedArrayItemProperty<T> : CProperty<T>, ICustomizedProperty, IProperty
	{
		// Token: 0x0601A4C6 RID: 107718 RVA: 0x00826AF0 File Offset: 0x00824EF0
		public CCustomizedArrayItemProperty(uint parentId, string parentName) : base(parentName)
		{
			this._parentId = parentId;
		}

		// Token: 0x0601A4C7 RID: 107719 RVA: 0x00826B00 File Offset: 0x00824F00
		public override T GetValue(Agent self, int index)
		{
			List<T> variable = self.GetVariable<List<T>>(this._parentId);
			if (variable != null)
			{
				return variable[index];
			}
			return default(T);
		}

		// Token: 0x0601A4C8 RID: 107720 RVA: 0x00826B34 File Offset: 0x00824F34
		public override void SetValue(Agent self, T value, int index)
		{
			List<T> variable = self.GetVariable<List<T>>(this._parentId);
			if (variable != null)
			{
				variable[index] = value;
			}
		}

		// Token: 0x0601A4C9 RID: 107721 RVA: 0x00826B5C File Offset: 0x00824F5C
		public IInstantiatedVariable Instantiate()
		{
			return new CArrayItemVariable<T>(this._parentId, base.Name);
		}

		// Token: 0x0401271B RID: 75547
		private uint _parentId;
	}
}
