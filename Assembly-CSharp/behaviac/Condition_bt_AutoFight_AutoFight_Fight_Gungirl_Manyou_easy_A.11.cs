using System;

namespace behaviac
{
	// Token: 0x02001FD3 RID: 8147
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node27 : Condition
	{
		// Token: 0x06012943 RID: 76099 RVA: 0x00571B56 File Offset: 0x0056FF56
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node27()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012944 RID: 76100 RVA: 0x00571B6C File Offset: 0x0056FF6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C335 RID: 49973
		private float opl_p0;
	}
}
