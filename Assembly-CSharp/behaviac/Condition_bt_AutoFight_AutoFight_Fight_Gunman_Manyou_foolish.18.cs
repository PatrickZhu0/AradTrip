using System;

namespace behaviac
{
	// Token: 0x0200214B RID: 8523
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node43 : Condition
	{
		// Token: 0x06012C28 RID: 76840 RVA: 0x005836F3 File Offset: 0x00581AF3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012C29 RID: 76841 RVA: 0x00583728 File Offset: 0x00581B28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C61A RID: 50714
		private int opl_p0;

		// Token: 0x0400C61B RID: 50715
		private int opl_p1;

		// Token: 0x0400C61C RID: 50716
		private int opl_p2;

		// Token: 0x0400C61D RID: 50717
		private int opl_p3;
	}
}
