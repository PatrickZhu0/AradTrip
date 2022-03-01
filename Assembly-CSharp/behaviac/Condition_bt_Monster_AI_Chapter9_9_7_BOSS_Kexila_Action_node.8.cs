using System;

namespace behaviac
{
	// Token: 0x02003206 RID: 12806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node24 : Condition
	{
		// Token: 0x06014C96 RID: 85142 RVA: 0x00643086 File Offset: 0x00641486
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node24()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x06014C97 RID: 85143 RVA: 0x0064309C File Offset: 0x0064149C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E5 RID: 58853
		private float opl_p0;
	}
}
