using System;

namespace behaviac
{
	// Token: 0x0200260B RID: 9739
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node92 : Condition
	{
		// Token: 0x0601355C RID: 79196 RVA: 0x005C0996 File Offset: 0x005BED96
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node92()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601355D RID: 79197 RVA: 0x005C09AC File Offset: 0x005BEDAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFA8 RID: 53160
		private float opl_p0;
	}
}
