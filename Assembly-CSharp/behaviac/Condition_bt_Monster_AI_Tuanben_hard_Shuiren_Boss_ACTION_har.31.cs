using System;

namespace behaviac
{
	// Token: 0x02003D6B RID: 15723
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node53 : Condition
	{
		// Token: 0x0601626C RID: 90732 RVA: 0x006B177A File Offset: 0x006AFB7A
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node53()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601626D RID: 90733 RVA: 0x006B1790 File Offset: 0x006AFB90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAC7 RID: 64199
		private float opl_p0;
	}
}
