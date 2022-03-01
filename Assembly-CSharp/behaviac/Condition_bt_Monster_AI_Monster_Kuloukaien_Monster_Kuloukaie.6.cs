using System;

namespace behaviac
{
	// Token: 0x020036B1 RID: 14001
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node14 : Condition
	{
		// Token: 0x0601557C RID: 87420 RVA: 0x0067021B File Offset: 0x0066E61B
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node14()
		{
			this.opl_p0 = 5423;
		}

		// Token: 0x0601557D RID: 87421 RVA: 0x00670230 File Offset: 0x0066E630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF51 RID: 61265
		private int opl_p0;
	}
}
