using System;

namespace behaviac
{
	// Token: 0x02002E7A RID: 11898
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node146 : Condition
	{
		// Token: 0x060145D1 RID: 83409 RVA: 0x0061C5F9 File Offset: 0x0061A9F9
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node146()
		{
			this.opl_p0 = 21623;
		}

		// Token: 0x060145D2 RID: 83410 RVA: 0x0061C60C File Offset: 0x0061AA0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF5C RID: 57180
		private int opl_p0;
	}
}
