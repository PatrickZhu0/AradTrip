using System;

namespace behaviac
{
	// Token: 0x020024E0 RID: 9440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node31 : Condition
	{
		// Token: 0x0601330A RID: 78602 RVA: 0x005B2952 File Offset: 0x005B0D52
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node31()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601330B RID: 78603 RVA: 0x005B2968 File Offset: 0x005B0D68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD27 RID: 52519
		private float opl_p0;
	}
}
