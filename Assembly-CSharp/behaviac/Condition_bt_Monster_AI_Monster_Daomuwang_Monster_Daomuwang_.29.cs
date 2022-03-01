using System;

namespace behaviac
{
	// Token: 0x02003642 RID: 13890
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node8 : Condition
	{
		// Token: 0x060154A7 RID: 87207 RVA: 0x0066B5F5 File Offset: 0x006699F5
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154A8 RID: 87208 RVA: 0x0066B608 File Offset: 0x00669A08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE61 RID: 61025
		private float opl_p0;
	}
}
