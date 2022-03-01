using System;

namespace behaviac
{
	// Token: 0x02002E0E RID: 11790
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node22 : Condition
	{
		// Token: 0x060144F9 RID: 83193 RVA: 0x00619993 File Offset: 0x00617D93
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node22()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060144FA RID: 83194 RVA: 0x006199B4 File Offset: 0x00617DB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE9F RID: 56991
		private HMType opl_p0;

		// Token: 0x0400DEA0 RID: 56992
		private BE_Operation opl_p1;

		// Token: 0x0400DEA1 RID: 56993
		private float opl_p2;
	}
}
