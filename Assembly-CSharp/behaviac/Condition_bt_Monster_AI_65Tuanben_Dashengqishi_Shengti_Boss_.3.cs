using System;

namespace behaviac
{
	// Token: 0x02002DCE RID: 11726
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node68 : Condition
	{
		// Token: 0x06014479 RID: 83065 RVA: 0x006180F9 File Offset: 0x006164F9
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node68()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x0601447A RID: 83066 RVA: 0x0061811C File Offset: 0x0061651C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE37 RID: 56887
		private HMType opl_p0;

		// Token: 0x0400DE38 RID: 56888
		private BE_Operation opl_p1;

		// Token: 0x0400DE39 RID: 56889
		private float opl_p2;
	}
}
