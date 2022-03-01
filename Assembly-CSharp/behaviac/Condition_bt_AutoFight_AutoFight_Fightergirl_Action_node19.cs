using System;

namespace behaviac
{
	// Token: 0x02001EE6 RID: 7910
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node19 : Condition
	{
		// Token: 0x06012771 RID: 75633 RVA: 0x00566A6D File Offset: 0x00564E6D
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node19()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012772 RID: 75634 RVA: 0x00566A80 File Offset: 0x00564E80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C166 RID: 49510
		private float opl_p0;
	}
}
