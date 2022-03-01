using System;

namespace behaviac
{
	// Token: 0x0200203F RID: 8255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node8 : Condition
	{
		// Token: 0x06012A18 RID: 76312 RVA: 0x005770D3 File Offset: 0x005754D3
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012A19 RID: 76313 RVA: 0x00577108 File Offset: 0x00575508
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C40A RID: 50186
		private int opl_p0;

		// Token: 0x0400C40B RID: 50187
		private int opl_p1;

		// Token: 0x0400C40C RID: 50188
		private int opl_p2;

		// Token: 0x0400C40D RID: 50189
		private int opl_p3;
	}
}
