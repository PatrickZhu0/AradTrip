using System;

namespace behaviac
{
	// Token: 0x02002DEA RID: 11754
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node14 : Condition
	{
		// Token: 0x060144B1 RID: 83121 RVA: 0x00618C75 File Offset: 0x00617075
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node14()
		{
			this.opl_p0 = 21623;
		}

		// Token: 0x060144B2 RID: 83122 RVA: 0x00618C88 File Offset: 0x00617088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE6A RID: 56938
		private int opl_p0;
	}
}
