using System;

namespace behaviac
{
	// Token: 0x020030E8 RID: 12520
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2 : Condition
	{
		// Token: 0x06014A83 RID: 84611 RVA: 0x00638659 File Offset: 0x00636A59
		public Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014A84 RID: 84612 RVA: 0x0063867C File Offset: 0x00636A7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3F2 RID: 58354
		private HMType opl_p0;

		// Token: 0x0400E3F3 RID: 58355
		private BE_Operation opl_p1;

		// Token: 0x0400E3F4 RID: 58356
		private float opl_p2;
	}
}
