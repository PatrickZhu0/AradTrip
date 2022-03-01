using System;

namespace behaviac
{
	// Token: 0x02003C7E RID: 15486
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node75 : Action
	{
		// Token: 0x060160A3 RID: 90275 RVA: 0x006A9133 File Offset: 0x006A7533
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node75()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570105;
			this.method_p2 = 15000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060160A4 RID: 90276 RVA: 0x006A916E File Offset: 0x006A756E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F934 RID: 63796
		private BE_Target method_p0;

		// Token: 0x0400F935 RID: 63797
		private int method_p1;

		// Token: 0x0400F936 RID: 63798
		private int method_p2;

		// Token: 0x0400F937 RID: 63799
		private int method_p3;

		// Token: 0x0400F938 RID: 63800
		private int method_p4;
	}
}
