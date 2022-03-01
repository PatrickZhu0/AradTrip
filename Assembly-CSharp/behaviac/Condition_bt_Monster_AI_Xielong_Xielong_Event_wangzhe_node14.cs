using System;

namespace behaviac
{
	// Token: 0x02003E59 RID: 15961
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node14 : Condition
	{
		// Token: 0x06016436 RID: 91190 RVA: 0x006BB292 File Offset: 0x006B9692
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x06016437 RID: 91191 RVA: 0x006BB2B4 File Offset: 0x006B96B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC80 RID: 64640
		private HMType opl_p0;

		// Token: 0x0400FC81 RID: 64641
		private BE_Operation opl_p1;

		// Token: 0x0400FC82 RID: 64642
		private float opl_p2;
	}
}
