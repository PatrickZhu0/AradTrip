using System;

namespace behaviac
{
	// Token: 0x02003210 RID: 12816
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node52 : Condition
	{
		// Token: 0x06014CAA RID: 85162 RVA: 0x0064349A File Offset: 0x0064189A
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node52()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06014CAB RID: 85163 RVA: 0x006434B0 File Offset: 0x006418B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5F4 RID: 58868
		private float opl_p0;
	}
}
