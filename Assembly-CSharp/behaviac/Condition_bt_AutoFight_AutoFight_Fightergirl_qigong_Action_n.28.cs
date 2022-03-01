using System;

namespace behaviac
{
	// Token: 0x02001F17 RID: 7959
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node55 : Condition
	{
		// Token: 0x060127D2 RID: 75730 RVA: 0x00568B4F File Offset: 0x00566F4F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node55()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060127D3 RID: 75731 RVA: 0x00568B84 File Offset: 0x00566F84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1C9 RID: 49609
		private int opl_p0;

		// Token: 0x0400C1CA RID: 49610
		private int opl_p1;

		// Token: 0x0400C1CB RID: 49611
		private int opl_p2;

		// Token: 0x0400C1CC RID: 49612
		private int opl_p3;
	}
}
