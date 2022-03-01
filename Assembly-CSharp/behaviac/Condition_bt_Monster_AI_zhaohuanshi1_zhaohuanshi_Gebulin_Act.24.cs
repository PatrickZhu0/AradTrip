using System;

namespace behaviac
{
	// Token: 0x02004054 RID: 16468
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node42 : Condition
	{
		// Token: 0x06016807 RID: 92167 RVA: 0x006CF521 File Offset: 0x006CD921
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node42()
		{
			this.opl_p0 = 5109;
		}

		// Token: 0x06016808 RID: 92168 RVA: 0x006CF534 File Offset: 0x006CD934
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010053 RID: 65619
		private int opl_p0;
	}
}
