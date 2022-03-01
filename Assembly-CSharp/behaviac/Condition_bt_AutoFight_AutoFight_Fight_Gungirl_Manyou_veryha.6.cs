using System;

namespace behaviac
{
	// Token: 0x0200206B RID: 8299
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node13 : Condition
	{
		// Token: 0x06012A6F RID: 76399 RVA: 0x0057908B File Offset: 0x0057748B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node13()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A70 RID: 76400 RVA: 0x005790C0 File Offset: 0x005774C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C461 RID: 50273
		private int opl_p0;

		// Token: 0x0400C462 RID: 50274
		private int opl_p1;

		// Token: 0x0400C463 RID: 50275
		private int opl_p2;

		// Token: 0x0400C464 RID: 50276
		private int opl_p3;
	}
}
