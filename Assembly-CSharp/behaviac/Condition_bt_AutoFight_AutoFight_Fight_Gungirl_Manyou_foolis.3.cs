using System;

namespace behaviac
{
	// Token: 0x02001FEA RID: 8170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node2 : Condition
	{
		// Token: 0x06012970 RID: 76144 RVA: 0x005731CA File Offset: 0x005715CA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node2()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012971 RID: 76145 RVA: 0x005731E0 File Offset: 0x005715E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C363 RID: 50019
		private float opl_p0;
	}
}
