using System;

namespace behaviac
{
	// Token: 0x020023BA RID: 9146
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node47 : Condition
	{
		// Token: 0x060130DA RID: 78042 RVA: 0x005A4CB7 File Offset: 0x005A30B7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node47()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060130DB RID: 78043 RVA: 0x005A4CEC File Offset: 0x005A30EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB0A RID: 51978
		private int opl_p0;

		// Token: 0x0400CB0B RID: 51979
		private int opl_p1;

		// Token: 0x0400CB0C RID: 51980
		private int opl_p2;

		// Token: 0x0400CB0D RID: 51981
		private int opl_p3;
	}
}
