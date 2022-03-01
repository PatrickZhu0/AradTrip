using System;

namespace behaviac
{
	// Token: 0x0200373F RID: 14143
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node15 : Action
	{
		// Token: 0x06015689 RID: 87689 RVA: 0x006756DA File Offset: 0x00673ADA
		public Action_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528402;
			this.method_p2 = 500;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x0601568A RID: 87690 RVA: 0x00675715 File Offset: 0x00673B15
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F059 RID: 61529
		private BE_Target method_p0;

		// Token: 0x0400F05A RID: 61530
		private int method_p1;

		// Token: 0x0400F05B RID: 61531
		private int method_p2;

		// Token: 0x0400F05C RID: 61532
		private int method_p3;

		// Token: 0x0400F05D RID: 61533
		private int method_p4;
	}
}
