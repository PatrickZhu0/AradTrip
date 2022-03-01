using System;

namespace behaviac
{
	// Token: 0x02003A5B RID: 14939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node50 : Condition
	{
		// Token: 0x06015C7F RID: 89215 RVA: 0x00693FAD File Offset: 0x006923AD
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node50()
		{
			this.opl_p0 = 21061;
		}

		// Token: 0x06015C80 RID: 89216 RVA: 0x00693FC0 File Offset: 0x006923C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5AD RID: 62893
		private int opl_p0;
	}
}
