using System;

namespace behaviac
{
	// Token: 0x0200369A RID: 13978
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2 : Condition
	{
		// Token: 0x06015550 RID: 87376 RVA: 0x0066F58A File Offset: 0x0066D98A
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06015551 RID: 87377 RVA: 0x0066F5C0 File Offset: 0x0066D9C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF12 RID: 61202
		private int opl_p0;

		// Token: 0x0400EF13 RID: 61203
		private int opl_p1;

		// Token: 0x0400EF14 RID: 61204
		private int opl_p2;

		// Token: 0x0400EF15 RID: 61205
		private int opl_p3;
	}
}
