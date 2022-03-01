using System;

namespace behaviac
{
	// Token: 0x0200363A RID: 13882
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node3 : Condition
	{
		// Token: 0x06015497 RID: 87191 RVA: 0x0066B28D File Offset: 0x0066968D
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015498 RID: 87192 RVA: 0x0066B2A0 File Offset: 0x006696A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE51 RID: 61009
		private float opl_p0;
	}
}
