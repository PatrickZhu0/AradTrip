using System;

namespace behaviac
{
	// Token: 0x02003B79 RID: 15225
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node1 : Condition
	{
		// Token: 0x06015EA5 RID: 89765 RVA: 0x0069F649 File Offset: 0x0069DA49
		public Condition_bt_Monster_AI_Tuanben_Xianfeng_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x06015EA6 RID: 89766 RVA: 0x0069F66C File Offset: 0x0069DA6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F769 RID: 63337
		private HMType opl_p0;

		// Token: 0x0400F76A RID: 63338
		private BE_Operation opl_p1;

		// Token: 0x0400F76B RID: 63339
		private float opl_p2;
	}
}
