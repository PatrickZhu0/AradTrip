using System;

namespace behaviac
{
	// Token: 0x02003B0A RID: 15114
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node11 : Condition
	{
		// Token: 0x06015DCE RID: 89550 RVA: 0x0069B2D9 File Offset: 0x006996D9
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_action_node11()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x06015DCF RID: 89551 RVA: 0x0069B2EC File Offset: 0x006996EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6BD RID: 63165
		private int opl_p0;
	}
}
