using System;

namespace behaviac
{
	// Token: 0x02002E73 RID: 11891
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node275 : Condition
	{
		// Token: 0x060145C3 RID: 83395 RVA: 0x0061C2BA File Offset: 0x0061A6BA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node275()
		{
			this.opl_p0 = 21640;
		}

		// Token: 0x060145C4 RID: 83396 RVA: 0x0061C2D0 File Offset: 0x0061A6D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF4B RID: 57163
		private int opl_p0;
	}
}
