using System;

namespace behaviac
{
	// Token: 0x02002898 RID: 10392
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node6 : Condition
	{
		// Token: 0x06013A6B RID: 80491 RVA: 0x005DE6B5 File Offset: 0x005DCAB5
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171001;
		}

		// Token: 0x06013A6C RID: 80492 RVA: 0x005DE6D8 File Offset: 0x005DCAD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4C6 RID: 54470
		private BE_Target opl_p0;

		// Token: 0x0400D4C7 RID: 54471
		private BE_Equal opl_p1;

		// Token: 0x0400D4C8 RID: 54472
		private int opl_p2;
	}
}
