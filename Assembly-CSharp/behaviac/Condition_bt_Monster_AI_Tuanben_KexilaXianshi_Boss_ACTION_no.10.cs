using System;

namespace behaviac
{
	// Token: 0x02003A42 RID: 14914
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node15 : Condition
	{
		// Token: 0x06015C4D RID: 89165 RVA: 0x0069356F File Offset: 0x0069196F
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node15()
		{
			this.opl_p0 = 21059;
		}

		// Token: 0x06015C4E RID: 89166 RVA: 0x00693584 File Offset: 0x00691984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F56D RID: 62829
		private int opl_p0;
	}
}
