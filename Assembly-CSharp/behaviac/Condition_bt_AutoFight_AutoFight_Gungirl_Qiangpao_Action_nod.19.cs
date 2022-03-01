using System;

namespace behaviac
{
	// Token: 0x0200252C RID: 9516
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node72 : Condition
	{
		// Token: 0x060133A1 RID: 78753 RVA: 0x005B65E2 File Offset: 0x005B49E2
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node72()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060133A2 RID: 78754 RVA: 0x005B6618 File Offset: 0x005B4A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDC3 RID: 52675
		private int opl_p0;

		// Token: 0x0400CDC4 RID: 52676
		private int opl_p1;

		// Token: 0x0400CDC5 RID: 52677
		private int opl_p2;

		// Token: 0x0400CDC6 RID: 52678
		private int opl_p3;
	}
}
