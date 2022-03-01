using System;

namespace behaviac
{
	// Token: 0x020034C8 RID: 13512
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node35 : Condition
	{
		// Token: 0x060151D6 RID: 86486 RVA: 0x0065C747 File Offset: 0x0065AB47
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node35()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521715;
		}

		// Token: 0x060151D7 RID: 86487 RVA: 0x0065C768 File Offset: 0x0065AB68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAE4 RID: 60132
		private BE_Target opl_p0;

		// Token: 0x0400EAE5 RID: 60133
		private BE_Equal opl_p1;

		// Token: 0x0400EAE6 RID: 60134
		private int opl_p2;
	}
}
