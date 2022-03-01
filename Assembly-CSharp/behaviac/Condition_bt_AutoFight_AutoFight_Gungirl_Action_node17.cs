using System;

namespace behaviac
{
	// Token: 0x020024AA RID: 9386
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node17 : Condition
	{
		// Token: 0x0601329F RID: 78495 RVA: 0x005B032A File Offset: 0x005AE72A
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060132A0 RID: 78496 RVA: 0x005B0360 File Offset: 0x005AE760
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCB8 RID: 52408
		private int opl_p0;

		// Token: 0x0400CCB9 RID: 52409
		private int opl_p1;

		// Token: 0x0400CCBA RID: 52410
		private int opl_p2;

		// Token: 0x0400CCBB RID: 52411
		private int opl_p3;
	}
}
