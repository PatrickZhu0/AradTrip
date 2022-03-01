using System;

namespace behaviac
{
	// Token: 0x02002DE1 RID: 11745
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node43 : Condition
	{
		// Token: 0x0601449F RID: 83103 RVA: 0x00618842 File Offset: 0x00616C42
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node43()
		{
			this.opl_p0 = 21637;
		}

		// Token: 0x060144A0 RID: 83104 RVA: 0x00618858 File Offset: 0x00616C58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE56 RID: 56918
		private int opl_p0;
	}
}
