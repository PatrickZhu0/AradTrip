using System;

namespace behaviac
{
	// Token: 0x02002252 RID: 8786
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node54 : Condition
	{
		// Token: 0x06012E2C RID: 77356 RVA: 0x00591249 File Offset: 0x0058F649
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node54()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 171001;
		}

		// Token: 0x06012E2D RID: 77357 RVA: 0x0059126C File Offset: 0x0058F66C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C832 RID: 51250
		private BE_Target opl_p0;

		// Token: 0x0400C833 RID: 51251
		private BE_Equal opl_p1;

		// Token: 0x0400C834 RID: 51252
		private int opl_p2;
	}
}
