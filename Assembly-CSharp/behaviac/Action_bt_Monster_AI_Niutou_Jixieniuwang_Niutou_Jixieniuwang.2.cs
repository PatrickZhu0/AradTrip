using System;

namespace behaviac
{
	// Token: 0x020036FE RID: 14078
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node12 : Action
	{
		// Token: 0x0601560B RID: 87563 RVA: 0x00673123 File Offset: 0x00671523
		public Action_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 540102;
			this.method_p2 = 60000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x0601560C RID: 87564 RVA: 0x0067315D File Offset: 0x0067155D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFD1 RID: 61393
		private BE_Target method_p0;

		// Token: 0x0400EFD2 RID: 61394
		private int method_p1;

		// Token: 0x0400EFD3 RID: 61395
		private int method_p2;

		// Token: 0x0400EFD4 RID: 61396
		private int method_p3;

		// Token: 0x0400EFD5 RID: 61397
		private int method_p4;
	}
}
