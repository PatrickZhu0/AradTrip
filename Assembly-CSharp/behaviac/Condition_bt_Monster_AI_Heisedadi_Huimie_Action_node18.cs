using System;

namespace behaviac
{
	// Token: 0x02003406 RID: 13318
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node18 : Condition
	{
		// Token: 0x0601505D RID: 86109 RVA: 0x0065585D File Offset: 0x00653C5D
		public Condition_bt_Monster_AI_Heisedadi_Huimie_Action_node18()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x0601505E RID: 86110 RVA: 0x00655880 File Offset: 0x00653C80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E939 RID: 59705
		private HMType opl_p0;

		// Token: 0x0400E93A RID: 59706
		private BE_Operation opl_p1;

		// Token: 0x0400E93B RID: 59707
		private float opl_p2;
	}
}
