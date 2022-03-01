using System;

namespace behaviac
{
	// Token: 0x020036A8 RID: 13992
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_hengpuli_event_node1 : Condition
	{
		// Token: 0x0601556B RID: 87403 RVA: 0x0066FE14 File Offset: 0x0066E214
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_hengpuli_event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521236;
		}

		// Token: 0x0601556C RID: 87404 RVA: 0x0066FE38 File Offset: 0x0066E238
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF3C RID: 61244
		private BE_Target opl_p0;

		// Token: 0x0400EF3D RID: 61245
		private BE_Equal opl_p1;

		// Token: 0x0400EF3E RID: 61246
		private int opl_p2;
	}
}
