using System;

namespace behaviac
{
	// Token: 0x02003339 RID: 13113
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node24 : Condition
	{
		// Token: 0x06014ED6 RID: 85718 RVA: 0x0064E2F8 File Offset: 0x0064C6F8
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_jiaodoushi_Destination_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014ED7 RID: 85719 RVA: 0x0064E30C File Offset: 0x0064C70C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7C0 RID: 59328
		private float opl_p0;
	}
}
