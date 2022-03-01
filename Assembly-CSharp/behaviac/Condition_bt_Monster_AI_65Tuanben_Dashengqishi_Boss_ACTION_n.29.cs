using System;

namespace behaviac
{
	// Token: 0x02002DB3 RID: 11699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node165 : Condition
	{
		// Token: 0x06014447 RID: 83015 RVA: 0x00616625 File Offset: 0x00614A25
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node165()
		{
			this.opl_p0 = 21642;
		}

		// Token: 0x06014448 RID: 83016 RVA: 0x00616638 File Offset: 0x00614A38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE10 RID: 56848
		private int opl_p0;
	}
}
