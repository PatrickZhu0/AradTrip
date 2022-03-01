using System;

namespace behaviac
{
	// Token: 0x02002E77 RID: 11895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node293 : Condition
	{
		// Token: 0x060145CB RID: 83403 RVA: 0x0061C48C File Offset: 0x0061A88C
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node293()
		{
			this.opl_p0 = 21626;
		}

		// Token: 0x060145CC RID: 83404 RVA: 0x0061C4A0 File Offset: 0x0061A8A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF55 RID: 57173
		private int opl_p0;
	}
}
