using System;

namespace behaviac
{
	// Token: 0x02001F00 RID: 7936
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node12 : Condition
	{
		// Token: 0x060127A4 RID: 75684 RVA: 0x00567FFF File Offset: 0x005663FF
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node12()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060127A5 RID: 75685 RVA: 0x0056801C File Offset: 0x0056641C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C199 RID: 49561
		private BE_Target opl_p0;

		// Token: 0x0400C19A RID: 49562
		private BE_Equal opl_p1;

		// Token: 0x0400C19B RID: 49563
		private BE_State opl_p2;
	}
}
