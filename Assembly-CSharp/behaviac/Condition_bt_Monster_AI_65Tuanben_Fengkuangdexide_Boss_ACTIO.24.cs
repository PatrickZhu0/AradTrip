using System;

namespace behaviac
{
	// Token: 0x02002ED0 RID: 11984
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node23 : Condition
	{
		// Token: 0x0601467A RID: 83578 RVA: 0x00622945 File Offset: 0x00620D45
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node23()
		{
			this.opl_p0 = 21590;
		}

		// Token: 0x0601467B RID: 83579 RVA: 0x00622958 File Offset: 0x00620D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFEA RID: 57322
		private int opl_p0;
	}
}
