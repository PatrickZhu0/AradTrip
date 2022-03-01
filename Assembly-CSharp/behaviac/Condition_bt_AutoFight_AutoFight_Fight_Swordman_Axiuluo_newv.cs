using System;

namespace behaviac
{
	// Token: 0x02002204 RID: 8708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node6 : Condition
	{
		// Token: 0x06012D92 RID: 77202 RVA: 0x0058CAB5 File Offset: 0x0058AEB5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012D93 RID: 77203 RVA: 0x0058CAD8 File Offset: 0x0058AED8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C77B RID: 51067
		private BE_Target opl_p0;

		// Token: 0x0400C77C RID: 51068
		private BE_Equal opl_p1;

		// Token: 0x0400C77D RID: 51069
		private int opl_p2;
	}
}
