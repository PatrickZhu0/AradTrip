using System;

namespace behaviac
{
	// Token: 0x020033A1 RID: 13217
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node10 : Condition
	{
		// Token: 0x06014F9D RID: 85917 RVA: 0x00651CAE File Offset: 0x006500AE
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node10()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x06014F9E RID: 85918 RVA: 0x00651CD0 File Offset: 0x006500D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E878 RID: 59512
		private HMType opl_p0;

		// Token: 0x0400E879 RID: 59513
		private BE_Operation opl_p1;

		// Token: 0x0400E87A RID: 59514
		private float opl_p2;
	}
}
