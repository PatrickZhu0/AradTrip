using System;

namespace behaviac
{
	// Token: 0x020022CC RID: 8908
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node9 : Condition
	{
		// Token: 0x06012F13 RID: 77587 RVA: 0x00597BBB File Offset: 0x00595FBB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node9()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06012F14 RID: 77588 RVA: 0x00597BF0 File Offset: 0x00595FF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C924 RID: 51492
		private int opl_p0;

		// Token: 0x0400C925 RID: 51493
		private int opl_p1;

		// Token: 0x0400C926 RID: 51494
		private int opl_p2;

		// Token: 0x0400C927 RID: 51495
		private int opl_p3;
	}
}
