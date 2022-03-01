using System;

namespace behaviac
{
	// Token: 0x020036A0 RID: 13984
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node13 : Condition
	{
		// Token: 0x0601555C RID: 87388 RVA: 0x0066F81D File Offset: 0x0066DC1D
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node13()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521232;
		}

		// Token: 0x0601555D RID: 87389 RVA: 0x0066F840 File Offset: 0x0066DC40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF2B RID: 61227
		private BE_Target opl_p0;

		// Token: 0x0400EF2C RID: 61228
		private BE_Equal opl_p1;

		// Token: 0x0400EF2D RID: 61229
		private int opl_p2;
	}
}
