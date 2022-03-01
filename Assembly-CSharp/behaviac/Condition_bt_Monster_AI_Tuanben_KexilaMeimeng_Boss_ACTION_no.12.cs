using System;

namespace behaviac
{
	// Token: 0x02003A2A RID: 14890
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node14 : Condition
	{
		// Token: 0x06015C1E RID: 89118 RVA: 0x0069233E File Offset: 0x0069073E
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node14()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C1F RID: 89119 RVA: 0x00692374 File Offset: 0x00690774
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F538 RID: 62776
		private int opl_p0;

		// Token: 0x0400F539 RID: 62777
		private int opl_p1;

		// Token: 0x0400F53A RID: 62778
		private int opl_p2;

		// Token: 0x0400F53B RID: 62779
		private int opl_p3;
	}
}
