using System;

namespace behaviac
{
	// Token: 0x02001EF0 RID: 7920
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node29 : Condition
	{
		// Token: 0x06012785 RID: 75653 RVA: 0x00566E89 File Offset: 0x00565289
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node29()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012786 RID: 75654 RVA: 0x00566E9C File Offset: 0x0056529C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C17C RID: 49532
		private float opl_p0;
	}
}
