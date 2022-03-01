using System;

namespace behaviac
{
	// Token: 0x02001F26 RID: 7974
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node6 : Condition
	{
		// Token: 0x060127EF RID: 75759 RVA: 0x0056A06F File Offset: 0x0056846F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 183205;
		}

		// Token: 0x060127F0 RID: 75760 RVA: 0x0056A090 File Offset: 0x00568490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1E7 RID: 49639
		private BE_Target opl_p0;

		// Token: 0x0400C1E8 RID: 49640
		private BE_Equal opl_p1;

		// Token: 0x0400C1E9 RID: 49641
		private int opl_p2;
	}
}
