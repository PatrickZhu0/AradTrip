using System;

namespace GameClient
{
	// Token: 0x02001280 RID: 4736
	public class EnterGameMessageHandleAttribute : Attribute
	{
		// Token: 0x0600B64A RID: 46666 RVA: 0x002921E1 File Offset: 0x002905E1
		public EnterGameMessageHandleAttribute(uint a_id, int a_nOrder = 0)
		{
			this.id = a_id;
			this.order = a_nOrder;
		}

		// Token: 0x0400670C RID: 26380
		public uint id;

		// Token: 0x0400670D RID: 26381
		public int order;
	}
}
