using System;

namespace behaviac
{
	// Token: 0x02002057 RID: 8279
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node38 : Condition
	{
		// Token: 0x06012A48 RID: 76360 RVA: 0x00577BDB File Offset: 0x00575FDB
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012A49 RID: 76361 RVA: 0x00577C10 File Offset: 0x00576010
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C43A RID: 50234
		private int opl_p0;

		// Token: 0x0400C43B RID: 50235
		private int opl_p1;

		// Token: 0x0400C43C RID: 50236
		private int opl_p2;

		// Token: 0x0400C43D RID: 50237
		private int opl_p3;
	}
}
