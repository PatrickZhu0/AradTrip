using System;

namespace behaviac
{
	// Token: 0x02001CFF RID: 7423
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node6 : Condition
	{
		// Token: 0x060123C3 RID: 74691 RVA: 0x00550823 File Offset: 0x0054EC23
		public Condition_bt_APC_APC_Demian_Action_node6()
		{
			this.opl_p0 = 8004;
		}

		// Token: 0x060123C4 RID: 74692 RVA: 0x00550838 File Offset: 0x0054EC38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDBA RID: 48570
		private int opl_p0;
	}
}
