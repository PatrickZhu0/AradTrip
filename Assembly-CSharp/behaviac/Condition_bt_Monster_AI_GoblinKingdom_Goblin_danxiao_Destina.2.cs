using System;

namespace behaviac
{
	// Token: 0x020032F8 RID: 13048
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node20 : Condition
	{
		// Token: 0x06014E5A RID: 85594 RVA: 0x0064C009 File Offset: 0x0064A409
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Destination_node20()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06014E5B RID: 85595 RVA: 0x0064C01C File Offset: 0x0064A41C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E748 RID: 59208
		private float opl_p0;
	}
}
