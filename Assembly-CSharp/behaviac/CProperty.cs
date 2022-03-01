using System;

namespace behaviac
{
	// Token: 0x02004769 RID: 18281
	public class CProperty<T> : IProperty
	{
		// Token: 0x0601A47C RID: 107644 RVA: 0x008267FA File Offset: 0x00824BFA
		public CProperty(string name)
		{
			this._name = name;
		}

		// Token: 0x1700226E RID: 8814
		// (get) Token: 0x0601A47D RID: 107645 RVA: 0x00826809 File Offset: 0x00824C09
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x0601A47E RID: 107646 RVA: 0x00826811 File Offset: 0x00824C11
		public IInstanceMember CreateInstance(string instance, IInstanceMember indexMember)
		{
			return new CInstanceProperty<T>(instance, indexMember, this);
		}

		// Token: 0x0601A47F RID: 107647 RVA: 0x0082681C File Offset: 0x00824C1C
		public IValue CreateIValue()
		{
			return new TValue<T>(default(T));
		}

		// Token: 0x0601A480 RID: 107648 RVA: 0x00826837 File Offset: 0x00824C37
		public object GetValueObject(Agent self)
		{
			return this.GetValue(self);
		}

		// Token: 0x0601A481 RID: 107649 RVA: 0x00826845 File Offset: 0x00824C45
		public object GetValueObject(Agent self, int index)
		{
			return this.GetValue(self, index);
		}

		// Token: 0x0601A482 RID: 107650 RVA: 0x00826854 File Offset: 0x00824C54
		public void SetValueFromString(Agent self, string valueStr)
		{
			T value;
			ValueConverter<T>.Convert(valueStr, out value);
			this.SetValue(self, value);
		}

		// Token: 0x0601A483 RID: 107651 RVA: 0x00826874 File Offset: 0x00824C74
		public void SetValue(Agent self, IInstanceMember right)
		{
			T value = ((CInstanceMember<T>)right).GetValue(self);
			this.SetValue(self, value);
		}

		// Token: 0x0601A484 RID: 107652 RVA: 0x00826896 File Offset: 0x00824C96
		public virtual void SetValue(Agent self, T value)
		{
		}

		// Token: 0x0601A485 RID: 107653 RVA: 0x00826898 File Offset: 0x00824C98
		public virtual void SetValue(Agent self, T value, int index)
		{
		}

		// Token: 0x0601A486 RID: 107654 RVA: 0x0082689C File Offset: 0x00824C9C
		public virtual T GetValue(Agent self)
		{
			return default(T);
		}

		// Token: 0x0601A487 RID: 107655 RVA: 0x008268B4 File Offset: 0x00824CB4
		public virtual T GetValue(Agent self, int index)
		{
			return default(T);
		}

		// Token: 0x0401270F RID: 75535
		private string _name;
	}
}
