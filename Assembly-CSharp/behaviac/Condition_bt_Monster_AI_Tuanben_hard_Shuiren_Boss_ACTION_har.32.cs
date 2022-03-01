using System;

namespace behaviac
{
	// Token: 0x02003D6C RID: 15724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node3 : Condition
	{
		// Token: 0x0601626E RID: 90734 RVA: 0x006B17C3 File Offset: 0x006AFBC3
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node3()
		{
			this.opl_p0 = 21079;
		}

		// Token: 0x0601626F RID: 90735 RVA: 0x006B17D8 File Offset: 0x006AFBD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAC8 RID: 64200
		private int opl_p0;
	}
}
