using System;

namespace behaviac
{
	// Token: 0x02002E10 RID: 11792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node151 : Condition
	{
		// Token: 0x060144FD RID: 83197 RVA: 0x00619A9E File Offset: 0x00617E9E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node151()
		{
			this.opl_p0 = 21629;
		}

		// Token: 0x060144FE RID: 83198 RVA: 0x00619AB4 File Offset: 0x00617EB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEA4 RID: 56996
		private int opl_p0;
	}
}
