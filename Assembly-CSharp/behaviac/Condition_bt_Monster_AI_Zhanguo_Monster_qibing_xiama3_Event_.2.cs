using System;

namespace behaviac
{
	// Token: 0x02003EEE RID: 16110
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node1 : Condition
	{
		// Token: 0x06016555 RID: 91477 RVA: 0x006C1C25 File Offset: 0x006C0025
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06016556 RID: 91478 RVA: 0x006C1C48 File Offset: 0x006C0048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD7D RID: 64893
		private HMType opl_p0;

		// Token: 0x0400FD7E RID: 64894
		private BE_Operation opl_p1;

		// Token: 0x0400FD7F RID: 64895
		private float opl_p2;
	}
}
