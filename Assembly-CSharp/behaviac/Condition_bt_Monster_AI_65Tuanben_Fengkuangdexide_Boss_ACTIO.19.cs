using System;

namespace behaviac
{
	// Token: 0x02002EC4 RID: 11972
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node49 : Condition
	{
		// Token: 0x06014662 RID: 83554 RVA: 0x0062250E File Offset: 0x0062090E
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node49()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x06014663 RID: 83555 RVA: 0x00622530 File Offset: 0x00620930
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFD0 RID: 57296
		private BE_Target opl_p0;

		// Token: 0x0400DFD1 RID: 57297
		private BE_Equal opl_p1;

		// Token: 0x0400DFD2 RID: 57298
		private int opl_p2;
	}
}
