using System;

namespace behaviac
{
	// Token: 0x02003677 RID: 13943
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node17 : Condition
	{
		// Token: 0x0601550F RID: 87311 RVA: 0x0066DAC6 File Offset: 0x0066BEC6
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06015510 RID: 87312 RVA: 0x0066DAFC File Offset: 0x0066BEFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEC5 RID: 61125
		private int opl_p0;

		// Token: 0x0400EEC6 RID: 61126
		private int opl_p1;

		// Token: 0x0400EEC7 RID: 61127
		private int opl_p2;

		// Token: 0x0400EEC8 RID: 61128
		private int opl_p3;
	}
}
