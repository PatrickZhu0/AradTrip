using System;

namespace behaviac
{
	// Token: 0x02003E54 RID: 15956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node20 : Condition
	{
		// Token: 0x0601642C RID: 91180 RVA: 0x006BB0DF File Offset: 0x006B94DF
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node20()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x0601642D RID: 91181 RVA: 0x006BB100 File Offset: 0x006B9500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC7A RID: 64634
		private HMType opl_p0;

		// Token: 0x0400FC7B RID: 64635
		private BE_Operation opl_p1;

		// Token: 0x0400FC7C RID: 64636
		private float opl_p2;
	}
}
