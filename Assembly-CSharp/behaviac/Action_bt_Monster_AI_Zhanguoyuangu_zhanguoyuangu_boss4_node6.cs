using System;

namespace behaviac
{
	// Token: 0x02003F33 RID: 16179
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node6 : Action
	{
		// Token: 0x060165D7 RID: 91607 RVA: 0x006C4131 File Offset: 0x006C2531
		public Action_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_boss4_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570231;
			this.method_p2 = 30000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x060165D8 RID: 91608 RVA: 0x006C416B File Offset: 0x006C256B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FDFB RID: 65019
		private BE_Target method_p0;

		// Token: 0x0400FDFC RID: 65020
		private int method_p1;

		// Token: 0x0400FDFD RID: 65021
		private int method_p2;

		// Token: 0x0400FDFE RID: 65022
		private int method_p3;

		// Token: 0x0400FDFF RID: 65023
		private int method_p4;
	}
}
