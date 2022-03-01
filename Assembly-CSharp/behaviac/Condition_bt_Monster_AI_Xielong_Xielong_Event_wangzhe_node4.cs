using System;

namespace behaviac
{
	// Token: 0x02003E4F RID: 15951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node4 : Condition
	{
		// Token: 0x06016422 RID: 91170 RVA: 0x006BAF2B File Offset: 0x006B932B
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node4()
		{
			this.opl_p0 = 7228;
		}

		// Token: 0x06016423 RID: 91171 RVA: 0x006BAF40 File Offset: 0x006B9340
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC74 RID: 64628
		private int opl_p0;
	}
}
