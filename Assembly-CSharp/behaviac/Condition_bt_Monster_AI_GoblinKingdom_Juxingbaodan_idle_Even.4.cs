using System;

namespace behaviac
{
	// Token: 0x02003381 RID: 13185
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10 : Condition
	{
		// Token: 0x06014F5F RID: 85855 RVA: 0x006509E5 File Offset: 0x0064EDE5
		public Condition_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node10()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014F60 RID: 85856 RVA: 0x00650A08 File Offset: 0x0064EE08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E82B RID: 59435
		private HMType opl_p0;

		// Token: 0x0400E82C RID: 59436
		private BE_Operation opl_p1;

		// Token: 0x0400E82D RID: 59437
		private float opl_p2;
	}
}
