using System;

namespace behaviac
{
	// Token: 0x02003EF4 RID: 16116
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node2 : Condition
	{
		// Token: 0x06016560 RID: 91488 RVA: 0x006C1F41 File Offset: 0x006C0341
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06016561 RID: 91489 RVA: 0x006C1F64 File Offset: 0x006C0364
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD83 RID: 64899
		private HMType opl_p0;

		// Token: 0x0400FD84 RID: 64900
		private BE_Operation opl_p1;

		// Token: 0x0400FD85 RID: 64901
		private float opl_p2;
	}
}
