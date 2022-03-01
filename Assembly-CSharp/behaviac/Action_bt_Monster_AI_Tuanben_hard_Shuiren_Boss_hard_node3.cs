using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003D92 RID: 15762
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node3 : Action
	{
		// Token: 0x060162B9 RID: 90809 RVA: 0x006B34E4 File Offset: 0x006B18E4
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80700011;
			this.method_p1 = new List<int>();
			this.method_p1.Capacity = 3;
			int item = 8000;
			this.method_p1.Add(item);
			int item2 = -3000;
			this.method_p1.Add(item2);
			int item3 = 5000;
			this.method_p1.Add(item3);
			this.method_p2 = true;
			this.method_p3 = 60;
		}

		// Token: 0x060162BA RID: 90810 RVA: 0x006B3565 File Offset: 0x006B1965
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_Summon(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB0A RID: 64266
		private int method_p0;

		// Token: 0x0400FB0B RID: 64267
		private List<int> method_p1;

		// Token: 0x0400FB0C RID: 64268
		private bool method_p2;

		// Token: 0x0400FB0D RID: 64269
		private int method_p3;
	}
}
