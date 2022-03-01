using System;

namespace behaviac
{
	// Token: 0x02003A3D RID: 14909
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node82 : Condition
	{
		// Token: 0x06015C43 RID: 89155 RVA: 0x00693353 File Offset: 0x00691753
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node82()
		{
			this.opl_p0 = 21053;
		}

		// Token: 0x06015C44 RID: 89156 RVA: 0x00693368 File Offset: 0x00691768
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F55F RID: 62815
		private int opl_p0;
	}
}
