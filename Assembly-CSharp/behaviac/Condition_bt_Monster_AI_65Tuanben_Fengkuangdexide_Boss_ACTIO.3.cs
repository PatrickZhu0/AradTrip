using System;

namespace behaviac
{
	// Token: 0x02002EAF RID: 11951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node79 : Condition
	{
		// Token: 0x06014638 RID: 83512 RVA: 0x00621E26 File Offset: 0x00620226
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node79()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x06014639 RID: 83513 RVA: 0x00621E48 File Offset: 0x00620248
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFAD RID: 57261
		private BE_Target opl_p0;

		// Token: 0x0400DFAE RID: 57262
		private BE_Equal opl_p1;

		// Token: 0x0400DFAF RID: 57263
		private int opl_p2;
	}
}
