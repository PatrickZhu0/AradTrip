using System;

namespace behaviac
{
	// Token: 0x02003443 RID: 13379
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node6 : Condition
	{
		// Token: 0x060150D2 RID: 86226 RVA: 0x00657F27 File Offset: 0x00656327
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521840;
		}

		// Token: 0x060150D3 RID: 86227 RVA: 0x00657F48 File Offset: 0x00656348
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9A1 RID: 59809
		private BE_Target opl_p0;

		// Token: 0x0400E9A2 RID: 59810
		private BE_Equal opl_p1;

		// Token: 0x0400E9A3 RID: 59811
		private int opl_p2;
	}
}
