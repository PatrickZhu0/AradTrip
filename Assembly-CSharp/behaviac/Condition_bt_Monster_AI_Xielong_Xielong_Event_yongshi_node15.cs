using System;

namespace behaviac
{
	// Token: 0x02003E6C RID: 15980
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node15 : Condition
	{
		// Token: 0x0601645B RID: 91227 RVA: 0x006BBD9F File Offset: 0x006BA19F
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node15()
		{
			this.opl_p0 = 7227;
		}

		// Token: 0x0601645C RID: 91228 RVA: 0x006BBDB4 File Offset: 0x006BA1B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC9B RID: 64667
		private int opl_p0;
	}
}
