using System;

namespace behaviac
{
	// Token: 0x02002D8E RID: 11662
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node31 : Condition
	{
		// Token: 0x060143FD RID: 82941 RVA: 0x00615787 File Offset: 0x00613B87
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node31()
		{
			this.opl_p0 = 21646;
		}

		// Token: 0x060143FE RID: 82942 RVA: 0x0061579C File Offset: 0x00613B9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDCA RID: 56778
		private int opl_p0;
	}
}
