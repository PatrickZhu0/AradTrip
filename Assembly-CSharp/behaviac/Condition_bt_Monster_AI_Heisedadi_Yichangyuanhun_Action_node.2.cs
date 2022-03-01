using System;

namespace behaviac
{
	// Token: 0x02003552 RID: 13650
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node3 : Condition
	{
		// Token: 0x060152E3 RID: 86755 RVA: 0x00662429 File Offset: 0x00660829
		public Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node3()
		{
			this.opl_p0 = 6250;
		}

		// Token: 0x060152E4 RID: 86756 RVA: 0x0066243C File Offset: 0x0066083C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC9C RID: 60572
		private int opl_p0;
	}
}
