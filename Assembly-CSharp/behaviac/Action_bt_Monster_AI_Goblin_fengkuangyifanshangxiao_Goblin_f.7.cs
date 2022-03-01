using System;

namespace behaviac
{
	// Token: 0x020033B7 RID: 13239
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node17 : Action
	{
		// Token: 0x06014FC7 RID: 85959 RVA: 0x00652A02 File Offset: 0x00650E02
		public Action_bt_Monster_AI_Goblin_fengkuangyifanshangxiao_Goblin_fengkuangyifanshangxiao_Event_jiasu_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538502;
			this.method_p2 = 100000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FC8 RID: 85960 RVA: 0x00652A3C File Offset: 0x00650E3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8AC RID: 59564
		private BE_Target method_p0;

		// Token: 0x0400E8AD RID: 59565
		private int method_p1;

		// Token: 0x0400E8AE RID: 59566
		private int method_p2;

		// Token: 0x0400E8AF RID: 59567
		private int method_p3;

		// Token: 0x0400E8B0 RID: 59568
		private int method_p4;
	}
}
