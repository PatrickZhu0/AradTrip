using System;

namespace behaviac
{
	// Token: 0x02002214 RID: 8724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node37 : Condition
	{
		// Token: 0x06012DB2 RID: 77234 RVA: 0x0058D5F9 File Offset: 0x0058B9F9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012DB3 RID: 77235 RVA: 0x0058D61C File Offset: 0x0058BA1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7A8 RID: 51112
		private BE_Target opl_p0;

		// Token: 0x0400C7A9 RID: 51113
		private BE_Equal opl_p1;

		// Token: 0x0400C7AA RID: 51114
		private int opl_p2;
	}
}
