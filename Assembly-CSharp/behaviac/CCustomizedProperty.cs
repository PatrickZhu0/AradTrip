using System;

namespace behaviac
{
	// Token: 0x02004779 RID: 18297
	public class CCustomizedProperty<T> : CProperty<T>, ICustomizedProperty, IProperty
	{
		// Token: 0x0601A4C2 RID: 107714 RVA: 0x00826A57 File Offset: 0x00824E57
		public CCustomizedProperty(uint id, string name, string valueStr) : base(name)
		{
			this._id = id;
			ValueConverter<T>.Convert(valueStr, out this._defaultValue);
		}

		// Token: 0x0601A4C3 RID: 107715 RVA: 0x00826A74 File Offset: 0x00824E74
		public override T GetValue(Agent self)
		{
			T result;
			if (self != null && self.GetVarValue<T>(this._id, out result))
			{
				return result;
			}
			return this._defaultValue;
		}

		// Token: 0x0601A4C4 RID: 107716 RVA: 0x00826AA4 File Offset: 0x00824EA4
		public override void SetValue(Agent self, T value)
		{
			bool flag = self.SetVarValue<T>(this._id, value);
		}

		// Token: 0x0601A4C5 RID: 107717 RVA: 0x00826AC0 File Offset: 0x00824EC0
		public IInstantiatedVariable Instantiate()
		{
			T value = default(T);
			Utils.Clone<T>(ref value, this._defaultValue);
			return new CVariable<T>(base.Name, value);
		}

		// Token: 0x04012719 RID: 75545
		private uint _id;

		// Token: 0x0401271A RID: 75546
		private T _defaultValue;
	}
}
