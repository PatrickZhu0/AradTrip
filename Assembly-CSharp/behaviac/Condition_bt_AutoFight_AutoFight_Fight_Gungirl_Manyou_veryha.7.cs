using System;

namespace behaviac
{
	// Token: 0x0200206E RID: 8302
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node17 : Condition
	{
		// Token: 0x06012A75 RID: 76405 RVA: 0x0057928E File Offset: 0x0057768E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012A76 RID: 76406 RVA: 0x005792A4 File Offset: 0x005776A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C468 RID: 50280
		private float opl_p0;
	}
}
