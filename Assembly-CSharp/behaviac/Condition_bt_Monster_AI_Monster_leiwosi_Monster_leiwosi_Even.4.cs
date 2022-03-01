using System;

namespace behaviac
{
	// Token: 0x020036C0 RID: 14016
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node7 : Condition
	{
		// Token: 0x06015599 RID: 87449 RVA: 0x00670C8F File Offset: 0x0066F08F
		public Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node7()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x0601559A RID: 87450 RVA: 0x00670CA4 File Offset: 0x0066F0A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF6D RID: 61293
		private float opl_p0;
	}
}
