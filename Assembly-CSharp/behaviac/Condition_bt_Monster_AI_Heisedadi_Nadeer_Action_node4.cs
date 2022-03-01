using System;

namespace behaviac
{
	// Token: 0x020034D3 RID: 13523
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node4 : Condition
	{
		// Token: 0x060151EB RID: 86507 RVA: 0x0065D5A6 File Offset: 0x0065B9A6
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Action_node4()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060151EC RID: 86508 RVA: 0x0065D5DC File Offset: 0x0065B9DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAFC RID: 60156
		private int opl_p0;

		// Token: 0x0400EAFD RID: 60157
		private int opl_p1;

		// Token: 0x0400EAFE RID: 60158
		private int opl_p2;

		// Token: 0x0400EAFF RID: 60159
		private int opl_p3;
	}
}
