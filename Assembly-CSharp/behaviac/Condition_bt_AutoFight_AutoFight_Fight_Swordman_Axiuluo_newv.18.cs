using System;

namespace behaviac
{
	// Token: 0x02002219 RID: 8729
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node48 : Condition
	{
		// Token: 0x06012DBC RID: 77244 RVA: 0x0058DB41 File Offset: 0x0058BF41
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node48()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012DBD RID: 77245 RVA: 0x0058DB64 File Offset: 0x0058BF64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7B3 RID: 51123
		private BE_Target opl_p0;

		// Token: 0x0400C7B4 RID: 51124
		private BE_Equal opl_p1;

		// Token: 0x0400C7B5 RID: 51125
		private int opl_p2;
	}
}
