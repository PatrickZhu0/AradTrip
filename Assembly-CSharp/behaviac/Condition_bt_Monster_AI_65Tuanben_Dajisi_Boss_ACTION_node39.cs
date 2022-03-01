using System;

namespace behaviac
{
	// Token: 0x02002D6F RID: 11631
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node39 : Condition
	{
		// Token: 0x060143C0 RID: 82880 RVA: 0x00614187 File Offset: 0x00612587
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node39()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570281;
		}

		// Token: 0x060143C1 RID: 82881 RVA: 0x006141A8 File Offset: 0x006125A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD89 RID: 56713
		private BE_Target opl_p0;

		// Token: 0x0400DD8A RID: 56714
		private BE_Equal opl_p1;

		// Token: 0x0400DD8B RID: 56715
		private int opl_p2;
	}
}
