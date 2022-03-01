using System;

namespace behaviac
{
	// Token: 0x020033A5 RID: 13221
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node18 : Condition
	{
		// Token: 0x06014FA5 RID: 85925 RVA: 0x00651E7E File Offset: 0x0065027E
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node18()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014FA6 RID: 85926 RVA: 0x00651EA0 File Offset: 0x006502A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E883 RID: 59523
		private HMType opl_p0;

		// Token: 0x0400E884 RID: 59524
		private BE_Operation opl_p1;

		// Token: 0x0400E885 RID: 59525
		private float opl_p2;
	}
}
