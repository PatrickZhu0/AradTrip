using System;

namespace behaviac
{
	// Token: 0x02003E55 RID: 15957
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node9 : Condition
	{
		// Token: 0x0601642E RID: 91182 RVA: 0x006BB13F File Offset: 0x006B953F
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node9()
		{
			this.opl_p0 = 7228;
		}

		// Token: 0x0601642F RID: 91183 RVA: 0x006BB154 File Offset: 0x006B9554
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC7D RID: 64637
		private int opl_p0;
	}
}
