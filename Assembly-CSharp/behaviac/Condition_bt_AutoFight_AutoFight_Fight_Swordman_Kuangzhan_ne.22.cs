using System;

namespace behaviac
{
	// Token: 0x020023AE RID: 9134
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node67 : Condition
	{
		// Token: 0x060130C2 RID: 78018 RVA: 0x005A3D5F File Offset: 0x005A215F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node67()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130C3 RID: 78019 RVA: 0x005A3D94 File Offset: 0x005A2194
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAEC RID: 51948
		private int opl_p0;

		// Token: 0x0400CAED RID: 51949
		private int opl_p1;

		// Token: 0x0400CAEE RID: 51950
		private int opl_p2;

		// Token: 0x0400CAEF RID: 51951
		private int opl_p3;
	}
}
