using System;

namespace behaviac
{
	// Token: 0x020023A6 RID: 9126
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node30 : Condition
	{
		// Token: 0x060130B2 RID: 78002 RVA: 0x005A3147 File Offset: 0x005A1547
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node30()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130B3 RID: 78003 RVA: 0x005A317C File Offset: 0x005A157C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAD8 RID: 51928
		private int opl_p0;

		// Token: 0x0400CAD9 RID: 51929
		private int opl_p1;

		// Token: 0x0400CADA RID: 51930
		private int opl_p2;

		// Token: 0x0400CADB RID: 51931
		private int opl_p3;
	}
}
