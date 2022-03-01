using System;

namespace behaviac
{
	// Token: 0x0200359B RID: 13723
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node16 : Condition
	{
		// Token: 0x06015366 RID: 86886 RVA: 0x00664A7B File Offset: 0x00662E7B
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node16()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 528401;
		}

		// Token: 0x06015367 RID: 86887 RVA: 0x00664A9C File Offset: 0x00662E9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED2D RID: 60717
		private BE_Target opl_p0;

		// Token: 0x0400ED2E RID: 60718
		private BE_Equal opl_p1;

		// Token: 0x0400ED2F RID: 60719
		private int opl_p2;
	}
}
