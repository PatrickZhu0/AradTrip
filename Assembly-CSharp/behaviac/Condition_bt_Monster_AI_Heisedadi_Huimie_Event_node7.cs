using System;

namespace behaviac
{
	// Token: 0x02003423 RID: 13347
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node7 : Condition
	{
		// Token: 0x06015095 RID: 86165 RVA: 0x00656886 File Offset: 0x00654C86
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Event_node7()
		{
			this.opl_p0 = 6221;
		}

		// Token: 0x06015096 RID: 86166 RVA: 0x0065689C File Offset: 0x00654C9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E964 RID: 59748
		private int opl_p0;
	}
}
