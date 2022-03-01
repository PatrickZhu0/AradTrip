using System;

namespace behaviac
{
	// Token: 0x020036AD RID: 13997
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node9 : Condition
	{
		// Token: 0x06015574 RID: 87412 RVA: 0x00670067 File Offset: 0x0066E467
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node9()
		{
			this.opl_p0 = 5422;
		}

		// Token: 0x06015575 RID: 87413 RVA: 0x0067007C File Offset: 0x0066E47C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF49 RID: 61257
		private int opl_p0;
	}
}
