using System;

namespace behaviac
{
	// Token: 0x02001DB5 RID: 7605
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node10 : Condition
	{
		// Token: 0x06012523 RID: 75043 RVA: 0x00559528 File Offset: 0x00557928
		public Condition_bt_APC_APC_Kuangzhan_Action_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012524 RID: 75044 RVA: 0x0055955C File Offset: 0x0055795C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = false;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF13 RID: 48915
		private int opl_p0;

		// Token: 0x0400BF14 RID: 48916
		private int opl_p1;

		// Token: 0x0400BF15 RID: 48917
		private int opl_p2;

		// Token: 0x0400BF16 RID: 48918
		private int opl_p3;
	}
}
