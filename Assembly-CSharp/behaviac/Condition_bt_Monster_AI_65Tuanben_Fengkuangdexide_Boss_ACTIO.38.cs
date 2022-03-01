using System;

namespace behaviac
{
	// Token: 0x02002EE2 RID: 12002
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node61 : Condition
	{
		// Token: 0x0601469E RID: 83614 RVA: 0x006230F6 File Offset: 0x006214F6
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node61()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x0601469F RID: 83615 RVA: 0x00623118 File Offset: 0x00621518
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E014 RID: 57364
		private BE_Target opl_p0;

		// Token: 0x0400E015 RID: 57365
		private BE_Equal opl_p1;

		// Token: 0x0400E016 RID: 57366
		private int opl_p2;
	}
}
