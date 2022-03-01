using System;

namespace behaviac
{
	// Token: 0x020034C1 RID: 13505
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node27 : Condition
	{
		// Token: 0x060151C8 RID: 86472 RVA: 0x0065C4E6 File Offset: 0x0065A8E6
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node27()
		{
			this.opl_p0 = 6206;
		}

		// Token: 0x060151C9 RID: 86473 RVA: 0x0065C4FC File Offset: 0x0065A8FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAD1 RID: 60113
		private int opl_p0;
	}
}
