using System;

namespace behaviac
{
	// Token: 0x02002D76 RID: 11638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node41 : Condition
	{
		// Token: 0x060143CE RID: 82894 RVA: 0x0061445B File Offset: 0x0061285B
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node41()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570282;
		}

		// Token: 0x060143CF RID: 82895 RVA: 0x0061447C File Offset: 0x0061287C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD9B RID: 56731
		private BE_Target opl_p0;

		// Token: 0x0400DD9C RID: 56732
		private BE_Equal opl_p1;

		// Token: 0x0400DD9D RID: 56733
		private int opl_p2;
	}
}
