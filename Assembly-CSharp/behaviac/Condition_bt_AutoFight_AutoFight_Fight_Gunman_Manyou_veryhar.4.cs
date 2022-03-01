using System;

namespace behaviac
{
	// Token: 0x020021A7 RID: 8615
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node8 : Condition
	{
		// Token: 0x06012CDD RID: 77021 RVA: 0x00588397 File Offset: 0x00586797
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012CDE RID: 77022 RVA: 0x005883CC File Offset: 0x005867CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6CF RID: 50895
		private int opl_p0;

		// Token: 0x0400C6D0 RID: 50896
		private int opl_p1;

		// Token: 0x0400C6D1 RID: 50897
		private int opl_p2;

		// Token: 0x0400C6D2 RID: 50898
		private int opl_p3;
	}
}
