using System;

namespace behaviac
{
	// Token: 0x02003186 RID: 12678
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node15 : Condition
	{
		// Token: 0x06014BA3 RID: 84899 RVA: 0x0063D9E2 File Offset: 0x0063BDE2
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node15()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570253;
		}

		// Token: 0x06014BA4 RID: 84900 RVA: 0x0063DA04 File Offset: 0x0063BE04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E50F RID: 58639
		private BE_Target opl_p0;

		// Token: 0x0400E510 RID: 58640
		private BE_Equal opl_p1;

		// Token: 0x0400E511 RID: 58641
		private int opl_p2;
	}
}
