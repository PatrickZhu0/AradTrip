using System;

namespace behaviac
{
	// Token: 0x020036B5 RID: 14005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node19 : Condition
	{
		// Token: 0x06015584 RID: 87428 RVA: 0x006703CF File Offset: 0x0066E7CF
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node19()
		{
			this.opl_p0 = 5652;
		}

		// Token: 0x06015585 RID: 87429 RVA: 0x006703E4 File Offset: 0x0066E7E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF59 RID: 61273
		private int opl_p0;
	}
}
