using System;

namespace behaviac
{
	// Token: 0x02002D7F RID: 11647
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node22 : Condition
	{
		// Token: 0x060143E0 RID: 82912 RVA: 0x00614823 File Offset: 0x00612C23
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node22()
		{
			this.opl_p0 = 21603;
		}

		// Token: 0x060143E1 RID: 82913 RVA: 0x00614838 File Offset: 0x00612C38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDB0 RID: 56752
		private int opl_p0;
	}
}
