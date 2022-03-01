using System;

namespace behaviac
{
	// Token: 0x0200207A RID: 8314
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node32 : Condition
	{
		// Token: 0x06012A8D RID: 76429 RVA: 0x00579812 File Offset: 0x00577C12
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node32()
		{
			this.opl_p0 = 0.82f;
		}

		// Token: 0x06012A8E RID: 76430 RVA: 0x00579828 File Offset: 0x00577C28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C480 RID: 50304
		private float opl_p0;
	}
}
