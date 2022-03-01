using System;

namespace behaviac
{
	// Token: 0x02004830 RID: 18480
	public interface ISerializableNode
	{
		// Token: 0x0601A8E1 RID: 108769
		ISerializableNode newChild(CSerializationID chidlId);

		// Token: 0x0601A8E2 RID: 108770
		void setAttr(CSerializationID attrId, string value);

		// Token: 0x0601A8E3 RID: 108771
		void setAttr<VariableType>(CSerializationID attrId, VariableType value);
	}
}
