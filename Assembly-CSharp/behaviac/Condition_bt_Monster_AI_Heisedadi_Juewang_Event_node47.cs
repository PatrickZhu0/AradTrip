using System;

namespace behaviac
{
	// Token: 0x0200349C RID: 13468
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node47 : Condition
	{
		// Token: 0x06015181 RID: 86401 RVA: 0x0065AA3B File Offset: 0x00658E3B
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node47()
		{
			this.opl_p0 = 6212;
		}

		// Token: 0x06015182 RID: 86402 RVA: 0x0065AA50 File Offset: 0x00658E50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA82 RID: 60034
		private int opl_p0;
	}
}
