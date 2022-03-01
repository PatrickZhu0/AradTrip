using System;

namespace behaviac
{
	// Token: 0x02002EE0 RID: 12000
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node78 : Condition
	{
		// Token: 0x0601469A RID: 83610 RVA: 0x00623005 File Offset: 0x00621405
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node78()
		{
			this.opl_p0 = 21601;
		}

		// Token: 0x0601469B RID: 83611 RVA: 0x00623018 File Offset: 0x00621418
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E011 RID: 57361
		private int opl_p0;
	}
}
