using System;

namespace behaviac
{
	// Token: 0x02003A10 RID: 14864
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node27 : Action
	{
		// Token: 0x06015BED RID: 89069 RVA: 0x0069107C File Offset: 0x0068F47C
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
			this.method_p1 = 0;
		}

		// Token: 0x06015BEE RID: 89070 RVA: 0x00691099 File Offset: 0x0068F499
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F50B RID: 62731
		private int method_p0;

		// Token: 0x0400F50C RID: 62732
		private int method_p1;
	}
}
