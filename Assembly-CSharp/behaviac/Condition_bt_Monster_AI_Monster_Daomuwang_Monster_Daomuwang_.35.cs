using System;

namespace behaviac
{
	// Token: 0x0200364A RID: 13898
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node23 : Condition
	{
		// Token: 0x060154B7 RID: 87223 RVA: 0x0066B95D File Offset: 0x00669D5D
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node23()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060154B8 RID: 87224 RVA: 0x0066B970 File Offset: 0x00669D70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE71 RID: 61041
		private float opl_p0;
	}
}
