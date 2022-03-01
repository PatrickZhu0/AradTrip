using System;

namespace behaviac
{
	// Token: 0x020024F6 RID: 9462
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node42 : Condition
	{
		// Token: 0x06013336 RID: 78646 RVA: 0x005B3563 File Offset: 0x005B1963
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node42()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06013337 RID: 78647 RVA: 0x005B3598 File Offset: 0x005B1998
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD55 RID: 52565
		private int opl_p0;

		// Token: 0x0400CD56 RID: 52566
		private int opl_p1;

		// Token: 0x0400CD57 RID: 52567
		private int opl_p2;

		// Token: 0x0400CD58 RID: 52568
		private int opl_p3;
	}
}
