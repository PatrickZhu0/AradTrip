using System;

namespace behaviac
{
	// Token: 0x02001F1B RID: 7963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node49 : Condition
	{
		// Token: 0x060127DA RID: 75738 RVA: 0x00568D02 File Offset: 0x00567102
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node49()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060127DB RID: 75739 RVA: 0x00568D38 File Offset: 0x00567138
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1D1 RID: 49617
		private int opl_p0;

		// Token: 0x0400C1D2 RID: 49618
		private int opl_p1;

		// Token: 0x0400C1D3 RID: 49619
		private int opl_p2;

		// Token: 0x0400C1D4 RID: 49620
		private int opl_p3;
	}
}
