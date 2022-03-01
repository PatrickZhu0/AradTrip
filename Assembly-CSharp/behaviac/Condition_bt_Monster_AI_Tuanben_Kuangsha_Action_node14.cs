using System;

namespace behaviac
{
	// Token: 0x02003AD2 RID: 15058
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node14 : Condition
	{
		// Token: 0x06015D63 RID: 89443 RVA: 0x00698B9A File Offset: 0x00696F9A
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node14()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570141;
		}

		// Token: 0x06015D64 RID: 89444 RVA: 0x00698BBC File Offset: 0x00696FBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F670 RID: 63088
		private BE_Target opl_p0;

		// Token: 0x0400F671 RID: 63089
		private BE_Equal opl_p1;

		// Token: 0x0400F672 RID: 63090
		private int opl_p2;
	}
}
