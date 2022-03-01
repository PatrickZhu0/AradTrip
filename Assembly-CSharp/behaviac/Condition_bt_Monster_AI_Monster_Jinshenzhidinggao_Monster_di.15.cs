using System;

namespace behaviac
{
	// Token: 0x0200369C RID: 13980
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3 : Condition
	{
		// Token: 0x06015554 RID: 87380 RVA: 0x0066F681 File Offset: 0x0066DA81
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.IDLEE;
		}

		// Token: 0x06015555 RID: 87381 RVA: 0x0066F6A0 File Offset: 0x0066DAA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF1A RID: 61210
		private BE_Target opl_p0;

		// Token: 0x0400EF1B RID: 61211
		private BE_Equal opl_p1;

		// Token: 0x0400EF1C RID: 61212
		private BE_State opl_p2;
	}
}
