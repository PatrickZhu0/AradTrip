using System;

namespace behaviac
{
	// Token: 0x020022A7 RID: 8871
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node25 : Condition
	{
		// Token: 0x06012ECA RID: 77514 RVA: 0x00595483 File Offset: 0x00593883
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node25()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 100;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012ECB RID: 77515 RVA: 0x005954B4 File Offset: 0x005938B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8D2 RID: 51410
		private int opl_p0;

		// Token: 0x0400C8D3 RID: 51411
		private int opl_p1;

		// Token: 0x0400C8D4 RID: 51412
		private int opl_p2;

		// Token: 0x0400C8D5 RID: 51413
		private int opl_p3;
	}
}
