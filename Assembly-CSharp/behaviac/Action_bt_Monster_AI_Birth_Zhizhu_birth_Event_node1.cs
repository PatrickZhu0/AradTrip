using System;

namespace behaviac
{
	// Token: 0x02002F30 RID: 12080
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node1 : Action
	{
		// Token: 0x06014732 RID: 83762 RVA: 0x00627176 File Offset: 0x00625576
		public Action_bt_Monster_AI_Birth_Zhizhu_birth_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 0;
			this.method_p2 = 0;
			this.method_p3 = 0;
		}

		// Token: 0x06014733 RID: 83763 RVA: 0x006271A1 File Offset: 0x006255A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0A1 RID: 57505
		private int method_p0;

		// Token: 0x0400E0A2 RID: 57506
		private int method_p1;

		// Token: 0x0400E0A3 RID: 57507
		private int method_p2;

		// Token: 0x0400E0A4 RID: 57508
		private int method_p3;
	}
}
