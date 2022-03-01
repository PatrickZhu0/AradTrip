using System;

namespace behaviac
{
	// Token: 0x0200363D RID: 13885
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node12 : Condition
	{
		// Token: 0x0601549D RID: 87197 RVA: 0x0066B3C6 File Offset: 0x006697C6
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node12()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 8000;
			this.opl_p2 = 8000;
			this.opl_p3 = 8000;
		}

		// Token: 0x0601549E RID: 87198 RVA: 0x0066B3FC File Offset: 0x006697FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE55 RID: 61013
		private int opl_p0;

		// Token: 0x0400EE56 RID: 61014
		private int opl_p1;

		// Token: 0x0400EE57 RID: 61015
		private int opl_p2;

		// Token: 0x0400EE58 RID: 61016
		private int opl_p3;
	}
}
