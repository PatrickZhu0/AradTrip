using System;

namespace behaviac
{
	// Token: 0x02003D91 RID: 15761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node2 : Condition
	{
		// Token: 0x060162B7 RID: 90807 RVA: 0x006B3481 File Offset: 0x006B1881
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_hard_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x060162B8 RID: 90808 RVA: 0x006B34A4 File Offset: 0x006B18A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB07 RID: 64263
		private HMType opl_p0;

		// Token: 0x0400FB08 RID: 64264
		private BE_Operation opl_p1;

		// Token: 0x0400FB09 RID: 64265
		private float opl_p2;
	}
}
