using System;

namespace behaviac
{
	// Token: 0x02003330 RID: 13104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node5 : Condition
	{
		// Token: 0x06014EC5 RID: 85701 RVA: 0x0064DE09 File Offset: 0x0064C209
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node5()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06014EC6 RID: 85702 RVA: 0x0064DE1C File Offset: 0x0064C21C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7AC RID: 59308
		private float opl_p0;
	}
}
