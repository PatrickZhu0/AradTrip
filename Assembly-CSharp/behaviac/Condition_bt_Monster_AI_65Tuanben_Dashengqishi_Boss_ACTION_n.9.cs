using System;

namespace behaviac
{
	// Token: 0x02002D93 RID: 11667
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node11 : Condition
	{
		// Token: 0x06014407 RID: 82951 RVA: 0x00615947 File Offset: 0x00613D47
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node11()
		{
			this.opl_p0 = 21645;
		}

		// Token: 0x06014408 RID: 82952 RVA: 0x0061595C File Offset: 0x00613D5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDD1 RID: 56785
		private int opl_p0;
	}
}
