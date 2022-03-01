using System;

namespace behaviac
{
	// Token: 0x020036B9 RID: 14009
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node4 : Condition
	{
		// Token: 0x0601558C RID: 87436 RVA: 0x00670583 File Offset: 0x0066E983
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node4()
		{
			this.opl_p0 = 5420;
		}

		// Token: 0x0601558D RID: 87437 RVA: 0x00670598 File Offset: 0x0066E998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF61 RID: 61281
		private int opl_p0;
	}
}
