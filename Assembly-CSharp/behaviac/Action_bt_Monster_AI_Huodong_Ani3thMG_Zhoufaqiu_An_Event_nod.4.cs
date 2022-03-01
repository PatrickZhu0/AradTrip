using System;

namespace behaviac
{
	// Token: 0x02003572 RID: 13682
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node6 : Action
	{
		// Token: 0x0601531A RID: 86810 RVA: 0x00663372 File Offset: 0x00661772
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522096;
			this.method_p2 = 500;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601531B RID: 86811 RVA: 0x006633AD File Offset: 0x006617AD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECD7 RID: 60631
		private BE_Target method_p0;

		// Token: 0x0400ECD8 RID: 60632
		private int method_p1;

		// Token: 0x0400ECD9 RID: 60633
		private int method_p2;

		// Token: 0x0400ECDA RID: 60634
		private int method_p3;

		// Token: 0x0400ECDB RID: 60635
		private int method_p4;
	}
}
