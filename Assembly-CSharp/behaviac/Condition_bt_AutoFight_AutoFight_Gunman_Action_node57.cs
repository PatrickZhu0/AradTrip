using System;

namespace behaviac
{
	// Token: 0x02002592 RID: 9618
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node57 : Condition
	{
		// Token: 0x0601346C RID: 78956 RVA: 0x005BAD97 File Offset: 0x005B9197
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node57()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601346D RID: 78957 RVA: 0x005BADCC File Offset: 0x005B91CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE97 RID: 52887
		private int opl_p0;

		// Token: 0x0400CE98 RID: 52888
		private int opl_p1;

		// Token: 0x0400CE99 RID: 52889
		private int opl_p2;

		// Token: 0x0400CE9A RID: 52890
		private int opl_p3;
	}
}
