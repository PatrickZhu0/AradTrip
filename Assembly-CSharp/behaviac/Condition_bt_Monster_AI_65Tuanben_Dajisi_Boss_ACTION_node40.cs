using System;

namespace behaviac
{
	// Token: 0x02002D70 RID: 11632
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node40 : Condition
	{
		// Token: 0x060143C2 RID: 82882 RVA: 0x006141E7 File Offset: 0x006125E7
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node40()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570282;
		}

		// Token: 0x060143C3 RID: 82883 RVA: 0x00614208 File Offset: 0x00612608
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD8C RID: 56716
		private BE_Target opl_p0;

		// Token: 0x0400DD8D RID: 56717
		private BE_Equal opl_p1;

		// Token: 0x0400DD8E RID: 56718
		private int opl_p2;
	}
}
