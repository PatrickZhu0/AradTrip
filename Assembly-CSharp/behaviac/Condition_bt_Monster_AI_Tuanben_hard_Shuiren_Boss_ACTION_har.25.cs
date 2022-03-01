using System;

namespace behaviac
{
	// Token: 0x02003D63 RID: 15715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node44 : Condition
	{
		// Token: 0x0601625C RID: 90716 RVA: 0x006B140A File Offset: 0x006AF80A
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node44()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601625D RID: 90717 RVA: 0x006B1420 File Offset: 0x006AF820
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAB7 RID: 64183
		private float opl_p0;
	}
}
