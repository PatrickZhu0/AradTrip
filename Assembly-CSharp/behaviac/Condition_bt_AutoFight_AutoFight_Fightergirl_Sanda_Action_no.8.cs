using System;

namespace behaviac
{
	// Token: 0x02001F2E RID: 7982
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node11 : Condition
	{
		// Token: 0x060127FF RID: 75775 RVA: 0x0056A3A7 File Offset: 0x005687A7
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node11()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 183202;
		}

		// Token: 0x06012800 RID: 75776 RVA: 0x0056A3C8 File Offset: 0x005687C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1F5 RID: 49653
		private BE_Target opl_p0;

		// Token: 0x0400C1F6 RID: 49654
		private BE_Equal opl_p1;

		// Token: 0x0400C1F7 RID: 49655
		private int opl_p2;
	}
}
