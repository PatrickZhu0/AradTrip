using System;

namespace behaviac
{
	// Token: 0x02001FF2 RID: 8178
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node12 : Condition
	{
		// Token: 0x06012980 RID: 76160 RVA: 0x00573502 File Offset: 0x00571902
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node12()
		{
			this.opl_p0 = 0.23f;
		}

		// Token: 0x06012981 RID: 76161 RVA: 0x00573518 File Offset: 0x00571918
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C373 RID: 50035
		private float opl_p0;
	}
}
