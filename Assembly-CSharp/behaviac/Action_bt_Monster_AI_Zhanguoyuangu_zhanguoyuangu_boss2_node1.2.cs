using System;

namespace behaviac
{
	// Token: 0x02003F1F RID: 16159
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node14 : Action
	{
		// Token: 0x060165B1 RID: 91569 RVA: 0x006C34C3 File Offset: 0x006C18C3
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss2_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165B2 RID: 91570 RVA: 0x006C34FA File Offset: 0x006C18FA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDCF RID: 64975
		private BE_Target method_p0;

		// Token: 0x0400FDD0 RID: 64976
		private int method_p1;

		// Token: 0x0400FDD1 RID: 64977
		private int method_p2;

		// Token: 0x0400FDD2 RID: 64978
		private int method_p3;

		// Token: 0x0400FDD3 RID: 64979
		private int method_p4;
	}
}
