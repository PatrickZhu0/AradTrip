using System;

namespace behaviac
{
	// Token: 0x02002063 RID: 8291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node3 : Condition
	{
		// Token: 0x06012A5F RID: 76383 RVA: 0x00578D53 File Offset: 0x00577153
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node3()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012A60 RID: 76384 RVA: 0x00578D88 File Offset: 0x00577188
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C451 RID: 50257
		private int opl_p0;

		// Token: 0x0400C452 RID: 50258
		private int opl_p1;

		// Token: 0x0400C453 RID: 50259
		private int opl_p2;

		// Token: 0x0400C454 RID: 50260
		private int opl_p3;
	}
}
