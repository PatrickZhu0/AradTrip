using System;

namespace behaviac
{
	// Token: 0x020034C7 RID: 13511
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node31 : Condition
	{
		// Token: 0x060151D4 RID: 86484 RVA: 0x0065C701 File Offset: 0x0065AB01
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node31()
		{
			this.opl_p0 = 6204;
		}

		// Token: 0x060151D5 RID: 86485 RVA: 0x0065C714 File Offset: 0x0065AB14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAE3 RID: 60131
		private int opl_p0;
	}
}
