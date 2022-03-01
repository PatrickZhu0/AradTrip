using System;

namespace behaviac
{
	// Token: 0x02003213 RID: 12819
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13 : Condition
	{
		// Token: 0x06014CB0 RID: 85168 RVA: 0x006435D6 File Offset: 0x006419D6
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node13()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06014CB1 RID: 85169 RVA: 0x006435EC File Offset: 0x006419EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5F8 RID: 58872
		private float opl_p0;
	}
}
