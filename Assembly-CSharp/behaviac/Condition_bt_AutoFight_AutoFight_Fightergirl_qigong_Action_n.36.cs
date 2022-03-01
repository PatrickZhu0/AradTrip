using System;

namespace behaviac
{
	// Token: 0x02001F21 RID: 7969
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node0 : Condition
	{
		// Token: 0x060127E6 RID: 75750 RVA: 0x00568F5B File Offset: 0x0056735B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node0()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 180020;
		}

		// Token: 0x060127E7 RID: 75751 RVA: 0x00568F7C File Offset: 0x0056737C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1DD RID: 49629
		private BE_Target opl_p0;

		// Token: 0x0400C1DE RID: 49630
		private BE_Equal opl_p1;

		// Token: 0x0400C1DF RID: 49631
		private int opl_p2;
	}
}
