using System;

namespace behaviac
{
	// Token: 0x02001EFA RID: 7930
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node43 : Condition
	{
		// Token: 0x06012798 RID: 75672 RVA: 0x00567D8E File Offset: 0x0056618E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node43()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06012799 RID: 75673 RVA: 0x00567DC4 File Offset: 0x005661C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C18C RID: 49548
		private int opl_p0;

		// Token: 0x0400C18D RID: 49549
		private int opl_p1;

		// Token: 0x0400C18E RID: 49550
		private int opl_p2;

		// Token: 0x0400C18F RID: 49551
		private int opl_p3;
	}
}
