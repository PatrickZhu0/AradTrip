using System;

namespace behaviac
{
	// Token: 0x02003C37 RID: 15415
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node29 : Condition
	{
		// Token: 0x06016018 RID: 90136 RVA: 0x006A67B9 File Offset: 0x006A4BB9
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node29()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06016019 RID: 90137 RVA: 0x006A67DC File Offset: 0x006A4BDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F890 RID: 63632
		private HMType opl_p0;

		// Token: 0x0400F891 RID: 63633
		private BE_Operation opl_p1;

		// Token: 0x0400F892 RID: 63634
		private float opl_p2;
	}
}
