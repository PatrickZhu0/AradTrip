using System;

namespace behaviac
{
	// Token: 0x0200476A RID: 18282
	public class CInstanceProperty<T> : CInstanceMember<T>
	{
		// Token: 0x0601A488 RID: 107656 RVA: 0x008268CA File Offset: 0x00824CCA
		public CInstanceProperty(string instance, IInstanceMember indexMember, CProperty<T> prop) : base(instance, indexMember)
		{
			this._property = prop;
		}

		// Token: 0x0601A489 RID: 107657 RVA: 0x008268DC File Offset: 0x00824CDC
		public override T GetValue(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			if (this._indexMember != null)
			{
				int value = ((CInstanceMember<int>)this._indexMember).GetValue(self);
				return this._property.GetValue(parentAgent, value);
			}
			return this._property.GetValue(parentAgent);
		}

		// Token: 0x0601A48A RID: 107658 RVA: 0x00826930 File Offset: 0x00824D30
		public override void SetValue(Agent self, T value)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			if (this._indexMember != null)
			{
				int value2 = ((CInstanceMember<int>)this._indexMember).GetValue(self);
				this._property.SetValue(parentAgent, value, value2);
			}
			else
			{
				this._property.SetValue(parentAgent, value);
			}
		}

		// Token: 0x04012710 RID: 75536
		private CProperty<T> _property;
	}
}
