using System;

namespace behaviac
{
	// Token: 0x02003B0D RID: 15117
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node3 : Condition
	{
		// Token: 0x06015DD4 RID: 89556 RVA: 0x0069B412 File Offset: 0x00699812
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node3()
		{
			this.opl_p0 = 21021;
		}

		// Token: 0x06015DD5 RID: 89557 RVA: 0x0069B428 File Offset: 0x00699828
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6C1 RID: 63169
		private int opl_p0;
	}
}
