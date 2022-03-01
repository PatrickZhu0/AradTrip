using System;

namespace behaviac
{
	// Token: 0x02003329 RID: 13097
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node1 : Condition
	{
		// Token: 0x06014EB8 RID: 85688 RVA: 0x0064D925 File Offset: 0x0064BD25
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node1()
		{
			this.opl_p0 = 5758;
		}

		// Token: 0x06014EB9 RID: 85689 RVA: 0x0064D938 File Offset: 0x0064BD38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E79F RID: 59295
		private int opl_p0;
	}
}
