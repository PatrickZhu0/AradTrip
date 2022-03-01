using System;

namespace behaviac
{
	// Token: 0x02001EE7 RID: 7911
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node32 : Condition
	{
		// Token: 0x06012773 RID: 75635 RVA: 0x00566AB3 File Offset: 0x00564EB3
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node32()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012774 RID: 75636 RVA: 0x00566AD0 File Offset: 0x00564ED0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C167 RID: 49511
		private BE_Target opl_p0;

		// Token: 0x0400C168 RID: 49512
		private BE_Equal opl_p1;

		// Token: 0x0400C169 RID: 49513
		private BE_State opl_p2;
	}
}
