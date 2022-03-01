using System;

namespace behaviac
{
	// Token: 0x0200477D RID: 18301
	public class CInstanceCustomizedProperty<T> : CInstanceMember<T>
	{
		// Token: 0x0601A4E5 RID: 107749 RVA: 0x00826DA8 File Offset: 0x008251A8
		public CInstanceCustomizedProperty(string instance, IInstanceMember indexMember, uint id) : base(instance, indexMember)
		{
			this._id = id;
		}

		// Token: 0x0601A4E6 RID: 107750 RVA: 0x00826DBC File Offset: 0x008251BC
		public override T GetValue(Agent self)
		{
			if (self == null)
			{
				return default(T);
			}
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			if (this._indexMember != null)
			{
				int value = ((CInstanceMember<int>)this._indexMember).GetValue(self);
				return parentAgent.GetVariable<T>(this._id, value);
			}
			return parentAgent.GetVariable<T>(this._id);
		}

		// Token: 0x0601A4E7 RID: 107751 RVA: 0x00826E20 File Offset: 0x00825220
		public override void SetValue(Agent self, T value)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			if (this._indexMember != null)
			{
				int value2 = ((CInstanceMember<int>)this._indexMember).GetValue(self);
				parentAgent.SetVariable<T>(string.Empty, this._id, value, value2);
			}
			else
			{
				parentAgent.SetVariable<T>(string.Empty, this._id, value);
			}
		}

		// Token: 0x04012720 RID: 75552
		private uint _id;
	}
}
