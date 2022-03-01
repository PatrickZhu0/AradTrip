using System;

namespace behaviac
{
	// Token: 0x02003203 RID: 12803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node20 : Condition
	{
		// Token: 0x06014C90 RID: 85136 RVA: 0x00642F4A File Offset: 0x0064134A
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node20()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06014C91 RID: 85137 RVA: 0x00642F60 File Offset: 0x00641360
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5E1 RID: 58849
		private float opl_p0;
	}
}
