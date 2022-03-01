using System;

namespace behaviac
{
	// Token: 0x02002613 RID: 9747
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node63 : Condition
	{
		// Token: 0x0601356C RID: 79212 RVA: 0x005C0D56 File Offset: 0x005BF156
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node63()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601356D RID: 79213 RVA: 0x005C0D6C File Offset: 0x005BF16C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFB8 RID: 53176
		private float opl_p0;
	}
}
