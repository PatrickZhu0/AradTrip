using System;

namespace behaviac
{
	// Token: 0x020026EA RID: 9962
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node16 : Condition
	{
		// Token: 0x06013717 RID: 79639 RVA: 0x005C9EC6 File Offset: 0x005C82C6
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node16()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013718 RID: 79640 RVA: 0x005C9EFC File Offset: 0x005C82FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D16D RID: 53613
		private int opl_p0;

		// Token: 0x0400D16E RID: 53614
		private int opl_p1;

		// Token: 0x0400D16F RID: 53615
		private int opl_p2;

		// Token: 0x0400D170 RID: 53616
		private int opl_p3;
	}
}
