using System;

namespace behaviac
{
	// Token: 0x02003A9F RID: 15007
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node106 : Action
	{
		// Token: 0x06015D02 RID: 89346 RVA: 0x00696ED2 File Offset: 0x006952D2
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node106()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！讨厌！讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06015D03 RID: 89347 RVA: 0x00696EFE File Offset: 0x006952FE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F62C RID: 63020
		private string method_p0;

		// Token: 0x0400F62D RID: 63021
		private float method_p1;

		// Token: 0x0400F62E RID: 63022
		private int method_p2;
	}
}
