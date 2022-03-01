using System;

namespace behaviac
{
	// Token: 0x0200356C RID: 13676
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node0 : Action
	{
		// Token: 0x06015310 RID: 86800 RVA: 0x00663122 File Offset: 0x00661522
		public Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521996;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06015311 RID: 86801 RVA: 0x0066315D File Offset: 0x0066155D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECC9 RID: 60617
		private BE_Target method_p0;

		// Token: 0x0400ECCA RID: 60618
		private int method_p1;

		// Token: 0x0400ECCB RID: 60619
		private int method_p2;

		// Token: 0x0400ECCC RID: 60620
		private int method_p3;

		// Token: 0x0400ECCD RID: 60621
		private int method_p4;
	}
}
