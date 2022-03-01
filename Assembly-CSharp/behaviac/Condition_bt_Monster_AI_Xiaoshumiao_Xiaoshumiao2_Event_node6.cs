using System;

namespace behaviac
{
	// Token: 0x02003E1E RID: 15902
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node6 : Condition
	{
		// Token: 0x060163C4 RID: 91076 RVA: 0x006B90CE File Offset: 0x006B74CE
		public Condition_bt_Monster_AI_Xiaoshumiao_Xiaoshumiao2_Event_node6()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x060163C5 RID: 91077 RVA: 0x006B90F0 File Offset: 0x006B74F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC2B RID: 64555
		private HMType opl_p0;

		// Token: 0x0400FC2C RID: 64556
		private BE_Operation opl_p1;

		// Token: 0x0400FC2D RID: 64557
		private float opl_p2;
	}
}
