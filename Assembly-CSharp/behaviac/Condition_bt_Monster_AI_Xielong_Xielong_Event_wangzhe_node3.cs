using System;

namespace behaviac
{
	// Token: 0x02003E4D RID: 15949
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node3 : Condition
	{
		// Token: 0x0601641E RID: 91166 RVA: 0x006BAE6A File Offset: 0x006B926A
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node3()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x0601641F RID: 91167 RVA: 0x006BAE8C File Offset: 0x006B928C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC6E RID: 64622
		private HMType opl_p0;

		// Token: 0x0400FC6F RID: 64623
		private BE_Operation opl_p1;

		// Token: 0x0400FC70 RID: 64624
		private float opl_p2;
	}
}
