using System;

namespace behaviac
{
	// Token: 0x0200248B RID: 9355
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5 : Condition
	{
		// Token: 0x06013263 RID: 78435 RVA: 0x005AEDFF File Offset: 0x005AD1FF
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node5()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013264 RID: 78436 RVA: 0x005AEE34 File Offset: 0x005AD234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC7C RID: 52348
		private int opl_p0;

		// Token: 0x0400CC7D RID: 52349
		private int opl_p1;

		// Token: 0x0400CC7E RID: 52350
		private int opl_p2;

		// Token: 0x0400CC7F RID: 52351
		private int opl_p3;
	}
}
