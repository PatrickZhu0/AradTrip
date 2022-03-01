using System;

namespace behaviac
{
	// Token: 0x0200289C RID: 10396
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node90 : Condition
	{
		// Token: 0x06013A72 RID: 80498 RVA: 0x005DE819 File Offset: 0x005DCC19
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node90()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171901;
		}

		// Token: 0x06013A73 RID: 80499 RVA: 0x005DE83C File Offset: 0x005DCC3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4CC RID: 54476
		private BE_Target opl_p0;

		// Token: 0x0400D4CD RID: 54477
		private BE_Equal opl_p1;

		// Token: 0x0400D4CE RID: 54478
		private int opl_p2;
	}
}
