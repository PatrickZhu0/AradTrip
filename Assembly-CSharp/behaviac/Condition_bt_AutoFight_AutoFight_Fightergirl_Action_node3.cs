using System;

namespace behaviac
{
	// Token: 0x02001ED0 RID: 7888
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node3 : Condition
	{
		// Token: 0x06012745 RID: 75589 RVA: 0x00566125 File Offset: 0x00564525
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node3()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012746 RID: 75590 RVA: 0x00566138 File Offset: 0x00564538
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C137 RID: 49463
		private float opl_p0;
	}
}
